using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// </summary>
public class LogOnSceneCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UISceneCtrl.Instance.LoadSceneUI(UISceneCtrl.SceneUIType.LogOn, null, null);
    }
}
