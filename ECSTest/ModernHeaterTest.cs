using NUnit.Framework;
using ECS = ECS.Legacy.ECS;
using ECSModern;
using NSubstitute;

namespace ECSTest;

public class Tests
{
	private ECSModern.ECS _uut;
    private ITempSensor _fakeTempSensor;
    private IHeater _fakeHeater;
    private IWindows _fakeWindows;

	[SetUp]
	public void Setup()
    {
        _fakeTempSensor = Substitute.For<ITempSensor>();
        _fakeHeater = Substitute.For<IHeater>();
        _fakeWindows = Substitute.For<IWindows>();

        _uut = new ECSModern.ECS(15, _fakeTempSensor, _fakeHeater, _fakeWindows);
	}

    [Test]
    public void ECSRegulate_Temp10Thr15_TurnOnCount1()
    {
        _fakeTempSensor.GetTemp().Returns(10);
        _uut.Regulate();
        _fakeHeater.Received(1).TurnOn();
        _fakeHeater.DidNotReceive().TurnOff();
        _fakeWindows.Received(1).Close();
        _fakeWindows.DidNotReceive().Open();
    }

    [Test]
    public void ECSRegulate_Temp20Thr15_TurnOffCount1()
    {
        _fakeTempSensor.GetTemp().Returns(20);
        _uut.Regulate();

        _fakeHeater.Received(1).TurnOff();
        _fakeHeater.DidNotReceive().TurnOn();
        _fakeWindows.Received(1).Open();
        _fakeWindows.DidNotReceive().Close();
    }

    [Test]
    public void ECSRegulate_Temp15Thr15_TurnOffCount1()
    {
        _fakeTempSensor.GetTemp().Returns(15);
        _uut.Regulate();

        _fakeHeater.Received(1).TurnOff();
        _fakeHeater.DidNotReceive().TurnOn();
        _fakeWindows.Received(1).Open();
        _fakeWindows.DidNotReceive().Close();
    }

    [Test]
    public void ECSGetTemp_Temp15_15()
    {
        _fakeTempSensor.GetTemp().Returns(15);

        Assert.That(_uut.GetCurTemp(),Is.EqualTo(15));
    }


    [Test]
    public void ecsrunselftests_true()
    {
        Assert.That(_uut.RunSelfTest, Is.True);
    }

}