/*------------------------------------------------------------------------
'	프로그램명	: IISLogFind
'	작성자		: DevOpsFlux
'	작성일		: 2014-12-09
'	설명		: File Search
' ------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using System.IO;
using System.Threading;
using System.Collections;

namespace IISLogFind
{
    public partial class Form1 : Form
    {
        //private volatile bool boolThreadStop;

        LibCommon libCommon = new LibCommon();
        LibShell libShell = new LibShell();
        
        public Form1()
        {
            InitializeComponent();

            string strToday = DateTime.Today.ToString("yyyyMMdd");
            //txtLogFile.Text = "ex14100107.log";
            txtSearchEndFile.Text = "find_" + strToday + ".txt";
            //txtSearchData.Text = "ticket.interpark.com 500";

        }

        #region # Event Halller
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtSearchData.Text.Length) > 2)
                {
                    if (lstLogFileList.Items.Count > 0)
                    {
                        SetProgressbarStart();

                        //Thread t1 = new Thread(new ThreadStart(SetProgressbarStart));
                        //t1.Start();

                        //Thread t2 = new Thread(new ThreadStart(GetFind));
                        Thread t2 = new Thread(new ThreadStart(GetFindMulti));
                        t2.Start();
                    }
                    else
                    {
                        MessageBox.Show(" * 로그 파일을 지정해 주세요.");
                        //lstBox.Items.Add(" * 로그 파일을 지정해 주세요.");  
                    }
                }
                else
                {
                    MessageBox.Show(" * 검색 정보를 입력해 주세요.");
                }

            }
            catch (Exception ex)
            {
                lstBox.Items.Add(" Find Exception : " + ex.ToString());    
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
        }
        
        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLocation.Checked == true) {
                //txtLogFile.Text = @"F:\tmp\IISLog\ex14100107.log";
                txtLogFile.Text = System.IO.Directory.GetCurrentDirectory().ToString() + @"\" + "ex14100107.log";
            } else {
                txtLogFile.Text = "ex14100107.log";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txtSearchEndFile.Text);
            }
            catch (Exception ex)
            {
                lstBox.Items.Add(" FindLogView Exception " + ex.ToString());    
            }
        }

        private void btnMultiLogFile_Click(object sender, EventArgs e)
        {
            string strLogFile = txtLogFile.Text;

            if (strLogFile != "")
            {
                if (CheckLogFileExist(strLogFile) == false)
                {
                    lstLogFileList.Items.Add(strLogFile.ToString());
                }
                else
                {
                    MessageBox.Show(" * 이미 지정된 파일 입니다.");
                    //lstBox.Items.Add(" * 이미 지정된 파일 입니다.");    
                }
            }
        }

        private void btnLogFileListClear_Click(object sender, EventArgs e)
        {
            lstLogFileList.Items.Clear();
        }

        private void btnFileFind_Click(object sender, EventArgs e)
        {
            chkLocation.Checked = true;
            //txtLogFile.Text = libCommon.ChooseFilePath();

            ArrayList alFiles;
            alFiles = libCommon.ChooseFileMultiPath();
            foreach (Object file in alFiles)
            {
                lstLogFileList.Items.Add(file);
            }
            //MessageBox.Show(strMultiLogFile);
            //txtLogFile.Text = libCommon.ChooseFileMultiPath();
        }

        private void btnFileDelete_Click(object sender, EventArgs e)
        {
            lstLogFileList.Items.Remove(lstLogFileList.SelectedItem);
            //lstLogFileList.SelectedItems.Remove(lstLogFileList.SelectedIndex);
            //MessageBox.Show(lstLogFileList.SelectedIndex.ToString());
        }
        #endregion

        #region # GetFind
        private void GetFind()
        {
            try
            {
                string _Output = string.Empty;
                string _Error = string.Empty;
                string strCmdText = string.Empty;
                string strLogFile = txtLogFile.Text;
                string strSearchEndFile = txtSearchEndFile.Text;
                string strSearchData = txtSearchData.Text;

                //strCmdText = "findstr /C:\"ticket.interpark.com 500\" ex14100107.log > error_20141209.txt";
                //ExecuteShellCommand();
                //strCmdText = "/C:\"ticket.interpark.com 500\" ex14100107.log > error_20141209.txt";

                if (chkFindAdd.Checked == true)
                {
                    strCmdText = "/C:\"" + strSearchData + "\" " + strLogFile + " >> " + strSearchEndFile;
                }
                else
                {
                    strCmdText = "/C:\"" + strSearchData + "\" " + strLogFile + " > " + strSearchEndFile;
                }
                //txtShellCmd.Text = strCmdText.ToString();

                libShell.ExecuteShellCommand("findstr", strCmdText, ref _Output, ref _Error);

                if (_Error.ToString() == "")
                {
                    lstBox.Items.Add("Find Success !!!");

                    GetFileInfo();
                }
                else
                {
                    lstBox.Items.Add("Fail Error : " + _Error.ToString());
                }

                //MessageBox.Show(_Output.ToString());
                //MessageBox.Show(_Error.ToString());
            }
            catch (Exception ex)
            {
                lstBox.Items.Add(" Find Exception : " + ex.ToString());
            }
            finally
            {
                SetProgressbarEnd();
            }

        }
        #endregion

        #region # GetFindMulti
        private void GetFindMulti()
        {
            try
            {
                string _Output = string.Empty;
                string _Error = string.Empty;
                string strCmdText = string.Empty;
                string strLogFile = txtLogFile.Text;
                string strSearchEndFile = txtSearchEndFile.Text;
                string strSearchData = txtSearchData.Text;
                int iErrCnt = 0;
                int iLogFileCnt = lstLogFileList.Items.Count;
                string strFileCopyType = string.Empty;

                strFileCopyType = (chkFindAdd.Checked == true) ? " >> " : " > ";
                for (int i = 0; i < lstLogFileList.Items.Count; i++)
                {
                    strFileCopyType = (i > 0) ? " >> " : strFileCopyType;                    
                    strCmdText = "/C:\"" + strSearchData + "\" " + lstLogFileList.Items[i].ToString() + strFileCopyType + strSearchEndFile;

                    //MessageBox.Show(strCmdText.ToString());
                    libShell.ExecuteShellCommand("findstr", strCmdText, ref _Output, ref _Error);
                    iErrCnt = (_Error.ToString() == "") ? iErrCnt+0 : iErrCnt+1;
                }

                if (iErrCnt == 0)
                {
                    lstBox.Items.Add("Find Success !!!");
                    GetFileInfo();
                }
                else
                {
                    lstBox.Items.Add("Fail Error : " + _Error.ToString());
                }

                //MessageBox.Show(_Output.ToString());
                //MessageBox.Show(_Error.ToString());
            }
            catch (Exception ex)
            {
                lstBox.Items.Add(" Find Exception : " + ex.ToString());
            }
            finally
            {
                SetProgressbarEnd();
            }

        }
        #endregion

        #region # GetFileInfo
        private void GetFileInfo()
        {
            try
            {
                int i = 1;
                string strLine = string.Empty;
                //string strFilePath = @"F:\tmp\IISLog\error_20141209.txt";
                // System.Environment.CurrentDirectory
                string strFilePath = System.IO.Directory.GetCurrentDirectory().ToString() + @"\" + txtSearchEndFile.Text;
                txtShellCmd.Text = strFilePath.ToString();
                StreamReader srFile = new StreamReader(strFilePath, Encoding.GetEncoding("ks_c_5601-1987"));

                lstBox.Items.Clear();

                lstBox.BeginUpdate(); // Application Hang 방지 ㅋ 응답없음 예외처리 => 이거 안먹음. 
                while ((strLine = srFile.ReadLine()) != null)
                {
                    // item add 1000개 제한
                    if (i <= 1000)
                    {
                        lstBox.Items.Add("[" + i + "] " + strLine.ToString());
                    }
                    i += 1;
                }
                i -= 1;
                if (i > 1000)
                {
                    lstBox.Items.Add(" ............. Max 1000 Line ............. ");
                }
                lstBox.Items.Add(" => Search End Line Cnt : " + i.ToString());
                lstBox.EndUpdate();

                lblFindCnt.Text = " * Search Cnt : " + String.Format("{0:#,###}", i);

                srFile.Close();

            }
            catch (Exception ex)
            {
                lstBox.Items.Add(" GetFileInfo Exception : " + ex.ToString());
            }
        }
        #endregion

        #region # CheckLogFileExist
        private bool CheckLogFileExist(string strLogFile)
        {
            bool boolCheck = false;
            for (int i = 0; i < lstLogFileList.Items.Count; i++)
            {
                if (strLogFile == lstLogFileList.Items[i].ToString())
                {
                    boolCheck = true;
                }
            }
            return boolCheck;
        }
        #endregion

        #region # SetProgressbar
        private void SetProgressbarStart()
        {
            //while (!boolThreadStop)
            //{
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;
            progressBar1.Enabled = true;
            //}
        }
        private void SetProgressbarEnd()
        {
            //boolThreadStop = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Enabled = false;
        }
        #endregion

        #region # SetTimer
        /* SetTimer
       private Timer timer;
       //private int timerCount = 0;
       private void SetTimer(string strKind)
       {
           if (strKind == "START")
           {
               // 테스트용으로 타이머 이용
               timer = new Timer();
               timer.Interval = 100;
               timer.Tick += new EventHandler(timer_Tick);

               // 디폴트값 사용 (Maximum=100, Minimum=0, Step=10)
               //progressBar1.Style = ProgressBarStyle.Blocks;
                                    
               //// 최대,최소,간격을 임의로 조정
               //progressBar1.Style = ProgressBarStyle.Continuous;
               //progressBar1.Minimum = 0;
               //progressBar1.Maximum = 90;
               //progressBar1.Step = 5;
               //progressBar1.Value = 0;

               //// Marquee 스타일
               progressBar1.Style = ProgressBarStyle.Marquee;
               progressBar1.MarqueeAnimationSpeed = 10;
               progressBar1.Enabled = true;
                    
               // 테스트를 위해 타이머 시작
               timer.Start();
           }
           else
           {
               timer.Stop();
               progressBar1.Style = ProgressBarStyle.Continuous;
               progressBar1.MarqueeAnimationSpeed = 0;
               progressBar1.Enabled = false;                
           }

       }
       void timer_Tick(object sender, EventArgs e)
       {
           // 한 스텝 이동
           progressBar1.PerformStep();
       }
       */
        #endregion

    }

    #region # class LibCommon
    public class LibCommon
    {
        private string strLogFile;

        public string ChooseFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strLogFile = folderBrowserDialog1.SelectedPath;
            }
            return strLogFile;
        }
        public string ChooseFilePath()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "F:\\";
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory().ToString();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    strLogFile = openFileDialog1.FileName.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return strLogFile;
        }
        public ArrayList ChooseFileMultiPath()
        {
            ArrayList alFile = new ArrayList();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "F:\\";
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory().ToString();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (String file in openFileDialog1.FileNames)
                    {
                        //strLogFile = strLogFile + "," + file.ToString();
                        alFile.Add(file.ToString());

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return alFile;
        }
    }
    #endregion


    #region # class LibShell
    public class LibShell
    {
        //public string strOutputMessage;
        public void ExecuteShellCommand(string strCmdText) 
        {
            Process.Start("CMD.exe", strCmdText);
            // MessageBox.Show(ex.ToString());
            /*
            try
            {
                string strCmdText;
                strCmdText = "findstr ticket.interpark.com 500 ex14100107.log > error_20141209.txt";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
        }

        /// <summary>
        /// Execute a shell command
        /// </summary>
        /// <param name="_FileToExecute">File/Command to execute</param>
        /// <param name="_CommandLine">Command line parameters to pass</param> 
        /// <param name="_outputMessage">returned string value after executing shell command</param> 
        /// <param name="_errorMessage">Error messages generated during shell execution</param> 
        public void ExecuteShellCommand(string _FileToExecute, string _CommandLine, ref string _outputMessage, ref string _errorMessage)
        {
            // Set process variable
            // Provides access to local and remote processes and enables you to start and stop local system processes.
            System.Diagnostics.Process _Process = null;
            try
            {
                _Process = new System.Diagnostics.Process();

                // invokes the cmd process specifying the command to be executed.
                string _CMDProcess = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"{0}\cmd.exe", new object[] { Environment.SystemDirectory });

                // pass executing file to cmd (Windows command interpreter) as a arguments
                // /C tells cmd that we want it to execute the command that follows, and then exit.
                string _Arguments = string.Format(System.Globalization.CultureInfo.InvariantCulture, "/C {0}", new object[] { _FileToExecute });

                // pass any command line parameters for execution
                if (_CommandLine != null && _CommandLine.Length > 0)
                {
                    _Arguments += string.Format(System.Globalization.CultureInfo.InvariantCulture, " {0}", new object[] { _CommandLine, System.Globalization.CultureInfo.InvariantCulture });
                }

                // Specifies a set of values used when starting a process.
                System.Diagnostics.ProcessStartInfo _ProcessStartInfo = new System.Diagnostics.ProcessStartInfo(_CMDProcess, _Arguments);
                // sets a value indicating not to start the process in a new window. 
                _ProcessStartInfo.CreateNoWindow = true;
                // sets a value indicating not to use the operating system shell to start the process. 
                _ProcessStartInfo.UseShellExecute = false;
                // sets a value that indicates the output/input/error of an application is written to the Process.
                _ProcessStartInfo.RedirectStandardOutput = true;
                _ProcessStartInfo.RedirectStandardInput = true;
                _ProcessStartInfo.RedirectStandardError = true;
                _Process.StartInfo = _ProcessStartInfo;

                // Starts a process resource and associates it with a Process component.
                _Process.Start();

                // Instructs the Process component to wait indefinitely for the associated process to exit.
                _errorMessage = _Process.StandardError.ReadToEnd();
                _Process.WaitForExit();

                // Instructs the Process component to wait indefinitely for the associated process to exit.
                _outputMessage = _Process.StandardOutput.ReadToEnd();
                _Process.WaitForExit();
            }
            catch (Win32Exception _Win32Exception)
            {
                // Error
                Console.WriteLine("Win32 Exception caught in process: {0}", _Win32Exception.ToString());
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }
            finally
            {
                // close process and do cleanup
                _Process.Close();
                _Process.Dispose();
                _Process = null;
            }
        }
    }
    #endregion LibShell

}
