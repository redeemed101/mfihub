using MFIHub.Shared.Models;

namespace MFIHub.Server.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequest request);
        Task Logout();
        Task Register(RegisterRequest parameters);
    }
}