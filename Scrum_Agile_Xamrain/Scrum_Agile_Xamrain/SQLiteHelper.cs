using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_Agile_Xamrain
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Person>().Wait();
            db.CreateTableAsync<Project>().Wait();
            db.CreateTableAsync<Story>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Person person)
        {
            if (person.PersonID != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }



        public Task<int> Save_Project_ItemAsync(Project project)
        {
            if (project.ProjectID != 0)
            {
                return db.UpdateAsync(project);
            }
            else
            {
                return db.InsertAsync(project);
            }
        }

        public Task<int> Save_Story_ItemAsync(Story varstory)
        {
            if (varstory.StoryID != 0)
            {
                return db.UpdateAsync(varstory);
            }
            else
            {
                return db.InsertAsync(varstory);
            }
        }









        //Delete
        public Task<int> DeleteItemAsync(Person person)
        {
            return db.DeleteAsync(person);
        }

        public Task<int> Delete_stroy_ItemAsync(Story story)
        {
            return db.DeleteAsync(story);
        }

        //Read All Items
        public Task<List<Person>> GetItemsAsync()
        {
            return db.Table<Person>().ToListAsync();
        }

        public Task<List<Project>> Get_All_ProjectItemsAsync()
        {
            return db.Table<Project>().ToListAsync();
        }

        public Task<Project> GetItem_Project_Name(string projectname)
        {
            return db.Table<Project>().Where(x => x.Name == projectname).FirstOrDefaultAsync();
           
        }

        public Task<List<Story>> GetItem_Story_Name(string storyname)
        {
            return db.Table<Story>().Where(x => x.Name == storyname).ToListAsync();

        }


        public Task<List<Story>> GetItem_All_Story()
        {
            return db.Table<Story>().ToListAsync();

        }

        //Read Item
        public Task<Person> GetItemAsync(int personId)
        {
            return db.Table<Person>().Where(i => i.PersonID == personId).FirstOrDefaultAsync();
        }




        public Task<Person> LoginValidate(string userName1, string pwd1)
        {

            return db.Table<Person>().Where(x => x.Name == userName1 && x.Passwrd == pwd1).FirstOrDefaultAsync();
          
        }







    }
}