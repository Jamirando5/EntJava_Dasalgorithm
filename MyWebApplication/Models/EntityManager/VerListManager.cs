using Microsoft.Identity.Client;
using MyWebApplication.Models.DB;
using MyWebApplication.Models.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyWebApplication.Models.EntityManager
{
    public class VerListManager
    {
        public void AddList(VerListModel list)
        {
            using (MyDBContext db = new MyDBContext())
            {
                //Add checking here if login exists

                VerLists newList = new VerLists
                {
                    Name = list.Name,
                    Description = list.Description, //this has to be encrypted
                    Visibility = list.Visibility,
                    Created_at = DateTime.Now
                };

                db.VerLists.Add(newList);
                db.SaveChanges();

            }
        }
        public void UpdateList(VerListModel list)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Check if a user with the given login name already exists
                VerLists existingList = db.VerLists.FirstOrDefault(l => l.Name == list.Name);

                if (existingList != null)
                {

                        // You can also update other properties of the user as needed
                        existingList.Name = list.Name;
                        existingList.Description = list.Description;
                        existingList.Visibility = list.Visibility;

                    db.SaveChanges();
                }
                else
                {
                    // Add a new user since the user doesn't exist
                    VerLists newList = new VerLists
                    {
                        Name = list.Name,
                        Description = list.Description,
                        Visibility = list.Visibility,
                        Created_at = DateTime.Now
                    };

                    db.VerLists.Add(newList);
                    db.SaveChanges();
                }
            }

        }

        public VerListsModel GetAllLists()
        {
            VerListsModel list = new VerListsModel();

            using (MyDBContext db = new MyDBContext())
            {
                var lists = db.VerLists;

                list.VerLists = lists.Select(records => new VerListModel()
                {
                    Name = records.Name,
                    Description = records.Description,
                    Visibility = records.Visibility,
                    Created_at = records.Created_at
                }).ToList();
            }

            return list;
        }

    }
}

