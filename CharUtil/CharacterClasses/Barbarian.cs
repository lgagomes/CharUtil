using System;
using System.Collections.Generic;
using System.Text;

namespace CharUtil
{
    public class Barbarian : BaseClass
    {
        public Barbarian(string classname)
        {
            ClassName = classname;
            CombatantType = 1;
			SkillClassModifier = 4;
        }
    }
}
