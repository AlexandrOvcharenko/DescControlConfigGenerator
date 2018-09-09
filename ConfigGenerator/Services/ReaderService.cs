using System.IO;

namespace ConfigGenerator.Services
{
    public class ReaderService
    {
        private string IniFile { get; set; }

        public string GetIniFileAsString ()
        {
            StreamReader streamReader = File.OpenText("Entries.txt");

            while (!streamReader.EndOfStream)
            {
                IniFile = streamReader.ReadToEnd();
            }

            streamReader.Close();

            return IniFile;
        }
    }
}
