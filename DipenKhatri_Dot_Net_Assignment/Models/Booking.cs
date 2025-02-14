using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    [ForeignKey("Car")]
    public int CarId { get; set; }
    public Car Car { get; set; }

    [Required]
    [ForeignKey("ApplicationUser")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }
}
