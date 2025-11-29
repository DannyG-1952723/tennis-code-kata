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
        Points points = init.Increment();

        Assert.AreEqual(expected, points);
    }

    [TestMethod]
    [DataRow(Points.Love, false)]
    [DataRow(Points.Fifteen, false)]
    [DataRow(Points.Thirty, false)]
    [DataRow(Points.Forty, true)]
    public void HasWon_AfterPoint(Points init, bool shouldWin)
    {
        Points points = init.Increment();

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
}
