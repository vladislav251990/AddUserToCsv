using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Microsoft.VisualBasic.FileIO;

namespace UserAdding.Models
{
    /// <summary>
    /// Class for data manipulating with csv file 
    /// </summary>
    public class UsersContext
    {

        private string path;

        public IEnumerable<User> GetUsers()
        {
            Users users = new Users();
            using (TextFieldParser myParser = new TextFieldParser(path))
            {

                myParser.TextFieldType = FieldType.Delimited;
                myParser.Delimiters = new string[] { ", " };
                myParser.HasFieldsEnclosedInQuotes = false;
                while (!myParser.EndOfData)
                {

                    if (users.IsUserFieldsInited())
                    {
                        users.addUser(myParser.ReadFields());
                    }
                    else
                    {
                        users.InitUserFields(myParser.ReadFields());
                    }

                }

            }

            return users.users;
        }

        public void AddUser(User user)
        {
            if (File.Exists(path))
            {
                File.AppendAllText(path, Environment.NewLine + user.getCsvRow());
            }
        }

        public UsersContext()
        {
            path = HttpContext.Current.Server.MapPath("~/App_Data/question1.csv");
        }

        public UsersContext(string path)
        {
            this.path = path;
        }
    }
}
