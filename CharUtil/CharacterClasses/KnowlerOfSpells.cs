using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace CharUtil
{
    public class KnowlerOfSpells : Spellcaster
    {
        public int[,] KnownSpells = new int[20, 10];

        public void UpdateKnownSpells()
        {
            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(ClassName + "_known_spells.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                int value;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < MaxSpellCycle; j++)
                    {
                        int.TryParse(ds.Tables[0].Rows[i].ItemArray[j].ToString(), out value);
                        KnownSpells[i, j] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
