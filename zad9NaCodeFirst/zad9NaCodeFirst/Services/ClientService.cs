using zad9NaCodeFirst.Repositories;

namespace zad9NaCodeFirst.Services;

public class ClientService : IClientService
{

    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClientAsync(int id)
    {
        await _clientRepository.DeleteClientAsync(id);
    }
}