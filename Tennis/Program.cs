using Tennis;

IInput? input = null;

// No input specified --> default, which is console input
if (args.Length == 0)
    input = new ConsoleInput();
else if (args.Length > 0 && args[0] == "console")
    input = new ConsoleInput();
else if (args.Length > 0 && args[0] == "random")
    input = new RandomInput();
else
{
    Console.WriteLine("Unknown input method. Input should be 'console', 'random' or left empty to default to 'console'");
    Environment.Exit(-1);
}

TennisGame tennis = new TennisGame(input: input);
tennis.Start();
