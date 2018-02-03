
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

        private readonly List<Points> _points;
        public Function(ParamDTO param)
        {
            _param = param;
            _points = new List<Points>();
        }

        public List<Points> Calculate() //если есть готовые ретурнить их
        {
            for (double x = _param.RangeFrom; x <= _param.RangeTo; x += _param.Step)
            {
                double y = _param.CoefficientA * Math.Pow(x, 2) + _param.CoefficientB * x + _param.CoefficientC;
                Points temp = new Points(x, y);
                _points.Add(temp);
            }

            return _points;
        }
    }
}
