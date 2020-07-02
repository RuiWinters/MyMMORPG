using UnityEngine;
using System.Collections;

/// <summary>
/// 在发布版本屏蔽Debug.log输出的Log
/// 可以在菜单栏工具中开启和关闭
/// 宏定义 请看SettingsWindow.cs
/// </summary>
public class AppDebug
{
    public static void Log(object message)
    {
#if DEBUG_LOG
        Debug.Log(message);
#endif
    }

    public static void LogError(object message)
    {
#if DEBUG_LOG
        Debug.LogError(message);
#endif
    }
}