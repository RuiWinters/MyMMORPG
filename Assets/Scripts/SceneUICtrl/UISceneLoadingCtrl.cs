using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Loading场景UI控制器
/// </summary>
public class UISceneLoadingCtrl : UISceneViewBase
{
    /// <summary>
    /// 进度条
    /// </summary>
    [SerializeField]
    private Slider m_SliderProgress;

    /// <summary>
    /// 进度条上的文本
    /// </summary>
    [SerializeField]
    private Text m_TextProgress;

    protected override void OnStart()
    {
        base.OnStart();

        if (m_SliderProgress == null)
        {
            m_SliderProgress = Container_Center.Find("SliderLoading").GetComponent<Slider>();
        }
        if (m_TextProgress == null)
        {
            m_TextProgress = Container_Center.Find("TextProgress").GetComponent<Text>();
        }
    }

    /// <summary>
    /// 设置进度条的值
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        if (m_SliderProgress == null || m_TextProgress == null)
        {
            AppDebug.LogError("m_SliderProgress或m_TextProgress没配置");
            return;
        }
            
        m_SliderProgress.value = value;
        m_TextProgress.text = string.Format("{0}%", (int)(value * 100));

        //m_ProgressLight.transform.localPosition = new Vector3(880 * value, 0, 0);
    }

    protected override void BeforeOnDestroy()
    {
        base.BeforeOnDestroy();
        m_SliderProgress = null;
        m_TextProgress = null;
        //m_ProgressLight = null;
    }
}