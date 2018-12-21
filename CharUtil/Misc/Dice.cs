using System;

namespace CharUtil
{
    public class Dice
    {
        public int NumberOfSizes { get; set; }
        private Random randomizer;

        public Dice(int numberOfSizes)
        {
            NumberOfSizes = numberOfSizes;
            randomizer = new Random(DateTime.Now.Millisecond);
        }
        
        public int Roll()
        {
            return randomizer.Next(1, this.NumberOfSizes+1);
        }
    }
}