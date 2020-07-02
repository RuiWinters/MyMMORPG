using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSceneCtrl : MonoBehaviour
{
    /// <summary>
    /// �ȴ�������
    /// </summary>
    [SerializeField]
    private float senconds = 2;
    // Start is called before the first frame update
    void Start()
    {
        AudioBackGroundMgr.Instance.Play("Audio_Bg_LogOn");
        //һ��ʱ�������¼
        StartCoroutine(LoadToLogOn(senconds));
    }

    private IEnumerator LoadToLogOn(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneMgr.Instance.LoadToLogOn();
    }
}
