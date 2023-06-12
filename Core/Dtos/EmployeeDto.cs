using System;
namespace Core.Dtos
{
    public record EmployeeDto(Guid Id, string Name, int Age, string Position);
}
