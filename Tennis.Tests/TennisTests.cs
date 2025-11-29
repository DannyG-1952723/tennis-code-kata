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
}
