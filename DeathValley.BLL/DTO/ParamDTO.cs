using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathValley.BLL.DTO
{
    public class ParamDTO
    {
        public int ParamId { get; set; }

        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
    }
}
