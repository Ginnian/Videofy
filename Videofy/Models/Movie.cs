using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videofy.Models
{
    public class Movie
    {
        public int Id { get; set; } //Primary key

        [StringLength(60, MinimumLength = 3)] //Maximum char 3 < x < 60
        [Required]              //Field must have a value
        public string Title { get; set; } //Title of movie.

        [Display(Name = "Release Date")] //Format name that appears as a label
        [DataType(DataType.Date)]       //Check input is type date.
        public DateTime ReleaseDate { get; set; } //Set or get the release date.

        [Range(1, 100)] //price must be between $1 and $100
        [DataType(DataType.Currency)] //Format input to currency data type
        [Column(TypeName = "decimal(18, 2)")] //Round decimal to 2 places
        public decimal Price { get; set; } //Get or set price of movie

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] //Prevent unvalidated characters
        [Required]  //Field must have a genre
        [StringLength(30)] //Genre must be maximum 30 characters
        public string Genre { get; set; } //Get or set movie genre
    }

}
