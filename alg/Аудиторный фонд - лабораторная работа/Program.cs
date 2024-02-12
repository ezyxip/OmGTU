/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

будут классы, конструкторы методы
один класс, описывающий аудиторный фонд конститута
характеристики: количество посадочных мест, оснащённость проектором, оснащённость компами и корпус, этаж и номер кабинета
1. выбрать аудитории, которые имеют количество посадочных мест >= заданному
2. выбрать аудитории с наличием компьютеров в заданном количестве
3. выборка аудиториий с наличием компьютеров на заднном этаже
4. выборка аудиторий в заданном корпусе на заданном этаже с заданнм количеством посадочных мест
Должен быть реализован класс меню в котором необходимо реализовать вывод меню на экран
Пункты меню: создание базы аудиторного фонда, дополнение базы аудиторного фонда,несколько пунктов по выборке, 
пункт по изменению данных для заданной аудиториий, вывод всех данных, выход


*******************************************************************************/

using ClassClient.MenuItems;
using ClassroomSubjectArea;
using ConsoleMenu;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Hello World");

        ClassroomRepository repository = new ClassroomRepository();

        MenuItem addClassroomItem = new AddClassItem("1", repository);
        MenuItem deleteClassroomItem = new DeleteCLassItem("2", repository);
        MenuItem findBySeats = new FindBySeats("3", repository);
        MenuItem findByComputers = new FindByComputersItem("4", repository);
        MenuItem findByComputersAndPlace = new FindByComputersAndPlaceItem("5", repository);
        MenuItem findBySeatsAndLevel = new FindBySeatsAndPlaceItem("6", repository);
        MenuItem showAllRepo = new MenuItem("7", () => { Console.WriteLine(repository);  }, "Показать все данные");

        Menu menu = new Menu(
            invitation: "class-stock:> ",
            addClassroomItem, 
            deleteClassroomItem, 
            findBySeats, 
            findByComputers, 
            findByComputersAndPlace, 
            findBySeatsAndLevel,
            showAllRepo
            );

        menu.StartWithHelp();
    }
}
