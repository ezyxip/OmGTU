
using System;
using System.Collections.Generic;
class HelloWorld {
    
    static Dictionary<int, int> dayMap = new Dictionary<int, int>(){
        {1, 31},
        {2, 28},
        {3, 31},
        {4, 30},
        {5, 31},
        {6, 30},
        {7, 31},
        {8, 31},
        {9, 30},
        {10, 31},
        {11, 30},
        {12, 31},
    };
    
    static string Normalize(string s){
        if(s.Length == 1){
            return "0"+s;
        } else {
            return s;
        }
    }
    
    static string AddYear(string ddmmyyyy){
        string[] date = ddmmyyyy.Split(".");
        
        int years = Int32.Parse(date[2]) + 1;
        date[2] = Convert.ToString(years);
        
        return string.Join(".", date);
    }
    
    static string AddMonth(string ddmmyyyy){
        string[] date = ddmmyyyy.Split(".");
        
        int months = Int32.Parse(date[1]) + 1;
        
        if(months > 12){
            date[1] = "01";
            string res = string.Join(".", date);
            return AddYear(res);
        } else{
            date[1] = Normalize(Convert.ToString(months));
            return string.Join(".", date);   
        }
    }
    
    static string AddDay(string ddmmyyyy){
        string[] date = ddmmyyyy.Split(".");
        
        int days = Int32.Parse(date[0]) + 1;
        int months = Int32.Parse(date[1]);
        int years = Int32.Parse(date[2]);
        
        if(years%4 == 0){
            dayMap[2] = 29;
        } else{
            dayMap[2] = 28;
        }
        
        if(days > dayMap[months]){
            date[0] = "01";
            string res = string.Join(".", date);
            return AddMonth(res);
        } else{
            date[0] = Normalize(Convert.ToString(days));
            return string.Join(".", date);   
        }
    }
    
  static void Main() {
    Console.WriteLine("Hello World");
    Console.WriteLine("Введите первую дату");
    string firstDay = Console.ReadLine(); //"12.05.2002";
    Console.WriteLine("Введите вторую дату");
    string secondDay = Console.ReadLine();//"09.04.2003";
    Console.WriteLine("Введите начальную мощность производства");
    int p = Convert.ToInt32(Console.ReadLine()); //10
    
    int res = 0;
    while(true){
        if(firstDay == secondDay){
            res += p;
            p++;
            break;
        }
        
        firstDay = AddDay(firstDay);
        res += p;
        p++;
    }
    
    
    Console.WriteLine(res);
  }
}

