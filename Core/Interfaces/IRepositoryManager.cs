using System.Threading.Tasks;
namespace Core.Interfaces
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; } 
        IEmployeeRepository Employee { get; }
        Task SaveAsync();
    }
}
