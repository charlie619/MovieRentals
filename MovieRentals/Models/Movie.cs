using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentals.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name ="Genre")]
        [Required]
        public byte GenreTypeId { get; set; }    
        public GenreType  GenreType { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,20)]
        public byte NoInStock { get; set; }

        public byte NoAvailable { get; set; }
    }
}