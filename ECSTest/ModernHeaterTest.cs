using NUnit.Framework;
using ECS = ECS.Legacy.ECS;

namespace ECSTest;

public class Tests
{
	private ECSModern.IHeater _uut;
	[SetUp]
	public void Setup()
	{
		_uut = new ECSModern.Heater();
	}

	[Test]
	public void TestHeater()
	{
		Assert.Pass();
	}
	
	
}