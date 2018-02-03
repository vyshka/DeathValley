using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathValley.DAL.Entities
{
    public class Param
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParamId { get; set; }

        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double  RangeTo { get; set; }
        public virtual ICollection<CacheData> Data { get; set;}
    }
}
