//===================================================
using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 场景UI的基类
/// </summary>
public class UISceneViewBase : UIViewBase
{
    /// <summary>
    /// 当前画布
    /// </summary>
    public Canvas CurrCanvas;

    /// <summary>
    /// 容器_居中
    /// </summary>
    [SerializeField]
    public Transform Container_Center;

    /// <summary>
    /// HUD
    /// </summary>
    //public bl_HUDText HUDText;

    /// <summary>
    /// 加载完毕
    /// </summary>
    public Action<GameObject> OnLoadComplete;

    protected override void OnStart()
    {
        base.OnStart();
        try
        {
            if (!CurrCanvas)
            {
                CurrCanvas = this.transform.GetChild(0).GetComponent<Canvas>();
                Container_Center = transform.Find("Container_Center");
            }
        }
        catch (Exception e)
        {
            AppDebug.LogError(e.Message);
            AppDebug.LogError("请检查CurrCanvas或Container_Center有没有配置");
        }
    }
}