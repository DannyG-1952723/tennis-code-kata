namespace Tennis;

public enum Player
{
    One,
    Two
}

public class TennisGame
{
    private Points _player1Points;
    private Points _player2Points;
    private readonly IInput _input;

    public TennisGame(Points player1Points = Points.Love, Points player2Points = Points.Love, IInput? input = null)
    {
        _player1Points = player1Points;
        _player2Points = player2Points;

        _input = input ?? new ConsoleInput();
    }

    public bool IsDeuce()
    {
        return _player1Points == Points.Forty && _player2Points == Points.Forty;
    }

    public void IncrementPoints(Player scoringPlayer)
    {
        if (scoringPlayer == Player.One)
        {
            // Skip advantage when the opponent has less than 40
            if (_player1Points == Points.Forty && _player2Points.IsLessThan40())
                _player1Points = Points.Win;
            // Set the points back to deuce when the opponent had advantage
            else if (HasAdvantage(Player.Two) && _player1Points == Points.Forty)
                _player2Points = Points.Forty;
            else
                _player1Points = _player1Points.Increment();
        }
        else
        {
            // Skip advantage when the opponent has less than 40
            if (_player2Points == Points.Forty && _player1Points.IsLessThan40())
                _player2Points = Points.Win;
            // Set the points back to deuce when the opponent had advantage
            else if (HasAdvantage(Player.One) && _player2Points == Points.Forty)
                _player1Points = Points.Forty;
            else
                _player2Points = _player2Points.Increment();
        }
    }

    public bool HasAdvantage(Player player)
    {
        if (player == Player.One)
            return _player1Points == Points.Advantage;

        return _player2Points == Points.Advantage;
    }

    public bool HasWon(Player player)
    {
        if (player == Player.One)
            return _player1Points.HasWon();

        return _player2Points.HasWon();
    }

    public void Start()
    {
        do
        {
            Player? scoringPlayer = GetPlayerFromInput();

            // No more input to play the game, so end it
            if (scoringPlayer == null)
                return;

            IncrementPoints(scoringPlayer.Value);
            DisplayScore(scoringPlayer.Value);
        } while (!HasWon(Player.One) && !HasWon(Player.Two));
    }

    private Player? GetPlayerFromInput()
    {
        Console.WriteLine("Choose the player that gets a point by entering '1' or '2'");

        string? input;

        while ((input = _input.ReadLine()) != null)
        {
            string playerString = input.Trim();

            if (playerString == "1" || playerString == "2")
                return playerString == "1" ? Player.One : Player.Two;

            Console.WriteLine("\nInvalid input. Enter '1' or '2' (without quotes)");
        }

        // Only happens when there will be no more input
        return null;
    }

    private void DisplayScore(Player scoringPlayer)
    {
        string player = scoringPlayer == Player.One ? "Player 1" : "Player 2";
        string deuce = IsDeuce() ? " (Deuce)" : "";

        Console.WriteLine($"\nPoint to {player}");

        if (HasWon(scoringPlayer))
            Console.WriteLine($"{player} won!");
        else
            Console.WriteLine($"Score: {_player1Points.ToCustomString()} - {_player2Points.ToCustomString()}{deuce}\n");
    }
}
