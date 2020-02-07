using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZLFSM
{
    public class FsmManager : MonoBehaviour
    {
        private int m_CurState = int.MaxValue;
        private int m_PreState = int.MaxValue;
        private IFsmState m_CurStateFsm;
        private KeyValueList<int, IFsmState> m_FsmList;

        /// <summary>
        /// 当前状态
        /// </summary>
        public int CurrectState
        {
            get
            {
                return m_CurState;
            }
        }

        /// <summary>
        /// 上一个状态
        /// </summary>
        public int PreviousState
        {
            get
            {
                return m_PreState;
            }
        }

        private void Start()
        {
            InitFsm();
            FSMDefault fSMDefault = new FSMDefault();
            RegistState(fSMDefault);
            ChangeState(FsmConsts.FSM_DEFAULT);
        }

        /// <summary>
        /// 初始化状态机
        /// </summary>
        public void InitFsm()
        {
            FSMTest1 fSMTest1 = new FSMTest1();
            FSMTest2 fSMTest2 = new FSMTest2();

            RegistState(fSMTest1);
            RegistState(fSMTest2);
        }

        /// <summary>
        /// 注册状态
        /// </summary>
        /// <param name="_state"></param>
        public void RegistState(IFsmState _state)
        {
            if (m_FsmList == null)
            {
                m_FsmList = new KeyValueList<int, IFsmState>();
            }

            if (m_FsmList.IsContainsKey(_state.FsmStateName))
            {
                Debug.LogFormat("已存在该转状态: {0},不要重复注册!", _state.FsmStateName);
                return;
            }

            m_FsmList.Put(_state.FsmStateName, _state);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="_stateName"></param>
        public void ChangeState(int _stateName, IFsmStateParam _param = null)
        {
            if (!m_FsmList.IsContainsKey(_stateName))
            {
                Debug.LogFormat("跳转失败! 要跳转的状态不存在: {0}", _stateName);
                return;
            }

            if(_stateName == m_CurState)
            {
                Debug.Log("跳转失败! 不能跳转到当前状态");
                return;
            }

            m_CurStateFsm?.OnFinishState();
            m_PreState = m_CurState;

            m_CurStateFsm = m_FsmList[_stateName];
            m_CurState = _stateName;
            m_CurStateFsm.OnInitState(_param);
            Debug.LogFormat("状态跳转:{0} => {1}", m_PreState, m_CurState);
        }

        public void DisposeFsm()
        {
            m_CurStateFsm?.OnFinishState();

            m_CurState = -1;

            m_CurStateFsm = null;

            m_FsmList = null;
        }

        private void Update()
        {
            m_CurStateFsm?.OnUpdateState();
        }

        private void FixedUpdate()
        {
            m_CurStateFsm?.OnFixedUpdateState();
        }

        private void LateUpdate()
        {
            m_CurStateFsm?.OnLateUpdateState();
        }
    }

    public class FSMDefault : IFsmState
    {
        public int FsmStateName
        {
            get
            {
                return FsmConsts.FSM_DEFAULT;
            }
        }

        public void OnFinishState()
        {
            Debug.Log("结束默认状态");
        }

        public void OnFixedUpdateState()
        {
        }

        public void OnInitState(IFsmStateParam _param)
        {
            Debug.Log("开启默认状态");
        }

        public void OnLateUpdateState()
        {
        }

        public void OnUpdateState()
        {
        }
    }
}