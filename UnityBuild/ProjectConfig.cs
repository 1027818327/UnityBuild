using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityBuild
{
    [Serializable]
    class ProjectConfig
    {
        public string mUnityPath = @"C:\Program Files\Unity\Editor\Unity.exe";
        public string mPCPath = "";
        public string mAndroidPath = "";
        public string mIosPath = "";
        public string mHaoYaPath = "";
        public string mMacXcodePath = "";
    }

    [Serializable]
    class ProjectAttribute
    {
        public string mProjectName = "新景德镇麻将";
        public string mNameSpace = "JDZSparrow";
    }
}
