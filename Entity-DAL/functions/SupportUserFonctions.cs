using Entity_DAL.DAL;
using Entity_DAL.Entities;
using Entity_DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_DAL.functions
{
    public class SupportUserFonctions:ISupportUser
    {

        //Add user :only allowed to admin user , will be added later 

        public async Task<SupportUser> AddUser(SupportUser user)
        {
            //we need to encrypte the password before saiving it in the database 
            // we are using " BCrypt.Net " package to do that

            string newPass = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = newPass;
       
            using (var context=new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                await context.AddAsync(user);
                await context.SaveChangesAsync();
            }
            return user;
        }

        public SupportUser Log_in(string mail,string pass)
        {
   
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            { 
               var res  =  context.SupportUsers.SingleOrDefault(u => u.Email == mail);
                if (res!=null &&  BCrypt.Net.BCrypt.Verify(pass, res.Password))
                    return res;
                else return null;
            }

           
        }


    }
}
