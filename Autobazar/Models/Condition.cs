using System.ComponentModel.DataAnnotations;

namespace Autobazar.Models;

public enum Condition
{
    [Display(Name = "Dobrý")]
    Good,

    [Display(Name = "Špatný")]
    Bad
}
