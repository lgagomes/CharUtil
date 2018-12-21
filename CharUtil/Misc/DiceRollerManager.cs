using System;
using System.Collections.Generic;
using System.Linq;

namespace CharUtil
{
    public class DiceRollerManager
    {
        public List<int> Rolls { get; private set; }
        public int TotalRolledValues { get; private set; }
        public int NumberOfRolls { get; set; }
        public int NumberOfDiceFaces { get; set; }
        public int Modifier { get; set; } = 0;
        public bool AddEachRoll { get; set; }
        private Dice Dice { get; set; }

        public void AccumulateValues()
        {
            TotalRolledValues = 0;
            Dice = new Dice(NumberOfDiceFaces);
            Rolls = new List<int>();

            int rolledValue;
            for (int i = 0; i < NumberOfRolls; i++)
            {
                rolledValue = Dice.Roll();
                Rolls.Add(rolledValue);
            }

            TotalRolledValues = Rolls.Sum();

            /* if "addEachRoll" is true, "modifier" is added on each roll separately, or in this case, we just 
             * get "modifier * numberOfRolls", which has the same effect
             * 
             * if "addEachRoll" is false, "modifier" is added only after all rolls are obtained */
            if (!AddEachRoll)
                TotalRolledValues += Modifier;
            else
                TotalRolledValues += (Modifier * NumberOfRolls);

            CheckNegativeRolledValues();
        }

        // In case of a negative modifier, the total rolled must be at least 1
        private void CheckNegativeRolledValues()
        {
            if (TotalRolledValues < 0)
                TotalRolledValues = 1;
        }
    }
}
