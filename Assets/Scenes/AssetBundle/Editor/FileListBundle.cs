using UnityEngine;
/**************************************************************************************
 * 
 *      Function: 打包指定的文件
 *      Author: xiaoxiao.yang
 *      Data: 2/16/2017
 *      Version: 0.1
 *      
 ***************************************************************************************/

using UnityEditor;
using System.Collections;
using System.IO;

public class FileListBundle : Editor
{
    [MenuItem("Assets/Bundle File List")]
    static void BuildABs()
    {
        // Create the array of bundle build details.
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        buildMap[0].assetBundleName = "UnityLibrary";     //打包的资源包名称 随便命名
        string[] resourcesAssets = new string[1];               //此资源包下面有多少文件
        resourcesAssets[0] = "Assets/Resources/UnityLibrary.bytes";
        buildMap[0].assetNames = resourcesAssets;
        if (!Directory.Exists("Assets/StreamingAssets"))
            Directory.CreateDirectory("Assets/StreamingAssets");
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", buildMap);
    }
}
