using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharUtil
{
    public partial class Form1 : Form
    {
        private List<Spellcaster> spellcastersList;
        private List<KnowlerOfSpells> knowlers;
        private List<Label> spellDCs;
        private List<Label> extraSpells;
        private List<Button> castButtons;
        private List<TextBox> knownSpells;
        private TextBox[] spellsPerDay;
        private Spellcaster spellcaster;
        private CasterSelector selector;

        private LoadCalculator loadCalculator;
        private int sizeModifiersCode = 4;
        private TextBox[] carryCapacities;
        private List<Label> unityLabels;

        private List<BaseClass> allClasses;
        private BaseClass miscClass;

        private CheckBox[] levelBonusPoints;

        private XPCalculator xpCalculator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region general initializations

            spellcastersList = new List<Spellcaster>();
            knowlers = new List<KnowlerOfSpells>();
            castButtons = new List<Button>();
            loadCalculator = new LoadCalculator();
            unityLabels = new List<Label>();
            allClasses = new List<BaseClass>();
            xpCalculator = new XPCalculator();

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

            levelBonusPoints = new CheckBox[5];
            InitializeLevelBonusPoints();

            InitializeCastButtons();
            CalculateCarryCapacity();
            InitializeUnityLabels();
            #endregion

            #region initialize all classes
            spellcaster = new Spellcaster();
            selector = new CasterSelector();         

            Barbarian barbarian = new Barbarian("barbarian");
            barbarian.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            AddClassMisc(barbarian);

            Bard bard = new Bard("Bard");
            bard.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            bard.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(bard);
            knowlers.Add(bard);
            AddClassMisc(bard);

            Cleric cleric = new Cleric("Cleric");
            cleric.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            cleric.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(cleric);
            AddClassMisc(cleric);

            Druid druid = new Druid("Druid");
            druid.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            druid.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(druid);
            AddClassMisc(druid);

            Monk monk = new Monk("monk");
            monk.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            AddClassMisc(monk);

            Paladin paladin = new Paladin("Paladin");
            paladin.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            paladin.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(paladin);
            AddClassMisc(paladin);

            Ranger ranger = new Ranger("Ranger");
            ranger.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            ranger.Wisdom = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(ranger);
            AddClassMisc(ranger);

            Rogue rogue = new Rogue("rogue");
            rogue.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            AddClassMisc(rogue);

            Sorcerer sorcerer = new Sorcerer("Sorcerer");
            sorcerer.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            sorcerer.Charisma = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(sorcerer);
            knowlers.Add(sorcerer);
            AddClassMisc(sorcerer);

            Warrior warrior = new Warrior("warrior");
            warrior.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            AddClassMisc(warrior);

            Wizard wizard = new Wizard("Wizard");
            wizard.CharacterLevel = Convert.ToInt32(comboBoxLevel.Text);
            wizard.Intelligence = Convert.ToInt32(textBoxKeyAttribute.Text);
            AddClass(wizard);
            AddClassMisc(wizard);

            #endregion
        }

        #region general methods

        private void InitializeLevels()
        {
            for (int i = 1; i <= 20; i++)
            {
                comboBoxLevel.Items.Add(i.ToString());
                comboBoxLevelMisc.Items.Add(i.ToString());
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright© 2018 Luiz Gustavo A. Gomes\n\n" +
                "If you have any questions just contact me at\n" +
                "\t\tlgustavogom@gmail.com\n\n" +
                "This program uses content from the d20 System.\n" +
                "With no intention to replace the books for full descriptions, " +
                "but rather to be a tool to ease the character creation.",
                "About", MessageBoxButtons.OK);
        }

        #endregion

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
            spellcastersList.Add(spellcasterCharacter);
            comboBoxClasses.Items.Add(spellcasterCharacter.ClassName.ToString());
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
                selector.Select(spellcaster, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));
                spellcaster.UpdateSpellsDC();

                int i = 0;
                foreach (var item in spellDCs)
                {
                    if (spellcaster.SpellsDC[i] > -1)
                        item.Text = spellcaster.SpellsDC[i].ToString();
                    else
                        item.Text = "-";
                    i++;
                }
            }
        }

        private void ShowExtraSpells()
        {
            selector.Select(spellcaster, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));
            spellcaster.UpdateExtraSpells();

            int i = 0;
            foreach (var item in extraSpells)
            {
                if (spellcaster.ExtraSpells[i] >= 0)
                    item.Text = spellcaster.ExtraSpells[i].ToString();
                else
                    item.Text = "-";
                i++;
            }
        }

        private void ShowSpellsPerDay()
        {
            /* TODO: Split this method in 2, one only for load the spells per level
             * from the XML and another to fill the textBoxes based on character
             * level */

            spellcaster.UpdateSpellsPerDay();

            int level = Convert.ToInt32(comboBoxLevel.Text);

            for (int i = 0; i < spellsPerDay.Length; i++)
            {
                if (spellcaster.DailySpells[level - 1, i] > 0)
                    spellsPerDay[i].Text = spellcaster.DailySpells[level - 1, i].ToString();
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

            spellcaster.CastSpell(level, spellCycle);

            spellsPerDay[spellCycle].Text = spellcaster.DailySpells[level - 1, spellCycle].ToString();
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            spellcaster = spellcastersList.Find(x => x.ClassName == comboBoxClasses.Text.ToString());

            labelBaseScore.Text = spellcaster.KeyAttribute;
            ShowSpellsDC();
            ShowExtraSpells();
            ShowSpellsPerDay();

            bool signal = selector.IsKnownlerOfSpells(spellcaster);
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
                selector.Select(spellcaster, labelBaseScore.Text, Convert.ToInt32(textBoxKeyAttribute.Text));

                if (spellcaster.KeyAttributeModifier < 0)
                    labelAttibuteBonus.Text = spellcaster.KeyAttributeModifier.ToString();
                else
                    labelAttibuteBonus.Text = "+" + spellcaster.KeyAttributeModifier.ToString();

                ShowSpellsDC();
                ShowExtraSpells();
            }
        }

        private void comboBoxLevel_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(comboBoxClasses.Text, "Choose a Class"))
            {
                MessageBox.Show("Please select a valid class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ShowSpellsPerDay();

                bool signal = selector.IsKnownlerOfSpells(spellcaster);
                ShowKnownSpells(signal);
                ResetKnownSpells(signal);
            }
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
            if (radioButtonKgs.Checked)
                for (int i = 0; i < carryCapacities.Length; i++)
                    carryCapacities[i].Text = loadCalculator.LoadsKgs[i].ToString("#,0.00");

            else if (radioButtonLbs.Checked)
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
            if (textBoxStrenghtScore != null)
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

        #region Misc tab's related stuff
        private void InitializeLevelBonusPoints()
        {
            levelBonusPoints[0] = checkBoxInt4thLevel;
            levelBonusPoints[1] = checkBoxInt8thLevel;
            levelBonusPoints[2] = checkBoxInt12thLevel;
            levelBonusPoints[3] = checkBoxInt16thLevel;
            levelBonusPoints[4] = checkBoxInt20thLevel;
        }

        private void AddClassMisc(BaseClass character)
        {
            allClasses.Add(character);
            comboBoxClassesMisc.Items.Add(character.ClassName.ToString());
        }

        private void UpdateBaseAttackBonus()
        {
            StringBuilder textBAB = new StringBuilder();
            miscClass.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            miscClass.CalculateBaseAttackBonus();

            for (int i = 0; i < miscClass.BaseAttackBonus.Length; i++)
            {
                if (miscClass.BaseAttackBonus[i] > 0)
                {
                    if ((i < 3) && (miscClass.BaseAttackBonus[i + 1] > 0))
                    {
                        textBAB.Append("+");
                        textBAB.Append(miscClass.BaseAttackBonus[i]);
                        textBAB.Append(" / ");
                    }
                    else
                    {
                        textBAB.Append("+");
                        textBAB.Append(miscClass.BaseAttackBonus[i]);
                    }
                }
            }
            textBoxBAB.Text = textBAB.ToString();

            if (miscClass is Monk)
            {
                StringBuilder textFoB = new StringBuilder();
                Monk monk = (Monk)miscClass;
                monk.CalculateFuryOfBlowsBonus();

                textFoB.Append(monk.FuryOfBlowsBonus[0].ToString("+0;-#"));
                textFoB.Append(" / ");
                textFoB.Append(monk.FuryOfBlowsBonus[1].ToString("+0;-#"));

                if (monk.CharacterLevel > 9)
                {
                    textFoB.Append(" / ");
                }

                for (int i = 2; i < monk.FuryOfBlowsBonus.Length; i++)
                {
                    if (monk.FuryOfBlowsBonus[i] > 0)
                    {
                        if ((i < 4) && (monk.FuryOfBlowsBonus[i + 1] > 0))
                        {
                            textFoB.Append(monk.FuryOfBlowsBonus[i].ToString("+#;-#;0"));
                            textFoB.Append(" / ");
                        }
                        else
                        {
                            textFoB.Append(monk.FuryOfBlowsBonus[i].ToString("+#;-#;0"));
                        }
                    }
                }
                textBoxMonkFoB.Text = textFoB.ToString();
            }
        }

        private void UpdateLevelBonusPointsCheckboxes()
        {
            int unlockIndex = Convert.ToInt32(comboBoxLevelMisc.Text) / 4;
            
            // enable checkboxes in case of increase the level
            for (int i = 0; i < unlockIndex; i++)
            {
                levelBonusPoints[i].Enabled = true;
            }

            // in case of decrease the level, disable any ckeckboxes already enabled
            for (int j = unlockIndex; j < levelBonusPoints.Length; j++)
            {
                levelBonusPoints[j].Enabled = false;
                levelBonusPoints[j].Checked = false;
            }
        }

        private void UpdateIntelligenceBonuses()
        {
            miscClass.SkillPointsCalculator.IntelligenceBonuses.IntBonus4thLevel = checkBoxInt4thLevel.Checked;
            miscClass.SkillPointsCalculator.IntelligenceBonuses.IntBonus8thLevel = checkBoxInt8thLevel.Checked;
            miscClass.SkillPointsCalculator.IntelligenceBonuses.IntBonus12thLevel = checkBoxInt12thLevel.Checked;
            miscClass.SkillPointsCalculator.IntelligenceBonuses.IntBonus16thLevel = checkBoxInt16thLevel.Checked;
            miscClass.SkillPointsCalculator.IntelligenceBonuses.IntBonus20thLevel = checkBoxInt20thLevel.Checked;
        }

        private void UpdateSkillPoints()
        {
            miscClass.CharacterLevel = Convert.ToInt32(comboBoxLevelMisc.Text);
            miscClass.Intelligence = Convert.ToInt32(textBoxIntelligenceScore.Text);

            miscClass.SkillPointsCalculator.ResetSkillPoints();
            miscClass.UpdateSkillPointsModifiers();

            miscClass.SkillPointsCalculator.CalculateSkillPoints(miscClass.CharacterLevel,
                    miscClass.GetModifier(miscClass.Intelligence),
                    miscClass.SkillClassModifier,
                    checkBoxIsHuman.Checked);

            textBoxSkillPoints.Text = miscClass.SkillPointsCalculator.SkillPoints.ToString();
        }

        private void UpdateSkillRanks()
        {
            miscClass.SkillPointsCalculator.CalculateSkillRanks(miscClass.CharacterLevel);

            textBoxClassSkillMaxRanks.Text = miscClass.SkillPointsCalculator.ClassSkillMaxRanks.ToString();
            textBoxNonClassSkillMaxRanks.Text = miscClass.SkillPointsCalculator.NonClassSkillMaxRanks.ToString();
        }

        private void UpdateLevelAfterXPGain()
        {
            textBoxLevelAfterXP.Text = (xpCalculator.CalculateLevelBySumXP(
                                    Convert.ToInt64(textBoxActualXP.Text),
                                    Convert.ToInt64(textBoxReceivedXP.Text))).ToString();
        }

        private void CheckEpicLevel()
        {
            // https://stackoverflow.com/a/20688985

            if (Convert.ToInt64(textBoxLevelAfterXP.Text) > 20)
                textBoxLevelAfterXP.ForeColor = Color.Blue;
            else
                textBoxLevelAfterXP.ForeColor = Color.Black;

            textBoxLevelAfterXP.BackColor = textBoxLevelAfterXP.BackColor;
        }

        private void UpdateTotalXP()
        {
            textBoxTotalXP.Text = (
                Convert.ToInt64(textBoxActualXP.Text) +
                Convert.ToInt64(textBoxReceivedXP.Text)).ToString();
        }

        private void comboBoxClassesMisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxMonkFoB.Text = "";
            miscClass = allClasses.Find(x => x.ClassName == comboBoxClassesMisc.Text.ToString());
            miscClass.SkillPointsCalculator = new SkillPointsCalculator();
            UpdateBaseAttackBonus();

            UpdateLevelBonusPointsCheckboxes();
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void comboBoxLevelMisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Equals(comboBoxClassesMisc.Text, "Choose a Class"))
            {
                MessageBox.Show("Please select a valid class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                UpdateBaseAttackBonus();
                UpdateLevelBonusPointsCheckboxes();
                UpdateIntelligenceBonuses();
                UpdateSkillPoints();
                UpdateSkillRanks();
            }
        }

        private void checkBoxInt4thLevel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void checkBoxInt8thLevel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void checkBoxInt12thLevel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void checkBoxInt16thLevel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void checkBoxInt20thLevel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIntelligenceBonuses();
            UpdateSkillPoints();
        }

        private void textBoxIntelligenceScore_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(comboBoxClassesMisc.Text, "Choose a Class"))
            {
                MessageBox.Show("Please select a valid class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxIntelligenceScore.Text != "")
            {
                UpdateSkillPoints();
            }
        }

        private void textBoxIntelligenceScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkBoxIsHuman_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSkillPoints();
        }
       
        private void textBoxActualXP_TextChanged(object sender, EventArgs e)
        {
            if (textBoxActualXP.Text != "")
            {
                UpdateLevelAfterXPGain();
                UpdateTotalXP();
                CheckEpicLevel();
            }
        }

        private void textBoxActualXP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxReceivedXP_TextChanged(object sender, EventArgs e)
        {
            if (textBoxReceivedXP.Text != "")
            {
                UpdateLevelAfterXPGain();
                UpdateTotalXP();
                CheckEpicLevel();
            }
        }       

        private void textBoxReceivedXP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        private void buttonXPProgression_Click(object sender, EventArgs e)
        {
            FormXpProgression formXpProgression = new FormXpProgression();
            formXpProgression.ShowDialog();
        }
        #endregion
    }
}