using System;

namespace CharUtil
{
    public class LoadCalculator
    {
        public double[] LoadsLbs { get; }
        public double[] LoadsKgs { get; }

        public LoadCalculator()
        {
            LoadsLbs = new double[8];
            LoadsKgs = new double[8];
        }

        public void CalculateLoad(int strength, int sizeCategory, bool hasFourLegs)
        {
            double maxLoad;
            double sizeModifier = GetSizeModifier(sizeCategory, hasFourLegs);

            if (strength <= 0)
                throw new ArgumentException("Strenght should be greanter than 0");

            else if (strength > 0 && strength <= 10)
                maxLoad = strength * 10;

            else
            {
                /* source:
                 * https://paizo.com/threads/rzs2qa0i?I-am-looking-for-the-math-behind-carrying#10
                 */
                int index = 1 + strength - 10 * (strength / 10);
                double[] vec = new double[10] { 25, 28.75, 32.5, 37.5, 43.75, 50, 57.5, 65, 75, 87.5 };
                double pot = Math.Pow(4, (strength / 10));

                maxLoad = pot * vec[index - 1];
            }

            LoadsLbs[0] = (maxLoad / 3) * sizeModifier;                 // light load
            LoadsLbs[1] = LoadsLbs[0] + 1;                              // medium load lower boundary
            LoadsLbs[2] = ((maxLoad * 2) / 3) * sizeModifier;           // medium load
            LoadsLbs[3] = LoadsLbs[2] + 1;                              // heavy load lower boundary
            LoadsLbs[4] = maxLoad * sizeModifier;                       // heavy load
            LoadsLbs[5] = maxLoad * sizeModifier;                       // Lift Over Head
            LoadsLbs[6] = maxLoad * 2 * sizeModifier;                   // Lift Off Ground
            LoadsLbs[7] = maxLoad * 5 * sizeModifier;                   // Push or Drag

            for (int i = 0; i < LoadsLbs.Length; i++)
                LoadsKgs[i] = LoadsLbs[i] / 2;
        }

        private double GetSizeModifier(int sizeCategory, bool hasFourLegs)
        {
            double[] sizeConstants = new double[18];

            // 0 to 8 = biped creature
            sizeConstants[0] = 0.125;   // Fine size (Minúsculo)
            sizeConstants[1] = 0.25;    // Diminutive size (Diminuto)
            sizeConstants[2] = 0.5;     // Tiny size (Miúdo)
            sizeConstants[3] = 0.75;    // Small size (Pequeno)
            sizeConstants[4] = 1;       // Medium size (Médio)
            sizeConstants[5] = 2;       // Large size (Grande)
            sizeConstants[6] = 4;       // Huge size (Enorme)
            sizeConstants[7] = 8;       // Gargantuan size (Imenso)
            sizeConstants[8] = 16;      // Colossal size (Colossal)

            // 9 to 17 = quadruped creature
            sizeConstants[9] = 0.25;    // Fine size (Minúsculo)
            sizeConstants[10] = 0.5;    // Diminutive size (Diminuto)
            sizeConstants[11] = 0.75;   // Tiny size (Miúdo)
            sizeConstants[12] = 1;      // Small size (Pequeno)
            sizeConstants[13] = 1.5;    // Medium size (Médio)
            sizeConstants[14] = 3;      // Large size (Grande)
            sizeConstants[15] = 6;      // Huge size (Enorme)
            sizeConstants[16] = 12;     // Gargantuan size (Imenso)
            sizeConstants[17] = 24;     // Colossal size (Colossal)

            if (!hasFourLegs)
                return sizeConstants[sizeCategory];
            else
                return sizeConstants[sizeCategory + 9];
        }
    }
}
