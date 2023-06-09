using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
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
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                var companiesDto = companies.Select(c =>
                    new CompanyDto(c.Id, c.Name ?? "", string.Join(' ',
                        c.Address, c.Country))).ToList();
                return companiesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
                throw;
            }
        }
    }
}