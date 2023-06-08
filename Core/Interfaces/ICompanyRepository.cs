using System.Collections.Generic;
using Core.Entities;
namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
