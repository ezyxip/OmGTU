using System;
using System.Collections.Generic;

class HelloWorld {
    
  static void Main() {
    Console.Write("Введите количество мышей: ");
    int allMouses = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите шаг: ");
    int k = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите позицию белой мыши: ");
    int whiteMousePosition = Convert.ToInt32(Console.ReadLine());
    
    List<int> positions = GetRange(1,5);
    
    int lastElem = GetLastElement(positions, 0, k);
    
    Console.WriteLine($"Необходимо начать с {1 + whiteMousePosition - lastElem}");
    
  }
  
  static int GetLastElement(List<int> _positions, int startPosition, int k){
      List<int> positions = _positions;
      int currentPosition = startPosition;
      while(true){
          positions.RemoveAt(currentPosition);
          currentPosition += k - 1;
          currentPosition %= positions.Count;
          if(positions.Count == 1) break;
      }
      
      return positions[0];
  }
  
  static List<int> GetRange(int min, int max){
      List<int> res = new List<int>();
      for(; min <= max; min++){
          res.Add(min);
      }
      return res;
  }
}

