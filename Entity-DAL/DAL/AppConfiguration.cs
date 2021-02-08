using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace Entity_DAL.DAL
{

        //This class allow us to get the connection string from appsettings.json and use it at any time
   public class AppConfiguration
    {
        public string sqlconnectionString { get; set; }

        //constructor
        public  AppConfiguration()
        {   //used to obtaine configuration settings and key values from a configuration file
            var configBuilder = new ConfigurationBuilder();
            //Getting the file path
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();//the json file is build now
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");//getting the string from it's section

            sqlconnectionString = appSetting.Value;


            }
    }
}
