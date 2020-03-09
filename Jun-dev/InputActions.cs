using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun_dev
{
    public class InputActions
    {
        InputData inputData = new InputData();

        //call all data functions
        public void startTest()
        {
            inputPersonaldata();
            inputBirthdayDate();
            inputFavLanguage();
            inputExperience();
            inputMobNumber();
        }

        public void inputPersonaldata()
        {
            //personal data functions
            Console.WriteLine(" Write Yours name, surname and father's names(e.g giorgi beridze,levani) :");
            string PersData = Console.ReadLine();
            bool isString = false;
            do
            {
                if (string.IsNullOrEmpty(PersData))
                {
                    Console.WriteLine(" invalid answer, please check the input");
                    PersData = Console.ReadLine();
                    isString = false;
                }
                else if (PersData == "restart_profile")
                {
                    restartProfile();
                }
                else
                {
                    isString = true;
                }
            }
            while (isString != true);
            inputData.PersonalData = PersData;
        }

        ////birthdate date functions
        public void inputBirthdayDate() {

            Console.WriteLine("write your birthdate :");
            string date = Console.ReadLine();
            DateTime dt;
            if (date == "restart_profile")
            {
                restartProfile();
            }
            while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt) || (date == "restart_profile"))
            {
                Console.WriteLine("Invalid date, please retry");
                date = Console.ReadLine();

                if (date == "restart_profile")
                {
                    restartProfile();
                }
            }
            inputData.BirthDate = dt;
        }


        ////// fav language date functions
        public void inputFavLanguage()
        {
            Console.WriteLine(" write Your favourite Programming Language from the following list:");
            Console.WriteLine(" - PHP, JavaScript, C, C++, Java, C#, Python, Ruby");
            string favLang = Console.ReadLine();
            bool checkFavLang = false;
            do
            {
                if (favLang == "PHP" || favLang == "JavaScript" || favLang == "C" ||
                    favLang == "C++" || favLang == "C#" || favLang == "Python" || favLang == "ruby")
                {
                    checkFavLang = true;
                }
                else if (favLang == "restart_profile")
                {
                    restartProfile();
                }
                else
                {
                    Console.WriteLine("Invalid date, please retry");
                    favLang = Console.ReadLine();
                    checkFavLang = false;
                }
            }
            while (checkFavLang != true);
            inputData.FavLanguage = favLang;
        }


        //// Programming experience date functions
        public void inputExperience()
        {
            Console.WriteLine(" write Your Programming experience in years:");
            int expNumber;
            string input = Console.ReadLine();         
            var checkExpYear = int.TryParse(input, out expNumber);         
            do
            {
                if (input != "restart_profile")
                {
                    if (!checkExpYear || expNumber > 50)
                    {
                        Console.WriteLine("Invalid date, please retry");
                        //checkExpYear = int.TryParse(Console.ReadLine(), out expNumber);
                        input = Console.ReadLine();
                        
                        if(int.TryParse(input, out expNumber))
                        {
                            checkExpYear = true;
                        }
                        else if (input == "restart_profile")
                        {                           
                            restartProfile();
                        }
                    } 
                }
                else
                    {                       
                        restartProfile();
                    }
            }
            while (checkExpYear != true);
            inputData.ExpYears = expNumber;
        }

        //// mobile number date functions
        public void inputMobNumber() {
            Console.WriteLine(" write your mobile number : ");
            int MobNumber;
            string input = Console.ReadLine();
            bool checkMobNumb = int.TryParse(input, out MobNumber);
            do
            {
                if (input != "restart_profile")
                {
                    if (!checkMobNumb || input.Count() > 9 || input.Count() < 9)
                    {
                        Console.WriteLine("Invalid date, please retry");
                        input = Console.ReadLine(); 
                       
                        if(int.TryParse(input, out MobNumber) || input.Count() > 9 || input.Count() < 9)
                        {
                            checkMobNumb = true;
                        }
                        else if (input == "restart_profile")
                        {
                            restartProfile();
                        }                   
                    }
                }
                else
                {
                    restartProfile();
                }
            }
            while (checkMobNumb != true);
            inputData.MobileNumber = MobNumber.ToString();
        }
    
    

        public InputData getdata()
            {
                return inputData;
            }


            public void restartProfile()
            {
                Console.WriteLine(" ");
                Console.WriteLine("profile was restarted ");
                Console.WriteLine(" ");
                startTest();
            }
        }
    }


