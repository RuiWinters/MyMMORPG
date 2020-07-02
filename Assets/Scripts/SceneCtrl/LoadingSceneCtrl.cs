using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneCtrl : MonoBehaviour
{
    /// <summary>
    /// ����UI������
    /// </summary>
    [SerializeField]
    private UISceneLoadingCtrl m_UILoadingCtrl;

    private AsyncOperation m_Async = null;

    /// <summary>
    /// ��ǰ����
    /// </summary>
    private int m_CurrProgress = 0;

    void Start()
    {
        try
        {
            if (!m_UILoadingCtrl)
            {
                m_UILoadingCtrl = GameObject.Find("LoadingSceneCtrl").GetComponent<UISceneLoadingCtrl>();
            }
            LayerUIMgr.Instance.Reset();
            StartCoroutine(LoadingScene());
        }
        catch (System.Exception e)
        {
            AppDebug.Log(e.Message);
        }
    }

    private IEnumerator LoadingScene()
    {
        string strSceneName = string.Empty;
        switch (SceneMgr.Instance.CurrSceneType)
        {
            case SceneType.LogOn:
                strSceneName = "Scene_LogOn";
                break;
            case SceneType.SelectRole:
                strSceneName = "Scene_SelectRole";
                break;
            case SceneType.WorldMap:
                strSceneName = "Scene_WorldMap";
                break;
            case SceneType.GameLevel:
                strSceneName = "Scene_GameLevel";
                break;
            default:
                break;
        }

        m_Async = SceneManager.LoadSceneAsync(strSceneName);
        //�Ȳ������л����ȵȽ�����
        m_Async.allowSceneActivation = false;
        yield return m_Async;
    }

    // Update is called once per frame
    void Update()
    {
        int toProgress = 0;
        //����ʱ��progressֻ�ܵ�0.9
        if (m_Async.progress < 0.9f)
        {
            toProgress = (int)(m_Async.progress * 100);
        }
        else
        {
            toProgress = 100;
        }

        if (m_CurrProgress < toProgress)
        {
            m_CurrProgress++;
        }
        else
        {
            m_Async.allowSceneActivation = true;
        }
        m_UILoadingCtrl.SetProgressValue(m_CurrProgress * 0.01f);
    }
}
