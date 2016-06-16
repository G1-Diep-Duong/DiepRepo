

using DiepProject.Common;
namespace DiepProject.DataObjects
{
    class Account
    {
        #region Properties
        private string _phone;
        private string _password;

        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        #endregion

        public Account() { }
        public Account(string phone, string password)
        {
            this._phone = phone;
            this._password = password;
        }

        
    }
}
