using ClassroomSubjectArea;
using ConsoleMenu;

class FindByComputersItem : MenuItem{
    ClassroomRepository repository;
    public FindByComputersItem(string key, ClassroomRepository repository)
    :base(key, "Поиск аудитории по количеству компьютеров"){
        this.repository = repository;
        this.Execute = () => Find();
    }

    void Find(){
        Console.Write("Введите количество компьютеров: ");
        int countOfComputers = Convert.ToInt32( Console.ReadLine() );
        List<Classroom> result = repository.GetClassroomsByFilter((e) => e.CountOfComputers >= countOfComputers);
        Console.WriteLine("{0}", string.Join("\n", result));
    }
}