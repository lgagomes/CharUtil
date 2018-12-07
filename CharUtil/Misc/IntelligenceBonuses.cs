namespace CharUtil
{
    public class IntelligenceBonuses
    {
        /* if the player decides to put the attribute bonuses gained in levels
         * 4,8,12,16 and 20 into intelligence, these choices are stoed here */

        public bool IntBonus4thLevel { get; set; }
        public bool IntBonus8thLevel { get; set; }
        public bool IntBonus12thLevel { get; set; }
        public bool IntBonus16thLevel { get; set; }
        public bool IntBonus20thLevel { get; set; }

        public int IntBonus4thLevelValue { get; set; }
        public int IntBonus8thLevelValue { get; set; }
        public int IntBonus12thLevelValue { get; set; }
        public int IntBonus16thLevelValue { get; set; }
        public int IntBonus20thLevelValue { get; set; }
    }
}
