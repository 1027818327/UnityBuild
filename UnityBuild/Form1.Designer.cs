using System.IO;
using System.Windows.Forms;

namespace UnityBuild
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ProjectConfig mConfig = null;
        private ProjectAttribute mProject = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ReadConfig()
        {
            string tempPath = Directory.GetCurrentDirectory() + "/config";
            if (Directory.Exists(tempPath) == false)
            {
                Directory.CreateDirectory(tempPath);
            }

            try
            {
                if (mConfig == null)
                {
                    mConfig = new ProjectConfig();
                }
                string tempStr = File.ReadAllText(tempPath + "/config.txt");
                if (string.IsNullOrEmpty(tempStr) == false)
                {
                    SimpleJSON.JSONNode tempNode = SimpleJSON.JSON.Parse(tempStr);
                    mConfig.mUnityPath = tempNode["mUnityPath"];
                    mConfig.mPCPath = tempNode["mPCPath"];
                    mConfig.mAndroidPath = tempNode["mAndroidPath"];
                    mConfig.mIosPath = tempNode["mIosPath"];
                    mConfig.mHaoYaPath = tempNode["mHaoYaPath"];
                    mConfig.mMacXcodePath = tempNode["mMacXcodePath"];
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                if (mProject == null)
                {
                    mProject = new ProjectAttribute();
                }
                string tempStr = File.ReadAllText(tempPath + "/project.txt");
                if (string.IsNullOrEmpty(tempStr) == false)
                {
                    SimpleJSON.JSONNode tempNode = SimpleJSON.JSON.Parse(tempStr);
                    mProject.mProjectName = tempNode["mProjectName"];
                    mProject.mNameSpace = tempNode["mNameSpace"];
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetupConfig()
        {
            mUnityLabel.Text = mConfig.mUnityPath;
            mPCFolder.Text = mConfig.mPCPath;
            mAndroidFolder.Text = mConfig.mAndroidPath;
            mIosFolder.Text = mConfig.mIosPath;
            mHaoYaLabel.Text = mConfig.mHaoYaPath;
            mMacXcodeFolder.Text = mConfig.mMacXcodePath;

            string tempProjectName = "空";
            if (string.IsNullOrEmpty(mProject.mProjectName) == false)
            {
                tempProjectName = mProject.mProjectName;
            }
            string tempNameSpace = "无";
            if (string.IsNullOrEmpty(mProject.mNameSpace) == false)
            {
                tempNameSpace = mProject.mNameSpace;
            }
            this.Text = string.Format("项目:{0}    命名空间:{1}", tempProjectName, tempNameSpace);
        }

        public void WriteConfig()
        {
            mConfig.mUnityPath = GetJsonStr(mUnityLabel.Text);
            mConfig.mPCPath = GetJsonStr(mPCFolder.Text);
            mConfig.mAndroidPath = GetJsonStr(mAndroidFolder.Text);
            mConfig.mIosPath = GetJsonStr(mIosFolder.Text);
            mConfig.mHaoYaPath = GetJsonStr(mHaoYaLabel.Text);
            mConfig.mMacXcodePath = GetJsonStr(mMacXcodeFolder.Text);

            string tempPath = Directory.GetCurrentDirectory() + "/config";
            if (Directory.Exists(tempPath) == false)
            {
                Directory.CreateDirectory(tempPath);
            }

            System.Text.StringBuilder tempSb = new System.Text.StringBuilder();
            try
            {
                tempSb.Append("{");

                tempSb.Append("\"mUnityPath\":\"");
                tempSb.Append(mConfig.mUnityPath);
                tempSb.Append("\",");

                tempSb.Append("\"mPCPath\":\"");
                tempSb.Append(mConfig.mPCPath);
                tempSb.Append("\",");

                tempSb.Append("\"mAndroidPath\":\"");
                tempSb.Append(mConfig.mAndroidPath);
                tempSb.Append("\",");

                tempSb.Append("\"mIosPath\":\"");
                tempSb.Append(mConfig.mIosPath);
                tempSb.Append("\",");

                tempSb.Append("\"mHaoYaPath\":\"");
                tempSb.Append(mConfig.mHaoYaPath);
                tempSb.Append("\",");

                tempSb.Append("\"mMacXcodePath\":\"");
                tempSb.Append(mConfig.mMacXcodePath);
                tempSb.Append("\",");

                tempSb.Append("\"end\":\"end0\"}");

                File.WriteAllText(tempPath + "/config.txt", tempSb.ToString());
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }

            tempSb.Clear();
            try
            {
                tempSb.Append("{");

                tempSb.Append("\"mProjectName\":\"");
                tempSb.Append(mProject.mProjectName);
                tempSb.Append("\",");

                tempSb.Append("\"mNameSpace\":\"");
                tempSb.Append(mProject.mNameSpace);
                tempSb.Append("\",");

                tempSb.Append("\"end\":\"end0\"}");

                File.WriteAllText(tempPath + "/project.txt", tempSb.ToString());
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        string GetJsonStr(string varStr)
        {
            string tempS = "";
            if (string.IsNullOrEmpty(varStr) == false)
            {
                tempS = varStr.Replace(@"\", @"\\");
            }
            return tempS;
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.mHaoYaLabel = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.mSaveButton = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.mMacXcodeFolder = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.mIosFolder = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.mAndroidFolder = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.mPCFolder = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.mUnityLabel = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel6);
            this.panel1.Controls.Add(this.linkLabel5);
            this.panel1.Controls.Add(this.linkLabel4);
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.mHaoYaLabel);
            this.panel1.Controls.Add(this.button15);
            this.panel1.Controls.Add(this.mSaveButton);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.mMacXcodeFolder);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.mIosFolder);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.mAndroidFolder);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.mPCFolder);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.mUnityLabel);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 704);
            this.panel1.TabIndex = 0;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel6.Location = new System.Drawing.Point(678, 580);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(40, 16);
            this.linkLabel6.TabIndex = 29;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "跳转";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToMac);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel5.Location = new System.Drawing.Point(678, 431);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(40, 16);
            this.linkLabel5.TabIndex = 28;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "跳转";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToIOS);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel4.Location = new System.Drawing.Point(678, 286);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(40, 16);
            this.linkLabel4.TabIndex = 27;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "跳转";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToAndroid);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel3.Location = new System.Drawing.Point(678, 140);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(40, 16);
            this.linkLabel3.TabIndex = 26;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "跳转";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToPC);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(678, 74);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(40, 16);
            this.linkLabel2.TabIndex = 25;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "跳转";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToHaoYa);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(678, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 16);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "跳转";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JumpToUnity);
            // 
            // mHaoYaLabel
            // 
            this.mHaoYaLabel.AutoSize = true;
            this.mHaoYaLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mHaoYaLabel.Location = new System.Drawing.Point(166, 76);
            this.mHaoYaLabel.Name = "mHaoYaLabel";
            this.mHaoYaLabel.Size = new System.Drawing.Size(49, 14);
            this.mHaoYaLabel.TabIndex = 23;
            this.mHaoYaLabel.Text = "初始值";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(17, 70);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(131, 29);
            this.button15.TabIndex = 22;
            this.button15.Text = "1.2选择好压安装目录";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.ChooseHaoYaFolder);
            // 
            // mSaveButton
            // 
            this.mSaveButton.Location = new System.Drawing.Point(660, 665);
            this.mSaveButton.Name = "mSaveButton";
            this.mSaveButton.Size = new System.Drawing.Size(75, 36);
            this.mSaveButton.TabIndex = 17;
            this.mSaveButton.Text = "保存配置";
            this.mSaveButton.UseVisualStyleBackColor = true;
            this.mSaveButton.Click += new System.EventHandler(this.SavaConfig);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(17, 626);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(253, 51);
            this.button14.TabIndex = 21;
            this.button14.Text = "5.1将Xcode工程压缩为zip拷贝到Mac电脑";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.CompressXcodeAndCopyToMac);
            // 
            // mMacXcodeFolder
            // 
            this.mMacXcodeFolder.AutoSize = true;
            this.mMacXcodeFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mMacXcodeFolder.Location = new System.Drawing.Point(207, 573);
            this.mMacXcodeFolder.Name = "mMacXcodeFolder";
            this.mMacXcodeFolder.Size = new System.Drawing.Size(49, 14);
            this.mMacXcodeFolder.TabIndex = 20;
            this.mMacXcodeFolder.Text = "初始值";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(17, 567);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(174, 29);
            this.button13.TabIndex = 19;
            this.button13.Text = "5.选择Mac电脑Xcode项目路径";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.ChooseMacXcodeFolder);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(311, 626);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(223, 51);
            this.button12.TabIndex = 18;
            this.button12.Text = "5.2复制资源到Mac电脑Xcode";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.CopyResToMacXcode);
            // 
            // mIosFolder
            // 
            this.mIosFolder.AutoSize = true;
            this.mIosFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mIosFolder.Location = new System.Drawing.Point(166, 433);
            this.mIosFolder.Name = "mIosFolder";
            this.mIosFolder.Size = new System.Drawing.Size(49, 14);
            this.mIosFolder.TabIndex = 16;
            this.mIosFolder.Text = "初始值";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 427);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(131, 29);
            this.button11.TabIndex = 15;
            this.button11.Text = "4.选择IOS项目路径";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.ChooseIOSFolder);
            // 
            // mAndroidFolder
            // 
            this.mAndroidFolder.AutoSize = true;
            this.mAndroidFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mAndroidFolder.Location = new System.Drawing.Point(166, 286);
            this.mAndroidFolder.Name = "mAndroidFolder";
            this.mAndroidFolder.Size = new System.Drawing.Size(49, 14);
            this.mAndroidFolder.TabIndex = 14;
            this.mAndroidFolder.Text = "初始值";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(17, 282);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(131, 29);
            this.button10.TabIndex = 13;
            this.button10.Text = "3.选择安卓项目路径";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ChooseAndroidFolder);
            // 
            // mPCFolder
            // 
            this.mPCFolder.AutoSize = true;
            this.mPCFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mPCFolder.Location = new System.Drawing.Point(166, 133);
            this.mPCFolder.Name = "mPCFolder";
            this.mPCFolder.Size = new System.Drawing.Size(49, 14);
            this.mPCFolder.TabIndex = 12;
            this.mPCFolder.Text = "初始值";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(17, 127);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 29);
            this.button9.TabIndex = 9;
            this.button9.Text = "2.选择PC项目路径";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ChoosePCFolder);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(17, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(131, 29);
            this.button8.TabIndex = 8;
            this.button8.Text = "1.选择Unity安装目录";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ChooseUnityFolder);
            // 
            // mUnityLabel
            // 
            this.mUnityLabel.AutoSize = true;
            this.mUnityLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mUnityLabel.Location = new System.Drawing.Point(166, 12);
            this.mUnityLabel.Name = "mUnityLabel";
            this.mUnityLabel.Size = new System.Drawing.Size(49, 14);
            this.mUnityLabel.TabIndex = 7;
            this.mUnityLabel.Text = "初始值";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(17, 482);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 51);
            this.button7.TabIndex = 6;
            this.button7.Text = "4.1导出Xcode";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ExportXcode);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 335);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 51);
            this.button6.TabIndex = 5;
            this.button6.Text = "3.1导出安卓包";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ExportAndroid);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(615, 191);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 51);
            this.button5.TabIndex = 4;
            this.button5.Text = "压缩电脑包";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.CompressPC);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(467, 191);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 51);
            this.button4.TabIndex = 3;
            this.button4.Text = "运行3个电脑包";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.RunPC3);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "运行2个电脑包";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RunPC2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "运行1个电脑包";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RunPC1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "2.1导出电脑包";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExportPC);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Unity.exe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 708);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnityBuild";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private Label mUnityLabel;
        private OpenFileDialog openFileDialog1;
        private Button button8;
        private Button button9;
        private Label mPCFolder;
        private Label mAndroidFolder;
        private Button button10;
        private Label mIosFolder;
        private Button button11;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button mSaveButton;
        private Button button12;
        private Button button13;
        private Label mMacXcodeFolder;
        private Button button14;
        private Button button15;
        private Label mHaoYaLabel;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel4;
    }
}