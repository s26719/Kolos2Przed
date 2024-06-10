using zad9NaCodeFirst.DTO_s;

namespace zad9NaCodeFirst.Services;

public interface ITripService
{
    Task<TripDetailsDto> GetTripDetailsAsync();
    Task AddClientToTripAsync (ClientInDto clientInDto);
}