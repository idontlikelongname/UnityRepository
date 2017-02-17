/* 
 *      Function: 从Unity中读取各种数据，.txt .bytes .bundle .unity3d
 *      Author: xiaoxiao.yang
 *      Data: 2/16/2017
 *      Version: 0.1
 *
 */

using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class FileIO : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    /**
     * 
     * 从Resources中读取二进制文档
     *
     */
    void ReadResources()
    {
        //string path = Application.dataPath;
        TextAsset textasset = (TextAsset)Resources.Load("out", typeof(TextAsset));
        string content = System.Text.Encoding.Default.GetString(textasset.bytes);
        Debug.Log(content);
        Debug.Log(textasset.text);
    }


    /**
     * 
     * 从本地文件夹中通过www的形式读取打包后的资源，资源可以是mananged dll，要求dll在打包之前把后缀名改为.bytes
     * 
     */
    IEnumerator loadDllScript()
    {
        WWW www = new WWW("file:///F:/Unity Project/GetComputerID/Assets/AssetbundleOut/unitylibrary");
        yield return www;
        AssetBundle bundle = www.assetBundle;
        TextAsset asset = bundle.LoadAsset("UnityLibrary", typeof(TextAsset)) as TextAsset;

        System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(asset.bytes);
        Type function = assembly.GetType("Function");
        gameObject.AddComponent(function);
    }


    /**
     * 
     * 把文档保存在文件夹下
     * 
     */
    void WriteResources()
    {
        string path = Path.Combine(Application.dataPath, "StreamingAssets/out");
        if(!File.Exists(path))
        {
            File.Create(path);
        }

        StreamWriter sw;
        FileInfo fi = new FileInfo(path);
        if(!fi.Exists)
        {
            sw = fi.CreateText();
        }
        else
        {
            sw = fi.AppendText();
        }
        sw.WriteLine("This is output test");
        sw.Close();
        sw.Dispose();
    }
}
