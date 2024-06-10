using Kols2.DTO_s;

namespace Kols2.Services;

public interface IEventService
{
    Task<EventDetailsDto> GetEventDetailsAsync(bool includeEndDate);
    Task DeleteEventAsync(int id);
}