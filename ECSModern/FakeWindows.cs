namespace ECSModern;

public class FakeWindows : IWindows
{
	public int WindowOpenCount { get; set; }
	public int WindowCloseCount { get; set; }

	public void Open()
	{
		WindowOpenCount++;
		Console.WriteLine("Window is open!");
	}

	public void Close()
	{
		WindowCloseCount++;
		Console.WriteLine("Window is closed!");
	}
}