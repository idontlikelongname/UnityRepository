/**************************************************************************************
 * 
 *      Function: 打包文件夹中所有后缀标注的文件
 *      Author: xiaoxiao.yang
 *      Data: 2/16/2017
 *      Version: 0.1
 *      
 ***************************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AllFolderFiles : Editor
{
    private static List<string> assetPathList = new List<string>();
    private static Dictionary<string, string> asExtensionDic = new Dictionary<string, string>();
    private static string assetPath = "__Prefabs";
    private static string assetBundleOutPath = "Assets/StreamingAssets";

    [MenuItem("Assets/Bundle All Folder Files")]
    private static void BuildAllFolderFiles()
    {
        // clear the path list, path list contain all the files in the folder
        assetPathList.Clear();

        // 需要打包文件的后缀
        asExtensionDic.Clear();
        asExtensionDic.Add(".prefab", ".unity3d");

        GetDirs(Application.dataPath + "/" + assetPath);

        // add the windows/android/osx/ios
        string outPath = Path.Combine(assetBundleOutPath, Platform.GetPlatformFolder(EditorUserBuildSettings.activeBuildTarget));
        BuildAsset(outPath);



    }

    private static void GetDirs(string dirPath)
    {
        // directory to be bundled
        foreach (string path in Directory.GetFiles(dirPath))
        {
            if (asExtensionDic.ContainsKey(System.IO.Path.GetExtension(path)))
            {
                string pathReplace = "";

                if (Application.platform == RuntimePlatform.WindowsEditor)
                {
                    pathReplace = path.Replace('\\', '/');
                }

                assetPathList.Add(pathReplace);

                // file path
                Debug.Log(pathReplace);
            }
        }

        if (Directory.GetDirectories(dirPath).Length > 0)
        {
            foreach (string path in Directory.GetDirectories(dirPath))
                GetDirs(path);
        }
    }


    private static void BuildAsset(string outPath)
    {
        Debug.Log("--------------------- bundle asset --------------------------");

        for (int i = 0; i < assetPathList.Count; i++)
        {
            string asPath = assetPathList[i];

            string path = "";

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                // 获取资源文件路径的后半部分
                path = asPath.Substring(asPath.IndexOf("Assets/"));
                Debug.Log(i + " asset to bundle " + path);
            }

            // use the relative path
            AssetImporter assetImporter = AssetImporter.GetAtPath(path);
            if (assetImporter == null)
            {
                Debug.LogWarning("null" + path);
                continue;
            }

            string assetName = asPath.Substring(asPath.IndexOf(assetPath));

            assetName = assetName.Replace(Path.GetExtension(assetName), ".unity3d");
            assetImporter.assetBundleName = assetName;
        }

        if (!Directory.Exists(outPath))
            Directory.CreateDirectory(outPath);

        BuildPipeline.BuildAssetBundles(outPath, 0, EditorUserBuildSettings.activeBuildTarget);

        AssetDatabase.Refresh();
    }
}

public class Platform
{
    public static string GetPlatformFolder(BuildTarget target)
    {
        //        Debug.Log(target);
        switch (target)
        {
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.iOS:
                return "iOS";
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Windows";
            default:
                return null;
        }
    }
}
