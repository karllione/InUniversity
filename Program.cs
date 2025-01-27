
namespace StudentAccounting
{    
    internal class Program
    {
        static void Main(string[] args)
        {
            var university = new University();

            Console.WriteLine("Система учета студентов.");
            while(true)
            {
                Console.WriteLine("Операции: ");
                Console.WriteLine("1. Добавить нового студента");
                Console.WriteLine("2. Добавить оценку для конкретного студента");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Найти студента по имени и вывести его среднюю оценку");
                Console.WriteLine("5. Вывести список всех студентов и их средних оценок");
                Console.WriteLine("6. Вывести имена студентов, чья средняя оценка выше некоторого числа");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.Write("Номер операции: ");

                int numberOfAnswer = int.Parse(Console.ReadLine());

                if (numberOfAnswer == 0)
                    break;

                switch(numberOfAnswer)
                {
                    case 1:
                        {
                            Console.Write("Введите имя и фамилию студента: ");

                            string input = Console.ReadLine();
                            string[] name = input.Split(' ');
                            Console.WriteLine();

                            university.AddStudent(name[0], name[1]);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите имя и фамилию студента: ");

                            string input = Console.ReadLine();
                            string[] name = input.Split(' ');

                            Console.Write("Введите оценку/оценки студента: ");
                            
                            int grade = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            university.AddGradeForStudent(name[0], name[1], grade);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите имя и фамилию студента: ");

                            string input = Console.ReadLine();
                            string[] name = input.Split(' ');
                            Console.WriteLine();

                            university.DeleteStudent(name[0], name[1]);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Введите имя и фамилию студента: ");

                            string input = Console.ReadLine();
                            string[] name = input.Split(' ');
                            Console.WriteLine();

                            university.PrintAverageGrade(name[0], name[1]);
                            break;
                        }
                    case 5:
                        {
                            university.PrintStudents();
                            break;
                        }
                    case 6: 
                        {
                            Console.Write("Введите число: ");

                            int number = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            university.PrintAverageGradeMoreThan(number);
                            break;
                        }
                    default:
                        Console.WriteLine("Такого варианта ответа нет.");
                        break;
                }
            }
        }
    }
}
