1using System;

/*
  для n вводимых элементов выяснить:
1) Кратен ли элемент месту, где лежит
2) Определить положение первого чётного элемента в массиве
3) Определить положение последнего нулевого элемента массива
4) Определить количество элемента кратных минимальному элементу массива (минимальный элемент нулём не будет)
5) Определить, образуют ли элементы расположенные между максимальным и минимальным элементом массива убывающую последовательность (минимум и максимум только один, предусмотреть, что количество элементов расположенных между равно нулю, если элемент один, то последовательность нормальная)

*/

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Five();
  }

  static void One(){
    int n = Convert.ToInt32(Console.ReadLine());
    int[] entered = new int[n];
    
    for(int i = 0; i < n; i++){
        entered[i] = Convert.ToInt32(Console.ReadLine());
    }
    
    for(int i = 0; i < n; i++){
        if(entered[i] % (i+1) != 0){
            Console.WriteLine("Есть некратности");
            return;
        }
    }
    
    Console.WriteLine("Некратностей нет");
  } 
  
  static void Two(){
    int n = Convert.ToInt32(Console.ReadLine());
    int[] entered = new int[n];
    
    for(int i = 0; i < n; i++){
        entered[i] = Convert.ToInt32(Console.ReadLine());
    }
    
    for(int i = 0; i < n; i++){
        if(entered[i] % 2 == 0){
            Console.WriteLine($"Позиция первого чётного: {i + 1}");
            return;
        }
    }
    
    Console.WriteLine("Нечётного нет");
  }
  
  static void Three(){
    int n = Convert.ToInt32(Console.ReadLine());
    int[] entered = new int[n];
    
    for(int i = 0; i < n; i++){
        entered[i] = Convert.ToInt32(Console.ReadLine());
    }
    
    int nullPosition = -1;
    for(int i = 0; i < n; i++){
        if(entered[i] == 0){
            nullPosition = i;
        }
    }
    
    if(nullPosition == -1){
        Console.WriteLine($"Нулевого элемента нет");
    }else {
        Console.WriteLine($"Последний нулевой элемент на позиции: {nullPosition + 1}");
    }
  }
  
  static void Four(){
    int n = Convert.ToInt32(Console.ReadLine());
    int[] entered = new int[n];
    
    int minimalElement = Convert.ToInt32(Console.ReadLine());
    entered[0] = minimalElement;
    for(int i = 1; i < n; i++){
        entered[i] = Convert.ToInt32(Console.ReadLine());
        minimalElement = Math.Min(entered[i], minimalElement);
    }
    
    
    int res = 0;
    for(int i = 0; i < n; i++){
        if(entered[i] % minimalElement == 0){
            res++;
        }
    }
    
    Console.WriteLine($"Количество кратных элементов: {res}");
  }
  
  static void Five(){
    int n = Convert.ToInt32(Console.ReadLine());
    int[] entered = new int[n];
    
    entered[0] = Convert.ToInt32(Console.ReadLine());
    entered[1] = Convert.ToInt32(Console.ReadLine());
    
    int minimalIndex = entered[0] < entered[1] ? 0 : 1;
    int maximalIndex = entered[0] > entered[1] ? 0 : 1;
    
    for(int i = 2; i < n; i++){
        entered[i] = Convert.ToInt32(Console.ReadLine());
        minimalIndex = entered[i] < entered[minimalIndex] ? i : minimalIndex;
        maximalIndex = entered[i] > entered[maximalIndex] ? i : maximalIndex;
    }
    
    
    if(Math.Min(minimalIndex, maximalIndex) + 1 == Math.Max(minimalIndex, maximalIndex)){
        Console.WriteLine("Минимальный и максимальные элементы находятся на соседних позициях");
        return;
    }
    for(int i = Math.Min(minimalIndex, maximalIndex) + 2; i <= Math.Max(minimalIndex, maximalIndex) ; i++){
        if(entered[i - 1] < entered[i]){
            Console.WriteLine("Убывающая последовательность не выполняется");
            return;
        }
    }
   
    Console.WriteLine("Убывающая последовательность выполняется");
  }
}
