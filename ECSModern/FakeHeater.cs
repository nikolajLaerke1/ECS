using ECSModern;

namespace ECS.Legacy
{
    public class FakeHeater : IHeater
    {
        public string TurnOnString { get; set; } = "Heater is on";
        public string TurnOffString { get; set; } = "Heater is off";

        public void TurnOn()
        {
            System.Console.WriteLine(TurnOnString);
        }

        public void TurnOff()
        {
            System.Console.WriteLine(TurnOffString);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}