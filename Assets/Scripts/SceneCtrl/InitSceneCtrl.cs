using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSceneCtrl : MonoBehaviour
{
    /// <summary>
    /// 等待的秒数
    /// </summary>
    [SerializeField]
    private float senconds = 2;
    // Start is called before the first frame update
    void Start()
    {
        AudioBackGroundMgr.Instance.Play("Audio_Bg_LogOn");
        //一定时间后进入登录
        StartCoroutine(LoadToLogOn(senconds));
    }

    private IEnumerator LoadToLogOn(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneMgr.Instance.LoadToLogOn();
    }
}
