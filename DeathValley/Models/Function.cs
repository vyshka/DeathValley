using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeathValley.Models
{
    
    public class Function
    {
        private readonly Data _data;

        private readonly List<Points> _points;
        public Function(Data data)
        {
            _data = data;
            _points = new List<Points>();
        }

        public List<Points> Calculate()
        {
            for (double x = _data.RangeFrom; x <= _data.RangeTo; x += _data.Step)
            {
                double y = _data.CoefficientA * Math.Pow(x, 2) + _data.CoefficientB * x + _data.CoefficientC;
                Points temp = new Points(x, y);
                _points.Add(temp);
            }

            return _points;
        }
    }
}