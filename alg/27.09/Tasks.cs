/*
    Для n вводимых элементов:
    1) Определить количество элементов, которые меньше соседа справа и соседа слева
    2) Определить количество смен знаков в последовательности
    3) Определить максимальную длину подпоследовательности, состоящей из одинаковых элементов
    4) Определить минимальную длину подпоследовательности, состоящей из отрицательных элементов
*/

using System;
class HelloWorld {
    
  static void Main() {
      Console.WriteLine("Задача 1:");
      One();
      Console.WriteLine("Задача 2:");
      Two();
      Console.WriteLine("Задача 3:");
      Three();
      Console.WriteLine("Задача 4:");
      Four();
  }



  static void One() {
    Console.Write("Количество вводимых чисел: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int res = 0;
    int prepreiousInt = Convert.ToInt32(Console.ReadLine());
    int previousInt = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < n-2; i++){
        int currentInt = Convert.ToInt32(Console.ReadLine());
        if(previousInt < prepreiousInt && prepreiousInt < currentInt){
            res++;
        }
        prepreiousInt = previousInt;
        previousInt = currentInt;
    }
    
    Console.WriteLine($"Результат: {res}");
  }


    static bool Znak(int a){
        if(a > 0){
            return true;
        }else{
            return false;
        }
    }
    
    
  static void Two() {
    Console.Write("Количество вводимых чисел: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int res = 0;
    int previousInt = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < n-1; i++){
        int currentInt = Convert.ToInt32(Console.ReadLine());
        if(Znak(previousInt) != Znak(currentInt)){
            res ++;
        }
        previousInt = currentInt;
    }
    
    Console.WriteLine($"Результат: {res}");
  }

    
  static void Three() {
    Console.Write("Количество вводимых чисел: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int res = 1;
    int currentSequenceLength = 1;
    int previousInt = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < n-1; i++){
        int currentInt = Convert.ToInt32(Console.ReadLine());
        if(currentInt == previousInt){
            currentSequenceLength += 1;
        } else {
            currentSequenceLength = 1;
        }
        res = Math.Max(res, currentSequenceLength);
        previousInt = currentInt;
    }
    
    Console.WriteLine($"Результат: {res}");
  }

    
    static bool isNegative(int a){
        return a < 0;
    }
    
  static void Four() {
    Console.Write("Количество вводимых чисел: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int res = 0;
    int currentSequenceLength = 1;
    int previousInt = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < n-1; i++){
        int currentInt = Convert.ToInt32(Console.ReadLine());
        if(isNegative(currentInt)){
            currentSequenceLength += 1;
        } 
        if(!isNegative(currentInt) || i + 1 == n - 1){
            if(res != 0){
                res = Math.Min(res, currentSequenceLength);
            } else {
                res = currentSequenceLength;
            }
            currentSequenceLength = 1;
        }
        previousInt = currentInt;
    }
    
    Console.WriteLine($"Результат: {res}");
  }

}
