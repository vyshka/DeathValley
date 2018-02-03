using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathValley.DAL.Entities
{
    public class CacheData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CacheDataId { get; set; }

        public double PointX { get; set; }

        public double PointY { get; set; }
        public virtual Param Param { get; set; }
    }
}
