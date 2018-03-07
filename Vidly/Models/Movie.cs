using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a genre.")]
        [Display(Name = "Select Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }
    }
}