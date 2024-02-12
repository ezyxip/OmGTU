using ClassroomSubjectArea;
using ConsoleMenu;

class FindBySeatsAndPlaceItem : MenuItem{
    ClassroomRepository repository;
    public FindBySeatsAndPlaceItem(string key, ClassroomRepository repository)
    :base(key, "Поиск аудитории по месту и посадочным местам"){
        this.repository = repository;
        this.Execute = () => Find();
    }

    void Find(){
        Console.Write("Введите номер корпуса: ");
        int building = Convert.ToInt32( Console.ReadLine() );
        Console.Write("Введите номер этажа: ");
        int level = Convert.ToInt32( Console.ReadLine() );
        Console.Write("Введите необходимое количество посадочных мест: ");
        int seats = Convert.ToInt32( Console.ReadLine() );
        List<Classroom> result = repository.GetClassroomsByFilter((e) => e.Building == building && e.Level == level && e.CountOfSeats >= seats);
        Console.WriteLine("{0}", string.Join("\n", result));
    }
}