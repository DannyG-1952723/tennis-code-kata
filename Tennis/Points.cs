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
    public static Points Increment(this Points points)
    {
        return points + 1;
    }

    public static bool HasWon(this Points points)
    {
        return points == Points.Win;
    }

    public static bool IsLessThan40(this Points points)
    {
        return points < Points.Forty;
    }

    // ToString() is a default method on enums, overwriting it still displayed the default ToString() output
    public static string ToCustomString(this Points points)
    {
        return points switch
        {
            Points.Love => "Love",
            Points.Fifteen => "15",
            Points.Thirty => "30",
            Points.Forty => "40",
            Points.Advantage => "Adv.",
            // Points.Win will never be displayed
            _ => ""
        };
    }
}
