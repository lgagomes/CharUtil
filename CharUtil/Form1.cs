using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharUtil
{
    public partial class Form1 : Form
    {
        private List<Spellcaster> spellcasters;
        private List<KnowlerOfSpells> knowlers;
        private List<Label> spellDCs;
        private List<Label> extraSpells;
        private List<Button> castButtons;
        private List<TextBox> knownSpells;
        private TextBox[] spellsPerDay;        
        private Spellcaster character;
        private CasterSelector selector;

        private LoadCalculator loadCalculator;
        private int sizeModifiersCode = 4;
        private TextBox[] carryCapacities;
        private List<Label> unityLabels;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region general initializations

            spellcasters = new List<Spellcaster>();
            knowlers = new List<KnowlerOfSpells>();
            castButtons = new List<Button>();
            loadCalculator = new LoadCalculator();
            unityLabels = new List<Label>();

            InitializeLevels();

            spellDCs = new List<Label>();
            InitializeDCs();

            extraSpells = new List<Label>();
            InitializeExtraSpells();

            spellsPerDay = new TextBox[10];
            InitializeSpellsPerDay();

            knownSpells = new List<TextBox>();
            InitializeKnownSpells();

            carryCapacities = new TextBox[8];
            InitializeCarryCapacities();

            InitializeCastButtons();
            CalculateCarryCapacity();
            InitializeUnityLabels();
            #endregion

            #region initialize all classes
            character = new Spellcaster();
            selector = new CasterSelector();

            Bard bard = new Bard("Bard");
            bard.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            bard.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(bard);
            knowlers.Add(bard);

            Cleric cleric = new Cleric("Cleric");
            cleric.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            cleric.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(cleric);

            Druid druid = new Druid("Druid");
            druid.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            druid.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(druid);

            Paladin paladin = new Paladin("Paladin");
            paladin.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            paladin.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(paladin);

            Ranger ranger = new Ranger("Ranger");
            ranger.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            ranger.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(ranger);

            Sorcerer sorcerer = new Sorcerer("Sorcerer");
            sorcerer.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            sorcerer.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(sorcerer);
            knowlers.Add(sorcerer);

            Wizard wizard = new Wizard("Wizard");
            wizard.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            wizard.Intelligence = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(wizard);

            #endregion
        }
        
        #region spellcasting tab's related stuff

        private void InitializeCastButtons()
        {
            castButtons.Add(buttonCastLevel0);
            castButtons.Add(buttonCastLevel1);
            castButtons.Add(buttonCastLevel2);
            castButtons.Add(buttonCastLevel3);
            castButtons.Add(buttonCastLevel4);
            castButtons.Add(buttonCastLevel5);
            castButtons.Add(buttonCastLevel6);
            castButtons.Add(buttonCastLevel7);
            castButtons.Add(buttonCastLevel8);
            castButtons.Add(buttonCastLevel9);

            foreach (var item in castButtons)
                item.Enabled = false;

            buttonRegainSpells.Enabled = false;
        }
        
        private void AddClass(Spellcaster spellcasterCharacter)
        {
            spellcasters.Add(spellcasterCharacter);
            comboBoxClasses.Items.Add(spellcasterCharacter.ClassName.ToString());
        }

        private void InitializeLevels()
        {
            for (int i = 1; i <= 20; i++)
                comboBoxLevel.Items.Add(i.ToString());
        }

        private void InitializeDCs()
        {
            spellDCs.Add(labelDC0);
            spellDCs.Add(labelDC1);
            spellDCs.Add(labelDC2);
            spellDCs.Add(labelDC3);
            spellDCs.Add(labelDC4);
            spellDCs.Add(labelDC5);
            spellDCs.Add(labelDC6);
            spellDCs.Add(labelDC7);
            spellDCs.Add(labelDC8);
            spellDCs.Add(labelDC9);
        }

        private void InitializeExtraSpells()
        {
            extraSpells.Add(labelExtraSpells0);
            extraSpells.Add(labelExtraSpells1);
            extraSpells.Add(labelExtraSpells2);
            extraSpells.Add(labelExtraSpells3);
            extraSpells.Add(labelExtraSpells4);
            extraSpells.Add(labelExtraSpells5);
            extraSpells.Add(labelExtraSpells6);
            extraSpells.Add(labelExtraSpells7);
            extraSpells.Add(labelExtraSpells8);
            extraSpells.Add(labelExtraSpells9);
        }

        private void InitializeSpellsPerDay()
        {
            spellsPerDay[0] = textBoxSpellsLvL0;
            spellsPerDay[1] = textBoxSpellsLvL1;
            spellsPerDay[2] = textBoxSpellsLvL2;
            spellsPerDay[3] = textBoxSpellsLvL3;
            spellsPerDay[4] = textBoxSpellsLvL4;
            spellsPerDay[5] = textBoxSpellsLvL5;
            spellsPerDay[6] = textBoxSpellsLvL6;
            spellsPerDay[7] = textBoxSpellsLvL7;
            spellsPerDay[8] = textBoxSpellsLvL8;
            spellsPerDay[9] = textBoxSpellsLvL9;
        }

        private void InitializeKnownSpells()
        {
            knownSpells.Add(textBoxKnownSpells0);
            knownSpells.Add(textBoxKnownSpells1);
            knownSpells.Add(textBoxKnownSpells2);
            knownSpells.Add(textBoxKnownSpells3);
            knownSpells.Add(textBoxKnownSpells4);
            knownSpells.Add(textBoxKnownSpells5);
            knownSpells.Add(textBoxKnownSpells6);
            knownSpells.Add(textBoxKnownSpells7);
            knownSpells.Add(textBoxKnownSpells8);
            knownSpells.Add(textBoxKnownSpells9);
        }

        private void ShowSpellsDC()
        {
            if (!string.Equals(comboBoxClasses.Text, "Choose a Class"))
            {
                selector.Select(character, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));
                character.UpdateSpellsDC();

                int i = 0;
                foreach (var item in spellDCs)
                {
                    if (character.SpellsDC[i] > -1)
                        item.Text = character.SpellsDC[i].ToString();
                    else
                        item.Text = "-";
                    i++;
                }
            }
        }

        private void ShowExtraSpells()
        {
            selector.Select(character, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));
            character.UpdateExtraSpells();

            int i = 0;
            foreach (var item in extraSpells)
            {
                if (character.ExtraSpells[i] >= 0)
                    item.Text = character.ExtraSpells[i].ToString();
                else
                    item.Text = "-";
                i++;
            }
        }

        private void ShowSpellsPerDay()
        {
            int level = Convert.ToInt32(comboBoxLevel.Text);

            character.UpdateSpellsPerDay();

            for (int i = 0; i < spellsPerDay.Length; i++)
            {
                if (character.DailySpells[level - 1, i] > 0)
                    spellsPerDay[i].Text = character.DailySpells[level - 1, i].ToString();
                else
                    spellsPerDay[i].Text = "-";
            }
        }

        private void ShowKnownSpells(bool signal)
        {
            if (signal)
            {
                KnowlerOfSpells character = knowlers.Find(x => x.ClassName == comboBoxClasses.Text.ToString());
                int level = Convert.ToInt32(comboBoxLevel.Text);

                character.UpdateKnownSpells();

                int i = 0;
                foreach (var item in knownSpells)
                {
                    if (character.KnownSpells[level - 1, i] > 0)
                        item.Text = character.KnownSpells[level - 1, i].ToString();
                    else
                        item.Text = "-";
                    i++;
                }
            }
        }

        private void ResetKnownSpells(bool signal)
        {
            if (!signal)
            {
                foreach (var item in knownSpells)
                    item.Text = "-";
            }
        }

        private void Cast(int spellCycle)
        {
            int level = Convert.ToInt32(comboBoxLevel.Text);

            character.CastSpell(level, spellCycle);

            spellsPerDay[spellCycle].Text = character.DailySpells[level - 1, spellCycle].ToString();
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            character = spellcasters.Find(x => x.ClassName == comboBoxClasses.Text.ToString());

            labelBaseScore.Text = character.KeyAttribute;
            ShowSpellsDC();
            ShowExtraSpells();
            ShowSpellsPerDay();

            bool signal = selector.IsKnownlerOfSpells(character);
            ShowKnownSpells(signal);
            ResetKnownSpells(signal);

            foreach (var item in castButtons)
                item.Enabled = true;

            buttonRegainSpells.Enabled = true;
        }

        private void textBoxKeyAttribute_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxKeyAttribute_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(comboBoxClasses.Text, "Choose a Class"))
            {
                MessageBox.Show("Please select a valid class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxKeyAttribute.Text != "")
            {
                selector.Select(character, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));

                if (character.KeyAttributeModifier < 0)
                    labelAttibuteBonus.Text = character.KeyAttributeModifier.ToString();
                else
                    labelAttibuteBonus.Text = "+" + character.KeyAttributeModifier.ToString();

                ShowSpellsDC();
                ShowExtraSpells();
            }
        }

        private void comboBoxLevel_TextChanged(object sender, EventArgs e)
        {
            ShowSpellsPerDay();

            bool signal = selector.IsKnownlerOfSpells(character);
            ShowKnownSpells(signal);
            ResetKnownSpells(signal);
        }

        private void buttonCastLevel0_Click(object sender, EventArgs e)
        {
            Cast(0);
        }

        private void buttonCastLevel1_Click(object sender, EventArgs e)
        {
            Cast(1);
        }

        private void buttonCastLevel2_Click(object sender, EventArgs e)
        {
            Cast(2);
        }

        private void buttonCastLevel3_Click(object sender, EventArgs e)
        {
            Cast(3);
        }

        private void buttonCastLevel4_Click(object sender, EventArgs e)
        {
            Cast(4);
        }

        private void buttonCastLevel5_Click(object sender, EventArgs e)
        {
            Cast(5);
        }

        private void buttonCastLevel6_Click(object sender, EventArgs e)
        {
            Cast(6);
        }

        private void buttonCastLevel7_Click(object sender, EventArgs e)
        {
            Cast(7);
        }

        private void buttonCastLevel8_Click(object sender, EventArgs e)
        {
            Cast(8);
        }

        private void buttonCastLevel9_Click(object sender, EventArgs e)
        {
            Cast(9);
        }

        private void buttonRegainSpells_Click(object sender, EventArgs e)
        {
            ShowSpellsPerDay();

            foreach (var item in castButtons)
                item.Enabled = true;
        }

        #endregion

        #region carrying capacity tab's related stuff

        private void InitializeCarryCapacities()
        {
            carryCapacities[0] = textBoxLightLoad;
            carryCapacities[1] = textBoxMediumLoadMin;
            carryCapacities[2] = textBoxMediumLoadMax;
            carryCapacities[3] = textBoxHeavyLoadMin;
            carryCapacities[4] = textBoxHeavyLoadMax;
            carryCapacities[5] = textBoxLiftHead;
            carryCapacities[6] = textBoxLiftGround;
            carryCapacities[7] = textBoxPushGround;
        }

        private void InitializeUnityLabels()
        {
            unityLabels.Add(labelLightLoad);
            unityLabels.Add(labelMediumLoadMin);
            unityLabels.Add(labelMediumLoadMax);
            unityLabels.Add(labelHeavyLoadMin);
            unityLabels.Add(labelHeavyLoadMax);
            unityLabels.Add(labelLiftHead);
            unityLabels.Add(labelLiftGround);
            unityLabels.Add(labelPushDrag);
        }

        private void UpdateCarryCapacities()
        {
            if(radioButtonKgs.Checked)
                for (int i = 0; i < carryCapacities.Length; i++)
                    carryCapacities[i].Text = loadCalculator.LoadsKgs[i].ToString("#,0.00");

            else if(radioButtonLbs.Checked)
                for (int i = 0; i < carryCapacities.Length; i++)
                    carryCapacities[i].Text = loadCalculator.LoadsLbs[i].ToString("#,0.00");
        }

        private void CalculateCarryCapacity()
        {
            loadCalculator.CalculateLoad(Convert.ToInt32(textBoxStrenghtScore.Text),
                                        sizeModifiersCode,
                                        checkBoxFourLegs.Checked);
            UpdateCarryCapacities();
        }

        private void textBoxStrenghtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxStrenghtScore_TextChanged(object sender, EventArgs e)
        {
            if(textBoxStrenghtScore != null)
                CalculateCarryCapacity();
        }

        private void radioButtonSizeFine_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 0;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeDiminutive_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 1;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeTiny_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 2;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 3;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 4;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeLarge_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 5;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeHuge_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 6;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeGargantuan_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 7;
            CalculateCarryCapacity();
        }

        private void radioButtonSizeColossal_CheckedChanged(object sender, EventArgs e)
        {
            sizeModifiersCode = 8;
            CalculateCarryCapacity();
        }
        
        private void checkBoxFourLegs_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCarryCapacity();
        }
       
        private void radioButtonKgs_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in unityLabels)
            {
                item.Text = "Kgs";
                UpdateCarryCapacities();
            }
        }

        private void radioButtonLbs_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in unityLabels)
            {
                item.Text = "Lbs";
                
            }
            UpdateCarryCapacities();
        }

        #endregion
    }
}