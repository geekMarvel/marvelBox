using System;
using System.Collections.Generic;
namespace PetShop.Models.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int AnimalId { get; set; }

    public string? Text { get; set; }

    //public virtual Animal Animal { get; set; } = null!;
}
