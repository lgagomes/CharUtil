namespace CharUtil
{
    public class Ranger : Spellcaster
    {
        public Ranger(string classname)
        {
            ClassName = classname.ToLower();
            MaxSpellCycle = 5;
            FirstDC = 1;
            KeyAttribute = "Wisdom";
            CombatantType = 1;
			SkillClassModifier = 4;
        }
    }
}
