using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaderTest.Reader;
using Reader;
using System.IO;
using AutoCreator;

namespace ReaderTest
{
    public partial class FormReader : Form
    {                
        //ReaderController Reader;
        public Reader2 Reader;
        ReaderSettings readerSettings = new ReaderSettings();
        public Paths AppPaths;
        string Val ;
        int Num = 0;
        
        public FormReader()
        {
            InitializeComponent();
            
            AppPaths = Paths.Load();
            if (File.Exists(AppPaths.ReaderSettingsPath))
                readerSettings = ISettings.Load<ReaderSettings>(AppPaths.ReaderSettingsPath);
            else
            {
                Form frm = AutoCreator.ControlCreator.CreateForm(readerSettings, AppPaths.ReaderSettingsPath);
                frm.ShowDialog();
            }

            Reader = new Reader2(readerSettings.ListenIP, readerSettings.ListenPort, readerSettings.ReaderIP, readerSettings.ReaderPort, readerSettings.Timeout);            
            Reader.onReceiveData += new ReceiveDataHandler(ReaderListener_onReceiveData);
            Reader.Start();            
        }

        private void FormReader_Load(object sender, EventArgs e)
        {
            //啟動 BackgroundWorker
            //if (!backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.RunWorkerAsync();
            //}
        }

        private delegate void ShowList(object sender, ReceiveDataEventArgs e);

        private void ReaderListener_onReceiveData(object sender, ReceiveDataEventArgs e)
        {
            Val = e.Data;

            //Num++;
            //listBoxOutput.Items.Add($"ID : {Val} #{Num}");

            if (!checkBoxManual.Checked)
            {
                if (this.InvokeRequired) //若非同執行緒
                {
                    ShowList show = new ShowList(ReaderListener_onReceiveData);
                    this.Invoke(show, sender, e);
                }
                else //同執行緒
                {
                    Num++;
                    listBoxOutput.Items.Add($"ID : {Val} #{Num}");
                }
            }   
        }
        
        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;

        //    while (!worker.CancellationPending)
        //    {
        //        if (CheckCondition())
        //        {                    
        //            worker.ReportProgress(0);
        //        }
        //        Thread.Sleep(1000);
        //    }
        //}

        //接收ReportProgress
        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    //執行實際需要的操作
        //    PerformAction();

        //    if(Val == null)
        //    {
        //        return;
        //    }            
        //}

        //需要時處理完成操作
        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //
        //}

        //檢查條件
        //private bool CheckCondition()
        //{
        //    bool result = false;

        //    if (!checkBoxManual.Checked && Val != null)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}

        //執行實際需要的操作
        //private void PerformAction()
        //{            
        //    Num++;
        //    listBoxOutput.Items.Add($"ID : {Val} #{Num}");            
        //}

        private void GetVal_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;

            if (checkBoxManual.Checked)
            {                
                Val = Reader.ReadBarcode();
                
                if (Val != null)
                {
                    Num++;
                    listBoxOutput.Items.Add($"ID : {Val} #{Num}");
                }
                else
                {
                    return;
                }
            }            
        }

        private void FormReader_FormClosed(object sender, FormClosedEventArgs e)
        {
            //關閉 BackgroundWorker
            //if (backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.CancelAsync();
            //}

            if (Reader != null)
            {
                Reader.Stop();
            }
        }

        ////public async Task<string> TimeoutMethod()
        //public string TimeoutMethod()
        //{            
        //    Task<string> taskRead = Task<string>.Factory.StartNew(() => Reader.ReceiceValue);
        //    string result = taskRead.Result;            
        //    return result;
        //}        
    }
}
