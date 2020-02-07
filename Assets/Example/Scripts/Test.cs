using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZLFSM;

public class Test : MonoBehaviour
{
    public FsmManager mFsmManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mFsmManager.ChangeState(FsmConsts.FSM_TEST_1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mFsmManager.ChangeState(FsmConsts.FSM_TEST_2);
        }
    }
}
