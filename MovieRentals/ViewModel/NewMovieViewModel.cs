using MovieRentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentals.ViewModel
{
    public class NewMovieViewModel
    {
        public List<GenreType> GenreTypes { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte? GenreTypeId { get; set; }
        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }        
        
        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NoInStock { get; set; }

        public byte NoAvailable { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";



            }
        }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NoInStock = movie.NoInStock;
            GenreTypeId = movie.GenreTypeId;
            
        }
    }
}