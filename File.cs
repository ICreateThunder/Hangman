using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class File
    {
        public static String getFile(String filePath)
        {
            string fileContents;

            try
            {
                
                using (StreamReader sr = new StreamReader(filePath))
                {
                    fileContents = sr.ReadToEnd();
                }

                return fileContents;
            }
            catch (IOException e)
            {
                Console.WriteLine($"[!] ERROR :: Failed to read/open file. File might not exist.\n\n\nPath: {filePath}\nExeception: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] ERROR :: Something went wrong trying to open the file.\n\nPath: {filePath}\nExeception: {e}");
            }

            return "";
        }
    }
}
