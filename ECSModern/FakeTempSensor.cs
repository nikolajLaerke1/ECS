using System;

namespace ECSModern;


internal class FakeTempSensor : ITempSensor
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