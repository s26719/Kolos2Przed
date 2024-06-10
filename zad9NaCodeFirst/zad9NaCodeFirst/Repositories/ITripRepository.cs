using zad9NaCodeFirst.DTO_s;

namespace zad9NaCodeFirst.Repositories;

public interface ITripRepository
{
    Task<TripDetailsDto> GetAllTripsAsync();
    Task AddClientToTripAsync (ClientInDto clientInDto);
}