using Kols2.Context;
using Kols2.DTO_s;
using Kols2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kols2.Repository;

public class EventRepository : IEventRepository
{
    private readonly MyDbContext _myDbContext;

    public EventRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<EventDetailsDto> GetEventDetailsAsync(bool includeEndDate)
    {
        var eventsQuery = _myDbContext.Events.AsQueryable();

        if (includeEndDate)
        {
            eventsQuery = eventsQuery.Where(e => e.DateTo.HasValue);
        }
        else
        {
            eventsQuery = eventsQuery.Where(e => !e.DateTo.HasValue);
        }
        var events = await eventsQuery
            .Select(e => new EventOutDto
            {
                IdEvent = e.IdEvent,
                Name = e.Name,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                MainOrganisers = e.EventOrganisers.Where(eo => eo.MainOrganiser == true).Select(eo =>
                    new OrganiserOutDto
                    {
                        IdOrganiser = eo.IdOrganiserNavigation.IdOrganiser,
                        Name = eo.IdOrganiserNavigation.Name
                    }).ToList(),
                SubOrganisers = e.EventOrganisers.Where(eo => eo.MainOrganiser == false).Select(eo =>
                    new OrganiserOutDto
                    {
                        IdOrganiser = eo.IdOrganiserNavigation.IdOrganiser,
                        Name = eo.IdOrganiserNavigation.Name
                    }).ToList()
            }).ToListAsync();

        var eventsDto = new EventDetailsDto
        {
            Events = events
        };

        return eventsDto;


    }

    public async Task DeleteEventAsync(int id)
    {
        
        //sprawdzamy czy istnieje event z podanym id
        var eventExist = await _myDbContext.Events.AnyAsync(e => e.IdEvent == id);
        if (!eventExist)
        {
            throw new NotFoundExceptions("event o podanym id nie istnieje");
        }
        //sprawdzamy czy event jeszcze sie nie zaczal
        var eventStartDate = _myDbContext.Events.Where(e=>e.IdEvent == id).Select(e => e.DateFrom).FirstOrDefault();
        if (eventStartDate > DateTime.Now || await _myDbContext.Events.Where(e=>e.IdEvent==id).Select(e=>e.DateTo).FirstOrDefaultAsync() == null)
        {
            //sprawdzamy czy event ma conajmniej 3 glownych organizatorow
            var mainOrganisersCount = await _myDbContext.EventOrganisers.Where(eo => eo.IdEvent == id)
                .CountAsync(eo => eo.MainOrganiser == true);
            if (mainOrganisersCount >=3)
            {
                throw new BadRequestException("nie mozna usunac eventu ktory ma conajmniej trzech glownych organizatorow");
            }

            var eventTodelete = await _myDbContext.Events.Where(e => e.IdEvent == id).FirstOrDefaultAsync();
            _myDbContext.Events.Remove(eventTodelete!);
            await _myDbContext.SaveChangesAsync();

        }
        else
        {
            throw new BadRequestException("nie mozna usunac eventu ktory juz sie zaczal");
        }
        

    }
}