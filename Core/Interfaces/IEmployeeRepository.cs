using System;
using System.Collections.Generic;
using Core.Entities;
namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee? GetEmployee(Guid companyId, Guid id, bool trackChanges);
    }
}
