using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Bikin.Models
{
    public class Services
    {
        public int Id { get; set; }
        
        [Required]
        public string Icon { get; set; }

        [Required]
        [MaxLength(100)]

        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Desc { get; set; }

    }
}
