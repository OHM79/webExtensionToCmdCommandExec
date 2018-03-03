using System.Windows.Forms;

namespace native2
{
    class Program
    {
        static void Main(string[] args)
        {
            string outString = "host start";
            NativeMessage.OpenStandardStreamOut(outString);
            string inStr = NativeMessage.OpenStandardStreamIn();
            MessageBox.Show(inStr, "native host");
        }
    }
}