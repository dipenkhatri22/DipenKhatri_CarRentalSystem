using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int CarId { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public decimal RentalPrice { get; set; }

    public bool IsAvailable { get; set; } = true;
}
