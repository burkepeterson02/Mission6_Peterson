using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mission6_Peterson.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Rating { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be at least 1888.")]
        public int Year { get; set; }

        [Required]
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
        public string? Director { get; set; }

    }
}
