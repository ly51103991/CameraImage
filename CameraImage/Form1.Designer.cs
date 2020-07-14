namespace CameraImage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TrueNum = new System.Windows.Forms.Label();
            this.WrongNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.allNum = new System.Windows.Forms.Label();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.modelList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timeCam = new System.Windows.Forms.Label();
            this.lazyTime = new System.Windows.Forms.TextBox();
            this.yuZhi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yuZhi)).BeginInit();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 1280, 1024);
            this.hWindowControl1.Location = new System.Drawing.Point(100, 49);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(640, 512);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(640, 512);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(907, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "开启";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RealTimeSnap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(1007, 515);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 54);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // TrueNum
            // 
            this.TrueNum.AutoSize = true;
            this.TrueNum.Font = new System.Drawing.Font("宋体", 12F);
            this.TrueNum.Location = new System.Drawing.Point(954, 621);
            this.TrueNum.Name = "TrueNum";
            this.TrueNum.Size = new System.Drawing.Size(16, 16);
            this.TrueNum.TabIndex = 8;
            this.TrueNum.Text = "0";
            // 
            // WrongNum
            // 
            this.WrongNum.AutoSize = true;
            this.WrongNum.Font = new System.Drawing.Font("宋体", 12F);
            this.WrongNum.Location = new System.Drawing.Point(1067, 621);
            this.WrongNum.Name = "WrongNum";
            this.WrongNum.Size = new System.Drawing.Size(16, 16);
            this.WrongNum.TabIndex = 9;
            this.WrongNum.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(908, 621);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "OK：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(1023, 621);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "NG：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(1115, 621);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "共：";
            // 
            // allNum
            // 
            this.allNum.AutoSize = true;
            this.allNum.Font = new System.Drawing.Font("宋体", 12F);
            this.allNum.Location = new System.Drawing.Point(1151, 621);
            this.allNum.Name = "allNum";
            this.allNum.Size = new System.Drawing.Size(16, 16);
            this.allNum.TabIndex = 13;
            this.allNum.Text = "0";
            // 
            // btnAddModel
            // 
            this.btnAddModel.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAddModel.Location = new System.Drawing.Point(1080, 413);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(126, 50);
            this.btnAddModel.TabIndex = 14;
            this.btnAddModel.Text = "添加模板";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // modelList
            // 
            this.modelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelList.Font = new System.Drawing.Font("宋体", 12F);
            this.modelList.FormattingEnabled = true;
            this.modelList.Location = new System.Drawing.Point(1011, 120);
            this.modelList.Name = "modelList";
            this.modelList.Size = new System.Drawing.Size(121, 24);
            this.modelList.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(946, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "模板:";
            // 
            // timeCam
            // 
            this.timeCam.AutoSize = true;
            this.timeCam.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeCam.Location = new System.Drawing.Point(890, 257);
            this.timeCam.Name = "timeCam";
            this.timeCam.Size = new System.Drawing.Size(115, 19);
            this.timeCam.TabIndex = 20;
            this.timeCam.Text = "延时(毫秒):";
            // 
            // lazyTime
            // 
            this.lazyTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lazyTime.Location = new System.Drawing.Point(1011, 255);
            this.lazyTime.Name = "lazyTime";
            this.lazyTime.Size = new System.Drawing.Size(52, 26);
            this.lazyTime.TabIndex = 21;
            this.lazyTime.Text = "1000";
            // 
            // yuZhi
            // 
            this.yuZhi.Font = new System.Drawing.Font("宋体", 12F);
            this.yuZhi.Location = new System.Drawing.Point(1161, 255);
            this.yuZhi.Name = "yuZhi";
            this.yuZhi.Size = new System.Drawing.Size(39, 26);
            this.yuZhi.TabIndex = 22;
            this.yuZhi.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F);
            this.label5.Location = new System.Drawing.Point(1089, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "阈值：";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1287, 701);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yuZhi);
            this.Controls.Add(this.lazyTime);
            this.Controls.Add(this.timeCam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelList);
            this.Controls.Add(this.btnAddModel);
            this.Controls.Add(this.allNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WrongNum);
            this.Controls.Add(this.TrueNum);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.hWindowControl1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yuZhi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TrueNum;
        private System.Windows.Forms.Label WrongNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label allNum;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.ComboBox modelList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeCam;
        private System.Windows.Forms.TextBox lazyTime;
        private System.Windows.Forms.NumericUpDown yuZhi;
        private System.Windows.Forms.Label label5;
    }
}

