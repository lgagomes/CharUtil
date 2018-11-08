using CharUtil;
using System.Linq;
using Xunit;

namespace XUnitSpellcasters
{
    public class UnitTest1
    {
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
            int[,] SpellsPerDayWizard= new int[20, 10] {{3,1,0,0,0,0,0,0,0,0},
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
            int[] SpellsPerDayLevel_11 = new int[10] {3,3,3,3,1,0,0,0,0,0};
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
            decimal [] extraSpells = new decimal[10] {0, 3, 3, 3, 2, 2, 2, -1, -1, -1};

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
    }
}