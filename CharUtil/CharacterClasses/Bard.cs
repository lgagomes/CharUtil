namespace CharUtil
{
    public class Bard : KnowlerOfSpells
    {
        public Bard(string classname)
        {
            ClassName = classname.ToLower();            
            MaxSpellCycle = 7;
            FirstDC = 0;
            KeyAttribute = "Charisma";
            CombatantType = 2;
			SkillClassModifier = 6;
        }
    }
}