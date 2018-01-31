using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Foolproof;

namespace DeathValley.Models
{
    public class Data
    {
        [Required]
        public double CoefA { get; set; }

        [Required]
        public double CoefB { get; set; }

        [Required]
        public double CoefC { get; set; }

        [Required]
        public double RangeFrom { get; set; }

        [Required]
        [GreaterThan("RangeFrom")]
        public double RangeTo { get; set; }

        [Required]
        public double Step { get; set; }


    }
}