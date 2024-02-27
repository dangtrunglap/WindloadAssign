using ETABSv1;
using ExcelDna.Integration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindloadAssign
{
    public partial class WindAssign : Form
    {
        // DIMMENSION ETABS OBJECT
        cOAPI EtabsObject = null;
        int ret = -1;
        cHelper myHelper = null;
        cSapModel SapModel;

        // DIMMENSION EXCEL OBJECT
        Microsoft.Office.Interop.Excel.Application appXL;
        Range rngXL;
        Workbook wbXL;
        long NumberStories;
        string[] StoryNames;
        double[] StoryHeights;
        double[] StoryElevations;
        bool[] IsMasterStory;
        string[] SimilarToStory;
        bool[] SpliceAbove;
        double[] SpliceHeight;

        #region Innitial Form
        public WindAssign()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            TopMost = true;

            appXL = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;
            wbXL = appXL.ActiveWorkbook;
            Worksheet Assign_load_shXL = (Worksheet)wbXL.Sheets["Assign_load"];

            myHelper = new Helper();
            EtabsObject = myHelper.GetObject("CSI.ETABS.API.ETABSObject");
            SapModel = EtabsObject.SapModel;

            int stt, eend;
            eend = SapModel.GetModelFilename().LastIndexOf(".");
            stt = SapModel.GetModelFilename().LastIndexOf("\\");
            TextBox5.Text = (SapModel.GetModelFilename().Substring(stt + 1, eend - stt - 1));
            
            int NumberLoadPattern = 0;
            string[] NameOfLoadPattern = null;
            SapModel.LoadPatterns.GetNameList(ref NumberLoadPattern, ref NameOfLoadPattern);
            for (int i = 0; i < NumberLoadPattern; i++)
            {
                ComboBox1.Items.Add(NameOfLoadPattern[i]);
                if (NameOfLoadPattern[i] == Assign_load_shXL.Range["B1"].Value)
                    ComboBox1.SelectedIndex = i;

                ComboBox2.Items.Add(NameOfLoadPattern[i]);
                if (NameOfLoadPattern[i] == Assign_load_shXL.Range["C1"].Value)
                    ComboBox2.SelectedIndex = i;

                ComboBox3.Items.Add(NameOfLoadPattern[i]);
                if (NameOfLoadPattern[i] == Assign_load_shXL.Range["D1"].Value)
                    ComboBox3.SelectedIndex = i;

                ComboBox4.Items.Add(NameOfLoadPattern[i]);
                if (NameOfLoadPattern[i] == Assign_load_shXL.Range["E1"].Value)
                    ComboBox4.SelectedIndex = i;
            }
            
            for (int i = 0; i < 7; i++)
            {
                if (Assign_load_shXL.Range["T2"].Value == Define_Direction_Cbb.Items[i].ToString())
                    Define_Direction_Cbb.SelectedIndex = i;
            }

            RadioButton6.Checked = true;

            // Add Story to Delete Save data
            Worksheet Frame_saved_shXL = (Worksheet)wbXL.Sheets["Frame_data"];
            object[,] Frame_saved;
            long Frame_count = Frame_saved_shXL.Cells[3, 1].End[XlDirection.xlDown].Row;
            if (Frame_count < 3)
                Frame_count = 3;
            Frame_saved = Frame_saved_shXL.Range["A3:I" + Frame_count].Value;
            System.Collections.Generic.Dictionary<string, string> dic = new System.Collections.Generic.Dictionary<string, string>();

            for (int i = 1; i <= Frame_saved.GetLength(0); i++)
            {
                if (Frame_saved[1, 1] != null)
                {
                    if (!dic.ContainsKey((string)Frame_saved[i, 1]))
                        dic.Add((string)Frame_saved[i, 1], (string)Frame_saved[i, 1]);
                }
            }

            if (Frame_saved[1, 1] != null)
            {
                foreach (string key in dic.Keys)
                    ComboBox5.Items.Add(key);
            }
            ComboBox5.Items.Add("ALL");
        }
        #endregion
        //---------------------------------------------------
        #region Assign Load to Etabs (Button ClickEvent)
        private void AssignLoadBtn_Click(object sender, EventArgs e)
        {
            appXL = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;
            wbXL = appXL.ActiveWorkbook;
            Worksheet Assign_load_shXL = (Worksheet)wbXL.Sheets["Assign_load"];
            Assign_load_shXL.Range["T2"].Value = Define_Direction_Cbb.SelectedItem;
            long data_index_count;
            data_index_count = Assign_load_shXL.Cells[3, 1].End[XlDirection.xlDown].Row;
            if (data_index_count < 3)
            {
                data_index_count = 3;
            }
            object[,] Data_index;
            Data_index = (object[,])Assign_load_shXL.Range["A3:I" + data_index_count].Value;
            if (Data_index[1, 1] == null)
            {
                MessageBox.Show("Sheet Assign_Load chưa có dữ liệu, hãy thêm dữ liệu vào trước", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (RadioButton6.Checked == true)
            {
                Assign_load_shXL.Range["V2"].Value = "1";
            }
            else
            {
                Assign_load_shXL.Range["V2"].Value = "2";
            }
            string Wx = ComboBox1.SelectedItem.ToString();
            string Wy = ComboBox2.SelectedItem.ToString();
            string Wxx = ComboBox3.SelectedItem.ToString();
            string Wyy = ComboBox4.SelectedItem.ToString();

            Assign_load_shXL.Range["B1"].Value = Wx;
            Assign_load_shXL.Range["C1"].Value = Wxx;
            Assign_load_shXL.Range["D1"].Value = Wy;
            Assign_load_shXL.Range["E1"].Value = Wyy;

            object[,] Frame_Name_arr;
            bool[] Selected;
            int NumberNames = 0;
            string[] MyName = null;
            string[] PropName = null;
            string[] StoryName = null;
            string[] PointName1 = null;
            string[] PointName2 = null;
            double[] Point1X = null;
            double[] Point1Y = null;
            double[] Point1Z = null;
            double[] Point2X = null;
            double[] Point2Y = null;
            double[] Point2Z = null;
            double[] Angle = null;
            double[] Offset1X = null;
            double[] Offset2X = null;
            double[] Offset1Y = null;
            double[] Offset2Y = null;
            double[] Offset1Z = null;
            double[] Offset2Z = null;
            int[] CardinalPoint = null;
            string CSys1 = "Global";
            string LoadPat = null; // Load pattern name
            int MyType = 1; // Load type
            int Dir = 0; // Load direction
            double Dist1 = 0; // Start distance
            double Dist2 = 1; // End distance
            double Val1 = 0; // Start value
            double Val2 = 0; // End value
            string CSys = ""; // Coordinate system
            bool RelDist = true; // Relative distance flag
            bool Replace = true; // Replace flag
            int ItemType = 0; // Item type

            double WX_db;
            double WXX_db;
            double WY_db;
            double WYY_db;

            switch (Define_Direction_Cbb.SelectedItem.ToString())
            {
                case "1. Local 1 axis":
                    Dir = 1;
                    CSys = "Local"; // Local coordinate system
                    break;
                case "2. Local 2 axis":
                    Dir = 2;
                    CSys = "Local"; // Local coordinate system
                    break;
                case "3. Local 3 axis":
                    Dir = 3;
                    CSys = "Local"; // Local coordinate system
                    break;
                case "4. X direction":
                    Dir = 4;
                    CSys = "Global"; // Local coordinate system
                    break;
                case "5. Y direction":
                    Dir = 5;
                    CSys = "Global"; // Local coordinate system
                    break;
                case "6. Z direction":
                    Dir = 6;
                    CSys = "Global"; // Local coordinate system
                    break;
                case "7. Gravity direction":
                    Dir = 10;
                    CSys = "Global"; // Local coordinate system
                    break;
            }

            //MyName = new string[1] ;
            
            ret = SapModel.FrameObj.GetAllFrames(ref NumberNames, ref MyName, ref PropName, ref StoryName, ref PointName1, ref PointName2, ref Point1X, ref Point1Y, ref Point1Z,
                                                ref Point2X, ref Point2Y, ref Point2Z, ref Angle, ref Offset1X, ref Offset2X, ref Offset1Y, ref Offset2Y, ref Offset1Z, ref Offset2Z,
                                                ref CardinalPoint, CSys1);
            Selected = new bool[NumberNames];
            Frame_Name_arr = new object[NumberNames, 9];
            long count_selected = 0;
            for (int i = 0; i < NumberNames; i++)
            {
                ret = SapModel.FrameObj.GetSelected(MyName[i],ref Selected[i]);
                if (Selected[i] == true)
                {
                    for (int a1 = 1; a1 <= data_index_count - 2; a1++)
                    {
                        if (StoryName[i] == Data_index[a1, 1].ToString())
                        {
                            WX_db = Convert.ToDouble(Data_index[a1, 2]);
                            WXX_db = Convert.ToDouble(Data_index[a1, 4]);
                            WY_db = Convert.ToDouble(Data_index[a1, 3]);
                            WYY_db = Convert.ToDouble(Data_index[a1, 5]);

                            if (RadioButton6.Checked == true)
                            {
                                for (int i1 = 1; i1 <= 2; i1++)
                                {
                                    if (i1 == 1)
                                    {
                                        if (CheckBox1.Checked == false)
                                        {
                                            Val1 = WX_db;
                                        }
                                        else
                                        {
                                            Val1 = -WX_db;
                                        }
                                        Val2 = Val1;
                                        LoadPat = ComboBox1.SelectedItem.ToString();
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 2] = Val1;
                                        Frame_Name_arr[count_selected, 8] = Wx;
                                        count_selected++;
                                    }
                                    else if (i1 == 2)
                                    {
                                        if (CheckBox3.Checked == false)
                                        {
                                            Val1 = -WXX_db;
                                        }
                                        else
                                        {
                                            Val1 = WXX_db;
                                        }
                                        Val2 = Val1;
                                        LoadPat = ComboBox3.SelectedItem.ToString();
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 3] = Val1;
                                        Frame_Name_arr[count_selected, 8] = Wxx;
                                        count_selected++;
                                    }
                                    ret = SapModel.FrameObj.SetLoadDistributed(MyName[i], LoadPat, MyType, Dir, Dist1, Dist2,
                                                                           Val1, Val2, CSys, RelDist, Replace, (eItemType)ItemType);
                                }
                            }
                            if (RadioButton7.Checked == true)
                            {
                                for (int i1 = 1; i1 <= 2; i1++)
                                {
                                    if (i1 == 1)
                                    {
                                        if (!CheckBox1.Checked)
                                        {
                                            Val1 = -WX_db;
                                        }
                                        else
                                        {
                                            Val1 = WX_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox3.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 3] = Val1;
                                        Frame_Name_arr[count_selected, 8] = "-" + Wx;

                                        count_selected++;
                                    }
                                    else if (i1 == 2)
                                    {
                                        if (!CheckBox3.Checked)
                                        {
                                            Val1 = WXX_db;
                                        }
                                        else
                                        {
                                            Val1 = -WXX_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox1.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 2] = Val1;
                                        Frame_Name_arr[count_selected, 8] = "-" + Wxx;

                                        count_selected++;
                                    }

                                    ret = SapModel.FrameObj.SetLoadDistributed(MyName[i], LoadPat, MyType, Dir, Dist1, Dist2, Val1, Val2, CSys, RelDist, Replace, (eItemType)ItemType);
                                }
                            }
                            if (RadioButton4.Checked == true)
                            {
                                for (int i1 = 1; i1 <= 2; i1++)
                                {
                                    if (i1 == 1)
                                    {
                                        if (!CheckBox2.Checked)
                                        {
                                            Val1 = WY_db;
                                        }
                                        else
                                        {
                                            Val1 = -WY_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox2.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 4] = Val1;
                                        Frame_Name_arr[count_selected, 8] = Wy;

                                        count_selected++;
                                    }
                                    else if (i1 == 2)
                                    {
                                        if (!CheckBox4.Checked)
                                        {
                                            Val1 = -WYY_db;
                                        }
                                        else
                                        {
                                            Val1 = WYY_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox4.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 5] = Val1;
                                        Frame_Name_arr[count_selected, 8] = Wyy;

                                        count_selected++;
                                    }

                                    ret = SapModel.FrameObj.SetLoadDistributed(MyName[i], LoadPat, MyType, Dir, Dist1, Dist2, Val1, Val2, CSys, RelDist, Replace, (eItemType)ItemType);
                                }
                            }
                            if (RadioButton3.Checked)
                            {
                                for (int i1 = 1; i1 <= 2; i1++)
                                {
                                    if (i1 == 1)
                                    {
                                        if (!CheckBox2.Checked)
                                        {
                                            Val1 = -WY_db;
                                        }
                                        else
                                        {
                                            Val1 = WY_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox4.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 5] = Val1;
                                        Frame_Name_arr[count_selected, 8] = "-" + Wy;
                                        count_selected++;
                                    }
                                    else if (i1 == 2)
                                    {
                                        if (!CheckBox4.Checked)
                                        {
                                            Val1 = WYY_db;
                                        }
                                        else
                                        {
                                            Val1 = -WYY_db;
                                        }

                                        Val2 = Val1;
                                        LoadPat = ComboBox2.SelectedItem.ToString();
                                        // ---- Assign to Frame_data wbXL ----
                                        Frame_Name_arr[count_selected, 0] = StoryName[i];
                                        Frame_Name_arr[count_selected, 1] = MyName[i];
                                        Frame_Name_arr[count_selected, 6] = Dir;
                                        Frame_Name_arr[count_selected, 7] = CSys;
                                        Frame_Name_arr[count_selected, 4] = Val1;
                                        Frame_Name_arr[count_selected, 8] = "-" + Wyy;
                                        count_selected++;
                                    }

                                    ret = SapModel.FrameObj.SetLoadDistributed(MyName[i], LoadPat, MyType, Dir, Dist1, Dist2, Val1, Val2, CSys, RelDist, Replace, (eItemType)ItemType);
                                }
                            }


                        }
                    }
                }
            }

            Worksheet Assign_data_shXL;
            Assign_data_shXL = (Worksheet)wbXL.Sheets["Frame_data"];
            data_index_count = Assign_data_shXL.Cells[1, 1].End[XlDirection.xlDown].Row;
            if (count_selected > 0)
            {
                Assign_data_shXL.Range["A" + (data_index_count + 1)].Resize[count_selected, 9].Value = Frame_Name_arr;
            }
            else if (count_selected == 0)
            {
                MessageBox.Show("Không có đối tượng nào được gán. Có thể có các lỗi sau:" + Environment.NewLine +
                        "     - Tên tầng trong sheet Assign_Load chưa khớp với mô hình ETABS" + Environment.NewLine +
                        "     - Chưa chọn đối tượng Frame trong mô hình ETABS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ret = SapModel.SelectObj.ClearSelection();
            //ret = SapModel.View.RefreshView();
        }
        #endregion

        //---------------------------------------------------
        #region "Delete Load Which Assigned Etabs (Button ClickEvent)"
        private void Del_Load_Btn_Click(object sender, EventArgs e)
        {
            int NumberNames = 0;
            string[] MyName = null;
            string[] PropName = null;
            string[] StoryName = null;
            string[] PointName1 = null;
            string[] PointName2 = null;
            double[] Point1X = null;
            double[] Point1Y = null;
            double[] Point1Z = null;
            double[] Point2X = null;
            double[] Point2Y = null;
            double[] Point2Z = null;
            double[] Angle = null;
            double[] Offset1X = null;
            double[] Offset2X = null;
            double[] Offset1Y = null;
            double[] Offset2Y = null;
            double[] Offset1Z = null;
            double[] Offset2Z = null;
            int[] CardinalPoint = null;
            string CSys1 = "Global";

            ret = SapModel.FrameObj.GetAllFrames(ref NumberNames, ref MyName, ref PropName, ref StoryName, ref PointName1, ref PointName2, ref Point1X, ref Point1Y, ref Point1Z,
                                                        ref Point2X, ref Point2Y, ref Point2Z, ref Angle, ref Offset1X, ref Offset2X, ref Offset1Y, ref Offset2Y, ref Offset1Z, ref Offset2Z,
                                                        ref CardinalPoint, CSys1);

            bool[] Selected = new bool[NumberNames];
            for (int i = 0; i < NumberNames; i++)
            {
                ret = SapModel.FrameObj.GetSelected(MyName[i], ref Selected[i]);
                if (Selected[i] == true)
                {
                    ret = SapModel.FrameObj.DeleteLoadDistributed(MyName[i], (string)ComboBox1.SelectedItem);
                    ret = SapModel.FrameObj.DeleteLoadDistributed(MyName[i], (string)ComboBox2.SelectedItem);
                    ret = SapModel.FrameObj.DeleteLoadDistributed(MyName[i], (string)ComboBox3.SelectedItem);
                    ret = SapModel.FrameObj.DeleteLoadDistributed(MyName[i], (string)ComboBox4.SelectedItem);
                }
            }

            ret = SapModel.SelectObj.ClearSelection();
            //ret = SapModel.View.RefreshView();
        }
        #endregion

        //----------------------------------------------------
        #region "Delete Data which Saved (Button ClickEvent)"
        private void Del_sv_Btn_Click(object sender, EventArgs e)
        {
            Worksheet Assign_data_shXL;
            Assign_data_shXL = (Worksheet)wbXL.Sheets["Frame_data"];
            long data_index_count;
            object Data_index;
            data_index_count = Assign_data_shXL.Cells[1, 1].End[XlDirection.xlDown].Row;
            if (data_index_count < 3)
            {
                data_index_count = 3;
                return;
            }
            Data_index = Assign_data_shXL.Range["A3:I" + data_index_count].Value;
            Assign_data_shXL.Range["A3:I" + data_index_count].ClearContents();


            object[,] new_data_index = new object[data_index_count, 9];



            long u = 0;
            if (ComboBox5.SelectedItem.ToString() != "ALL")
            {
                for (int i = 1; i <= data_index_count - 2; i++)
                {
                    if (Data_index is object[,] data && data[i, 1] != null && data[i, 1].ToString() != ComboBox5.SelectedItem.ToString())
                    {
                        for (int j = 0; j <= 8; j++)
                        {
                            new_data_index[u, j] = data[i, j + 1];
                        }
                        u++;
                    }
                }
                if (u != 0)
                {
                    Assign_data_shXL.Range["A3"].Resize[data_index_count - 1, 9].Value = new_data_index;
                }
            }
            MessageBox.Show("Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region "Assing Etabs with Saved data (Button ClickEvent)"
        private void Assign_Sv_Data_Btn_Click(object sender, EventArgs e)
        {
            appXL = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;
            wbXL = appXL.ActiveWorkbook;
            Worksheet Assign_data_shXL;
            Assign_data_shXL = wbXL.Sheets["Frame_data"];
            Worksheet Assign_load_shXL = (Worksheet)wbXL.Sheets["Assign_load"];
            long LastRow;
            LastRow = Assign_data_shXL.Cells[3, 1].End[XlDirection.xlDown].Row;
            object[,] Wind_sheet_index;
            if (LastRow < 3)
            {
                LastRow = 3;
            }

            Wind_sheet_index = Assign_data_shXL.Range["A3:H" + LastRow].Value;
            object[,] Loadpattern_index;
            Loadpattern_index = Assign_load_shXL.Range["B1:E1"].Value;

            // string FrameName; // Frame object name
            string LoadPat = null; // Load pattern name
            int MyType; // Load type
            int Dir; // Load direction
            double Dist1; // Start distance
            double Dist2; // End distance
            double Val1; // Start value
            double Val2; // End value
            string CSys; // Coordinate system
            bool RelDist; // Relative distance flag
            bool Replace; // Replace flag
            int ItemType; // Item type
            MyType = 1; // Force per unit length
            Dist1 = 0; // Start at I-End
            Dist2 = 1; // End at J-End
            RelDist = true; // Relative distance
            Replace = true;
            ItemType = 0;
            Val1 = 0;
            Val2 = 0;
            // string selectedStory;
            for (int i = 1; i <= LastRow - 2; i++)
            {
                Dir = Convert.ToInt32(Wind_sheet_index[i, 7]);
                CSys = Wind_sheet_index[i, 8].ToString();

                if (Wind_sheet_index[i, 3] != null)
                {
                    LoadPat = Loadpattern_index[1, 1].ToString();
                    Val1 = Convert.ToDouble(Wind_sheet_index[i, 3]);
                    Val2 = Val1;
                }
                else if (Wind_sheet_index[i, 4] != null)
                {
                    LoadPat = Loadpattern_index[1, 2].ToString();
                    Val1 = Convert.ToDouble(Wind_sheet_index[i, 4]);
                    Val2 = Val1;
                }
                else if (Wind_sheet_index[i, 5] != null)
                {
                    LoadPat = Loadpattern_index[1, 3].ToString();
                    Val1 = Convert.ToDouble(Wind_sheet_index[i, 5]);
                    Val2 = Val1;
                }
                else if (Wind_sheet_index[i, 6] != null)
                {
                    LoadPat = Loadpattern_index[1, 4].ToString();
                    Val1 = Convert.ToDouble(Wind_sheet_index[i, 6]);
                    Val2 = Val1;
                }
                if (LoadPat != null)
                {
                    ret = SapModel.FrameObj.SetLoadDistributed(Wind_sheet_index[i, 2].ToString(), LoadPat, MyType, Dir, Dist1, Dist2, Val1, Val2, CSys, RelDist, Replace, (eItemType)ItemType);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu, hãy nhập dữ liệu và thử lại", "Wind load Assign", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //ret = SapModel.View.RefreshView();
            MessageBox.Show("Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion

        #region RadioButton6_CheckedChanged
        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton6.Checked)
            {
                CheckBox8.Checked = true;
                CheckBox7.Checked = false;
                CheckBox6.Checked = true;
                CheckBox5.Checked = false;
            }
        }
        #endregion

        #region RadioButton7_CheckedChanged
        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton7.Checked)
            {
                CheckBox8.Checked = true;
                CheckBox7.Checked = false;
                CheckBox6.Checked = true;
                CheckBox5.Checked = false;
            }
        }
        #endregion

        #region RadioButton4_CheckedChanged
        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton4.Checked)
            {
                CheckBox7.Checked = true;
                CheckBox8.Checked = false;
                CheckBox5.Checked = true;
                CheckBox6.Checked = false;
            }
        }
        #endregion

        #region RadioButton3_CheckedChanged
        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton3.Checked)
            {
                CheckBox7.Checked = true;
                CheckBox8.Checked = false;
                CheckBox5.Checked = true;
                CheckBox6.Checked = false;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        //#region CheckBox1_CheckedChanged
        //private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox1.Checked)
        //    {
        //        CheckBox3.Checked = true;
        //    }
        //    else
        //    {
        //        CheckBox3.Checked = false;
        //    }
        //}
        //#endregion

        //#region CheckBox2_CheckedChanged
        //private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox2.Checked)
        //    {
        //        CheckBox4.Checked = true;
        //    }
        //    else
        //    {
        //        CheckBox4.Checked = false;
        //    }
        //}
        //#endregion

        //#region CheckBox3_CheckedChanged
        //private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox3.Checked)
        //    {
        //        CheckBox1.Checked = true;
        //    }
        //    else
        //    {
        //        CheckBox1.Checked = false;
        //    }
        //}
        //#endregion

        //#region CheckBox4_CheckedChanged
        //private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox4.Checked)
        //    {
        //        CheckBox2.Checked = true;
        //    }
        //    else
        //    {
        //        CheckBox2.Checked = false;
        //    }
        //}







    } 

}
