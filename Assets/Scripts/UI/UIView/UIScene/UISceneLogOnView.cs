using UnityEngine;
using System.Collections;

/// <summary>
/// 登录 场景UI 视图
/// </summary>
public class UISceneLogOnView : UISceneViewBase
{
    protected override void OnStart()
    {
        base.OnStart();
        StartCoroutine(OpenLogOnWindow());
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(.2f);
        UIViewMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }
}