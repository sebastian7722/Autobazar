using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Autobazar.Models;

public class Car
{
    public int Id { get; set; }

    [StringLength(10, MinimumLength = 3)]
    [Required]
    public string? Manufacturer { get; set; }

    [StringLength(10, MinimumLength = 3)]
    [Required]
    public string? Model { get; set; }

    [DataType(DataType.Date)]
    public DateTime ManufacturingDate { get; set; }

    public int Tachometer { get; set; }

    [Required]
    public Fuel Fuels { get; set; }

    [Required]
    public Body Bodies { get; set; }

    [Remote(action: "VerifySpz", controller: "Cars", AdditionalFields = "Id")]
    [StringLength(7, MinimumLength = 7)]
    [Required]
    public string? Spz {get; set; }

    [Required]
    public Condition Conditions { get; set; }

    [DataType(DataType.Date)]
    public DateTime InBazarFrom { get; set; }

    [StringLength(500, MinimumLength = 10)]
    [Required]
    public string? Note { get; set; }

}
