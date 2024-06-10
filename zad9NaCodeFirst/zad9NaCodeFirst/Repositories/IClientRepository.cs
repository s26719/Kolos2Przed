namespace zad9NaCodeFirst.Repositories;

public interface IClientRepository
{
    Task DeleteClientAsync(int id);
    
}