namespace Tennis;

public enum Points
{
    Love = 0,
    Fifteen = 1,
    Thirty = 2,
    Forty = 3,
    Advantage = 4,
    Win = 5
}

public static class PointsExtension
{
    public static Points Increment(this Points points, Points otherPoints)
    {
        if (points == Points.Forty && otherPoints == Points.Forty)
            return Points.Advantage;

        if (points == Points.Forty && otherPoints < Points.Forty)
            return Points.Win;

        return points + 1;
    }

    public static bool HasWon(this Points points)
    {
        return points == Points.Win;
    }
}
