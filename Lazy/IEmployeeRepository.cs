namespace Lazy
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }
}