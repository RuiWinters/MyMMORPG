using System;
using UnityEngine;
using System.Collections.Generic;
using LitJson;

/// <summary>
/// 账户控制
/// </summary>
internal class AccountCtrl : Singleton<AccountCtrl>, ISystemCtrl
{
    private UILogOnView m_LogOnView;
    private UIRegView m_RegView;

    public AccountCtrl()
    {
        UIDispatcher.Instance.AddEventListener(ConstDefine.UILogOnView_btnLogOn, LogOnViewBtnLogOnClick);
        UIDispatcher.Instance.AddEventListener(ConstDefine.UILogOnView_btnToReg, LogOnViewBtnToRegClick);

        UIDispatcher.Instance.AddEventListener(ConstDefine.UIRegView_btnReg, RegViewBtnRegClick);
        UIDispatcher.Instance.AddEventListener(ConstDefine.UIRegView_btnToLogOn, RegViewBtnToLogOnClick);
    }

    #region 登录界面

    /// <summary>
    /// 登录按钮点击
    /// </summary>
    /// <param name="param"></param>
    private void LogOnViewBtnLogOnClick(string[] param)
    {
        if (string.IsNullOrEmpty(m_LogOnView.txtUserName.text))
        {
            Debug.Log("请输入用户名！");
        }
        if (string.IsNullOrEmpty(m_LogOnView.txtPwd.text))
        {
            Debug.Log("请输入密码！");
        }
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic["Type"] = 1;
        dic["UserName"] = m_LogOnView.txtUserName.text;
        dic["Pwd"] = m_LogOnView.txtPwd.text;

        NetWorkHttp.Instance.SendData(GlobalInit.WebAccountUrl + "api/Account", OnLogOnCallBack, isPost: true, dic);
    }

    private void OnLogOnCallBack(NetWorkHttp.CallBackArgs obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 从登录界面跳转到注册界面
    /// </summary>
    /// <param name="param"></param>
    private void LogOnViewBtnToRegClick(string[] param)
    {
        m_LogOnView.CloseAndOpenNext(WindowUIType.Reg);
    }
    #endregion

    #region 注册界面

    /// <summary>
    /// 注册按钮点击
    /// </summary>
    /// <param name="param"></param>
    private void RegViewBtnRegClick(string[] param)
    {
        if (string.IsNullOrEmpty(m_RegView.txtUserName.text))
        {
            Debug.Log("请输入用户名！");
        }
        if (string.IsNullOrEmpty(m_RegView.txtPwd.text))
        {
            Debug.Log("请输入密码！");
        }

        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic["Type"] = 1;
        dic["UserName"] = m_RegView.txtUserName.text;
        dic["Pwd"] = m_RegView.txtPwd.text;
        dic["ChannelId"] = 0;
        NetWorkHttp.Instance.SendData(GlobalInit.WebAccountUrl + "api/Account", OnRegCallBack, isPost: true, dic);
    }

    /// <summary>
    /// 注册功能的回调函数
    /// </summary>
    /// <param name="obj"></param>
    private void OnRegCallBack(NetWorkHttp.CallBackArgs obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 返回到登录界面
    /// </summary>
    /// <param name="param"></param>
    private void RegViewBtnToLogOnClick(string[] param)
    {
        m_RegView.CloseAndOpenNext(WindowUIType.LogOn);
    }

    #endregion


    public void QuickLogOn()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 打开登录窗口
    /// </summary>
    public void OpenLogOnView()
    {
        UIViewUtil.Instance.LoadWindow(WindowUIType.LogOn.ToString(), (GameObject obj) => { m_LogOnView = obj.GetComponent<UILogOnView>(); });
    }

    /// <summary>
    /// 打开注册窗口
    /// </summary>
    private void OpenRegView()
    {
        UIViewUtil.Instance.LoadWindow(WindowUIType.Reg.ToString(), (GameObject obj) => { m_RegView = obj.GetComponent<UIRegView>(); });
    }

    public void OpenView(WindowUIType type)
    {
        switch (type)
        {
            case WindowUIType.None:
                break;
            case WindowUIType.LogOn:
                OpenLogOnView();
                break;
            case WindowUIType.Reg:
                OpenRegView();
                break;
            case WindowUIType.GameServerEnter:
                break;
            case WindowUIType.GameServerSelect:
                break;
            case WindowUIType.RoleInfo:
                break;
            case WindowUIType.GameLevelMap:
                break;
            case WindowUIType.GameLevelDetail:
                break;
            case WindowUIType.GameLevelVictory:
                break;
            case WindowUIType.GameLevelFail:
                break;
            case WindowUIType.WorldMap:
                break;
            case WindowUIType.WorldMapFail:
                break;
            default:
                break;
        }
    }

    public override void Dispose()
    {
        base.Dispose();

        UIDispatcher.Instance.RemoveEventListener(ConstDefine.UILogOnView_btnLogOn, LogOnViewBtnLogOnClick);
        UIDispatcher.Instance.RemoveEventListener(ConstDefine.UILogOnView_btnToReg, LogOnViewBtnToRegClick);

        UIDispatcher.Instance.RemoveEventListener(ConstDefine.UIRegView_btnReg, RegViewBtnRegClick);
        UIDispatcher.Instance.RemoveEventListener(ConstDefine.UIRegView_btnToLogOn, RegViewBtnToLogOnClick);
    }
}