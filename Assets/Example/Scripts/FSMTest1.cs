﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZLFSM;

public class FSMTest1 : IFsmState
{
    public int FsmStateName
    {
        get
        {
            return FsmConsts.FSM_TEST_1;
        }
    }

    public void OnFinishState()
    {
    }

    public void OnFixedUpdateState()
    {
    }

    public void OnInitState(IFsmStateParam _param)
    {
    }

    public void OnLateUpdateState()
    {
    }

    public void OnUpdateState()
    {
    }
}
