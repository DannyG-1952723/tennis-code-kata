namespace Tennis;

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

    public void IncrementPoints(int player)
    {
        if (player == 1)
            _player1Points = _player1Points.Increment(_player2Points);
        else
            _player2Points = _player2Points.Increment(_player1Points);
    }

    public bool HasAdvantage(int player)
    {
        if (player == 1)
            return _player1Points == Points.Advantage;

        return _player2Points == Points.Advantage;
    }
}
