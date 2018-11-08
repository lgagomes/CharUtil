namespace CharUtil
{
    public class BaseClass
    {
        #region Attributes

        public string ClassName { get; set; }
        public int CharacterLevel { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public int Strenght { get; set; }
        public int Wisdom { get; set; }      

        #endregion

        #region Methods

        public int GetModifier(int attributeScore)
        {
            if (attributeScore > 0)
                return (attributeScore - 10) / 2;
            else
                return 0;
        }

        #endregion
    }
}