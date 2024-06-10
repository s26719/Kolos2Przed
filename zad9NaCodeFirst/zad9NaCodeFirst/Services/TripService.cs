using zad9NaCodeFirst.DTO_s;
using zad9NaCodeFirst.Repositories;

namespace zad9NaCodeFirst.Services;

public class TripService : ITripService
{

    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<TripDetailsDto> GetTripDetailsAsync()
    {
        return await _tripRepository.GetAllTripsAsync();
    }

    public async Task AddClientToTripAsync(ClientInDto clientInDto)
    {
        await _tripRepository.AddClientToTripAsync(clientInDto);
    }
}