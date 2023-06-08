using System.Collections.Generic;
using Core.Entities;
namespace Core.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
