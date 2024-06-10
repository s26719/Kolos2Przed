using Microsoft.EntityFrameworkCore;
using zad9NaCodeFirst.Context;
using zad9NaCodeFirst.DTO_s;
using zad9NaCodeFirst.Exceptions;
using zad9NaCodeFirst.Models;

namespace zad9NaCodeFirst.Repositories;

public class TripRepository : ITripRepository
{
    private readonly MyDbContext _myDbContext;

    public TripRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<TripDetailsDto> GetAllTripsAsync()
    {

        //wyswietlamy wszystkie wycieczki

        var tripDetailsDto = new TripDetailsDto
        {

            Trips = _myDbContext.Trips.Select(t => new TripOutDto
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.CountryTrips.Select(ct => new CountryOutDto
                {
                    Name = ct.IdCountryNavigation.Name
                }).ToList(),
                Clients = t.ClientTrips.Select(ct => new ClientOutDto
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            }).ToList().FirstOrDefault()
        };
        return tripDetailsDto;
    }

    public async Task AddClientToTripAsync(ClientInDto clientInDto)
    {
        var transaction = await _myDbContext.Database.BeginTransactionAsync();
        try
        {
//sprawdzamy czy klient o numerze pesel juz istnieje
            var client = await _myDbContext.Clients.FirstOrDefaultAsync(c => c.Pesel == clientInDto.Pesel);
            if (client != null)
            {
                throw new BadRequestException("klient o podanym peselu juz istnieje");
            }

            //sprawdzamy czy klient o podanym numerze pesel jest zapisany na dana wycieczke
            var clientOnTrip = await _myDbContext.ClientTrips.AnyAsync(ct =>
                ct.IdClientNavigation.Pesel == clientInDto.Pesel && ct.IdTrip == clientInDto.IdTrip);
            if (clientOnTrip)
            {
                throw new BadRequestException("klient o podanym peselu jest juz zapisany na wycieczke");
            }

            var clientToAdd = new Client
            {
                FirstName = clientInDto.FirstName,
                LastName = clientInDto.LastName,
                Email = clientInDto.Email,
                Telephone = clientInDto.Telephone,
                Pesel = clientInDto.Pesel
            };
            await _myDbContext.AddAsync(clientToAdd);
            await _myDbContext.SaveChangesAsync();

            //sprawdzamy czy wycieczka istnieje
            var trip = await _myDbContext.Trips.FirstOrDefaultAsync(t => t.IdTrip == clientInDto.IdTrip);
            if (trip == null)
            {
                throw new NotFoundException("wycieczka o podanym id nie istnieje");
            }
            //sprawdzamy czy dateFrom jest w przyszlosci
            if (await _myDbContext.Trips.Where(t=>t.IdTrip == clientInDto.IdTrip).Select(t=>t.DateFrom).FirstOrDefaultAsync() < DateTime.Now)
            {
                throw new BadRequestException("wycieczka o podanym id juz sie odbyla");
            }
            //dodajemy wycieczke do bazy
            var tripToAdd = new Client_Trip
            {
                IdClient =
                    _myDbContext.Clients.Where(c => c.FirstName == clientInDto.FirstName && c.LastName == clientInDto.LastName).Select(c => c.IdClient).FirstOrDefault(),
                IdTrip = clientInDto.IdTrip,
                RegisteredAt = 2024,
                PaymentDate = clientInDto.PaymentDate
            };
            await _myDbContext.ClientTrips.AddAsync(tripToAdd);
            await _myDbContext.SaveChangesAsync();
            
            //commitujemy transakcje
            await transaction.CommitAsync();
        }
        catch (NotFoundException e)
        {
            await transaction.RollbackAsync();
            throw new NotFoundException(e.Message);
        }
        catch (BadRequestException e)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(e.Message);
        }
        

    }
}