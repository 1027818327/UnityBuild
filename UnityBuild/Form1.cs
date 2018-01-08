using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace UnityBuild
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadConfig();
            SetupConfig();
        }

        private void PrepareBasePcCommand(ref StringBuilder varSb)
        {
            varSb.Append("set unity=\"");
            varSb.Append(mUnityLabel.Text);
            varSb.AppendLine("\"");

            varSb.Append("set projectPath=");
            varSb.Append(mPCFolder.Text);
            varSb.AppendLine(@"\");
        }

        private void PrepareBaseAndroidCommand(ref StringBuilder varSb)
        {
            varSb.Append("set unity=\"");
            varSb.Append(mUnityLabel.Text);
            varSb.AppendLine("\"");

            varSb.Append("set projectPath=");
            varSb.Append(mAndroidFolder.Text);
            varSb.AppendLine(@"\");
        }

        private void PrepareBaseIosCommand(ref StringBuilder varSb)
        {
            varSb.Append("set unity=\"");
            varSb.Append(mUnityLabel.Text);
            varSb.AppendLine("\"");

            varSb.Append("set projectPath=");
            varSb.Append(mIosFolder.Text);
            varSb.AppendLine(@"\");
        }

        private void WirteTempFileAndRun(string varStr)
        {
            string tempPath = Directory.GetCurrentDirectory() + "/config/temp.bat";
            File.WriteAllText(tempPath, varStr, Encoding.GetEncoding("gbk"));
            Tool.RunCmd(tempPath);
        }

        private void ExportPC(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mUnityLabel.Text))
            {
                MessageBox.Show("Unity安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mPCFolder.Text))
            {
                MessageBox.Show("PC项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            StringBuilder tempSb = new StringBuilder();
            PrepareBasePcCommand(ref tempSb);

            tempSb.Append("%unity% -batchmode -projectPath %projectPath% -executeMethod ");
            if (string.IsNullOrEmpty(mProject.mNameSpace))
            {
                tempSb.AppendLine("BuildTool.BuildPC -quit");
            }
            else
            {
                tempSb.Append(mProject.mNameSpace);
                tempSb.AppendLine(".BuildTool.BuildPC -quit");
            }

            WirteTempFileAndRun(tempSb.ToString());
        }

        private void RunWindow(uint varNum)
        {
            if (string.IsNullOrEmpty(mPCFolder.Text))
            {
                MessageBox.Show("PC项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            string tempPath = @"\Windows\game.exe";
            tempPath = mPCFolder.Text + tempPath;
            for (uint i = 0; i < varNum; i++)
            {
                Tool.RunCmd(tempPath);
            }
        }

        private void RunPC1(object sender, EventArgs e)
        {
            RunWindow(1);
        }

        private void RunPC2(object sender, EventArgs e)
        {
            RunWindow(2);
        }

        private void RunPC3(object sender, EventArgs e)
        {
            RunWindow(3);
        }

        private void CompressPC(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mPCFolder.Text))
            {
                MessageBox.Show("PC项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mHaoYaLabel.Text))
            {
                MessageBox.Show("好压安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            StringBuilder tempSb = new StringBuilder();
            tempSb.Append("set path=");
            tempSb.Append(mPCFolder.Text);
            tempSb.AppendLine(@"\");

            tempSb.AppendLine("rem 取得好压程序位置");
            //tempSb.AppendLine(@"set haozip=C:\Program Files\2345Soft\HaoZip\HaoZipC.exe");
            tempSb.Append("set haozip=");
            tempSb.AppendLine(mHaoYaLabel.Text);

            tempSb.AppendLine("rem 取得PC压缩包路径");
            tempSb.AppendLine(@"set zipPath=E:\JXZC_Publish_Game\Windows");
            tempSb.AppendLine("rem 取得项目名称");
            tempSb.Append("set projectName=");
            tempSb.AppendLine(mProject.mProjectName);
            tempSb.AppendLine("rem 取得当前年月日时分");
            tempSb.AppendLine("set year=%date:~0,4%");
            tempSb.AppendLine("set month=%date:~5,2%");
            tempSb.AppendLine("set day=%date:~8,2%");
            tempSb.AppendLine("set hour=%time:~0,2%");
            tempSb.AppendLine("set minute=%time:~3,2%");
            tempSb.AppendLine("rem 小于10的小时首位要补0");
            tempSb.AppendLine("set hour=%hour: =0%");
            tempSb.AppendLine(@"set zipFile=%zipPath%\%projectName%_%year%%month%%day%%hour%%minute%.zip");
            tempSb.AppendLine("if exist %zipFile% del %zipFile%");
            tempSb.AppendLine("rem 开始压缩");
            tempSb.Append("\"%haozip%\" a -tzip %zipFile%");
            tempSb.Append(" \"");
            tempSb.Append(@"%path%Windows\*");
            tempSb.AppendLine("\"");

            tempSb.Append("\"");
            tempSb.Append(@"C:\Windows\explorer.exe");
            tempSb.Append("\"");
            tempSb.AppendLine(" %zipPath%");

            WirteTempFileAndRun(tempSb.ToString());
        }

        private void ChooseUnityFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = openFileDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
                mUnityLabel.Text = openFileDialog1.FileName;
            }
        }

        private void ChoosePCFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = folderBrowserDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
               mPCFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ChooseAndroidFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = folderBrowserDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
                mAndroidFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ChooseIOSFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = folderBrowserDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
                mIosFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SavaConfig(object sender, EventArgs e)
        {
            WriteConfig();
        }

        private void ExportAndroid(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mUnityLabel.Text))
            {
                MessageBox.Show("Unity安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mAndroidFolder.Text))
            {
                MessageBox.Show("安卓项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            StringBuilder tempSb = new StringBuilder();
            tempSb.Append("svn update ");
            tempSb.AppendLine(mAndroidFolder.Text);

            PrepareBaseAndroidCommand(ref tempSb);

            tempSb.Append("%unity% -batchmode -projectPath %projectPath% -executeMethod ");
            if (string.IsNullOrEmpty(mProject.mNameSpace))
            {
                tempSb.AppendLine("BuildTool.BuildAndroid -quit");
            }
            else
            {
                tempSb.Append(mProject.mNameSpace);
                tempSb.AppendLine(".BuildTool.BuildAndroid -quit");
            }

            WirteTempFileAndRun(tempSb.ToString());
        }

        private void ExportXcode(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mUnityLabel.Text))
            {
                MessageBox.Show("Unity安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mIosFolder.Text))
            {
                MessageBox.Show("Ios项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            StringBuilder tempSb = new StringBuilder();
            tempSb.Append("svn update ");
            tempSb.AppendLine(mIosFolder.Text);
            PrepareBaseIosCommand(ref tempSb);

            tempSb.Append("%unity% -batchmode -projectPath %projectPath% -executeMethod ");
            if (string.IsNullOrEmpty(mProject.mNameSpace))
            {
                tempSb.AppendLine("BuildTool.BuildIOS -quit");
            }
            else
            {
                tempSb.Append(mProject.mNameSpace);
                tempSb.AppendLine(".BuildTool.BuildIOS -quit");
            }

            WirteTempFileAndRun(tempSb.ToString());
        }

        private void ChooseMacXcodeFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = folderBrowserDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
                mMacXcodeFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void CopyResToMacXcode(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mIosFolder.Text))
            {
                MessageBox.Show("Ios项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mMacXcodeFolder.Text))
            {
                MessageBox.Show("Mac电脑Xcode项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }

            string tempMacXcodeFolder = mMacXcodeFolder.Text;
            string tempNativePath = tempMacXcodeFolder + "/Classes/Native";
            string tempDataPath = tempMacXcodeFolder + "/Data";
            Tool.DeleteDirectory(tempNativePath);
            Tool.DeleteDirectory(tempDataPath);

            Tool.CreateDirectory(tempNativePath);
            Tool.CreateDirectory(tempDataPath);

            string tempXcodeFolder = mIosFolder.Text + @"\XcodeProject";
            Tool.CopyDir(tempXcodeFolder + "/Classes/Native", tempNativePath);
            Tool.CopyDir(tempXcodeFolder + "/Data", tempDataPath);

            Process proc = new Process();
            proc.StartInfo.FileName = tempMacXcodeFolder;
            proc.Start();
        }

        private void ChooseHaoYaFolder(object sender, EventArgs e)
        {
            DialogResult tempDr = openFileDialog1.ShowDialog();
            if (tempDr == DialogResult.OK)
            {
                mHaoYaLabel.Text = openFileDialog1.FileName;
            }
        }

        private void CompressXcodeAndCopyToMac(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mHaoYaLabel.Text))
            {
                MessageBox.Show("好压安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mIosFolder.Text))
            {
                MessageBox.Show("Ios项目路径不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(mMacXcodeFolder.Text))
            {
                MessageBox.Show("好压安装目录不能为空", "警告", MessageBoxButtons.OK);
                return;
            }
            
            StringBuilder tempSb = new StringBuilder();
            tempSb.Append("set path=");
            tempSb.Append(mIosFolder.Text);
            tempSb.AppendLine(@"\");

            tempSb.AppendLine("rem 取得好压程序位置");
            //tempSb.AppendLine(@"set haozip=C:\Program Files\2345Soft\HaoZip\HaoZipC.exe");
            tempSb.Append("set haozip=");
            tempSb.AppendLine(mHaoYaLabel.Text);

            tempSb.AppendLine("rem 取得PC压缩包路径");
            tempSb.AppendLine(@"set zipPath=E:\JXZC_Publish_Game");

            tempSb.AppendLine("rem 取得Mac压缩包路径");
            tempSb.Append("set zipMacPath=");
            int tempIndex = mMacXcodeFolder.Text.LastIndexOf(@"\");
            tempSb.AppendLine(mMacXcodeFolder.Text.Substring(0, tempIndex));

            tempSb.AppendLine("rem 取得项目名称");
            tempSb.AppendLine("set projectName=XcodeProject");
            
            tempSb.AppendLine(@"set zipFile=%zipPath%\%projectName%.zip");
            tempSb.AppendLine("if exist %zipFile% del %zipFile%");
            tempSb.AppendLine("rem 开始压缩");
            tempSb.Append("\"%haozip%\" a -tzip %zipFile%");
            tempSb.Append(" \"");
            tempSb.Append(@"%path%XcodeProject\*");
            tempSb.AppendLine("\"");

            tempSb.AppendLine("rem 复制到Mac电脑");
            tempSb.AppendLine(@"set zipMacFile=%zipMacPath%\%projectName%.zip");
            tempSb.AppendLine("if exist %zipMacFile% del %zipMacFile%");
            tempSb.AppendLine("copy %zipFile% %zipMacPath%");

            tempSb.Append("\"");
            tempSb.Append(@"C:\Windows\explorer.exe");
            tempSb.Append("\"");
            tempSb.AppendLine(" %zipPath%");

            tempSb.Append("\"");
            tempSb.Append(@"C:\Windows\explorer.exe");
            tempSb.Append("\"");
            tempSb.AppendLine(" %zipMacPath%");

            WirteTempFileAndRun(tempSb.ToString());
        }

        private void JumpToUnity(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int tempIndex = mUnityLabel.Text.LastIndexOf(@"\");
            Tool.JumpToFolder(mUnityLabel.Text.Substring(0, tempIndex));
        }

        private void JumpToHaoYa(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int tempIndex = mHaoYaLabel.Text.LastIndexOf(@"\");
            Tool.JumpToFolder(mHaoYaLabel.Text.Substring(0, tempIndex));
        }

        private void JumpToPC(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tool.JumpToFolder(mPCFolder.Text);
        }

        private void JumpToAndroid(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tool.JumpToFolder(mAndroidFolder.Text);
        }

        private void JumpToIOS(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tool.JumpToFolder(mIosFolder.Text);
        }

        private void JumpToMac(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tool.JumpToFolder(mMacXcodeFolder.Text);
        }
    }
}