using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.DTO
{
    public class ChordInputDto
    {
        [RegularExpression(@"^[A-G](b|#)?((m(aj|in)?|M|aug|dim|sus)?([2-7]|9|13)?)?(\/[A-G](b|#)?)?$", ErrorMessage = "You did not enter a correctly formatted chord")]
        [Required]
        public string Name { get; set; }
    }
}
