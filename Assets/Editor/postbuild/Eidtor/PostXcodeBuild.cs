using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace PostBuild
{
    public class PostXcodeBuild
    {
        [PostProcessBuild]
        public static void SetXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
        {
            Debug.Log(">>> SetXcodePlist");
            if (buildTarget != BuildTarget.iOS) {
                Debug.Log("BuildTarget is not iOS buildTarget = " + buildTarget);
                return;
            } 

            var plistPath = pathToBuiltProject + "/Info.plist";
            var plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            var rootDict = plist.root;
            // ここに記載したKey-ValueがXcodeのinfo.plistに反映されます
            rootDict.SetString("GADApplicationIdentifier", "hogehoge");

            File.WriteAllText(plistPath, plist.WriteToString());

            Debug.Log("<<< SetXcodePlist");
        }
    }
}

