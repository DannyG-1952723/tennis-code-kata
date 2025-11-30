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
        TennisGame tennis = new TennisGame(init, Points.Love);
        tennis.IncrementPoints(Player.One);

        Assert.AreEqual(shouldWin, tennis.HasWon(Player.One));
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
    [DataRow(Points.Love, Points.Fifteen, Player.One, false)]
    [DataRow(Points.Fifteen, Points.Fifteen, Player.Two, false)]
    [DataRow(Points.Forty, Points.Love, Player.One, false)]
    [DataRow(Points.Forty, Points.Thirty, Player.One, false)]
    [DataRow(Points.Forty, Points.Forty, Player.Two, true)]
    public void HasAdvantage_AfterPoint(Points player1Points, Points player2Points, Player scoringPlayer, bool hasAdvantage)
    {
        TennisGame tennis = new TennisGame(player1Points, player2Points);
        tennis.IncrementPoints(scoringPlayer);

        Assert.AreEqual(hasAdvantage, tennis.HasAdvantage(scoringPlayer));
    }

    [TestMethod]
    [DataRow(Points.Advantage, Points.Forty, Player.One)]
    [DataRow(Points.Forty, Points.Advantage, Player.Two)]
    public void HasWon_AfterAdvantage(Points player1Points, Points player2Points, Player scoringPlayer)
    {
        TennisGame tennis = new TennisGame(player1Points, player2Points);
        tennis.IncrementPoints(scoringPlayer);

        Assert.IsTrue(tennis.HasWon(scoringPlayer));
    }

    [TestMethod]
    [DataRow(Points.Advantage, Points.Forty, Player.Two)]
    [DataRow(Points.Forty, Points.Advantage, Player.One)]
    public void Deuce_AfterAdvantage(Points player1Points, Points player2Points, Player scoringPlayer)
    {
        TennisGame tennis = new TennisGame(player1Points, player2Points);
        tennis.IncrementPoints(scoringPlayer);

        Assert.IsTrue(tennis.IsDeuce());
    }
}
