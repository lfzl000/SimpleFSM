using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZLFSM;

public class Test : MonoBehaviour
{
    void Start()
    {
        FsmManager.Instance.StartFsm();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TestParam param = new TestParam
            {
                testStr = "11111"
            };
            FsmManager.Instance.ChangeState(FsmConsts.FSM_TEST_1, param);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TestParam param = new TestParam
            {
                testStr = "22222"
            };
            FsmManager.Instance.ChangeState(FsmConsts.FSM_TEST_2, param);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FsmManager.Instance.ChangeState(FsmConsts.FSM_DEFAULT);
        }
    }
}

public class TestParam : IFsmStateParam
{
    public string testStr;
}