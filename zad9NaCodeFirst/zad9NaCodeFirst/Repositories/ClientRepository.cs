using Microsoft.EntityFrameworkCore;
using zad9NaCodeFirst.Context;
using zad9NaCodeFirst.Exceptions;

namespace zad9NaCodeFirst.Repositories;

public class ClientRepository : IClientRepository
{

    private readonly MyDbContext _myDbContext;

    public ClientRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task DeleteClientAsync(int id)
    {
        //sprawdzamy czy isntnieje klient z danym id
        var client = await _myDbContext.Clients.FirstOrDefaultAsync(c => c.IdClient == id);
        if (client == null)
        {
            throw new NotFoundException("klient o podanym id nie istnieje");
        }
        //sprawdzamy czy klient ma przypisana wycieczke
        var clientHasTrip = await _myDbContext.ClientTrips.AnyAsync(c => c.IdClient == id);
        if (clientHasTrip)
        {
            throw new BadRequestException("nie mozna usunac klienta ktory ma przypisane wycieczki");
        }
        //usuwamy klienta
        _myDbContext.Clients.Remove(client);
        await _myDbContext.SaveChangesAsync();
    }
}