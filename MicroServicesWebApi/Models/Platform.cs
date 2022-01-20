namespace MicroServicesWebApi.Models;

public class Platform : ModelBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public string Cost { get; set; }

}
