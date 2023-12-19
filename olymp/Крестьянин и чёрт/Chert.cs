using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Крестьянин и чёрт");
    
    Console.WriteLine("Введите MaxN");
    int maxN = Convert.ToInt32(Console.ReadLine());
    int res = maxN;
    for(int i = 3; i <= maxN; i = 2*i+1){
        int a = maxN / i;
        res += a;
    }
    
    Console.WriteLine(res);
  }
}
