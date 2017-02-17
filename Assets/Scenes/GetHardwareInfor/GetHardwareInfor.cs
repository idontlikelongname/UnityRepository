using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

public class GetHardwareInfor : MonoBehaviour {
    string id = "";
    string urlid = "";
	// Use this for initialization
	void Start () {
        //string id = HardwareInfor.GetHardwareInfor();
        //string id = GetHardwareInforTest();     
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    IEnumerator LoadBundleAndRunExe()
    {
        //WWW www = new WWW("file:///F:/Unity Project/UnityRepository/Assets/StreamingAssets/getexe");
        WWW www = new WWW("http://qingjinghudong-1253224328.costj.myqcloud.com/getidexe");
    
        yield return www;
        AssetBundle bundle = www.assetBundle;
        TextAsset asset = bundle.LoadAsset("GETIDEXE", typeof(TextAsset)) as TextAsset;

        string path = "C:/Users/Public/Downloads";
        path = Path.Combine(path, "temp.exe");
        try
        {
            // create exe file
            File.WriteAllBytes(path, asset.bytes);
            // run exe file
            RunExe(path);
            // delete exe
            if (File.Exists(path))
                File.Delete(path);
        }
        catch
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }

    void RunExe(string exepath)
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();

        process.EnableRaisingEvents = false;
        process.StartInfo.FileName = exepath;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.Start();
        id = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
    }


    public IEnumerator ConnectServer()
    {
        string dllurl = "http://qingjinghudong-1253224328.costj.myqcloud.com/unitylibrary_version2";

        WWW dllrequest = new WWW(dllurl);
        yield return dllrequest;

        AssetBundle bundle = dllrequest.assetBundle;
        TextAsset asset = bundle.LoadAsset("UnityLibrary", typeof(TextAsset)) as TextAsset;

        System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(asset.bytes);
        Type script = assembly.GetType("CheckoutComputer");

        gameObject.AddComponent(script);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 300, 30), id);

        if (GUI.Button(new Rect(100, 200, 100, 30), "Load"))
            StartCoroutine(LoadBundleAndRunExe());

        if (GUI.Button(new Rect(100, 300, 100, 30), "Load From URL"))
            StartCoroutine(ConnectServer());
    }
}
