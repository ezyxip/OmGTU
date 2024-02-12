using ClassroomSubjectArea;
using ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClient.MenuItems
{
    class FindBySeats : MenuItem
    {
        ClassroomRepository repository;

        public FindBySeats(string key, ClassroomRepository repository)
            :base(key, "Поиск аудиторий по количеству посадочных мест")
        {
            this.repository = repository;
            this.Execute = () => FindClassroomBySeats();
        }

        private void FindClassroomBySeats()
        {
            Console.WriteLine("Введите минимальное количество сидячих мест для поиска");
            int minimalSeatsCount = Convert.ToInt32(Console.ReadLine());
            List<Classroom> result = repository.GetClassroomsByFilter((e)=>e.CountOfSeats >= minimalSeatsCount);
            Console.WriteLine("{0}", string.Join("\n", result));
        }
    }
}
