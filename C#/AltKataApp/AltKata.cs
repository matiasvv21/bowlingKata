using System.Collections.Generic;
namespace AltKata;

public class BowlingGame
{
    List<int> rolls = new();
    readonly string mode;
    public BowlingGame(string mode = "Classic") { this.mode = mode; }

    public void Roll(int[] pins) { foreach (var p in pins) { Roll(p); } }

    public void Roll(int pins) { rolls.Add(pins); }

    private bool IsStrike(int idx) => rolls[idx] == 10;
    private bool IsSpare(int i) => rolls[i] + rolls[i + 1] == 10;

    public int Score()
    {
        int s = 0; int rIdx = 0;
        for (int f = 0; f < 10; f++)
        {
            if (IsStrike(rIdx))
            {
                if (f == 9)
                {
                    s += rolls[rIdx + 1] + rolls[rIdx + 2] + (rolls?[rIdx] ?? 0);
                }
                if (f < 9)
                {
                    s += 5 + rolls[rIdx + 1] + rolls[rIdx + 2];
                    if (mode == "Classic")
                    {
                        s += 5;
                    }
                }
                rIdx += 1;
            }
            else if (IsSpare(rIdx))
            {
                s += 10 + rolls[rIdx + 2];
                rIdx += 2;
            }
            else { s += rolls[rIdx] + rolls[rIdx + 1]; rIdx += 2; }
        }
        return s;
    }
}