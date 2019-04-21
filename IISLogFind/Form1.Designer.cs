namespace IISLogFind
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFind = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.txtSearchEndFile = new System.Windows.Forms.TextBox();
            this.txtSearchData = new System.Windows.Forms.TextBox();
            this.txtShellCmd = new System.Windows.Forms.TextBox();
            this.chkFindAdd = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblFindCnt = new System.Windows.Forms.Label();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstLogFileList = new System.Windows.Forms.ListBox();
            this.btnMultiLogFile = new System.Windows.Forms.Button();
            this.btnLogFileListClear = new System.Windows.Forms.Button();
            this.btnFileDelete = new System.Windows.Forms.Button();
            this.btnFileFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(648, 205);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(129, 30);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Search";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.HorizontalScrollbar = true;
            this.lstBox.ItemHeight = 12;
            this.lstBox.Location = new System.Drawing.Point(14, 291);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(764, 340);
            this.lstBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "* 로그 파일 지정 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 검색 결과 파일명 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "* 검색 데이터 : ";
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(134, 14);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(496, 21);
            this.txtLogFile.TabIndex = 5;
            // 
            // txtSearchEndFile
            // 
            this.txtSearchEndFile.Location = new System.Drawing.Point(134, 145);
            this.txtSearchEndFile.Name = "txtSearchEndFile";
            this.txtSearchEndFile.Size = new System.Drawing.Size(496, 21);
            this.txtSearchEndFile.TabIndex = 6;
            // 
            // txtSearchData
            // 
            this.txtSearchData.Location = new System.Drawing.Point(134, 175);
            this.txtSearchData.Name = "txtSearchData";
            this.txtSearchData.Size = new System.Drawing.Size(496, 21);
            this.txtSearchData.TabIndex = 7;
            // 
            // txtShellCmd
            // 
            this.txtShellCmd.Location = new System.Drawing.Point(18, 246);
            this.txtShellCmd.Name = "txtShellCmd";
            this.txtShellCmd.Size = new System.Drawing.Size(665, 21);
            this.txtShellCmd.TabIndex = 8;
            // 
            // chkFindAdd
            // 
            this.chkFindAdd.AutoSize = true;
            this.chkFindAdd.Checked = true;
            this.chkFindAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFindAdd.Location = new System.Drawing.Point(648, 150);
            this.chkFindAdd.Name = "chkFindAdd";
            this.chkFindAdd.Size = new System.Drawing.Size(96, 16);
            this.chkFindAdd.TabIndex = 9;
            this.chkFindAdd.Text = "검색결과추가";
            this.chkFindAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(520, 205);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(759, 10);
            this.progressBar1.TabIndex = 11;
            // 
            // lblFindCnt
            // 
            this.lblFindCnt.AutoSize = true;
            this.lblFindCnt.Location = new System.Drawing.Point(18, 222);
            this.lblFindCnt.Name = "lblFindCnt";
            this.lblFindCnt.Size = new System.Drawing.Size(0, 12);
            this.lblFindCnt.TabIndex = 12;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(710, 17);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(72, 16);
            this.chkLocation.TabIndex = 13;
            this.chkLocation.Text = "경로지정";
            this.chkLocation.UseVisualStyleBackColor = true;
            this.chkLocation.CheckedChanged += new System.EventHandler(this.chkLocation_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "LogView";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstLogFileList
            // 
            this.lstLogFileList.FormattingEnabled = true;
            this.lstLogFileList.ItemHeight = 12;
            this.lstLogFileList.Location = new System.Drawing.Point(134, 42);
            this.lstLogFileList.Name = "lstLogFileList";
            this.lstLogFileList.Size = new System.Drawing.Size(496, 88);
            this.lstLogFileList.TabIndex = 15;
            // 
            // btnMultiLogFile
            // 
            this.btnMultiLogFile.Location = new System.Drawing.Point(648, 42);
            this.btnMultiLogFile.Name = "btnMultiLogFile";
            this.btnMultiLogFile.Size = new System.Drawing.Size(129, 25);
            this.btnMultiLogFile.TabIndex = 16;
            this.btnMultiLogFile.Text = "Add";
            this.btnMultiLogFile.UseVisualStyleBackColor = true;
            this.btnMultiLogFile.Click += new System.EventHandler(this.btnMultiLogFile_Click);
            // 
            // btnLogFileListClear
            // 
            this.btnLogFileListClear.Location = new System.Drawing.Point(648, 102);
            this.btnLogFileListClear.Name = "btnLogFileListClear";
            this.btnLogFileListClear.Size = new System.Drawing.Size(129, 25);
            this.btnLogFileListClear.TabIndex = 17;
            this.btnLogFileListClear.Text = "Reset";
            this.btnLogFileListClear.UseVisualStyleBackColor = true;
            this.btnLogFileListClear.Click += new System.EventHandler(this.btnLogFileListClear_Click);
            // 
            // btnFileDelete
            // 
            this.btnFileDelete.Location = new System.Drawing.Point(648, 72);
            this.btnFileDelete.Name = "btnFileDelete";
            this.btnFileDelete.Size = new System.Drawing.Size(129, 25);
            this.btnFileDelete.TabIndex = 19;
            this.btnFileDelete.Text = "Delete";
            this.btnFileDelete.UseVisualStyleBackColor = true;
            this.btnFileDelete.Click += new System.EventHandler(this.btnFileDelete_Click);
            // 
            // btnFileFind
            // 
            this.btnFileFind.FlatAppearance.BorderSize = 0;
            this.btnFileFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileFind.Image = global::IISLogFind.Properties.Resources.filefinds1;
            this.btnFileFind.Location = new System.Drawing.Point(641, 12);
            this.btnFileFind.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileFind.Name = "btnFileFind";
            this.btnFileFind.Size = new System.Drawing.Size(45, 25);
            this.btnFileFind.TabIndex = 18;
            this.btnFileFind.UseVisualStyleBackColor = true;
            this.btnFileFind.Click += new System.EventHandler(this.btnFileFind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 652);
            this.Controls.Add(this.btnFileDelete);
            this.Controls.Add(this.btnFileFind);
            this.Controls.Add(this.btnLogFileListClear);
            this.Controls.Add(this.btnMultiLogFile);
            this.Controls.Add(this.lstLogFileList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkLocation);
            this.Controls.Add(this.lblFindCnt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkFindAdd);
            this.Controls.Add(this.txtShellCmd);
            this.Controls.Add(this.txtSearchData);
            this.Controls.Add(this.txtSearchEndFile);
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.btnFind);
            this.Name = "Form1";
            this.Text = "IISLogFind v2.0 - DevOpsFlux";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.TextBox txtSearchEndFile;
        private System.Windows.Forms.TextBox txtSearchData;
        private System.Windows.Forms.TextBox txtShellCmd;
        private System.Windows.Forms.CheckBox chkFindAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFindCnt;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstLogFileList;
        private System.Windows.Forms.Button btnMultiLogFile;
        private System.Windows.Forms.Button btnLogFileListClear;
        private System.Windows.Forms.Button btnFileFind;
        private System.Windows.Forms.Button btnFileDelete;
    }
}

