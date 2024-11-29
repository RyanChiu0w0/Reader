namespace ReaderTest
{
    partial class FormReader
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.GetVal = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBoxManual = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 12;
            this.listBoxOutput.Location = new System.Drawing.Point(12, 12);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(328, 316);
            this.listBoxOutput.TabIndex = 0;
            // 
            // GetVal
            // 
            this.GetVal.Location = new System.Drawing.Point(265, 360);
            this.GetVal.Name = "GetVal";
            this.GetVal.Size = new System.Drawing.Size(75, 23);
            this.GetVal.TabIndex = 1;
            this.GetVal.Text = "取值";
            this.GetVal.UseVisualStyleBackColor = true;
            this.GetVal.Click += new System.EventHandler(this.GetVal_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // checkBoxManual
            // 
            this.checkBoxManual.AutoSize = true;
            this.checkBoxManual.Location = new System.Drawing.Point(12, 360);
            this.checkBoxManual.Name = "checkBoxManual";
            this.checkBoxManual.Size = new System.Drawing.Size(59, 16);
            this.checkBoxManual.TabIndex = 4;
            this.checkBoxManual.Text = "Manual";
            this.checkBoxManual.UseVisualStyleBackColor = true;
            // 
            // FormReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 394);
            this.Controls.Add(this.checkBoxManual);
            this.Controls.Add(this.GetVal);
            this.Controls.Add(this.listBoxOutput);
            this.Name = "FormReader";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReader_FormClosed);
            this.Load += new System.EventHandler(this.FormReader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Button GetVal;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBoxManual;
    }
}

