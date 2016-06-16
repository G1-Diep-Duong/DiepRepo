

using DiepProject.Common;
namespace DiepProject.DataObjects
{
    class Account
    {
        #region Properties
        private string _phone;
        private string _password;
        private string _fullname;

        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string FullName { get { return _fullname; } set { _fullname = value; } }
        #endregion

        public Account() { }
        public Account(string phone, string password, string name)
        {
            this._phone = phone;
            this._password = password;
            this._fullname = name;
        }

        
    }
}
