using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a genre.")]
        public byte GenreId { get; set; }
        
        public DateTime? DateAdded { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
        
        public byte? NumberInStock { get; set; }
    }
}