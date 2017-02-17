using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class UsingPluginsExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void UseBytesArray()
    {
        byte[] bundleData = new byte[100];
        // encrypt bundle
        uint datalength = (uint)bundleData.Length;
        var dataPtr = GCHandle.Alloc(bundleData, GCHandleType.Pinned);
        //if (!DLLByteFunction(dataPtr.AddrOfPinnedObject(), datalength))
        //{
        //    Debug.LogError("In Data Error");
        //}
        dataPtr.Free();
    }
}
