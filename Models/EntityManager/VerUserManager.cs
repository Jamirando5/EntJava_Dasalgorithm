using Microsoft.Identity.Client;
using MyWebApplication.Models.DB;
using MyWebApplication.Models.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyWebApplication.Models.EntityManager
{
    public class VerUserManager
    {
 
        public bool IsLoginNameExist(string loginName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.SystemUsers.Where(u => u.LoginName.Equals(loginName)).Any();
            }
        }
        public void VerUserAccount(VerUserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                //Add checking here if login exists

                VerUsers newVerUser = new VerUsers
                {
                    Fullname = user.Fullname,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Birthdate = user.Birthdate,
                    Created_at = DateTime.Now
                };

                db.VerUsers.Add(newVerUser);
                db.SaveChanges();
            }
        }

        public VerUsersModel GetAllUsers()
        {
            VerUsersModel list = new VerUsersModel();

            using (MyDBContext db = new MyDBContext())
            {
                var users = db.VerUsers;

                list.VerUsers = users.Select(records => new VerUserModel()
                {
                    Fullname = records.Fullname,
                    Username = records.Username,
                    Email = records.Email,
                    Password = records.Password,
                    Birthdate = records.Birthdate,
                    Created_at = records.Created_at
                }).ToList();
            }

            return list;
        }
    }
}
