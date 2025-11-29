namespace Tennis.Tests;

[TestClass]
public sealed class TennisTests
{
    [TestMethod]
    [DataRow(Points.Love, Points.Fifteen)]
    [DataRow(Points.Fifteen, Points.Thirty)]
    [DataRow(Points.Thirty, Points.Forty)]
    public void IncrementPoints_BasePoints(Points init, Points expected)
    {
        Points points = init.Increment(Points.Love);

        Assert.AreEqual(expected, points);
    }

    [TestMethod]
    [DataRow(Points.Love, false)]
    [DataRow(Points.Fifteen, false)]
    [DataRow(Points.Thirty, false)]
    [DataRow(Points.Forty, true)]
    public void HasWon_AfterPoint(Points init, bool shouldWin)
    {
        Points points = init.Increment(Points.Love);

        Assert.AreEqual(shouldWin, points.HasWon());
    }

    [TestMethod]
    [DataRow(Points.Love, Points.Fifteen, false)]
    [DataRow(Points.Fifteen, Points.Fifteen, false)]
    [DataRow(Points.Thirty, Points.Love, false)]
    [DataRow(Points.Forty, Points.Thirty, false)]
    [DataRow(Points.Forty, Points.Forty, true)]
    public void IsDeuce(Points player1Points, Points player2Points, bool isDeuce)
    {
        TennisGame tennis = new TennisGame(player1Points, player2Points);

        Assert.AreEqual(isDeuce, tennis.IsDeuce());
    }

    [TestMethod]
    [DataRow(Points.Love, Points.Fifteen, 1, false)]
    [DataRow(Points.Fifteen, Points.Fifteen, 2, false)]
    [DataRow(Points.Forty, Points.Love, 1, false)]
    [DataRow(Points.Forty, Points.Thirty, 1, false)]
    [DataRow(Points.Forty, Points.Forty, 2, true)]
    public void HasAdvantage_AfterPoint(Points player1Points, Points player2Points, int scoringPlayer, bool hasAdvantage)
    {
        TennisGame tennis = new TennisGame(player1Points, player2Points);
        tennis.IncrementPoints(scoringPlayer);

        Assert.AreEqual(hasAdvantage, tennis.HasAdvantage(scoringPlayer));
    }
}
