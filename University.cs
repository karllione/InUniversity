
namespace StudentAccounting
{
    class University
    {
        readonly Dictionary<Student, List<int>> _students;

        public University()
        {
            _students = new Dictionary<Student, List<int>>();
        }

        // Метод добавления студента
        public void AddStudent(string name, string lastName)
        {
            var student = new Student(name, lastName);
            if(!_students.ContainsKey(student))
            {
                _students.Add(student, new List<int>());
            }
            else
            {
                Console.WriteLine($"Студент {name} {lastName} уже есть в списке.");
            }
        }
        // Метод вывода информации о студенте
        public void PrintStudents()
        {
            foreach (var studentEntry in _students)
            {
                string gradeInfo = studentEntry.Value == null
                    ? "Нет оценок"
                    : $"{string.Join(", ", studentEntry.Value)}";

                Console.WriteLine($"{studentEntry.Key}\t {gradeInfo}\n");
            }
        }
        // Метод добавления оценки студенту
        public void AddGradeForStudent(string name, string lastName, int grade)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Ошибка: имя или фамилия студента не могут быть пустыми, содержать null-значения или пробелы.\n");
                return;
            }

            if (grade < 1 || grade > 5)
            {
                Console.WriteLine("Ошибка: введите корректную отметку (1-5).\n");
                return;
            }

            var student = new Student(name, lastName);

            if (_students.TryGetValue(student, out var grades))
            {
                grades.Add(grade);
                Console.WriteLine($"Оценка {grade} для студента {name} {lastName} добавлена.\n");
            }
            else
            {
                Console.WriteLine($"Студент {name} {lastName} отсутствует в списке. Добавляю студента.\n");
                _students[student] = new List<int> { grade };
            }
        }
        // Метод получения средней оценки студента
        public double GetAverageGrade(string name, string lastName)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Ошибка: имя или фамилия студента не могут быть пустыми, содержать null-значения или пробелы.\n");

            var studentKey = new Student(name, lastName);
            if (_students.TryGetValue(studentKey, out var listOfGrades) && listOfGrades?.Any() == true)
            {
                double averageGrade = listOfGrades.Average();
                return Math.Round(averageGrade, 2);
            }

            return 0;
        }
        // Метод вывода средней оценки студента
        public void PrintAverageGrade(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
                Console.WriteLine("Ошибка: имя или фамилия студента не могут быть пустыми, содержать null-значения или пробелы.\n");

            double averageGrade = GetAverageGrade(name, lastName);

            Console.WriteLine($"Средняя оценка студента {name} {lastName}: {averageGrade}\n");
        }
        // Метод вывода студентов, чья оценка выше заданной
        public void PrintStudentsAverageGradeMoreThan(double grade)
        {
            Console.WriteLine($"Список студентов, чья средняя отметка выше {grade}: ");

            var studentsWithAverageGrade = _students
                .Where(student => GetAverageGrade(student.Key.FirstName, student.Key.LastName) > grade)
                .Select(student => new
                {
                    student.Key.FirstName,
                    student.Key.LastName,
                    AverageGrade = GetAverageGrade(student.Key.FirstName, student.Key.LastName)
                }).ToList();

            foreach (var student in studentsWithAverageGrade)
                Console.WriteLine($"{student.FirstName} {student.LastName} -> {student.AverageGrade}");
        }
        // Метод удаления студента
        public void DeleteStudent(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
                Console.WriteLine("Ошибка: имя или фамилия студента не могут быть пустыми, содержать null-значения или пробелы.\n");

            var student = new Student(name, lastName);
            _students.Remove(student);
        }
    }
}
