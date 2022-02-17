using NUnit.Framework;
using ECS = ECS.Legacy.ECS;
using ECSModern;

namespace ECSTest;

public class Tests
{
	private ECSModern.ECS _uut;
    private FakeTempSensor fakeTempSensor;
    private FakeHeater fakeHeater;

	[SetUp]
	public void Setup()
    {
        fakeTempSensor = new();
        fakeHeater = new();

        _uut = new ECSModern.ECS(15, fakeTempSensor, fakeHeater);
	}

    [Test]
    public void ECSRegulate_Temp10Thr15_TurnOnCount1()
    {
        fakeTempSensor.fakeTemp = 10;
        _uut.Regulate();

        Assert.That(fakeHeater.TurnOnCount, Is.EqualTo(1));
        Assert.That(fakeHeater.TurnOffCount, Is.EqualTo(0));
    }

    [Test]
    public void ECSRegulate_Temp20Thr15_TurnOffCount1()
    {
        fakeTempSensor.fakeTemp = 20;
        _uut.Regulate();

        Assert.That(fakeHeater.TurnOnCount, Is.EqualTo(0));
        Assert.That(fakeHeater.TurnOffCount, Is.EqualTo(1));
    }

    [Test]
    public void ECSRegulate_Temp15Thr15_TurnOffCount1()
    {
        fakeTempSensor.fakeTemp = 15;
        _uut.Regulate();

        Assert.That(fakeHeater.TurnOnCount, Is.EqualTo(0));
        Assert.That(fakeHeater.TurnOffCount, Is.EqualTo(1));
    }

    [Test]
    public void ECSGetTemp_Temp15_15()
    {
        fakeTempSensor.fakeTemp = 15;

        Assert.That(_uut.GetCurTemp, Is.EqualTo(fakeTempSensor.fakeTemp));
    }

    [Test]
    public void ECSRunSelfTests_True()
    {
        Assert.That(_uut.RunSelfTest, Is.True);
    }



}