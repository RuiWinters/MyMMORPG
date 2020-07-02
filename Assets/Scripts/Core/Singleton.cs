using UnityEngine;
using System.Collections;
using System;

public class Singleton<T> : IDisposable where T :new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    //public static T GetInstance
    //{
    //    get
    //    {
    //        lock (_instance)
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new T();
    //            }
    //        }
    //        return _instance;
    //    }
    //}

    public virtual void Dispose()
    {
        
    }
}