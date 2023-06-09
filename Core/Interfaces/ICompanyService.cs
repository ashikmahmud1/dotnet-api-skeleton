using System.Collections.Generic;
using Core.Dtos;
using Core.Entities;
namespace Core.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
    }
}
