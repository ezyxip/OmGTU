using System;

abstract class Product
{
  public string Name;
  public string Unit;
  public int Cost;

  public Product (string name, string unit, int cost)
  {
    this.Name = name;
    this.Unit = unit;
    this.Cost = cost;
  }

  public abstract void Print ();

}

class Edible : Product
{
  public string ExpirationDate;
  public int Kcal;
  public int Protein;
  public int Fats;
  public int Carbohydrates;

  public Edible (string name, string unit, int cost, string expirationDate, int kcal, int protein, int fats, int carbohydrates) 
  : base(name, unit, cost)
  {
    this.ExpirationDate = expirationDate;
    this.Kcal = kcal;
    this.Protein = protein;
    this.Fats = fats;
    this.Carbohydrates = carbohydrates;
  }
    
    public override void Print(){
        Console.WriteLine(
            "Edible{" +
            $"Name={Name}, " +
            $"Unit={Unit}, " +
            $"Cost={Cost}, " +
            $"ExpirationDate={ExpirationDate}, " + 
            $"Kcal={Kcal}, " + 
            $"Protein={Protein}, " +
            $"Fats={Fats}, " +
            $"Carbohydrates={Carbohydrates}, " + 
            "}"
            );
    }
    
}

class BuildResource : Product{
    public string ResourceType;
    
    public BuildResource(string name, string unit, int cost, string resourceType)
    :base(name, unit, cost)
    {
        this.ResourceType = resourceType;
    }
    
    public override void Print(){
        Console.WriteLine(
            "BuildResource{" +
            $"Name={Name}, " +
            $"Unit={Unit}, " +
            $"Cost={Cost}, " +
            $"ResourceType = {ResourceType}" +
            "}"
            );
    }
}

class HelloWorld
{
  static void Main ()
  {
    Edible[] edibles = new Edible[]{
        new Edible("Milk", "л", 60, "21.10.2020", 1, 23, 18, 19),
        new Edible("Bread", "шт", 23, "24.08.2019", 2, 64, 12, 34),
        new Edible("Apple", "кг", 40, "10.12.2000", 3, 23, 18, 19)
    };
    
    BuildResource[] builds = new BuildResource[]{
        new BuildResource("Доски", "м^2", 50, "Дуб"),
        new BuildResource("Кирпичи", "шт", 50, "Глина"),
        new BuildResource("Клей", "л", 50, "Сопли")
    };
    
    foreach(var i in edibles) i.Print();
    foreach(var i in builds) i.Print();
    
  }
}
