
using Lazy;

var employeeRepository = new EmployeeRepository();

var employees = await employeeRepository.GetEmployees();

employees.ForEach(e => Console.WriteLine(e.Name));


//This time Create Employee method will not be executed so only the employees created before will be returned
var employees2 = await employeeRepository.GetEmployees();


Console.ReadKey();


