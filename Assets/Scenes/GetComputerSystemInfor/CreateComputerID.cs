/*
 *      Function: 获取计算机的硬件ID地址（系统更新时会变化，待改进）
 *      Date: 2/16/2017
 *      Author: xiaoxiao.yang
 *      Version: 0.1
 */



using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

public class CreateComputerID : MonoBehaviour {

    void WriteResources()
    {
        string hardwareID = "";
        // 显卡信息
        hardwareID += SystemInfo.deviceUniqueIdentifier;
        // 去掉空格
        hardwareID = hardwareID.Trim();
        // 转大写
        hardwareID = hardwareID.ToUpper();

        Debug.Log(hardwareID);
    }
}
