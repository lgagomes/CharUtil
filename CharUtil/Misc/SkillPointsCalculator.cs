using System.Collections.Generic;

namespace CharUtil
{
    public class SkillPointsCalculator
    {
        /*TODO: Think in a better approach for negative intelligence modifiers */

        private int IntelligenceModifier;
        private int ClassModifier;
        private int HumanBonusNextLevels;
        public int SkillPoints { get; private set; }
        public int ClassSkillMaxRanks { get; private set; }
        public double NonClassSkillMaxRanks { get; private set; }
        public IntelligenceBonuses IntelligenceBonuses { get; set; }        

        public SkillPointsCalculator()
        {
            ResetSkillPoints();
            IntelligenceBonuses = new IntelligenceBonuses();
        }

        public void ResetSkillPoints()
        {
            SkillPoints = 0;
        }

        public void CalculateSkillPoints(int level, int intelligenceModifier, int classModifier, bool isHuman)
        {
            IntelligenceModifier = intelligenceModifier;
            ClassModifier = classModifier;
            int humanBonusFirstLevel = isHuman ? 4 : 0; // if is human, gains an additional 4 points in 1st level
            HumanBonusNextLevels = isHuman ? 1 : 0; // and an additional point each level            

            CheckIntelligenceModifiers();

            //1st level
            SkillPoints = ((ClassModifier + IntelligenceModifier) * 4) + humanBonusFirstLevel;

            // subsequent levels
            for (int i = 2; i <= level; i++)
            {
                if (i >= 4 && i <= 7 && IntelligenceBonuses.IntBonus4thLevel)
                    IncrementSkillPoints(IntelligenceBonuses.IntBonus4thLevelValue);

                else if (i >= 8 && i <= 11 && IntelligenceBonuses.IntBonus8thLevel)
                    IncrementSkillPoints(IntelligenceBonuses.IntBonus8thLevelValue);

                else if (i >= 12 && i <= 15 && IntelligenceBonuses.IntBonus12thLevel)
                    IncrementSkillPoints(IntelligenceBonuses.IntBonus12thLevelValue);

                else if (i >= 16 && i <= 19 && IntelligenceBonuses.IntBonus16thLevel)
                    IncrementSkillPoints(IntelligenceBonuses.IntBonus16thLevelValue);

                else if (i == 20 && IntelligenceBonuses.IntBonus20thLevel)
                    IncrementSkillPoints(IntelligenceBonuses.IntBonus20thLevelValue);

                else
                    IncrementSkillPoints();
            }
        }

        private void CheckIntelligenceModifiers()
        {
            List<int> listOfModifiers = new List<int>
            {
                IntelligenceModifier,
                IntelligenceBonuses.IntBonus4thLevelValue,
                IntelligenceBonuses.IntBonus8thLevelValue,
                IntelligenceBonuses.IntBonus12thLevelValue,
                IntelligenceBonuses.IntBonus16thLevelValue,
                IntelligenceBonuses.IntBonus20thLevelValue
            };

            /* By PHB, any character with negative intelligence modifier receives at 
             * least 4 points (1 * 4) in the first level and 1 point in subsequent levels. 
             * By doing the intelligence bonuses used here equals to 'ClassModifier' - 1, 
             * we don't need to write a special case, just reuse the same formula */

            for (int i = 0; i < listOfModifiers.Count; i++)
            {
                if (listOfModifiers[i] < 0)
                    listOfModifiers[i] = ClassModifier - 1;
            }
        }

        // default
        private void IncrementSkillPoints()
        {
            SkillPoints += (ClassModifier + IntelligenceModifier + HumanBonusNextLevels);
        }

        // if additional points where put into intelligence
        private void IncrementSkillPoints(int specialIntelligenceModifier)
        {
            SkillPoints += (ClassModifier + specialIntelligenceModifier + HumanBonusNextLevels);
        }

        public void CalculateSkillRanks(int level)
        {
            ClassSkillMaxRanks = level + 3;
            NonClassSkillMaxRanks = ClassSkillMaxRanks / 2.0;
        }
    }
}
