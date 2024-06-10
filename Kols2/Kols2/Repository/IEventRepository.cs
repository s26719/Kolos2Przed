using Kols2.DTO_s;

namespace Kols2.Repository;

public interface IEventRepository
{
    Task<EventDetailsDto> GetEventDetailsAsync(bool includeEndDate);
    Task DeleteEventAsync(int id);
}