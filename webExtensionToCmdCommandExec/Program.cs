
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace webExtensionToCmdCommndExec
{
    class Program
    {
        //エントリポイント
        static void Main(string[] args)
        {
            //Processオブジェクトを作成
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //出力をストリームに書き込むようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            //OutputDataReceivedイベントハンドラを追加
            p.OutputDataReceived += p_OutputDataReceived;

            p.StartInfo.FileName =
                System.Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = @"/c dir c:\ /w";

            //起動
            p.Start();

            //非同期で出力の読み取りを開始
            p.BeginOutputReadLine();

            p.WaitForExit();
            p.Close();

            Console.ReadLine();
        }

        //OutputDataReceivedイベントハンドラ
        //行が出力されるたびに呼び出される
        static void p_OutputDataReceived(object sender,
            System.Diagnostics.DataReceivedEventArgs e)
        {
            //出力された文字列を表示する
            Console.WriteLine(e.Data);
        }
    }
}
