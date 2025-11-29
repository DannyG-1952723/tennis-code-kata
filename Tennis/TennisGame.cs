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
}