/**************************************************************************************
 * 
 *      Function: 打包Editor中选中的文件
 *      Author: xiaoxiao.yang
 *      Data: 2/16/2017
 *      Version: 0.1
 *      
 ***************************************************************************************/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class SelectedFile : Editor 
{
    [MenuItem("Assets/Bundle Select File")]
    private static void BuildSelectFile()
    {
        UnityEngine.Object[] selects = Selection.objects;
        foreach (UnityEngine.Object ob in selects)
        {
            string path = AssetDatabase.GetAssetPath(ob);
            AssetImporter asset = AssetImporter.GetAtPath(path);

            string fileInfor = string.Format("File name: {0}, file path: {1}", ob.name, path);
            Debug.Log(fileInfor);

            asset.assetBundleName = ob.name;
            asset.assetBundleVariant = "bytes";
            asset.SaveAndReimport();
        }
        AssetDatabase.Refresh();
    }
}
