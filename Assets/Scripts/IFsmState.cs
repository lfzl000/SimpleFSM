using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZLFSM
{
    public interface IFsmState
    {
        int FsmStateName { get; }
        void OnInitState(IFsmStateParam _param);
        void OnFinishState();
        void OnUpdateState();
        void OnFixedUpdateState();
        void OnLateUpdateState();
    }

    public interface IFsmStateParam
    {

    }
}