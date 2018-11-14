namespace CharUtil
{
    public class Druid : Spellcaster
    {
        public Druid(string classname)
        {
            ClassName = classname.ToLower();
            MaxSpellCycle = 10;
            FirstDC = 0;
            KeyAttribute = "Wisdom";
            CombatantType = 2;
        }
    }
}