namespace ECSModern;

public class Windows : IWindows
{
	public void Open()
	{
		Console.WriteLine("Window is open!");
	}

	public void Close()
	{
		Console.WriteLine("Window is closed!");
	}
}