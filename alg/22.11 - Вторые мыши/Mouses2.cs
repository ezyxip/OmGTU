using System;
using System.Collections.Generic;

class HelloWorld {
    
  static void Main() {
    Console.Write("Введите общее количество серых мышей: ");
    int countOfGray = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите общее количество белых мышей: ");
    int countOfWhite = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите нужное количество серых мышей: ");
    int targetCountOfGray = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите нужное количество белых мышей: ");
    int targetCountOfWhite = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите шаг: ");
    int step = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите начальную позицию: ");
    int startPosition = Convert.ToInt32(Console.ReadLine());
    
    int countOfEatedGray = countOfGray - targetCountOfGray;
    int countOfEatedWhite = countOfWhite - targetCountOfWhite;
    
    List<int> positions = GetRange(0,9);
    List<int> targetPosition = GetRange(0,9);
    targetPosition = GetTargetPositions(targetPosition, startPosition, step, targetCountOfWhite + targetCountOfGray);
    foreach(var i in targetPosition){
        if(targetCountOfWhite != 0) {
            positions[i] = -1;
            targetCountOfWhite--;
        }
        else{
            positions[i] = -2;
            targetCountOfGray--;
        }
    }
    for(int i = 0; i < positions.Count; i++){
        if(positions[i] > 0){
            if(countOfEatedWhite != 0){
                positions[i] = -1;
                countOfEatedWhite--;
            } else {
                positions[i] = -2;
                countOfEatedGray--;
            }
        }
    }
    foreach(var i in positions){
        if(i == -1) Console.Write("Белая, ");
        else Console.Write("Серая, ");
    }
  }
  
  static List<int> GetTargetPositions(List<int> _positions, int startPosition, int k, int countOfTargetPositions){
      List<int> positions = _positions;
      int currentPosition = startPosition;
      while(true){
          positions.RemoveAt(currentPosition);
          currentPosition += k - 1;
          currentPosition %= positions.Count;
          if(positions.Count == countOfTargetPositions) break;
      }
      
      return positions;
  }
  
  static List<int> GetRange(int min, int max){
      List<int> res = new List<int>();
      for(; min <= max; min++){
          res.Add(min);
      }
      return res;
  }
}
