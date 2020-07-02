//===================================================
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// 所有UI视图的基类，UI分成了“场景UI——SceneUI”和“窗口——WindowUI”两大类
/// </summary>
public class UIViewBase : MonoBehaviour
{
    public Action OnShow;

    void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        //绑定按钮的点击事件
        Button[] btnArr = GetComponentsInChildren<Button>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            EventTriggerListener.Get(btnArr[i].gameObject).onClick += BtnClick;
        }
        OnStart();
        if (OnShow != null) OnShow();
    }

    void OnDestroy()
    {
        BeforeOnDestroy();
    }

    /// <summary>
    /// 根据按钮的名称判断是否按钮自身被点击
    /// </summary>
    /// <param name="go"></param>
    private void BtnClick(GameObject go)
    {
        if (!go.name.Equals("BtnSkill1", StringComparison.CurrentCultureIgnoreCase)
            && !go.name.Equals("BtnSkill2", StringComparison.CurrentCultureIgnoreCase)
            && !go.name.Equals("BtnSkill3", StringComparison.CurrentCultureIgnoreCase)
            && !go.name.Equals("BtnAddHP", StringComparison.CurrentCultureIgnoreCase)
            && !go.name.Equals("btnClose", StringComparison.CurrentCultureIgnoreCase)
            )
        {
            AudioEffectMgr.Instance.PlayUIAudioEffect(UIAudioEffectType.ButtonClick);
        }
        
        OnBtnClick(go);
    }

    #region 生命周期函数
    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void BeforeOnDestroy() { }
    protected virtual void OnBtnClick(GameObject go) { }
    #endregion
}