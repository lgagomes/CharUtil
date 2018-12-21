using CharUtil;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace XUnitSpellcasters
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestWisdomModifier()
        {
            // Arrange
            Cleric cleric = new Cleric("cleric");

            // Act
            cleric.Wisdom = 6;
            cleric.KeyAttributeModifier = cleric.GetModifier(cleric.Wisdom);

            // Assert
            Assert.Equal(-2, cleric.KeyAttributeModifier);
        }

        [Fact]
        public void TestCharismaModifier()
        {
            // Arrange
            Sorcerer sorcerer = new Sorcerer("sorcerer");

            // Act
            sorcerer.Charisma = 14;
            sorcerer.KeyAttributeModifier = sorcerer.GetModifier(sorcerer.Charisma);

            // Assert
            Assert.Equal(2, sorcerer.KeyAttributeModifier);
        }

        [Fact]
        public void TestIntelligenceModifier()
        {
            // Arrange
            Wizard wizard = new Wizard("Wizard");

            // Act
            wizard.Intelligence = 23;
            wizard.KeyAttributeModifier = wizard.GetModifier(wizard.Intelligence);

            // Assert
            Assert.Equal(6, wizard.KeyAttributeModifier);
        }

        [Fact]
        public void TestBardSpellsPerDay()
        {
            // Arrange
            Bard bard = new Bard("bard");
            int[,] SpellsPerDayBard = new int[20, 10] { {2,0,0,0,0,0,0,0,0,0},
                                                    {3,0,0,0,0,0,0,0,0,0},
                                                    {3,1,0,0,0,0,0,0,0,0},
                                                    {3,2,0,0,0,0,0,0,0,0},
                                                    {3,3,1,0,0,0,0,0,0,0},
                                                    {3,3,2,0,0,0,0,0,0,0},
                                                    {3,3,2,0,0,0,0,0,0,0},
                                                    {3,3,3,1,0,0,0,0,0,0},
                                                    {3,3,3,2,0,0,0,0,0,0},
                                                    {3,3,3,2,0,0,0,0,0,0},
                                                    {3,3,3,3,1,0,0,0,0,0},
                                                    {3,3,3,3,2,0,0,0,0,0},
                                                    {3,3,3,3,2,0,0,0,0,0},
                                                    {4,3,3,3,3,1,0,0,0,0},
                                                    {4,4,3,3,3,2,0,0,0,0},
                                                    {4,4,4,3,3,2,0,0,0,0},
                                                    {4,4,4,4,3,3,1,0,0,0},
                                                    {4,4,4,4,4,3,2,0,0,0},
                                                    {4,4,4,4,4,4,3,0,0,0},
                                                    {4,4,4,4,4,4,4,0,0,0}};
            try
            {
                // Act
                bard.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDayBard, bard.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestSorcererSpellsPerDay()
        {
            // Arrange
            Sorcerer sorcerer = new Sorcerer("sorcerer");
            int[,] SpellsPerDaySorcerer = new int[20, 10] { {5,3,0,0,0,0,0,0,0,0},
                                                            {6,4,0,0,0,0,0,0,0,0},
                                                            {6,5,0,0,0,0,0,0,0,0},
                                                            {6,6,3,0,0,0,0,0,0,0},
                                                            {6,6,4,0,0,0,0,0,0,0},
                                                            {6,6,5,3,0,0,0,0,0,0},
                                                            {6,6,6,4,0,0,0,0,0,0},
                                                            {6,6,6,5,3,0,0,0,0,0},
                                                            {6,6,6,6,4,0,0,0,0,0},
                                                            {6,6,6,6,5,3,0,0,0,0},
                                                            {6,6,6,6,6,4,0,0,0,0},
                                                            {6,6,6,6,6,5,3,0,0,0},
                                                            {6,6,6,6,6,6,4,0,0,0},
                                                            {6,6,6,6,6,6,5,3,0,0},
                                                            {6,6,6,6,6,6,6,4,0,0},
                                                            {6,6,6,6,6,6,6,5,3,0},
                                                            {6,6,6,6,6,6,6,6,4,0},
                                                            {6,6,6,6,6,6,6,6,5,3},
                                                            {6,6,6,6,6,6,6,6,6,4},
                                                            {6,6,6,6,6,6,6,6,6,6}};

            try
            {
                // Act
                sorcerer.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDaySorcerer, sorcerer.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestClericSpellsPerDay()
        {
            // Arrange
            Cleric cleric = new Cleric("cleric");
            int[,] SpellsPerDayCleric = new int[20, 10] {   {3,1,0,0,0,0,0,0,0,0},
                                                            {4,2,0,0,0,0,0,0,0,0},
                                                            {4,2,1,0,0,0,0,0,0,0},
                                                            {5,3,2,0,0,0,0,0,0,0},
                                                            {5,3,2,1,0,0,0,0,0,0},
                                                            {5,3,3,2,0,0,0,0,0,0},
                                                            {6,4,3,2,1,0,0,0,0,0},
                                                            {6,4,3,3,2,0,0,0,0,0},
                                                            {6,4,4,3,2,1,0,0,0,0},
                                                            {6,4,4,3,2,2,0,0,0,0},
                                                            {6,5,4,4,3,2,1,0,0,0},
                                                            {6,5,4,4,3,3,2,0,0,0},
                                                            {6,5,5,4,4,3,2,1,0,0},
                                                            {6,5,5,4,4,3,3,2,0,0},
                                                            {6,5,5,5,4,4,3,2,1,0},
                                                            {6,5,5,5,4,4,3,3,2,0},
                                                            {6,5,5,5,5,4,4,3,2,1},
                                                            {6,5,5,5,5,4,4,3,3,2},
                                                            {6,5,5,5,5,5,4,4,3,3},
                                                            {6,5,5,5,5,5,4,4,4,4}};
            try
            {
                // Act
                cleric.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDayCleric, cleric.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestDruidSpellsPerDay()
        {
            // Arrange
            Druid druid = new Druid("druid");
            int[,] SpellsPerDayDruid = new int[20, 10] {   {3,1,0,0,0,0,0,0,0,0},
                                                            {4,2,0,0,0,0,0,0,0,0},
                                                            {4,2,1,0,0,0,0,0,0,0},
                                                            {5,3,2,0,0,0,0,0,0,0},
                                                            {5,3,2,1,0,0,0,0,0,0},
                                                            {5,3,3,2,0,0,0,0,0,0},
                                                            {6,4,3,2,1,0,0,0,0,0},
                                                            {6,4,3,3,2,0,0,0,0,0},
                                                            {6,4,4,3,2,1,0,0,0,0},
                                                            {6,4,4,3,2,2,0,0,0,0},
                                                            {6,5,4,4,3,2,1,0,0,0},
                                                            {6,5,4,4,3,3,2,0,0,0},
                                                            {6,5,5,4,4,3,2,1,0,0},
                                                            {6,5,5,4,4,3,3,2,0,0},
                                                            {6,5,5,5,4,4,3,2,1,0},
                                                            {6,5,5,5,4,4,3,3,2,0},
                                                            {6,5,5,5,5,4,4,3,2,1},
                                                            {6,5,5,5,5,4,4,3,3,2},
                                                            {6,5,5,5,5,5,4,4,3,3},
                                                            {6,5,5,5,5,5,4,4,4,4}};

            try
            {
                // Act
                druid.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDayDruid, druid.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestWizardSpellsPerDay()
        {
            // Arrange
            Wizard wizard = new Wizard("wizard");
            int[,] SpellsPerDayWizard = new int[20, 10] {{3,1,0,0,0,0,0,0,0,0},
                                                        {4,2,0,0,0,0,0,0,0,0},
                                                        {4,2,1,0,0,0,0,0,0,0},
                                                        {4,3,2,0,0,0,0,0,0,0},
                                                        {4,3,2,1,0,0,0,0,0,0},
                                                        {4,3,3,2,0,0,0,0,0,0},
                                                        {4,4,3,2,1,0,0,0,0,0},
                                                        {4,4,3,3,2,0,0,0,0,0},
                                                        {4,4,4,3,2,1,0,0,0,0},
                                                        {4,4,4,3,2,2,0,0,0,0},
                                                        {4,4,4,4,3,2,1,0,0,0},
                                                        {4,4,4,4,3,3,2,0,0,0},
                                                        {4,4,4,4,4,3,2,1,0,0},
                                                        {4,4,4,4,4,3,3,2,0,0},
                                                        {4,4,4,4,4,4,3,2,1,0},
                                                        {4,4,4,4,4,4,3,3,2,0},
                                                        {4,4,4,4,4,4,4,3,2,1},
                                                        {4,4,4,4,4,4,4,3,3,2},
                                                        {4,4,4,4,4,4,4,4,3,3},
                                                        {4,4,4,4,4,4,4,4,4,4}};

            try
            {
                // Act
                wizard.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDayWizard, wizard.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestPaladinSpellsPerDay()
        {
            // Arrange
            Paladin paladin = new Paladin("Paladin");
            int[,] SpellsPerDayPaladin = new int[20, 10] {{0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,1,0,0,0,0,0,0,0},
                                                        {0,1,1,1,0,0,0,0,0,0},
                                                        {0,1,1,1,0,0,0,0,0,0},
                                                        {0,2,1,1,0,0,0,0,0,0},
                                                        {0,2,2,1,1,0,0,0,0,0},
                                                        {0,2,2,1,1,0,0,0,0,0},
                                                        {0,2,2,2,1,0,0,0,0,0},
                                                        {0,3,2,2,1,0,0,0,0,0},
                                                        {0,3,3,3,2,0,0,0,0,0},
                                                        {0,3,3,3,3,0,0,0,0,0}};

            try
            {
                // Act
                paladin.UpdateSpellsPerDay();

                // Assert            
                Assert.Equal(SpellsPerDayPaladin, paladin.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestRangerSpellsPerDay()
        {
            // Arrange
            Ranger ranger = new Ranger("ranger");
            int[,] SpellsPerDayRanger = new int[20, 10] {{0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,0,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,0,0,0,0,0,0,0,0},
                                                        {0,1,1,0,0,0,0,0,0,0},
                                                        {0,1,1,1,0,0,0,0,0,0},
                                                        {0,1,1,1,0,0,0,0,0,0},
                                                        {0,2,1,1,0,0,0,0,0,0},
                                                        {0,2,2,1,1,0,0,0,0,0},
                                                        {0,2,2,1,1,0,0,0,0,0},
                                                        {0,2,2,2,1,0,0,0,0,0},
                                                        {0,3,2,2,1,0,0,0,0,0},
                                                        {0,3,3,3,2,0,0,0,0,0},
                                                        {0,3,3,3,3,0,0,0,0,0}};

            try
            {
                // Act
                ranger.UpdateSpellsPerDay();

                // Assert           
                Assert.Equal(SpellsPerDayRanger, ranger.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestUpdateSpellsPerDayByLevel()
        {
            // Arrange
            Bard bard = new Bard("bard");
            int[] SpellsPerDayLevel_11 = new int[10] { 3, 3, 3, 3, 1, 0, 0, 0, 0, 0 };
            int[] ReturnedSpellsPerDay = new int[10];
            int level = 11;

            try
            {
                // Act
                bard.UpdateSpellsPerDay();

                // Assert            
                ReturnedSpellsPerDay = Enumerable.Range(0, bard.DailySpells.GetLength(0))
                                        .Select(x => bard.DailySpells[x, level - 1])
                                        .ToArray();

                Assert.Equal(SpellsPerDayLevel_11, ReturnedSpellsPerDay);
            }
            catch { }
        }

        [Fact]
        public void TestUpdateExtraSpells()
        {
            // Arrange
            Bard bard = new Bard("bard");
            bard.Charisma = 32;
            bard.KeyAttributeModifier = bard.GetModifier(bard.Charisma);
            decimal[] extraSpells = new decimal[10] { 0, 3, 3, 3, 2, 2, 2, -1, -1, -1 };

            // Act
            bard.UpdateExtraSpells();

            // Assert
            Assert.Equal(extraSpells, bard.ExtraSpells);
        }

        [Fact]
        public void TestUpdateSpellsDC()
        {
            Bard bard = new Bard("bard");
            bard.Charisma = 32;
            bard.KeyAttributeModifier = bard.GetModifier(bard.Charisma);
            int[] spellsDc = new int[10] { 21, 22, 23, 24, 25, 26, 27, -1, -1, -1 };

            // Act
            bard.UpdateSpellsDC();

            // Assert
            Assert.Equal(spellsDc, bard.SpellsDC);

        }

        [Fact]
        public void TesBardKnownSpells()
        {
            // Arrange
            Bard bard = new Bard("bard");
            int[,] spellsKnownBard = new int[20, 10] { {4,0,0,0,0,0,0,0,0,0},
                                                    {5,2,0,0,0,0,0,0,0,0},
                                                    {6,3,0,0,0,0,0,0,0,0},
                                                    {6,3,2,0,0,0,0,0,0,0},
                                                    {6,4,3,0,0,0,0,0,0,0},
                                                    {6,4,3,0,0,0,0,0,0,0},
                                                    {6,4,4,2,0,0,0,0,0,0},
                                                    {6,4,4,3,0,0,0,0,0,0},
                                                    {6,4,4,3,0,0,0,0,0,0},
                                                    {6,4,4,4,2,0,0,0,0,0},
                                                    {6,4,4,4,3,0,0,0,0,0},
                                                    {6,4,4,4,3,0,0,0,0,0},
                                                    {6,4,4,4,4,2,0,0,0,0},
                                                    {6,4,4,4,4,3,0,0,0,0},
                                                    {6,4,4,4,4,3,0,0,0,0},
                                                    {6,5,4,4,4,4,2,0,0,0},
                                                    {6,5,5,4,4,4,3,0,0,0},
                                                    {6,5,5,5,4,4,3,0,0,0},
                                                    {6,5,5,5,5,4,4,0,0,0},
                                                    {6,5,5,5,5,5,4,0,0,0}};
            try
            {
                // Act
                bard.UpdateKnownSpells();

                // Assert            
                Assert.Equal(spellsKnownBard, bard.KnownSpells);
            }
            catch { }
        }

        [Fact]
        public void TestUpdateKnownSpells()
        {

            // Arrange
            Sorcerer sorcerer = new Sorcerer("sorcerer");
            int[,] spellsKnownSorcerer = new int[20, 10] {  {4,2,0,0,0,0,0,0,0,0},
                                                            {5,2,0,0,0,0,0,0,0,0},
                                                            {5,3,0,0,0,0,0,0,0,0},
                                                            {6,3,1,0,0,0,0,0,0,0},
                                                            {6,4,2,0,0,0,0,0,0,0},
                                                            {7,4,2,1,0,0,0,0,0,0},
                                                            {7,5,3,2,0,0,0,0,0,0},
                                                            {8,5,3,2,1,0,0,0,0,0},
                                                            {8,5,4,3,2,0,0,0,0,0},
                                                            {9,5,4,3,2,1,0,0,0,0},
                                                            {9,5,5,4,3,2,0,0,0,0},
                                                            {9,5,5,4,3,2,1,0,0,0},
                                                            {9,5,5,4,4,3,2,0,0,0},
                                                            {9,5,5,4,4,3,2,1,0,0},
                                                            {9,5,5,4,4,4,3,2,0,0},
                                                            {9,5,5,4,4,4,3,2,1,0},
                                                            {9,5,5,4,4,4,3,3,2,0},
                                                            {9,5,5,4,4,4,3,3,2,1},
                                                            {9,5,5,4,4,4,3,3,3,2},
                                                            {9,5,5,4,4,4,3,3,3,3}};

            try
            {
                // Act
                sorcerer.UpdateKnownSpells();

                // Assert           
                Assert.Equal(spellsKnownSorcerer, sorcerer.KnownSpells);
            }
            catch { }
        }

        [Fact]
        public void TestCastSpell()
        {
            // Arrange
            Cleric cleric = new Cleric("cleric");
            int[,] SpellsPerDayAfterUser = new int[20, 10] {{3,1,0,0,0,0,0,0,0,0},
                                                            {4,2,0,0,0,0,0,0,0,0},
                                                            {4,2,1,0,0,0,0,0,0,0},
                                                            {5,3,2,0,0,0,0,0,0,0},
                                                            {5,3,2,1,0,0,0,0,0,0},
                                                            {5,3,3,2,0,0,0,0,0,0},
                                                            {6,3,3,2,1,0,0,0,0,0}, // <--
                                                            {6,4,3,3,2,0,0,0,0,0},
                                                            {6,4,4,3,2,1,0,0,0,0},
                                                            {6,4,4,3,2,2,0,0,0,0},
                                                            {6,5,4,4,3,2,1,0,0,0},
                                                            {6,5,4,4,3,3,2,0,0,0},
                                                            {6,5,5,4,4,3,2,1,0,0},
                                                            {6,5,5,4,4,3,3,2,0,0},
                                                            {6,5,5,5,4,4,3,2,1,0},
                                                            {6,5,5,5,4,4,3,3,2,0},
                                                            {6,5,5,5,5,4,4,3,2,1},
                                                            {6,5,5,5,5,4,4,3,3,2},
                                                            {6,5,5,5,5,5,4,4,3,3},
                                                            {6,5,5,5,5,5,4,4,4,4}};
            try
            {
                // Act
                cleric.UpdateSpellsPerDay();
                cleric.CastSpell(7, 1);

                // Assert            
                Assert.Equal(SpellsPerDayAfterUser, cleric.DailySpells);
            }
            catch { }
        }

        [Fact]
        public void TestCarryingCapacity()
        {
            // Arrange
            LoadCalculator load = new LoadCalculator();
            int str = 39;
            double[] lbs = { 5600, 5601, 11200, 11201, 16800, 16800, 33600, 84000 };
            double[] kgs = { 2800, 2800.5, 5600, 5600.5, 8400, 8400, 16800, 42000 };

            // Act
            load.CalculateLoad(str, 5, true);

            // Assert
            Assert.Equal(lbs, load.LoadsLbs);
            Assert.Equal(kgs, load.LoadsKgs);
        }

        [Fact]
        public void TestBaseAttackBonus()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("barbarian");
            Monk monk = new Monk("monk");
            Wizard wizard = new Wizard("wizard");

            barbarian.CharacterLevel = 11;
            monk.CharacterLevel = 6;
            wizard.CharacterLevel = 20;

            double[] barbarianTemplate = { 11, 6, 1, 0 };
            double[] monkTemplate = { 4, 0, 0, 0 };
            double[] wizardTemplate = { 10, 5, 0, 0 };

            // Act
            barbarian.CalculateBaseAttackBonus();
            monk.CalculateBaseAttackBonus();
            wizard.CalculateBaseAttackBonus();

            // Assert
            Assert.Equal(barbarianTemplate, barbarian.BaseAttackBonus);
            Assert.Equal(monkTemplate, monk.BaseAttackBonus);
            Assert.Equal(wizardTemplate, wizard.BaseAttackBonus);
        }

        [Fact]
        public void TestMonkFuryBlows()
        {
            // Arrange
            Monk monk = new Monk("monk");
            monk.CharacterLevel = 18;
            double[] template = { 13, 13, 13, 8, 3 };

            // Act
            monk.CalculateFuryOfBlowsBonus();

            // Assert
            Assert.Equal(template, monk.FuryOfBlowsBonus);
        }

        [Fact]
        public void TestCalculateXPByLevel()
        {
            // Arrange
            XPCalculator xpCalculator = new XPCalculator();
            long expectedXP = 66000,
                actualXP,
                level = 12;

            // Act
            actualXP = xpCalculator.CalculateXPByLevel(level);

            // Assert
            Assert.Equal(expectedXP, actualXP);
        }

        [Fact]
        public void TestCalculateLevelByXP()
        {
            // Arrange
            XPCalculator xpCalculator = new XPCalculator();
            long xp = 119999;
            long expectedLevel = 15;
            long actualLevel;

            // Act
            actualLevel = xpCalculator.CalculateLevelByXP(xp);

            // Assert
            Assert.Equal(expectedLevel, actualLevel);
        }

        [Fact]
        public void TestCalculateLevelBySumXP()
        {
            // Arrange
            XPCalculator xpCalculator = new XPCalculator();
            long xpAmmount1 = 36000;
            long xpAmmount2 = 78000;
            long actualLevel;
            long expectedLevel = 15;

            // Act
            actualLevel = xpCalculator.CalculateLevelBySumXP(xpAmmount1, xpAmmount2);

            // Assert
            Assert.Equal(expectedLevel, actualLevel);
        }

        [Fact]
        public void TestRoll()
        {
            // Arrange
            Dice dice = new Dice(6);
            int rolledValue;

            // Act
            rolledValue = dice.Roll();

            // Assert           
            Assert.InRange<int>(rolledValue, 1, 6);
            output.WriteLine(rolledValue.ToString());

        }

        //[Fact] // Must change the visibility of XPCalculator.GetDelta() to public
        //public void TestGetDelta()
        //{
        //    

        //    // Arrange
        //    XPCalculator xpCalculator = new XPCalculator();
        //    int a = 1, b = -5, c = 6;
        //    int expectedDelta = 1;
        //    int actualDelta;

        //    // Act
        //    actualDelta = xpCalculator.GetDelta(a, b, c);

        //    // Assert
        //    Assert.Equal(expectedDelta, actualDelta);
        //}
    }
}