using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace CharUtil
{
    public class Spellcaster : BaseClass
    {
        #region Attributes
        
        public int MaxSpellCycle { get; set; }
        public string KeyAttribute { get; set; }
        public decimal KeyAttributeModifier { get; set; }
        public int[] SpellsDC { get; set; }
        public decimal[] ExtraSpells { get; set; }
        public int[,] DailySpells { get; set; }
        public int FirstDC { get; set; }

        #endregion

        #region Methods

        public Spellcaster()
        {
            SpellsDC = new int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            ExtraSpells = new decimal[10] {0, -1, -1, -1, -1, -1, -1, -1, -1, -1 }; ;
            DailySpells = new int[20, 10];
            KeyAttributeModifier = 0;
            InitializeDailySpells();
        }

        public void InitializeDailySpells()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                    DailySpells[i, j] = -1;
        }

        public void UpdateSpellsPerDay()
        {
            try
            {
                
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(ClassName + "_daily_spells.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                int value;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < MaxSpellCycle; j++)
                    {
                        int.TryParse(ds.Tables[0].Rows[i].ItemArray[j].ToString(), out value);
                        DailySpells[i, j] = value;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void UpdateExtraSpells()
        {
            for (int i = 1; i < MaxSpellCycle; i++)
                ExtraSpells[i] = Math.Ceiling((KeyAttributeModifier - (i - 1)) / 4);
        }

        public void UpdateSpellsDC()
        {
            for (int i = FirstDC; i < MaxSpellCycle; i++)
                SpellsDC[i] = 10 + (int)KeyAttributeModifier + i;
        }
        
        public void CastSpell(int charLevel, int spellCycle)
        {
            if (DailySpells[charLevel - 1, spellCycle] > 0)
                DailySpells[charLevel - 1, spellCycle]--;
            else // just in case
                MessageBox.Show("You don't have enough spells slots or don't have access to this spell cycle yet",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }
}
