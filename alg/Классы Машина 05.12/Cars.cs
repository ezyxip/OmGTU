/*
  Класс Машина, который содержит:
  Наименование
  Год выпуска
  Цвет
  Массив владельцев
  Массив дат прохождения техосмотра
  
  Осуществить выборку всех машин произведённых за заданный год
  Выборку всех машин которые прошли техосмотр в заданный год
  Выборку последних владельцев каждой машины

*/

using System;

class Car{
    public string ModelName;
    public int Year;
    public string Color;
    public string[] Owners;
    public int[] DatesOfTI;
    
    public Car(
        string ModelName,
        int Year,
        string Color,
        string[] Owners,
        int[] DatesOfTI
        ){
            this.ModelName = ModelName;
            this.Year = Year;
            this.Color = Color;
            this.Owners = Owners;
            this.DatesOfTI = DatesOfTI;
        }
        
        public override string ToString(){
            return $"Модель: {this.ModelName}, Год выпуска: {this.Year}, Текущий владелец: {this.Owners[this.Owners.Length-1]}";
        }
}

class Search{
    static public Car[] GetCarsByModelName(string ModelName, Car[] cars){
        int resCount = 0;
        foreach(var i in cars){
            if(i.ModelName == ModelName){
                resCount++;
            }
        }
        
        Car[] res = new Car[resCount];
        int resIndex = 0;
        foreach(var i in cars){
            if(i.ModelName == ModelName){
                res[resIndex] = i;
                resIndex++;
            }
        }
        
        return res;
    }
    
    static public Car[] GetCarsByYear(int year, Car[] cars){
        int resCount = 0;
        foreach(var i in cars){
            if(i.Year == year){
                resCount++;
            }
        }
        
        Car[] res = new Car[resCount];
        int resIndex = 0;
        foreach(var i in cars){
            if(i.Year == year){
                res[resIndex] = i;
                resIndex++;
            }
        }
        
        return res;
    }
    
    static public Car[] GetCarsByYearOfTI(int YearOfTI, Car[] cars){
        int resCount = 0;
        foreach(var i in cars){
            foreach(var j in i.DatesOfTI){
                if(j == YearOfTI){
                    resCount++;
                    break;
                }
            }
        }
        
        Car[] res = new Car[resCount];
        int resIndex = 0;
         foreach(var i in cars){
            foreach(var j in i.DatesOfTI){
                if(j == YearOfTI){
                    res[resIndex] = i;
                    resIndex++;
                    break;
                }
            }
        }
        
        return res;
    }
    
    
    static public Car[] GetCarsByLastOwner(string owner, Car[] cars){
        int resCount = 0;
        foreach(var i in cars){
            if(i.Owners[i.Owners.Length - 1] == owner){
                resCount++;
                break;
            }
        }
        
        Car[] res = new Car[resCount];
        int resIndex = 0;
        foreach(var i in cars){
            if(i.Owners[i.Owners.Length - 1] == owner){
                res[resIndex] = i;
                resIndex++;
                break;
            }
        }
        
        return res;
    }
}

class HelloWorld {
  static void Main() {
    Car[] cars = new Car[10];
    cars[0] = new Car("Toyota", 2000, "Black", new string[]{"Пупкин", "Папкин"}, new int[]{2001, 2002, 2100});
    cars[1] = new Car("Suzuki", 2005, "Red", new string[]{"Лалупкин", "Аникин"}, new int[]{2010, 2052, 2080});
    cars[2] = new Car("Audi", 2007, "Blue", new string[]{"Мельников", "Цейдлер"}, new int[]{2010, 2012, 2025});
    cars[3] = new Car("Porshe", 2001, "Black", new string[]{"Мотынга", "Тиль"}, new int[]{2002, 2003, 2010});
    cars[4] = new Car("Mercedes-Benz", 2010, "Yellow", new string[]{"Иванов", "Петров"}, new int[]{2011, 2012, 2100});
    cars[5] = new Car("Chery", 2012, "Green", new string[]{"Сидоров", "Анюткин"}, new int[]{2013, 2015, 2099});
    cars[6] = new Car("BMW", 2009, "Purple", new string[]{"Дейнерис", "Гроустритов"}, new int[]{2011, 2021, 2075});
    cars[7] = new Car("Honda", 2011, "Gray", new string[]{"Паравозов", "Сиджеев"}, new int[]{2020, 2021, 2045});
    cars[8] = new Car("Hyundai", 2000, "Brown", new string[]{"Райдеров", "Диджеев"}, new int[]{2018, 2020, 2034});
    cars[9] = new Car("Ford", 2023, "Orange", new string[]{"Светофоров", "Мышкин"}, new int[]{2024, 2025, 2056});
    
    Console.WriteLine("Выберите тип фильтра (1 - Год выпуска, 2 - Год техосмотра, 3 - Текущий владелец):");
    string filterType = Console.ReadLine();
    if(filterType == "1"){
        Console.Write("Введите год выпуска: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Car[] res = Search.GetCarsByYear(year, cars);
        foreach(var i in res){
           Console.WriteLine(i); 
        }
    }else if(filterType == "2"){
        Console.Write("Введите год техосмотра: ");
        int yearOfTI = Convert.ToInt32(Console.ReadLine());
        Car[] res = Search.GetCarsByYearOfTI(yearOfTI, cars);
        foreach(var i in res){
           Console.WriteLine(i); 
        }
    } else if(filterType == "3"){
        Console.Write("Введите владельца: ");
        string lastOwner = Console.ReadLine();
        Car[] res = Search.GetCarsByLastOwner(lastOwner, cars);
        foreach(var i in res){
           Console.WriteLine(i); 
        }
    } else {
        Console.Write("Недопустимый ввод");
    }
  }
}
