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
        {
            if (_player1Points == Points.Forty && _player2Points.IsLessThan40())
                _player1Points = Points.Win;
            else if (HasAdvantage(Player.Two) && _player1Points == Points.Forty)
                _player2Points = Points.Forty;
            else
                _player1Points = _player1Points.Increment();
        }
        else
        {
            if (_player2Points == Points.Forty && _player1Points.IsLessThan40())
                _player2Points = Points.Win;
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
}
