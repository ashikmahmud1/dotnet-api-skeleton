using System;
using System.Threading.Tasks;
using Core.Interfaces;
namespace Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }
        public ICompanyRepository Company
        {
            get => _companyRepository.Value;
        }
        public IEmployeeRepository Employee
        {
            get => _employeeRepository.Value;
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
