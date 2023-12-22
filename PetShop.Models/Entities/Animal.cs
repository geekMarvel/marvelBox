using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Entities;

public partial class Animal
{
    public int AnimalId { get; set; }
    [Required]
    [DisplayName("Animal Name")]
    [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "The value must contain only letters and spaces.")]
    public string Name { get; set; } = null!;
    [Required]
    [RegularExpression("^[1-9]\\d*$", ErrorMessage = "The value must be a positive whole number.")]
    public int? Lifespan { get; set; }
    [Required]
    [DisplayName("Picture Name")]
    public string? PhotoUrl { get; set; }
    [Required]
    public string? Description { get; set; }  

    public int CategoryId { get; set; }
    [NotMapped]
    public int CommentCount { get; set; }
    //[NotMapped]
    //public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment>? Comments { get; set; } 
}
