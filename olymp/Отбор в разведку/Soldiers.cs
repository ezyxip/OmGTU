using System;
class HelloWorld {
    
    static int Line(int soldierCount){
        if(soldierCount == 3){
            return 1;
        } else if (soldierCount < 3){
            return 0;
        } else if(soldierCount % 2 == 0){
            return Line(soldierCount / 2) * 2;
        } else {
            return Line((soldierCount - 1) / 2) + Line((soldierCount - 1) / 2 + 1);
        }
    }
    
  static void Main() {
    Console.WriteLine("Введите количество солдат в шеренге");
    int countOfSoldiers = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(Line(countOfSoldiers));
  }
}
