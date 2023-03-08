
using Lazy;

var employeeRepository = new EmployeeRepository();

var employees = await employeeRepository.GetEmployees();

employees.ForEach(e => Console.WriteLine(e.Name));

var employees2 = await employeeRepository.GetEmployees();


Console.ReadKey();


