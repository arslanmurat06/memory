using System;
using Bogus;

namespace Yield
{
    public static class StudentCreator 
    {

        private static Lazy<List<Student>> _lazyStudents;

         static StudentCreator()
        {
            _lazyStudents = new Lazy<List<Student>>(()=>GetStudents());
        }

        public static List<Student> CreateStudents ()=> _lazyStudents.Value;

        private static List<Student> GetStudents()
        {
            var studentCreator = new Faker<Student>()
               .RuleFor(e => e.ID, Guid.NewGuid)
               .RuleFor(e => e.Name, (f, e) => f.Name.FirstName())
               .RuleFor(e => e.LastName, (f, e) => f.Name.LastName())
               .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.Name, e.LastName))
               .RuleFor(e => e.DateofBirth, f => f.Date.Past(20));
           
            var students = studentCreator.GenerateBetween<Student>(10, 100);
            return students;
        }
    }
}

