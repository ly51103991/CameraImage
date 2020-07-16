using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HalconDotNet;
using System.IO;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using MVSDK;
namespace CameraImage
{
    public partial class Form1 : Form
    {
        public  HTuple hv_AcqHandle = null;
        public HObject ho_image = null;
        HalconAPI.HFramegrabberCallback delegateCallback;
        int a = 0, b = 0, c = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            updateList();
        }

        void updateList()
        {
            modelList.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo("c:/modelFiles/");
            FileInfo[] subDirs = dir.GetFiles("*.shm");
            foreach (FileInfo subDir in subDirs)
            {
                modelList.Items.Add(subDir.Name);
            }
            if (subDirs.Length!= 0) {
            modelList.SelectedIndex = 0;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                MessageBox.Show("无模板可用 请添加模板！");
            }
        }
        void returnNum()
        {
            TrueNum.Text = "0";WrongNum.Text = "0";allNum.Text = "0";
            a = 0; b = 0; c =0;
            pictureBox1.BackColor = Color.WhiteSmoke;
        }
        private int test = 1;//随便定义的一个变量，后面会取其地址带入回调函数的user_context

        public int takeCameraOne(IntPtr handle,IntPtr context,IntPtr user_context)
        {
            try
            {
                HOperatorSet.GrabImageAsync(out ho_image, hv_AcqHandle,-1);
                if (this.hWindowControl1.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => {
                        if (ho_image != null) {
                       checkModel(ho_image);
                        }
                    }));//把图像显示出来（这里是委托方式显示)
                }
                else
                {
                   // checkModel(ho_image);
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        private void RealTimeSnap_Click(object sender, EventArgs e)
        {
            int lTime = 0;
            try
            {
                if(Int32.Parse(lazyTime.Text)>0){ lTime = Int32.Parse(lazyTime.Text); }
            }
            catch (Exception)
            {
                MessageBox.Show("延迟设置错误！请输入正整数：");
                return;
            }
            if (button2.Text == "开启")
            {
                //MvApi.CameraSetExtTrigSignalType(hv_AcqHandle.H.TupleIsValidHandle(), 0); 
                HOperatorSet.OpenFramegrabber("MindVision17_X64", 1, 1, 0, 0, 0, 0, "progressive",
                8, "Gray", -1, "false", "auto", "oufang", 0, -1, out hv_AcqHandle);
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "color_space", "BGR24");
                HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "trigger_mode", 2);//开启硬触发
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "grab_timeout", -1);
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "trigger_delay_time", lTime*1000);
                delegateCallback = takeCameraOne;
                IntPtr ptr = Marshal.GetFunctionPointerForDelegate(delegateCallback);//取回调函数的地址
                IntPtr ptr1 = GCHandle.Alloc(test, GCHandleType.Pinned).AddrOfPinnedObject();//取test变量的地址
               HOperatorSet.SetFramegrabberCallback(hv_AcqHandle, "transfer_end", ptr, ptr1);//注册回调函数

                button2.Text = "关闭";
                returnNum();
                modelList.Enabled = false;
                btnAddModel.Enabled = false;
                lazyTime.Enabled = false;
                yuZhi.Enabled = false;
            }
            else 
            {
                button2.Text = "开启";
                modelList.Enabled = true;
                btnAddModel.Enabled = true;
                lazyTime.Enabled = true;
                yuZhi.Enabled = true;
                HOperatorSet.CloseFramegrabber(hv_AcqHandle);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }

        // private void checkBoxTiao_CheckedChanged(object sender, EventArgs e)
        //  {
        //    if (!checkBoxTiao.Checked) yuZhiCha.Text="";
        // }

        private void btnAddModel_Click(object sender, EventArgs e)
        {          
            string word = Interaction.InputBox("请输入密码", "身份验证", ""  , 100, 100);
            if (word != "123456") { MessageBox.Show("密码不能为空或错误！"); return; }
            string str = Interaction.InputBox("请输入模板名字", "创建模板", "", 100, 100);
            if (str == "") { MessageBox.Show("名字不能为空！"); return; };
            if (true == Directory.Exists("c:/modelFiles/model-" + str+".shm"))
            {
                MessageBox.Show("已有重复模板！");
                return;
            }
            HTuple hv_AcqHandle_model;
            HOperatorSet.OpenFramegrabber("MindVision17_X64", 1, 1, 0, 0, 0, 0, "progressive",
                     8, "Gray", -1, "false", "auto", "oufang", 0, -1, out hv_AcqHandle_model);
            HOperatorSet.SetFramegrabberParam(hv_AcqHandle_model, "color_space", "BGR24");
            // hv_AcqHandle = hv_AcqHandle_model;
            HOperatorSet.GrabImageStart(hv_AcqHandle_model, -1);
            HObject ho_Circle = null, ho_ImageReduced = null,ho_colorImage=null;
            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_WindowHandle = new HTuple(), hv_Row = new HTuple();
            HTuple hv_Column = new HTuple(), hv_Radius = new HTuple();
            HTuple hv_ModelID = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            try
            {                                    
                MessageBox.Show("单击鼠标左键并拖动选择模板区域，右键确定！");
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "software_trig", 1);
                HOperatorSet.GrabImageAsync(out ho_colorImage, hv_AcqHandle_model, -1);
                HOperatorSet.WriteImage(ho_colorImage, "png", 0, "c:/modelFiles/"+str);
                //HOperatorSet.Rgb1ToGray(ho_colorImage, out ho_Image_model);
               // hv_Width.Dispose(); hv_Height.Dispose();
                HOperatorSet.GetImageSize(ho_colorImage, out hv_Width, out hv_Height);
               // HOperatorSet.SetWindowAttr("background_color", "red");
                HOperatorSet.OpenWindow(0, 0, hv_Width+1, hv_Height+1, 0, "visible", "", out hv_WindowHandle);
                HOperatorSet.DispImage(ho_colorImage, hv_WindowHandle);
                HDevWindowStack.Push(hv_WindowHandle);
                   // ho_Image.Dispose();
               // hv_Row.Dispose(); hv_Column.Dispose(); hv_Radius.Dispose();
                HOperatorSet.DrawCircle(hv_WindowHandle, out hv_Row, out hv_Column, out hv_Radius);
                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_colorImage, ho_Circle, out ho_ImageReduced);
               // hv_ModelID.Dispose();
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", 0, (new HTuple(360)).TupleRad()
                    , "auto", "auto", "use_polarity", "auto", "auto", out hv_ModelID);
                HOperatorSet.WriteShapeModel(hv_ModelID, ("c:/modelFiles/model-" + str + ".shm"));
                    HOperatorSet.CloseWindow(hv_WindowHandle);               
            }
            catch (Exception)
                {
                    MessageBox.Show("操作出错！请重新添加模板。");
                    
                File.Delete("c:/modelFiles/model-"+str+".shm");
                File.Delete("c:/modelFiles/" + str + ".png");

                HOperatorSet.CloseWindow(hv_WindowHandle);
                return;
                    throw;                   
                }
                finally {
                    HOperatorSet.CloseFramegrabber(hv_AcqHandle_model);
                ho_colorImage.Dispose();
                    ho_Circle.Dispose();
                    ho_ImageReduced.Dispose();
            }
            
            MessageBox.Show("模板创建成功！");
            updateList();
        }

        private void checkModel(HObject ho_Image1)
        {         
            HTuple hv_Row = new HTuple();
            HTuple hv_Column = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_ModelID = new HTuple();
            HTuple hv_ModelIDs = new HTuple(), hv_Angle = new HTuple();
            HTuple hv_Score = new HTuple(), hv_ModelIndex = new HTuple();
           // HObject ho_Image1 = null;
           // HOperatorSet.Rgb1ToGray(ho_ImageColor, out ho_Image1);

            // hv_ModelID1.Dispose();
            HOperatorSet.ReadShapeModel("c:/modelFiles/"+modelList.SelectedItem.ToString(), out hv_ModelID);
           // hv_ModelIDs.Dispose();
  
                HOperatorSet.GetImageSize(ho_Image1, out hv_Width, out hv_Height);
                if (hWindowControl1.HalconWindow.ToString() == "") { return; }
                HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, hv_Width-1, hv_Height-1);
                HOperatorSet.DispObj(ho_Image1, hWindowControl1.HalconWindow);
               // hv_Row.Dispose(); hv_Column.Dispose(); hv_Angle.Dispose(); hv_Score.Dispose(); hv_ModelIndex.Dispose();
                HOperatorSet.FindShapeModel(ho_Image1, hv_ModelID, 0, (new HTuple(360)).TupleRad()
                    , 0.5, 8, 0.5, "least_squares", 0, 0.8, out hv_Row, out hv_Column, out hv_Angle,
                    out hv_Score);
            if ((int)(new HTuple(hv_Score.TupleGreater(0))) != 0)
            {
                HObject ho_ImageModel;
                HTuple hv_Value = null, hv_Index = null, hv_Grayval = new HTuple();
                HTuple hv_Mean = null, hv_Value2 = null, hv_Index2 = null;
                HTuple hv_Grayval2 = new HTuple(), hv_Mean2 = null, hv_resultValue = null;
                string s = modelList.SelectedItem.ToString();
                HOperatorSet.ReadImage(out ho_ImageModel, "c:/modelFiles/" + s.Substring(6, s.Length - 10) + ".png");
                hv_Value = new HTuple();
                for (hv_Index = 1; (int)hv_Index <= 200; hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetGrayval(ho_Image1, 5 * hv_Index, 5 * hv_Index, out hv_Grayval);
                    //HOperatorSet.GetGrayval(ho_Image1, 5 * hv_Index, 1024-5 * hv_Index, out hv_Grayval);
                    hv_Value = hv_Value.TupleConcat(hv_Grayval);
                }
                HOperatorSet.TupleMean(hv_Value, out hv_Mean);

                hv_Value2 = new HTuple();
                for (hv_Index2 = 1; (int)hv_Index2 <= 200; hv_Index2 = (int)hv_Index2 + 1)
                {
                    HOperatorSet.GetGrayval(ho_ImageModel, 5 * hv_Index2, 5 * hv_Index2, out hv_Grayval2);
                   // HOperatorSet.GetGrayval(ho_ImageModel, 5 * hv_Index2, 1024-(5 * hv_Index2), out hv_Grayval2);
                    hv_Value2 = hv_Value2.TupleConcat(hv_Grayval2);
                }
                HOperatorSet.TupleMean(hv_Value2, out hv_Mean2);
                if (hv_Mean < hv_Mean2) hv_resultValue = hv_Mean2 - hv_Mean;
                else { hv_resultValue = hv_Mean - hv_Mean2; }
                if (checkBoxTiao.Checked) yuZhiCha.Text = "检测:" + hv_Mean + "-模板：" + hv_Mean2 + "-差值：" + hv_resultValue;
                else yuZhiCha.Text = "";
                //MessageBox.Show("检测照片平均灰度："+hv_Mean+"------模板平均灰度："+hv_Mean2+"-----差值："+hv_resultValue);
                if ((int)(new HTuple(hv_resultValue.TupleGreater(int.Parse(yuZhi.Value.ToString())))) == 0)
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "GPO1", 1);
                    pictureBox1.BackColor = Color.Green;
                    a++;
                    TrueNum.Text = a + "个";
                }
                else
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "GPO1", 0);
                    pictureBox1.BackColor = Color.Red;
                    b++;
                    WrongNum.Text = b + "个";
                }       
                }
                else
                {
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "GPO1", 0);
                pictureBox1.BackColor = Color.Red;
                    b++;
                    WrongNum.Text = b + "个";
                }
                c = a + b;
                allNum.Text = c + "个";              
            }
        }
}
