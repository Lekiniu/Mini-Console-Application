using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Jun_dev
{
    class Commands
    {
        public void deleteFile(string model)
        {
            File.Delete(@"../../InputTexts/"+model+".txt");
        }
        public List<string> findFile(string model)
        {            
            string sourceDirectory = @"../../InputTexts/" + model + ".txt";
            List<string> lines = new List<string>();

            // Write file contents on console.    
            if (File.Exists(sourceDirectory))
                {
                using (StreamReader sr = File.OpenText(sourceDirectory))
                                
                    while (sr.Peek() >= 0)
                        lines.Add(sr.ReadLine());
                }          
            return lines;
        }

        public List<string> getInstruction() {
           
                string sourceDirectory = @"../../Instructions/Instructions.txt";
                List<string> lines = new List<string>();

                // Write file contents on console.    
                if (File.Exists(sourceDirectory))
                {
                    using (StreamReader sr = File.OpenText(sourceDirectory))

                        while (sr.Peek() >= 0)
                            lines.Add(sr.ReadLine());
                }
                return lines;
            }

            public void ZipArchive(string model) {

            string zipDirectory = @"../../InputTexts/" + model + ".zip";
            string getFile= @"../../InputTexts/" + model + ".txt";

            using (var archive = ZipFile.Open(zipDirectory, ZipArchiveMode.Create))
            { 
                    archive.CreateEntryFromFile(getFile, Path.GetFileName(getFile));
                
                }
            }
        }
    }  
