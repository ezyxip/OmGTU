/******************************************************************************

Ступенчатые массивы

Дан массив, в котором элементы строк - это множества целых неотрицательных чисел разной размерности
Необходимо сформировать одномерные массивы, которые содержат 
1) Элементы пересечения множества
2) Элементы объединения множеств
3) Массив из максимальных элементов множеств

*******************************************************************************/
using System;
using System.Linq;

class HelloWorld {
  static void Main() {
    Console.WriteLine("Hello World");
    int n = 3;
    int[][] sets = new int[n][];
    sets[0] = new int[]{1,2,3, 5,1,1, 32};
    sets[1] = new int[]{3,4, 32, 88, 1, 99};
    sets[2] = new int[]{2,3,4, 88, 88, 1, 88, 32};
    
    for(int i = 0; i < sets.Length; i++){
        sets[i] = Normalize(sets[i]);    
    }
    
    //Объединение
    int[] union = new int[calcLength(sets)];
    int count = 0; 
    foreach(int[] i in sets){
        foreach(int j in i){
            union[count] = j;
            count++;
        }
    }
    
    union = Normalize(union);
    Console.WriteLine("Объединение: [{0}]", string.Join(", ", Normalize(union)));
    
    //Пересечение
    int intersectionSize = sets[0].Length;
    foreach(int i in sets[0]){
        foreach(int[] j in sets){
            if(!j.Contains(i)){
                intersectionSize--;
                break;
            }
        }
    }
    
    int[] intersection = new int[intersectionSize];
    int intersectionCount = 0;
    foreach(int i in sets[0]){
        bool isRepeat = true;
        foreach(int[] j in sets){
            if(!j.Contains(i)){
                isRepeat = false;
                break;
            }
        }
        if(isRepeat){
            intersection[intersectionCount] = i;
            intersectionCount++;
        }
    }
    
    Console.WriteLine("Пересечение: [{0}]", string.Join(", ", Normalize(intersection)));
    
    
    //Максимальные элементы
    int[] maxs = new int[sets.Length];
    int maxsCount = 0;
    
    foreach(int[] i in sets){
        int maxElem = i[0];
        foreach(int j in i){
            maxElem = Math.Max(maxElem, j);
        }
        maxs[maxsCount] = maxElem;
        maxsCount++;
    }
    Console.WriteLine("Множество максимальных элементов: [{0}]", string.Join(", ", Normalize(maxs)));
  }
  
  
  static int calcLength(int[][] a){
      int res = 0;
      foreach(int[] i in a){
          res += i.Length;
      }
      return res;
  }
  
  static int[] Normalize(int[] a){
    int summarySize = a.Length;
    for(int i = 0; i < a.Length-1; i++){
        for(int j = i+1; j < a.Length; j++){
            if(a[j] == a[i]){
                summarySize--;
                break;
            }
        }
    }
      
    int[] res = new int[summarySize];
    int count = 0;
    
    for(int i = 0; i < a.Length-1; i++){
        bool isRepeat = false;
        for(int j = i+1; j < a.Length; j++){
            if(a[j] == a[i]){
                isRepeat = true;
                break;
            }
        }
        if(!isRepeat){
            res[count] = a[i];
            count++;
        }
    }
    
    res[summarySize - 1] = a[a.Length-1];
    return res;
   }
}




