using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Models;

public class Property
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome da propriedade é obrigatório.")]
    [StringLength(150, ErrorMessage = "O nome pode ter no máximo 150 caracteres.")]
    [Display(Name = "Nome da Propriedade")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O preço por noite é obrigatório.")]
    [Display(Name = "Preço diária")]
    public decimal PricePerNight { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
}