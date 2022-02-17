using ECSModern;

public class FakeHeater : IHeater
{
    public int TurnOnCount = 0;
    public int TurnOffCount = 0;

    public void TurnOn()
    {
        TurnOnCount++;
        Console.WriteLine("Heater is on");
    }

    public void TurnOff()
    {
        TurnOffCount++;
        Console.WriteLine("Heater is off");
    }

    public bool RunSelfTest()
    {
        return true;
    }
}