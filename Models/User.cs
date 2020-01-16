using System;
namespace UserAdding.Models
{
    public class User
    {
        private string isActive;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string IsActive
        {
            get
            {
                return isActive != null ? isActive : "false";
            }
            set
            {
                isActive = value;
            }
        }

        public string getCsvRow()
        {
            return FirstName + ", " +
                LastName + ", " +
                Address + ", " +
                City + ", " +
                State + ", " +
                Zip + ", " +
                ((IsActive == "true" || IsActive == "on")? "true" : "false");
        }

    }
}
