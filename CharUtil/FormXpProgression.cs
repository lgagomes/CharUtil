using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CharUtil
{
    public partial class FormXpProgression : Form
    {
        XpPerLevelHolder xpPerLevelHolder;
        XPCalculator xpCalculatorProgression;
        List<XpPerLevelHolder> levelProgression;

        public FormXpProgression()
        {
            InitializeComponent();

            xpCalculatorProgression = new XPCalculator();

            UpdateLevelProgressionList();
            FillDataGrid();
            VisualFormatDataGrid();
        }

        private void UpdateLevelProgressionList()
        {
            levelProgression = new List<XpPerLevelHolder>();

            for (int i = 1; i <= 20; i++)
            {
                xpPerLevelHolder = new XpPerLevelHolder
                {
                    Level = i,
                    XP = xpCalculatorProgression.CalculateXPByLevel(i)
                };

                levelProgression.Add(xpPerLevelHolder);
            }
        }

        private void FillDataGrid()
        {
            dataGridViewXpProgression.DataSource = levelProgression;
        }

        private void UpdateXpRequired()
        {
            textBoxXpRequired.Text = 
                xpCalculatorProgression.CalculateXPByLevel(Convert.ToInt64(textBoxCharLevel.Text)).ToString();
        }

        private void VisualFormatDataGrid()
        {
            dataGridViewXpProgression.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewXpProgression.Columns[0].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
            dataGridViewXpProgression.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewXpProgression.Columns[1].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCharLevel_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCharLevel.Text != "")
            {
                UpdateXpRequired();
            }
        }

        private void textBoxCharLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
