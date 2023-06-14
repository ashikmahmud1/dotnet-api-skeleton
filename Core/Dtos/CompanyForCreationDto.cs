using System.Collections.Generic;
namespace Core.Dtos
{
    public record CompanyForCreationDto
    {
        public string Name { get; init; }

        public string Address { get; init; }

        public string Country { get; init; }
        
        public IEnumerable<EmployeeForCreationDto> Employees { get; init; }
    }
}
