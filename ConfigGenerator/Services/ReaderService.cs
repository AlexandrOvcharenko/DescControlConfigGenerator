using System.IO;

namespace ConfigGenerator.Services
{
    public class ReaderService
    {
        private string IniFile { get; set; }

        public string GetIniFileAsString(string iniFilePath)
        {
            var a = new StreamReader(iniFilePath, System.Text.Encoding.GetEncoding(1251));

            while (!a.EndOfStream)
            {
                IniFile = a.ReadToEnd();
            }

            a.Close();

            return IniFile;
        }
    }
}
