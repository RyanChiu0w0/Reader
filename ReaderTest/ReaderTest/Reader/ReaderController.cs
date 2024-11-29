using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader;
using AutoCreator;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace ReaderTest.Reader
{
    public class ReaderController
    {
        public ReaderSettings Settings = new ReaderSettings();
        public Reader2 Reader;
        
        private string Value { get; set; }

        public ReaderController(string settingFilePath)
        {
            if (File.Exists(settingFilePath))
                Settings = ISettings.Load<ReaderSettings>(settingFilePath);
            else
            {
                Form frm = AutoCreator.ControlCreator.CreateForm(Settings, settingFilePath);
                frm.ShowDialog();
            }
        }

        public void Connect()
        {
            if (Reader == null)
            {
                Reader = new Reader2(Settings.ListenIP, Settings.ListenPort, Settings.ReaderIP, Settings.ReaderPort, Settings.Timeout);
                Reader.onReceiveData += new ReceiveDataHandler(ReaderListener_onReceiveData);               
            }
            
            Reader.Start();
        }
        
        //public async Task<string> GetBarcode(CancellationToken token)
        public string GetBarcode()
        {
            string barcode = "";
            //while (!token.IsCancellationRequested)
            //{
            //    barcode = Reader.ReadBarcode();
            //}
            
            try
            {
                //barcode = Reader.ReadBarcode();

                //reader取值
                barcode = Reader.ReceiceValue;
                
                if (barcode == "")
                {
                    MessageBox.Show(" GetBarcode_Timeout");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //await Task.Delay(100);
            //Thread.Sleep(100);
            return barcode;
        }

        /// <summary>
        /// 觸發讀取，並等待直到接收到讀取結果。
        /// </summary>
        /// <returns></returns>
        //public async Task<string> Read()
        public string Read()                        
        {
            Value = "";
            //string respone = Reader.ReadBarcode();
            string respone = GetBarcode();
            Value = respone;

            DateTime startTime = DateTime.Now;
            while (Value == "")
            {
                Thread.Sleep(50);
                if ((DateTime.Now - startTime).TotalMilliseconds > Settings.Timeout)
                {
                    //throw new Exception($"Reader監聽程式開啟逾時(超過{Settings.Timeout / 1000}秒)！");
                    return "N/A";
                }
            }
            return Value.Trim();
        }

        private void ReaderListener_onReceiveData(object sender, ReceiveDataEventArgs e)
        {
            Value = e.Data;
        }

        public void Disconnect()
        {
            if (Reader != null)
                Reader.Stop();
        }

    }
}
