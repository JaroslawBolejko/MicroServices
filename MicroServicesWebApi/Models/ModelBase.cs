namespace MicroServicesWebApi.Models;

public abstract class ModelBase
{
    [Key]
    [Required]
    public int Id { get; set; }
    
}
