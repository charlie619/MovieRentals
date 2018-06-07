using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentals.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreTypeDto GenreType { get; set; }
        [Required]
        public byte GenreTypeId { get; set; }       
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
              
        [Range(1, 20)]
        public byte NoInStock { get; set; }
        public byte NoAvailable { get; set; }
    }
}