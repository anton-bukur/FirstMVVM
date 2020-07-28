using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstMVVM
{
     class Model
    {
        public static void SaveData(string text1, string text2, string text3)
        {
            string writePath = "data.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text1 + Environment.NewLine + text2 + Environment.NewLine + text3);
                    sw.Close();
                }
                text1 = "Successful";
            }
            //потом сделать - убить процесс, если файл занят
            catch (Exception e)
            {
                text1 = e.Message;
            }
            MessageBox.Show(text1);
 
        }
        public static string[] LoadData()
        {
            string Path = "data.txt";
            string[] lines = null;
            if (File.Exists(Path))
            {
                lines = File.ReadAllLines(Path);
            }
            return lines;
        }


    }
}
