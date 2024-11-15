using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string BookName { get; init; }
        [Required(ErrorMessage ="Title is required field")]
        [Range(10, 1000)]
        public decimal Price { get; init; }
    }
}
