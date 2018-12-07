using System;

namespace CharUtil
{
    public class BaseClass
    {
        #region Attributes

        public string ClassName { get; set; }
        public int CharacterLevel { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public double[] BaseAttackBonus { get; set; }
        public int CombatantType { get; set; }		
		public int SkillClassModifier { get; set; } // how much each class adds to skill points calculations
		public SkillPointsCalculator SkillPointsCalculator;       
        
        /*
         * Combatant types:
         *  1 = Full combatants: barbarians, warriors, paladins, rangers
         *  2 = Semi-combatants: bards, clerics, druids, rogues, monks
         *  3 = Non-combatants: sorcerers, wizards         * 
         */

        #endregion

        #region Methods

        public BaseClass()
        {
            BaseAttackBonus = new double[4];
        }

        public void CalculateBaseAttackBonus()
        {
            double progression;     // defines the progression growth of the 1st attack
            int[] attackThresholds; // attackThresholds[0] defines when the class gains the 2nd extra attack
                                    // attackThresholds[1] defines when the class gains the 3rd extra attack (if available)
                                    // attackThresholds[2] defines when the class gains the 4th extra attack (if available)             

            switch (CombatantType)
            {
                case 1:
                    progression = 1;
                    attackThresholds = new int[] { 5, 10, 15 };
                    break;

                case 2:
                    progression = 0.75;
                    attackThresholds = new int[] { 8, 14, 20 };
                    break;

                case 3:
                    progression = 0.5;
                    attackThresholds = new int[] { 11, 20, 20 };
                    break;

                default:
                    progression = 0;
                    attackThresholds = new int[] { 0, 0, 0 };
                    break;
            }

            BaseAttackBonus[0] = Math.Floor(CharacterLevel * progression);

            for (int i = 0; i < attackThresholds.Length; i++)
            {
                if (CharacterLevel - attackThresholds[i] > 0)
                    BaseAttackBonus[i + 1] = BaseAttackBonus[i] - 5;
                else
                    BaseAttackBonus[i + 1] = 0;
            }
        }

        public int GetModifier(int attributeScore)
        {
            if (attributeScore > 0)
                return (attributeScore - 10) / 2;
            else
                return 0;
        }

		public void UpdateSkillPointsModifiers()
        {
            this.SkillPointsCalculator.IntelligenceBonuses.IntBonus4thLevelValue = this.GetModifier(this.Intelligence + 1);
            this.SkillPointsCalculator.IntelligenceBonuses.IntBonus8thLevelValue = this.GetModifier(this.Intelligence + 2);
            this.SkillPointsCalculator.IntelligenceBonuses.IntBonus12thLevelValue = this.GetModifier(this.Intelligence + 3);
            this.SkillPointsCalculator.IntelligenceBonuses.IntBonus16thLevelValue = this.GetModifier(this.Intelligence + 4);
            this.SkillPointsCalculator.IntelligenceBonuses.IntBonus20thLevelValue = this.GetModifier(this.Intelligence + 5);
        }
		
        #endregion
    }
}