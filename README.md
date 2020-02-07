# 简易有限状态机

## 使用说明

在项目开始初始化 FSM

示例:
``` csharp
void Start()
{
    FsmManager.Instance.StartFsm();
}
```

### 新建状态

步骤:

1. 引入命名空间 ZLFSM
2. 实现接口 IFsmState
3. 在 FsmConsts 定义一个消息名

注册消息代码示例:

``` csharp
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

    public void OnInitState(IFsmStateParam _param)
    {
    }
}
```

定义消息名称:

``` csharp
namespace ZLFSM
{
    public class FsmConsts
    {
        public const int FSM_DEFAULT = -1;
        public const int FSM_TEST_1 = 1001;
    }
}
```

### 注册状态

步骤:

1. 在 FsmManager.cs - InitFsm() 方法中 new 一个状态示例
2. 把状态示例注册到状态列表

发送消息代码示例:

``` csharp
public void InitFsm()
{
    FSMTest1 fSMTest1 = new FSMTest1();

    RegistState(fSMTest1);
}
```

### 跳转状态

## 无参数

``` csharp
FsmManager.Instance.ChangeState(FsmConsts.FSM_TEST_1);
```

## 有参数

1. 新建一个参数类，继承 IFsmStateParam 接口
``` csharp
public class TestParam : IFsmStateParam
{
    public string testStr;
}
```
2. 在需要跳转的地方 new 一个参数实例，然后跳转状态
``` csharp
TestParam param = new TestParam
{
    testStr = "11111"
};
FsmManager.Instance.ChangeState(FsmConsts.FSM_TEST_1, param);
```
