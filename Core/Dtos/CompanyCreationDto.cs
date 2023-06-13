using System.Collections.Generic;
namespace Core.Dtos
{
    public record CompanyCreationDto
    {
        public string Name { get; init; }

        public string Address { get; init; }

        public string Country { get; init; }
        
        public IEnumerable<EmployeeCreationDto> Employees { get; init; }
    }
}
