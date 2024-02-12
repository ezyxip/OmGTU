using ClassroomSubjectArea;
using ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClient.MenuItems
{
    internal class DeleteCLassItem : MenuItem
    {
        ClassroomRepository Repository;
        public DeleteCLassItem(string key, ClassroomRepository repository) 
            : base(key, "Удаление аудитории из фонда")
        {
            this.Repository = repository;
            Execute = () => DeleteClassroom();
        }

        void DeleteClassroom()
        {
            Console.Write("Адрес аудитории для удаления: ");
            string adress = Console.ReadLine();
            if (adress == "")
            {
                Console.WriteLine("Отмена удаления...");
                return;
            }
            bool isDeleted = Repository.DeleteClassroom(adress);
            Console.WriteLine(isDeleted ? "Элемент удалён" : "Элемент не найден");
        }
    }
}
