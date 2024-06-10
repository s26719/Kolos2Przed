using Kols2.DTO_s;
using Kols2.Repository;

namespace Kols2.Services;

public class EventService : IEventService
{

    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<EventDetailsDto> GetEventDetailsAsync(bool includeEndDate)
    {
       var events =  await _eventRepository.GetEventDetailsAsync(includeEndDate);
       return events;
    }

    public async Task DeleteEventAsync(int id)
    {
        await _eventRepository.DeleteEventAsync(id);
    }
}