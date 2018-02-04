using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathValley.BLL.DTO
{
    public class CacheDataDTO
    {
        public int CacheDataId { get; set; }

        public double PointX { get; set; }

        public double PointY { get; set; }
        public int ParamId { get; set; }

        public CacheDataDTO(double x, double y, int id)
        {
            PointX = x;
            PointY = y;
            ParamId = id;
        }
    }
}
