using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_DAL.DAL
{   
    //This class will allow us to handel database migration and database updtates
    //because our dbcontext is not sit in our startup project the EF need to know which dbcontext to use 
    public class DatabaseContextFactory:IDesignTimeDbContextFactory<DataBaseContext>

    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            AppConfiguration consString = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            opsBuilder.UseSqlServer(consString.sqlconnectionString);
            return new DataBaseContext(opsBuilder.Options);

        }
    }
}
