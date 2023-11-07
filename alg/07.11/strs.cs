/******************************************************************************

Строки
1. На вход подаётся строка. Надо определить сумму чётных цифр строки
2. является ли строка палиндромом?


*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Hello World");
    string input = "А роза упала на лапу азора";
    int result = 0;
    foreach(char i in input){
        if(Char.IsDigit(i)){
            int integer = Convert.ToInt32(Char.ToString(i));
            if(integer %2 == 0){
                result+=integer;
            }
        }
    }
    string prepairInput = input.Replace(" ", "").ToLower();
    string reverseInput = "";
    foreach(char i in prepairInput){
        reverseInput = Char.ToString(i) + reverseInput;
    }
    Console.WriteLine($"Сумма чётных цифр в строке: {result}");
    if(reverseInput == prepairInput){
        Console.WriteLine("Является палиндромом");
    } else {
        Console.WriteLine("Не является палиндромом");
    }
  }
}
