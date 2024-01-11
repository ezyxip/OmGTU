using System;
class HelloWorld {
  static void Main() {
    int[][] sets = new int[3][];
    sets[0] = new int[]{1, 2, 3, 4};
    sets[1] = new int[]{3, 4, 5};
    sets[2] = new int[]{1, 4, 6, 7, 8};
    
    
    int[] union = sets[0];
    for(int i = 1; i < sets.Length; i++){
        union = GetUnion(union, sets[i]);
    }
    Console.Write("Объединение множеств: ");
    foreach(var i in union){
        Console.Write($"{i}, ");
    }
    
    Console.WriteLine();
    
    int[] intersection = sets[0];
    for(int i = 1; i < sets.Length; i++){
        intersection = GetIntersection(intersection, sets[i]);
    }
    Console.Write("Пересечение множеств: ");
    foreach(var i in intersection){
        Console.Write($"{i}, ");
    }
    
    Console.WriteLine();
    
    Console.Write("Множество максимальных элементов: ");
    int[] maximalElements = new int[sets.Length];
    int index = 0;
    foreach(var i in sets){
        maximalElements[index++] = GetMaximalElement(i);
        Console.Write($"{GetMaximalElement(i)}, ");
    }
  }
  
  static int[] GetUnion(int[] setA, int[] setB){
      int[] res = new int[GetUnionSize(setA, setB)];
      int index = 0;
      foreach(var i in setA){
          res[index++] = i;
      }
      foreach(var i in setB){
          if(!IsContain(setA, i)) res[index++] = i;
      }
      
      return res;
  }
  static int GetUnionSize(int[] setA, int[] setB){
      int res = setB.Length;
      foreach(var i in setA){
          if(!IsContain(setB, i)) res++;
      }
      
      return res;
  }
  
  static int[] GetIntersection(int[] setA, int[] setB){
      int[] res = new int[GetIntersectionSize(setA, setB)];
      int index = 0;
      foreach(var i in setB){
          if(IsContain(setA, i)) res[index++] = i;
      }
      
      return res;
  }
  
  static int GetIntersectionSize(int[] setA, int[] setB){
      int res = 0;
      foreach(var i in setA){
          if(IsContain(setB, i)) res++;
      }
      
      return res;
  }
  
  static bool IsContain(int[] set, int elem){
      foreach(var i in set){
          if(i == elem) return true;
      }
      
      return false;
  }
  
  static int GetMaximalElement(int[] set){
      int res = set[0];
      foreach(var i in set){
          res = res > i? res : i;
      }
      
      return res;
  }
}
