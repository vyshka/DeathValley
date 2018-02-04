
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathValley.BLL.DTO;

namespace DeathValley.BLL.BusinessModels
{
    public class Function
    {
        private readonly ParamDTO _param;

        private readonly List<CacheDataDTO> _points;
        public Function(ParamDTO param)
        {
            _param = param;
            _points = new List<CacheDataDTO>();
        }

        public List<CacheDataDTO> Calculate() 
        {
            for (double x = _param.RangeFrom; x <= _param.RangeTo; x += _param.Step)
            {
                double y = _param.CoefficientA * Math.Pow(x, 2) + _param.CoefficientB * x + _param.CoefficientC;
                CacheDataDTO temp = new CacheDataDTO(x, y, _param.ParamId);
                _points.Add(temp);
            }

            return _points;
        }
    }
}
