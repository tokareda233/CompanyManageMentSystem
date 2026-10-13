using CompanyManageMentSystem.DTOs.Auth;

namespace CompanyManageMentSystem.Repo.Interface
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(RegisterDTO dto);
    }
}
