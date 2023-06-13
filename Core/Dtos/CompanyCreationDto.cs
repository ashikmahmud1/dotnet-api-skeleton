using System.ComponentModel.DataAnnotations;
namespace Core.Dtos
{
    public record CompanyCreationDto
    {
        public string Name { get; init; }

        public string Address { get; init; }

        public string Country { get; init; }
    }
}
