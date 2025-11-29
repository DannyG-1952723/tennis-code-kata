namespace Tennis;

public enum Points
{
    Love = 0,
    Fifteen = 1,
    Thirty = 2,
    Forty = 3,
    Win = 4
}

public static class PointsExtension
{
    public static Points Increment(this Points points)
    {
        return points += 1;
    }

    public static bool HasWon(this Points points)
    {
        return points == Points.Win;
    }
}
