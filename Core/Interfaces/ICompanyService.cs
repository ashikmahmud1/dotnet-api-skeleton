using System;
using System.Collections.Generic;
using Core.Dtos;
using Core.Entities;
namespace Core.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyCreationDto? company);
    }
}
