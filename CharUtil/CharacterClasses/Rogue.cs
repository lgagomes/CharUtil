using System;
using System.Collections.Generic;
using System.Text;

namespace CharUtil
{
    public class Rogue : BaseClass
    {
        public Rogue (string classname)
        {
            ClassName = classname;
            CombatantType = 2;
			SkillClassModifier = 8;
        }
    }
}
