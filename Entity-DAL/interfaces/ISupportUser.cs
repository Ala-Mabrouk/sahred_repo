using Entity_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity_DAL.interfaces
{
   public  interface ISupportUser
    {
      // Task<SupportUser> AddUser(string name, string lname, string mail,string pass, string phone,string role,int level);
        SupportUser Log_in(string Email,string pass);
        Task<SupportUser> AddUser(SupportUser user);
    }
}
