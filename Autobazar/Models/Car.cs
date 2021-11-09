using System.ComponentModel.DataAnnotations;

namespace Autobazar.Models;

public class Car
{
    public int Id { get; set; }

    [Required]
    public string? Manufacturer { get; set; }

    [Required]
    public string? Model { get; set; }

    [DataType(DataType.Date)]
    public DateTime ManufacturingDate { get; set; }

    public int Tachometer { get; set; }

    [Required]
    public Fuel Fuels { get; set; }

    [Required]
    public Body Bodies { get; set; }

    [Required]
    public string? Spz {get; set; }

    [DataType(DataType.Date)]
    public DateTime InBazarFrom { get; set; }

    [Required]
    public string? Note { get; set; }

}
