namespace Tennis;

public interface IInput
{
    string? ReadLine();
}

public class ConsoleInput : IInput
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}

public class TestInput : IInput
{
    private Queue<string> _inputs;

    public TestInput(string[] inputs)
    {
        _inputs = new Queue<string>(inputs);
    }

    public string? ReadLine()
    {
        return _inputs.Count > 0 ? _inputs.Dequeue() : null;
    }
}
