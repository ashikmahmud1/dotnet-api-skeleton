using System;
using System.Collections.Generic;
using Core.Dtos;
namespace Core.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
    }
}
