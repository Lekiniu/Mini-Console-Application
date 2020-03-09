using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;


namespace Jun_dev
{
    public class CreateFiles
    {
        public string folderPath { get; set; }
        public void putData(InputData model) {
                     
            string fileName = @"../../InputTexts/" + model.PersonalData + ".txt";
            string YearsfileName = @"../../Instructions/years.txt";
            string LangfileName = @"../../Instructions/languages.txt";
            string ExpfileName = @"../../Instructions/Experiences.txt";
            folderPath = fileName;
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // Create a new file                         
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("Name,Surname and Father's Name : <{0}>", model.PersonalData);
                    sw.WriteLine("Birthdate : <{0}>", model.BirthDate.ToString());
                    sw.WriteLine("Favourite programming language : <{0}>", model.FavLanguage);
                    sw.WriteLine("Years of Experience in above chosen Language : <{0}>", model.ExpYears.ToString());
                    sw.WriteLine("Mobile Number : <{0}>", model.MobileNumber);
                    sw.WriteLine("New profile created: <{0}>", DateTime.Now.ToString());
                }

                //create file for years
                if (YearsfileName == null)
                {
                    using (StreamWriter sw = File.CreateText(YearsfileName))
                    {

                        File.AppendAllText(YearsfileName, model.BirthDate.Year.ToString() + ",");
                    }
                }
                else
                {
                    File.AppendAllText(YearsfileName, model.BirthDate.Year.ToString() + ",");
                }

                //create file for the most popular languages
                if (LangfileName == null)
                {
                    using (StreamWriter sw = File.CreateText(LangfileName))
                    {

                        File.AppendAllText(LangfileName, model.FavLanguage + ",");
                    }
                }
                else
                {
                    File.AppendAllText(LangfileName, model.FavLanguage + ",");
                }


                //create file for the most experienced profile
                if (ExpfileName == null)
                {
                    using (StreamWriter sw = File.CreateText(ExpfileName))
                    {

                         File.AppendAllText(ExpfileName, model.PersonalData + "-" +  model.ExpYears + "/");
                    }
                }
                else
                {
                    File.AppendAllText(ExpfileName,  model.PersonalData + "-" + model.ExpYears + "/");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

      
    }
}
