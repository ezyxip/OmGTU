
namespace ConsoleMenu
{
    public class Menu
    {
        List<MenuItem> Items;
        string Invitation;

        public Menu(string invitation, params MenuItem[] items)
        {
            Invitation = invitation;
            Items = items.ToList<MenuItem>();

            MenuItem help = new MenuItem(
                key: "?",
                exec: () =>
                {
                    Items.ForEach((e) => Console.WriteLine($"{e.Key} --- {e.Info}"));
                },
                info: "Получение справки"
                );


            MenuItem exit = new MenuItem(
                key: "exit",
                () => { },
                info: "Выход из программы"
                );

            Items.Add(help);
            Items.Add(exit);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    Console.Write("\n" + Invitation);
                    string input = Console.ReadLine();
                    if (input == "exit") break;
                    ExecuteCommand(input);
                } catch (Exception ex)
                {
                    Console.WriteLine($"[{ex.Message}]");
                }
            }
        }

        public void StartWithHelp()
        {
            ExecuteCommand("?");
            Start();
        }

        public void ExecuteCommand(string key)
        {
            MenuItem targetMenuItem = Items.Find((e) => e.Key == key);
            if (targetMenuItem == null)
            {
                Console.WriteLine("Не является допустимой командой");
            }
            else
            {
                targetMenuItem.Execute();
            }
        }
    }
}