using ClassroomSubjectArea;
using ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClient.MenuItems
{
    class AddClassItem : MenuItem
    {
        ClassroomRepository repository;

        public AddClassItem(string key, ClassroomRepository repository)
            :base(key, "Добавить аудиторию")
        {
            this.repository = repository;
            this.Execute = () => AddClassroom();
        }

        private void AddClassroom()
        {
            string adress = RequestAdress();
            int seats = RequestSeats();
            bool isHaveProjector = RequestHavingProjector();
            int countOfComputers = RequestCountOfComputers();

            Classroom classroom = new Classroom(adress, seats, isHaveProjector, countOfComputers);

            repository.Add(classroom);
        }

        private string RequestAdress()
        {
            Console.Write("Адрес кабинета: ");
            string res = Console.ReadLine();
            if (!Classroom.ValidateAdress(res)) 
                throw new Exception("Не является адресом");

            return res;
        }

        private int RequestSeats()
        {
            Console.Write("Количество сидячих мест: ");
            string? input = Console.ReadLine();

            return ValidateSeats(input);
        }

        private int ValidateSeats(string? input)
        {
            int res;
            try
            {
                res = int.Parse(input);
            }
            catch (Exception ex)
            {
                throw new Exception("Недопустимое значение");
            }

            return res;
        }

        private bool RequestHavingProjector()
        {
            Console.Write("В наличии ли проектор? (Д/Н): ");
            string res = Console.ReadLine().ToString().ToLower();
            Console.WriteLine(res == "д" ? "Выбран ответ \"Да\"" : "Выбран ответ \"Нет\"");
            return res == "д";
        }

        private int RequestCountOfComputers()
        {
            Console.Write("Количество компьютеров: ");
            int res;
            try
            {
                res = Convert.ToInt32(Console.ReadLine());
            }
            catch 
            { 
                throw new Exception("Недопустимое значение");
            }
            

            return res;
        }
    }
}
