using NUnit.Framework;
using ECS = ECS.Legacy.ECS;

namespace ECSTest;

public class Tests
{
	private ECSModern.ECS _uut;
	[SetUp]
	public void Setup()
	{
		_uut = new ECSModern.ECS(15);
	}

	[Test]
	public void TestHeater() => Assert.That(_uut.RunSelfTest, Is.True);
}