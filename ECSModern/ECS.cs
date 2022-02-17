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
        private readonly IWindows _windows;

        public ECS(int thr, ITempSensor tempSensor, IHeater heater, IWindows windows)
        {
            _threshold = thr;
            _tempSensor = tempSensor;
            _heater = heater;
            _windows = windows;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
            {
                _heater.TurnOn();
                _windows.Close();
                return;
            }  
            
            _heater.TurnOff();
            _windows.Open();
            
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
