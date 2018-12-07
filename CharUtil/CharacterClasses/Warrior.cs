using System;
using System.Collections.Generic;
using System.Text;

namespace CharUtil
{
    public class Warrior : BaseClass
    {
        public Warrior(string classname)
        {
            ClassName = classname;
            CombatantType = 1;
			SkillClassModifier = 2;
        }
    }
}
