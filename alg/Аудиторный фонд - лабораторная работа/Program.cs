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
