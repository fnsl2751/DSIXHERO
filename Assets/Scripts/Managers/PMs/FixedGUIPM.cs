using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class FixedGUIPM : BasePM
{
    public override void Awake()
    {
        base.Awake();

        m_PM = PM.FixedGUIPM;
    }
}
