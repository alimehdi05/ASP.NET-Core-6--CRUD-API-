﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models;

public class Category
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1,100,ErrorMessage ="Please enter order between 1 and 100")]
    public int DisplayOrder { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;



}
