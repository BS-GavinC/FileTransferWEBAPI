using System.ComponentModel.DataAnnotations;
using ConsoDb;

namespace ConsoDb_Domain;

public class CarCreateDTO
{
    [Required]
    public string Brand { get; set; }
    
    [Required]
    public string Model { get; set; }

    
    
    public Car ToCar()
    {
        return new Car(Brand, Model);
    }
}