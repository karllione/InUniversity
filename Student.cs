
namespace StudentAccounting
{
    internal class Student
    {     
        public Student(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<double> Grades { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName}\tLast Name: {LastName}\tGrades {Grades}";
        }

        public override bool Equals(object? obj)
        {
            var otherStudent = obj as Student;

            if (otherStudent == null)
                return false;

            return otherStudent.FirstName == FirstName && otherStudent.LastName == LastName;   
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);            
        }
    }
}
