using NUnit.Framework;
using ECS = ECS.Legacy.ECS;
using ECSModern;

namespace ECSTest;

public class Tests
{
	private ECSModern.ECS _uut;
    private FakeTempSensor _fakeTempSensor;
    private FakeHeater _fakeHeater;
    private FakeWindows _fakeWindows;

	[SetUp]
	public void Setup()
    {
        _fakeTempSensor = new();
        _fakeHeater = new();
        _fakeWindows = new();

        _uut = new ECSModern.ECS(15, _fakeTempSensor, _fakeHeater, _fakeWindows);
	}

    [Test]
    public void ECSRegulate_Temp10Thr15_TurnOnCount1()
    {
        _fakeTempSensor.fakeTemp = 10;
        _uut.Regulate();

        Assert.That(_fakeHeater.TurnOnCount, Is.EqualTo(1));
        Assert.That(_fakeHeater.TurnOffCount, Is.EqualTo(0));
    }

    [Test]
    public void ECSRegulate_Temp20Thr15_TurnOffCount1()
    {
        _fakeTempSensor.fakeTemp = 20;
        _uut.Regulate();

        Assert.That(_fakeHeater.TurnOnCount, Is.EqualTo(0));
        Assert.That(_fakeHeater.TurnOffCount, Is.EqualTo(1));
    }

    [Test]
    public void ECSRegulate_Temp15Thr15_TurnOffCount1()
    {
        _fakeTempSensor.fakeTemp = 15;
        _uut.Regulate();

        Assert.That(_fakeHeater.TurnOnCount, Is.EqualTo(0));
        Assert.That(_fakeHeater.TurnOffCount, Is.EqualTo(1));
    }

    [Test]
    public void ECSGetTemp_Temp15_15()
    {
        _fakeTempSensor.fakeTemp = 15;

        Assert.That(_uut.GetCurTemp, Is.EqualTo(_fakeTempSensor.fakeTemp));
    }

    [Test]
    public void ECSRunSelfTests_True()
    {
        Assert.That(_uut.RunSelfTest, Is.True);
    }


}