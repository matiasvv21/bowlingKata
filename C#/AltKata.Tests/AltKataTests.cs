using Xunit;
using AltKata;
namespace AltKata.Tests;

public class BowlingGameTests
{
    private BowlingGame g;

    private void RollMany(int rolls, int pins)
    {
        for (int i = 0; i < rolls; i++)
            g.Roll(pins);
    }

    private void RollSpare()
    {
        g.Roll(7);
        g.Roll(3); // 7 + 3 = 10
    }

    private void RollStrike()
    {
        g.Roll(10);
    }

    [Theory]
    [InlineData("Classic")]
    [InlineData("Training")]
    public void TestGutterGame(string mode)
    {
        g = new BowlingGame(mode);
        RollMany(20, 0);
        Assert.Equal(0, g.Score());
    }

    [Theory]
    [InlineData("Classic")]
    [InlineData("Training")]
    public void TestAllOnes(string mode)
    {
        g = new BowlingGame(mode);
        RollMany(20, 1);
        Assert.Equal(20, g.Score());
    }

    [Theory]
    [InlineData("Classic", 18)] // 10 + 4 + 4 extra rolls
    [InlineData("Training", 18)] // same logic
    public void TestOneSpare(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        RollSpare();      // 10
        g.Roll(4);        // +4 bonus
        RollMany(17, 0);  // rest 0
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 28)] // 10 + 4 + 5 = 19 + 9
    [InlineData("Training", 23)] // 5 + 4 + 5 = 14 + 9
    public void TestOneStrike(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        RollStrike();     // 10 or 5
        g.Roll(4);
        g.Roll(5);
        RollMany(16, 0);
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 58)] // 10 + 4 + 5 = 19 + 9
    [InlineData("Training", 38)] // 5 + 4 + 5 = 14 + 9
    public void Test4EvenStrike(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        RollMany(2, 0);  //0 f1
        RollStrike();     // 10 or 5 or 15 + 4     19
        g.Roll(4);        
        g.Roll(0);    //4 + 19  23
        RollStrike();     // 10 or 5 or 15        38
        RollMany(2, 0);

        RollStrike();     // 10 or 5 or 15 + 5   20 + 38 58
        g.Roll(5);
        g.Roll(0);         //63
        RollStrike();     // 10 or 5 or 15   63 + 15 78

        RollMany(4, 0);
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 300)]
    [InlineData("Training", 255)]
    public void TestPerfectGame(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        RollMany(12, 10);
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 131)]
    [InlineData("Training", 121)] // each strike is worth 5 + bonus instead of 10
    public void TestRandomGameNoBonusRolls(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        g.Roll(new int[] { 
            1, 3,
            7, 3,
            10,
            1, 7,
            5, 2,
            5, 3, 
            8, 2, 
            8, 2, 
            10, 
            9, 0 });
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 143)]
    [InlineData("Training", 133)]
    public void TestRandomGameWithSpareThenStrikeAtEnd(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
        Assert.Equal(expectedScore, g.Score());
    }

    [Theory]
    [InlineData("Classic", 163)]
    [InlineData("Training", 153)]
    public void TestRandomGameWithThreeStrikesAtEnd(string mode, int expectedScore)
    {
        g = new BowlingGame(mode);
        g.Roll(new int[] { 
            1, 3,
            7, 3,
            10,
            1, 7,
            5, 2, 
            5, 3, 
            8, 2, 
            8,  2,
            10, 
            10,  10, 10 });
        Assert.Equal(expectedScore, g.Score());
    }


    [Theory]
    [InlineData("Classic", 38)]
    [InlineData("Training", 38)]
    public void SpareInTenthFrame_ShouldGetOneBonusRoll2(string mode, int expectedScore)
    {
        var game = new BowlingGame(mode);
        game.Roll(new int[]
        {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 10
        });
        Assert.Equal(expectedScore, game.Score());
    }

    [Theory]
    [InlineData("Classic", 23)]
    [InlineData("Training", 23)]
    public void NoBonusInTenthFrame_ShouldNotGetExtraRoll2(string mode, int expectedScore)
    {
        var game = new BowlingGame(mode);
        game.Roll(new int[]
        {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 2, 3 // Frame 10: 5 points only
        });
        Assert.Equal(expectedScore, game.Score());
    }
}
