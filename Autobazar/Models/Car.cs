using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Autobazar.Models;

public class Car
{
    public int Id { get; set; }

    [Display(Name = "Značka")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Značka musí mít alspoň 3 znaky.")]
    [Required(ErrorMessage = "Zadjete značku.")]
    public string? Manufacturer { get; set; }

    [Display(Name = "Model")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Model musí mít alspoň 3 znaky.")]
    [Required(ErrorMessage = "Zadejte Model.")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Zadejte rok výroby.")]
    [Display(Name = "Rok Výroby")]
    [DataType(DataType.Date, ErrorMessage = "Zadejte platný rok výroby.")]
    public DateTime ManufacturingDate { get; set; }

    [Required(ErrorMessage = "Zadejte najeté kilometry.")]
    [Display(Name = "Najeto Km")]
    [Range(0, 1000000, ErrorMessage = "Zadejte platný rozsah.")]
    public int Tachometer { get; set; }

    [Display(Name = "Palivo")]
    [Required]
    public Fuel Fuels { get; set; }

    [Display(Name = "Karosérie")]
    [Required]
    public Body Bodies { get; set; }

    [Display(Name = "Státní poznávací značka")]
    [Remote(action: "VerifySpz", controller: "Cars", AdditionalFields = "Id")]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "Neplatná značka.")]
    [Required(ErrorMessage = "Zadejte státní poznávací značku.")]
    public string? Spz {get; set; }

    [Display(Name = "Stav")]
    [Required]
    public Condition Conditions { get; set; }

    [Required(ErrorMessage = "Zadejte rok od kdy je auto v bazaru.")]
    [Display(Name = "V bazaru od")]
    [DataType(DataType.Date, ErrorMessage = "Špatně zadaný rok.")]
    public DateTime InBazarFrom { get; set; }

    [Display(Name = "Podrobnější informace")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Zadejte alspoň 10 znaků.")]
    [Required(ErrorMessage = "Zadejte popis vozu.")]
    public string? Note { get; set; }

}
