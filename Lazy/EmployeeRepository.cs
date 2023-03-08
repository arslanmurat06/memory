using System;
using Bogus;

namespace Lazy
{
	public class EmployeeRepository :IEmployeeRepository
	{
		Lazy<List<Employee>> _lazyEmployees;
		public EmployeeRepository()
		{
            _lazyEmployees = new Lazy<List<Employee>>(() => CreateEmployees());
		}


        private List<Employee> CreateEmployees()
        {
            var testEmployees = new Faker<Employee>()
         .RuleFor(e => e.ID, Guid.NewGuid)
         .RuleFor(e => e.Gender, f => f.PickRandom<Gender>())
         .RuleFor(e => e.Name, (f, e) => f.Name.FirstName())
         .RuleFor(e => e.Surname, (f, e) => f.Name.LastName())
         .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.Name, e.Surname))
         .FinishWith((f, u) =>
         {
             Console.WriteLine("User Created! {0} {1}", u.Name, u.Surname);
         });

            var employees = testEmployees.GenerateBetween<Employee>(10, 100);
            return employees;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(1000);
            return await Task.FromResult(_lazyEmployees.Value);
        }
    }
}

