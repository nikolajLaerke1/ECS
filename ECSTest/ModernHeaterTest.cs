using NUnit.Framework;
using ECS = ECS.Legacy.ECS;
using ECSModern;
using NSubstitute;

namespace ECSTest;

public class Tests
{
	private ECSModern.ECS _uut;
    private ITempSensor fakeTempSensor;
    private IHeater fakeHeater;

	[SetUp]
	public void Setup()
    {
        fakeTempSensor = Substitute.For<ITempSensor>();
        fakeHeater = Substitute.For<IHeater>();

        _uut = new ECSModern.ECS(15, fakeTempSensor, fakeHeater);
	}

    [TestCase(10, 15, 1, 0)]
    [TestCase(20, 15, 0, 1)]
    [TestCase(15, 10, 0, 1)]
    [TestCase(15, 15, 0, 1)]

    public void ECSRegulate_Temp10Thr15_TurnOnCount1(int Temp, int thr, int turnOnCount, int turnOffCount)
    {
        fakeTempSensor.GetTemp().Returns(Temp);
        _uut._threshold = thr;
        
        _uut.Regulate();

        fakeHeater.Received(turnOnCount).TurnOn();
        fakeHeater.Received(turnOffCount).TurnOff();
    }

    [TestCase(true, true, true)]
    [TestCase(false, true, false)]
    [TestCase(true, false, false)]
    [TestCase(false, false, false)]
    public void ECSRunSelfTests_True(bool tempSensorTest, bool heaterTest, bool result)
    {
        fakeTempSensor.RunSelfTest().Returns(tempSensorTest);
        fakeHeater.RunSelfTest().Returns(heaterTest);

        Assert.That(_uut.RunSelfTest, Is.EqualTo(result));
    }



}