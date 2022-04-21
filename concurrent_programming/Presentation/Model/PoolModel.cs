using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class PoolModel
    {
        public PoolModel(double canvasWidth, double canvasHeight, PoolAbstractAPI? poolAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            PoolAPI = poolAPI ?? PoolAbstractAPI.CreateLayer();
        }

        public ObservableCollection<Circle> GetStartingCirclePositions(int circleCount)
        {
            Animating = true;
            return PoolAPI.CreateCircles(_canvasWidth, _canvasHeight, circleCount);
        }

        public ObservableCollection<Circle> MoveCircle(ObservableCollection<Circle> circles)
        {
            return PoolAPI.UpdateCirlcePosition(_canvasWidth, _canvasHeight, circles);
        }

        private bool _animating;

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

        private readonly double _canvasWidth;

        private readonly double _canvasHeight;

        private readonly PoolAbstractAPI? PoolAPI = default;
    }
}
