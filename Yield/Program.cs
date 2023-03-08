using Yield;



//Sample 1 getting odd numbers from a number list
var numbers = NumberListCreator.Create100NumberList();

GetOddNumbers().ToList().ForEach(n => Console.WriteLine(n));



IEnumerable<int> GetOddNumbers()
{
	foreach (var number in numbers)
	{
		if (number % 2 == 0)
			yield return number;
	}
}


//Sample-2 getting only the students over 15 years old

var students = StudentCreator.CreateStudents();

IEnumerable<Student> GetStudentsOver15Years()
{
	foreach (var student in students)
	{
		if (DateTime.Now.Year - student.DateofBirth.Year > 15)
			yield return student;
	}
}

GetStudentsOver15Years().ToList().ForEach(s => Console.WriteLine($"{s.Name} {s.LastName}"));

Console.ReadKey();