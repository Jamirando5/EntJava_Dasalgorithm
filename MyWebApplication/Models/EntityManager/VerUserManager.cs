using MyWebApplication.Models.DB;
using MyWebApplication.Models.ViewModel;
using System;
using System.Linq;

namespace MyWebApplication.Models.EntityManager
{
    public class VerUserManager
    {
        // Method to add a new user to the VerUsers table
        public void VerUserAccount(VerUserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Create a new VerUsers entity with user information
                VerUsers newVerUser = new VerUsers
                {
                    Fullname = user.Fullname,
                    Username = user.Username,
                    Password = user.Password,
                    Birthdate = user.Birthdate,
                    Created_at = DateTime.Now
                };

                // Add the new user to the VerUsers table
                db.VerUsers.Add(newVerUser);

                // Save changes to the database
                db.SaveChanges();
            }
        }

        // Method to update user information in the VerUsers table
        public void UpdateUserAccount(VerUserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Check if a user with the given username already exists in VerUsers
                VerUsers existingVerUser = db.VerUsers.FirstOrDefault(u => u.Username == user.Username);

                if (existingVerUser != null)
                {
                    // Update the existing user's information
                    existingVerUser.Fullname = user.Fullname;
                    existingVerUser.Birthdate = user.Birthdate;

                    // You can update other properties as needed

                    // Save changes to the database
                    db.SaveChanges();
                }
                else
                {
                    // Handle the case where the user doesn't exist
                    // This could be an error or you might want to add a new user, depending on your requirements
                }
            }
        }

        // Method to retrieve all users from the VerUsers table
        public VerUsersModel GetAllUsers()
        {
            VerUsersModel list = new VerUsersModel();

            using (MyDBContext db = new MyDBContext())
            {
                // Retrieve all users from the VerUsers table
                var users = from u in db.VerUsers
                            select new { u };

                // Map the retrieved users to the VerUserModel and add to the list
                list.VerUsers = users.Select(records => new VerUserModel()
                {
                    Fullname = records.u.Fullname,
                    Username = records.u.Username,
                    Password = records.u.Password,
                    Birthdate = records.u.Birthdate,
                    Created_at = records.u.Created_at,
                    // Add other properties as needed
                }).ToList();
            }

            return list;
        }

        // Method to check if a login name exists in SystemUsers table
        public bool IsLoginNameExist(string Username)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.SystemUsers.Any(u => u.LoginName.Equals(Username));
            }
        }

        // Method to get user password from SystemUsers table
        public string GetUserPassword(string Username)
        {
            using (MyDBContext db = new MyDBContext())
            {
                var user = db.SystemUsers.FirstOrDefault(o =>
                o.LoginName.ToLower().Equals(Username));
                return user != null ? user.PasswordEncryptedText : string.Empty;
            }
        }

        // Method to check if a user is in a specific role
        public bool IsUserInRole(string Username, string roleName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                SystemUsers su = db.SystemUsers.Where(o => o.LoginName.ToLower().Equals(Username))?.FirstOrDefault();

                if (su != null)
                {
                    var roles = from ur in db.UserRole
                                join r in db.Role on ur.LookUpRoleID equals r.RoleID
                                where r.RoleName.Equals(roleName) && ur.UserID.Equals(su.UserID)
                                select r.RoleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }
    }
}
