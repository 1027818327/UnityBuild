using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityBuild
{
    class Tool
    {
        /// <summary>
        /// 运行cmd命令
        /// 会显示命令窗口
        public static void RunCmd(string varFile)
        {
            Process.Start(varFile);
        }

        public static void JumpToFolder(string varPath)
        {
            Process.Start("explorer.exe", varPath);
        }

        /// <summary>
        /// 发现文件夹不存在，则创建.
        /// </summary>
        /// <returns><c>true</c>, if directory was created, <c>false</c> otherwise.</returns>
        /// <param name="tempPath">Temp path.</param>
        public static bool CreateDirectory(string tempPath)
        {
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除目录.
        /// </summary>
        /// <param name="varPath">Variable path.</param>
        public static bool DeleteDirectory(string varPath)
        {
            bool tempResult = false;
            try
            {
                if (Directory.Exists(varPath) == true)
                {
                    Directory.Delete(varPath, true);
                }
                tempResult = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return tempResult;
        }

        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加;
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                {
                    aimPath += Path.DirectorySeparatorChar;
                }
                CreateDirectory(aimPath);

                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组,只获得当前目录下的目录和文件，取不到子目录;
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录;
                for (int i = 0; i < fileList.Length; i++)
                {
                    string tempFile = fileList[i];
                    if (Directory.Exists(tempFile))
                    {
                        CopyDir(tempFile, aimPath + Path.GetFileName(tempFile));
                    }
                    else
                    {
                        // 直接copy文件;
                        File.Copy(tempFile, aimPath + Path.GetFileName(tempFile), true);
                    }
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
