using System;

namespace ECSModern;


public class FakeTempSensor : ITempSensor
{
    public int fakeTemp { get; set; } = 10;

    public int GetTemp()
    {
        return fakeTemp;
    }

    public bool RunSelfTest()
    {
        return true;
    }
}