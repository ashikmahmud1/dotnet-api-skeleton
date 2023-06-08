namespace Core.Interfaces
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }

        IEmployeeService EmployeeService { get; }
    }
}
