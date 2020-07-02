//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2016-03-12 11:57:06
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    #region 单例
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                DontDestroyOnLoad(obj);
                instance = obj.GetOrCreatComponent<T>();
            }
            return instance;
        }
    }

//    public static T GetInstance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//#if UNITY_EDITOR
//                if (FindObjectsOfType(typeof(T)).Length > 1)
//                {
//                    Debug.LogError("Singleton must be unique");
//                }
//#endif
//                _instance = FindObjectOfType(typeof(T)) as T;

//            }
//            if (_instance == null)
//            {
//                GameObject go = new GameObject(typeof(T).ToString());
//                _instance = go.AddComponent(typeof(T)) as T;
//            }
//            return _instance;
//        }
//    }

    #endregion

    void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }

    void OnDestroy()
    {
        BeforeOnDestroy();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void BeforeOnDestroy() { }


}