using ECSModern;
using ECS.Legacy;
using System;

namespace ECSModern
{
    public class ECS
    {
        public int _threshold { get; set; }
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, ITempSensor tempSensor, IHeater heater)
        {
            _threshold = thr;
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
