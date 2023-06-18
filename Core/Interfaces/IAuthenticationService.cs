using System.Threading.Tasks;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
namespace Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}
