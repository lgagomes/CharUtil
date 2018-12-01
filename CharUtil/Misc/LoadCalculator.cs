using System;

namespace CharUtil
{
    public class LoadCalculator
    {
        private const double ONE = 1;
        private const double TWO = 2;
        private const double THREE = 3;
        private const double FOUR = 4;
        private const double SIX = 6;
        private const double EIGHT = 8;
        private const double TWELVE = 12;
        private const double SIXTEEN = 16;
        private const double TWENTY_FOUR = 24;

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

            if (strength == 0)
                maxLoad = 0;

            else if (strength > 0 && strength <= 10)
                maxLoad = strength * 10;

            else
            {
                /* source:
                 * https://paizo.com/threads/rzs2qa0i?I-am-looking-for-the-math-behind-carrying#10 */

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
            sizeConstants[0] = ONE / EIGHT;     // Fine size (Minúsculo)
            sizeConstants[1] = ONE / FOUR;      // Diminutive size (Diminuto)
            sizeConstants[2] = ONE / TWO;       // Tiny size (Miúdo)
            sizeConstants[3] = THREE / FOUR;    // Small size (Pequeno)
            sizeConstants[4] = ONE;             // Medium size (Médio)
            sizeConstants[5] = TWO;             // Large size (Grande)
            sizeConstants[6] = FOUR;            // Huge size (Enorme)
            sizeConstants[7] = EIGHT;           // Gargantuan size (Imenso)
            sizeConstants[8] = SIXTEEN;         // Colossal size (Colossal)

            // 9 to 17 = quadruped creature
            sizeConstants[9] = ONE / FOUR;      // Fine size (Minúsculo)
            sizeConstants[10] = ONE / TWO;      // Diminutive size (Diminuto)
            sizeConstants[11] = THREE / FOUR;   // Tiny size (Miúdo)
            sizeConstants[12] = ONE;            // Small size (Pequeno)
            sizeConstants[13] = THREE / TWO;    // Medium size (Médio)
            sizeConstants[14] = THREE;          // Large size (Grande)
            sizeConstants[15] = SIX;            // Huge size (Enorme)
            sizeConstants[16] = TWELVE;         // Gargantuan size (Imenso)
            sizeConstants[17] = TWENTY_FOUR;    // Colossal size (Colossal)

            if (!hasFourLegs)
                return sizeConstants[sizeCategory];
            else
                return sizeConstants[sizeCategory + 9];
        }
    }
}
