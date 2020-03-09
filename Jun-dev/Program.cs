using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jun_dev
{
    class Program
    {

        static void Main(string[] args)
        {
            InputActions actionData = new InputActions();
            CreateFiles createFile = new CreateFiles();
            ListData listData = new ListData();
            Commands commandData = new Commands();

            Console.WriteLine(" Enter -help to see commands : ");

            string retry = "no";
            bool save = false;
            bool retrySearch = false;
            Console.WriteLine("choose activity then press Enter : ");
            string command = Console.ReadLine();
            do
            {
                switch (command.ToLower())
                {
                    case "profile":
                        actionData.startTest();
                        retry = "no";
                        save = true;
                        break;
                    case "list":
                        foreach (var item in listData.GetdataList())
                        {
                            Console.WriteLine(item);                           
                        }
                        retry = "no";
                        break;                      
                    case "find":
                        do
                        {
                            Console.WriteLine("please enter name to find file : ");
                            string searchname = Console.ReadLine();
                            if (commandData.findFile(searchname).Count() != 0)
                            {
                                foreach (var item in commandData.findFile(searchname))
                                {
                                    Console.WriteLine(item);
                                    retrySearch = true;
                                }                               
                            }
                            else
                            {
                                Console.WriteLine("incorrect data");
                                Console.WriteLine("please enter name to find file : ");
                                searchname = Console.ReadLine();
                                foreach (var item in commandData.findFile(searchname))
                                {
                                    Console.WriteLine(item);
                                    retrySearch = true;
                                }
                            }
                        }
                        while (retrySearch != true) ;
                        break;
                    case "delete":
                        do
                        {
                            Console.WriteLine("please enter name to find file : ");
                            string searchname = Console.ReadLine();
                            if (commandData.findFile(searchname).Count() != 0)
                            {
                                commandData.deleteFile(searchname);
                                retrySearch = true;                              
                            }
                            else
                            {
                                Console.WriteLine("incorrect data, please enter name to find file : "); 
                                searchname = Console.ReadLine();  
                            }                           
                        }
                        while (retrySearch != true);
                        break;                  
                    case "statistics":
                        Console.WriteLine("Avarage year of profile owner : " + listData.getAvgYear());
                        Console.WriteLine();
                        Console.WriteLine("The most popular language : " + listData.getPopLang());
                        Console.WriteLine();
                        Console.WriteLine("The Most experienced person : " + listData.getExpPerson());
                        Console.WriteLine();
                        retry = "no";
                        break;
                    case "help":
                        foreach (var line in commandData.getInstruction()){
                            Console.WriteLine(line);
                        }
                        retry = "no";
                        break;
                    case "zip":
                        do
                        {
                            Console.WriteLine("please enter name to find file to zip: ");
                            string searchname = Console.ReadLine();
                            if (commandData.findFile(searchname).Count() != 0)
                            {
                                commandData.ZipArchive(searchname);
                                retrySearch = true;
                            }
                            else
                            {
                                Console.WriteLine("incorrect data, please enter name to find file : ");
                                searchname = Console.ReadLine();
                            }
                        }
                        while (retrySearch != true);
                        break;
                    default:
                        Console.WriteLine("invalid input : ");
                        Console.WriteLine("press yes if Would you like to retry or no if you want to exist?");
                        retry = Console.ReadLine();
                        if (retry == "yes")
                        {
                            Console.WriteLine("choose activity then press Enter : ");
                            command = Console.ReadLine();
                        }
                        break;
                }
            }
            while (retry != "no");
            if (save == true)
            {
                Console.WriteLine("press save to save data in file or exist to end console app : ");
                command = Console.ReadLine();
                if (command == "save")
                {
                    createFile.putData(actionData.getdata());
                    Environment.Exit(1);
                        }
                if(command == "exist")
                {
                    Environment.Exit(1);
                }
                Console.ReadKey();
            }
        }
    }
}


