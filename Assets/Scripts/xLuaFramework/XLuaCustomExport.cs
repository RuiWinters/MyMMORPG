using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class XLuaCustomExport
{
    public delegate void OnCreate(GameObject obj);
    public delegate void NetWorkSendDataCallBack(NetWorkHttp.CallBackArgs obj);
}
