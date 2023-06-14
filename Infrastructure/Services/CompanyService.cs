using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
namespace Infrastructure.Services
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repository, ILoggerManager
            logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges).ToList();
            var companiesDto = _mapper.Map<IReadOnlyList<Company>, IReadOnlyList<CompanyDto>>(companies);
            return companiesDto;

        }
        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(id, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
        public CompanyDto CreateCompany(CompanyCreationDto? company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();
            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return companyToReturn;
        }
        public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var companyIds = ids.ToList();
            var companyEntities = _repository.Company.GetByIds(companyIds, trackChanges);
            if (companyIds.Count != companyEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            return companiesToReturn;
        }
        
        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection (IEnumerable<CompanyCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
            _repository.Save();
            var companyCollectionToReturn =
                _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var companiesToReturn = companyCollectionToReturn.ToList();
            var ids = string.Join(",", companiesToReturn.Select(c => c.Id));
            return (companies: companiesToReturn, ids);
        }

    }
}
