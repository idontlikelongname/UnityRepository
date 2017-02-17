/**************************************************************************************
 * 
 *      Function: 删除打包后生成的.pdb文件
 *      Author: xiaoxiao.yang
 *      Data: 2/16/2017
 *      Version: 0.1
 *      
 ***************************************************************************************/

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

//public class PostProcessBuild
//{
//    //[PostProcessBuildAttribute(1)]
//    //public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
//    //{
//    //    if (target == BuildTarget.StandaloneWindows || target == BuildTarget.StandaloneWindows64)
//    //    {
//    //        // remove these annoying PDB files as we don't want to debug stand alone builds!
//    //        string pureBuildPath = Path.GetDirectoryName(pathToBuiltProject);
//    //        foreach (string file in Directory.GetFiles(pureBuildPath, "*.pdb"))
//    //        {
//    //            Debug.Log(file + " deleted!");
//    //            File.Delete(file);
//    //        }
//    //    }
//    //}
//}
