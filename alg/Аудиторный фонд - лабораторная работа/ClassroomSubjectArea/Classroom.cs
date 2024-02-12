using System.Text.RegularExpressions;

namespace ClassroomSubjectArea
{
    public class Classroom
    {
        public int Building;
        public int Level;
        public int Number;
        public int CountOfSeats;
        public bool IsHaveProjector;
        public int CountOfComputers;
        public bool IsHaveComputer
        {
            get { return CountOfComputers != 0; }
        }
        public string Adress
        {
            get { return Building + "-" + Level + Number; }
        }

        public Classroom(
                int building = 1,
                int level = 1,
                int number = 1,
                int countOfSeats = 0,
                bool isHaveProjector = false,
                int countOfComputers = 0
            )
        {
            this.Building = building;
            this.Level = level;
            this.Number = number;
            this.CountOfComputers = countOfComputers;
            this.IsHaveProjector = isHaveProjector;
            this.CountOfComputers = countOfComputers;
            this.CountOfSeats = countOfSeats;
        }

        public Classroom(
                string adress,
                int countOfSeats = 0,
                bool isHaveProjector = false,
                int countOfComputers = 0
            )
        {
            (int building, int level, int number) = SplitAdress(adress);

            this.Building = building;
            this.Level = level;
            this.Number = number;
            this.CountOfComputers = countOfComputers;
            this.IsHaveProjector = isHaveProjector;
            this.CountOfComputers = countOfComputers;
            this.CountOfSeats = countOfSeats;
        }

        private (int, int, int) SplitAdress(string adress)
        {
            if (!ValidateAdress(adress)) throw new Exception("Не является адресом");
            string[] splitAdress = adress.Split('-');
            int building = Convert.ToInt32(splitAdress[0]);
            int level = int.Parse(splitAdress[1][0].ToString());
            int number = Convert.ToInt32(splitAdress[1][1..]);

            return (building, level, number);
        }

        public static bool ValidateAdress(string adress)
        {
            Regex regex = new Regex(@"^\d+-\d\d+$");
            return regex.IsMatch(adress);
        }

        override public string ToString()
        {
            return $"[Аудитория {Adress}: "
                + "Посадочных мест: " + CountOfSeats + "; "
                + "Компьютерных мест: " + CountOfComputers + "; "
                + "Наличие проектора: " + (IsHaveProjector ? "есть" : "нет") + "; " 
                + "]";
        }
    }
}