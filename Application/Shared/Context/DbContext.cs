using MySql.Data.MySqlClient;

namespace Application.Shared.Context
{
    public class DbContext
    {
        public MySqlConnection connection;
        Banco banco = new Banco();

        public void DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            Banco banco = new Banco();

            banco.HostMySql = "192.168.0.164";
            banco.DataBaseMySql = "avaDbCentral";
            banco.UsernameMySql = "eros";
            banco.PasswordMySql = "102030";

            string dataResponse;
            dataResponse = "SERVER=" + banco.HostMySql + ";" + "DATABASE=" +
            banco.DataBaseMySql + ";" + "UID=" + banco.UsernameMySql + ";" + "PASSWORD=" + banco.PasswordMySql + ";";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = dataResponse;
                //connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
