using Entity_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_DAL.DAL

{
    //This class will allow us to interact with our database
    public class DataBaseContext:DbContext

    {   
        //this class to intiate database connection and it's entity
        public class OptionBuild
        {

            //Allow us to configure the connection to database
            public DbContextOptionsBuilder<DataBaseContext> opsBuilder { get; set; }

            //We can obtain and hold on to database configuration information
            public DbContextOptions<DataBaseContext> dbOptions { get; set; }

            //the variable that will get us the connection string
            private AppConfiguration constring { get; set; }

            public OptionBuild()
            {
                constring = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                opsBuilder.UseSqlServer(constring.sqlconnectionString);
                dbOptions = opsBuilder.Options;
            }


        }
        public static OptionBuild ops = new OptionBuild();



        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {

        }
        
        public DbSet<SupportUser> SupportUsers { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

}
