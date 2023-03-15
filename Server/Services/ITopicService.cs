using MFIHub.Shared.Models;

namespace MFIHub.Server.Services
{
    public interface ITopicService
    {
        Task<ICollection<Topic>> GetTopicsAsync();
    }
}