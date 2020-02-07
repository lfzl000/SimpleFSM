﻿using UnityEngine;
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
        Debug.Log("Finish 1");
    }

    public void OnInitState(IFsmStateParam _param)
    {
        TestParam param = _param as TestParam;
        Debug.Log(param.testStr);
    }
}
