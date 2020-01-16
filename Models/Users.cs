using System;
using System.Collections.Generic;

namespace UserAdding.Models
{
    public class Users
    {
        private bool userFieldsInited;

        public List<User> users;

        public Users()
        {
            users = new List<User>();
            userFieldsInited = false;
        }


        private string[] dictionaryKeys;


        public bool IsUserFieldsInited()
        {
            return userFieldsInited;
        }

        /// <summary>
        ///  Initialize user fields such as FirstName, LastName, etc.
        /// </summary>
        public void InitUserFields(params string[] cells)
        {
            this.dictionaryKeys = cells;
            this.userFieldsInited = true;
        }


        /// <summary>
        ///  Add user to list of users from string[] cells 
        /// </summary>
        public void addUser(params string[] cells)
        {

            Dictionary<string, object> userDictionary = new Dictionary<string, object>();
            for (int i = 0; i < cells.Length; ++i)
            {
                userDictionary[this.dictionaryKeys[i]] = cells[i];
            }
            this.users.Add(Tools.DictionaryToObject<User>(userDictionary));
        }
    }
}
