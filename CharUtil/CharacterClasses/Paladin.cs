namespace CharUtil
{
    public class Paladin : Spellcaster
    {
        public Paladin(string classname)
        {
            ClassName = classname.ToLower();
            MaxSpellCycle = 5;
            FirstDC = 1;
            KeyAttribute = "Charisma";
        }
    }
}
