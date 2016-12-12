using System;
using SharpTalk;
using System.Web;
class Program
{
    static void Main(string[] args)
    {
        long length = new System.IO.FileInfo("scripts\\voicequeue.txt").Length;
        System.IO.FileStream file;
        if (length > 0)
        {
            file = System.IO.File.Open("scripts\\voicequeue.txt", System.IO.FileMode.Open);
            byte[] result = new byte[file.Length];
            file.Read(result, 0, (int)file.Length);
            string result2 = System.Text.Encoding.UTF8.GetString(result);
            char delimiter = char.Parse("\n");
            if (result2.Contains("\n"))
            {
                Array lines = result2.Split(delimiter);
                foreach (string i in lines)
                {
                    if (i != "")
                    {
                        speak(i);
                    }
                }
            }
            else
            {
             	speak(result2);
            }
            file.SetLength(0);
            file.Close();
        }
        System.Environment.Exit(1);
    }

    static void speak(string msg)
    {
        using (var tts = new FonixTalkEngine())
        {
            
            System.Collections.Specialized.NameValueCollection list = HttpUtility.ParseQueryString(msg);
           
            string message = list["msg"];
            string ckey = list["ckey"];
            ckey = ckey.Replace(System.Environment.NewLine, string.Empty);
            ckey = ckey.Replace("\r", string.Empty);
            message = HttpUtility.HtmlDecode(message);
            try
            {
            	tts.SpeakToWavFile(string.Format("sound\\playervoices\\{0}.wav", ckey), message);
            }
            catch {
                Console.WriteLine("Failed");
            }
        }
    }
}
