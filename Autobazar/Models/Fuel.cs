using System.ComponentModel.DataAnnotations;

namespace Autobazar.Models;

public enum Fuel
{
    [Display(Name = "Benzín")]
    Petrol,

    [Display(Name = "Nafta")]
    Diesel,

    [Display(Name = "Elektřina")]
    Electricity,

    [Display(Name = "Plyn")]
    Gas
}
