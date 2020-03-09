using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jun_dev
{
    public class ListData
    {
        
        public List<string> GetdataList()
        {
            string sourceDirectory = @"../../InputTexts/";
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
            List<string> lines = new List<string>();          

            // Write file contents on console.  
            foreach (string currentFile in txtFiles)
            {
                lines.Add(" ");
                lines.Add("Next Profile : ");               
                using (StreamReader sr = File.OpenText(currentFile))
                {
                    while (sr.Peek() >= 0)
                        lines.Add(sr.ReadLine());
                }
                
            }
            return lines;
        }

        // avarage years block 
        public string getAvgYear()
        {
            var AvgYears = "";
            string sourceDirectory = @"../../Instructions/years.txt";
            List<string> lines = new List<string>();

            // Write file contents on console.            
            using (StreamReader sr = File.OpenText(sourceDirectory))
            {
                while (sr.Peek() >= 0)
                    lines.Add(sr.ReadLine());
            }

            var listAsString = string.Join(",", lines.ToArray());           
            var yearsList = listAsString.Split(',').ToList();
            yearsList.RemoveAt(yearsList.Count() - 1);
             var result= yearsList.ConvertAll(int.Parse);
            var years = new List<int>();
            foreach (int number in result)
            {
                int dateNow = DateTime.Now.Year;
                years.Add(dateNow - number);
            }
            int resultInt = (int)years.Average();
            AvgYears = resultInt.ToString();
            return AvgYears;
        }

        // most popular language block 
        public string getPopLang()
        {          
            string sourceDirectory = @"../../Instructions/languages.txt";
            List<string> lines = new List<string>();

            // Write file contents on console.            
            using (StreamReader sr = File.OpenText(sourceDirectory))
            {
                while (sr.Peek() >= 0)
                    lines.Add(sr.ReadLine());
            }
            var listAsString= string.Join(",", lines.ToArray());
            var langList = listAsString.Split(',').ToList();

            var popLang = langList.GroupBy(x => x).OrderByDescending(g => g.Count()).FirstOrDefault().Key.ToString();
          
            return popLang;
        }

        public string getExpPerson()
        {
            string sourceDirectory = @"../../Instructions/Experiences.txt";
            List<string> lines = new List<string>();
           // List<string> stringsList = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            // Write file contents on console.            
            using (StreamReader sr = File.OpenText(sourceDirectory))
            {
                while (sr.Peek() >= 0)
                    lines.Add(sr.ReadLine());
            }
                var listAsString = string.Join(",", lines.ToArray());
                var myList = listAsString.Split('/').ToList();
                myList.RemoveAt(myList.Count() - 1);

            foreach (string line in myList)
            {
                string[] keyvalue = line.Split('-');
                if (keyvalue.Length == 2)
                {
                    dict.Add(keyvalue[0], Convert.ToInt32(keyvalue[1]));
                }
            }
            var keyOfMaxValue = dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}

