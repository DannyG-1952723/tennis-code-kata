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

    public TennisGame(Points player1Points = Points.Love, Points player2Points = Points.Love)
    {
        _player1Points = player1Points;
        _player2Points = player2Points;
    }

    public bool IsDeuce()
    {
        return _player1Points == Points.Forty && _player2Points == Points.Forty;
    }

    public void IncrementPoints(Player scoringPlayer)
    {
        if (scoringPlayer == Player.One)
            _player1Points = IncrementPoints(_player1Points, _player2Points);
        else
            _player2Points = IncrementPoints(_player2Points, _player1Points);
    }

    private static Points IncrementPoints(Points scoringPoints, Points opponentPoints)
    {
        if (scoringPoints == Points.Forty && opponentPoints.IsLessThan40())
            return Points.Win;

        return scoringPoints.Increment();
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
}
