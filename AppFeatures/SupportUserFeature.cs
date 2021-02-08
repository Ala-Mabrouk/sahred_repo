using Entity_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity_DAL.interfaces;

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

        public  Boolean Log_in(string mail,string pass)
        {
            try
            {
                var res = newUser.Log_in(mail,pass);
                if (res!=null)
            {
                return true;// we have a log in 
            }

             
            }
          
            catch(Exception ex)
            {
                Console.WriteLine("Erreur:" + ex);

            }
            return false;
        }



    }
}
