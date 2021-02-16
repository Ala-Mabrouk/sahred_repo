using Entity_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity_DAL.interfaces;
using Entity_DAL.DAL;
using System.Linq;
 
namespace AppFeatures
{
    public class SupportUserFeature
    {
        ISupportUser newUser = new Entity_DAL.functions.SupportUserFonctions();





        public async Task<Boolean> CreateNewUser(SupportUser user)
        {
     
            try
            {
                
                var res = await newUser.AddUser(user);

                if (res.UserID > 0)
                {
                 
                    return true;
                }
                else
                {
                  
                    return false;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("ERREUR: " + ex);
                return false;
            }

        }
       
        public List<SupportUser> ListUsers()
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                return context.SupportUsers.ToList();
            }
        }

        public  string Log_in(string mail,string pass)
        {
            try
            {
                var res = newUser.Log_in(mail,pass);
                if (res != null)
                {


                    //getting the role

                    using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
                    {
                        string testo = context.Roles.SingleOrDefault(u => u.RoleID == res.RoleId).RoleName;

                        switch (testo)
                        {
                            case "admin": return "admin?"+res.UserID;
                            case "client": return "client?" + res.UserID;
                            default: return "SupportUser?" + res.UserID ;
                        }
                    }
                }
            

             
            }
          
            catch(Exception ex)
            {
                Console.WriteLine("Erreur:" + ex);

            }
            return null;
        }

        public SupportUser getUser(int id)
        {
            return newUser.GetUser(id);
        }

    }

}

