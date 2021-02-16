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
    public class SupportUserFonctions : ISupportUser
    {



        //making a globale DataBaseContext variable :
        private static DataBaseContext context = new DataBaseContext(DataBaseContext.ops.dbOptions);



        //Add user :only allowed to admin user , will be added later 

        public async Task<SupportUser> AddUser(SupportUser user)
        {
            //we need to encrypte the password before saving it in the database 
            // we are using " BCrypt.Net " package to do that

            string newPass = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = newPass;



            await context.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public SupportUser Log_in(string mail, string pass)
        {

            var res = context.SupportUsers.SingleOrDefault(u => u.Email == mail);
            if (res != null && pass == res.Password)//BCrypt.Net.BCrypt.Verify(pass, res.Password))
                return res;
            else return null;

        }

        public SupportUser GetUser(int id)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))

                return context.SupportUsers.SingleOrDefault(u => u.UserID == id);


        }

        public List<SupportUser> ListUsers()
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))

                return context.SupportUsers.ToList();

        }

    }
}
