using System;
using System.Collections.Generic;
using WikimediaProject_Bussiness.Model;
using WikimediaProject_Bussiness.Repository;
using System.Linq;
namespace WikimediaProject_Console
{
    class Program
    {

       
        static void Main(string[] args)
        {


            
                ProcessInformation objProcessData = new ProcessInformation();
                objProcessData.ProcessAllData();
            
                Console.ReadLine();
        }





    }
  
       

    
}