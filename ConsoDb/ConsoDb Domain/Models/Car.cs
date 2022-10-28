namespace ConsoDb;

public class Car
{

    private Car()
    {
        Id = Guid.NewGuid().ToString();
    }


    public Car(string brand, string model) : this()
    {
        Brand = brand;
        Model = model;
    }

    public string Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}