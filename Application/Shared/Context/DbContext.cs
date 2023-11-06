using MySql.Data.MySqlClient;

namespace Application.Shared.Context
{
    public class DbContext
    {
        public static MySqlConnection connection;
        Banco banco = new Banco();

        public static void DBConnect()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Banco banco = new Banco();
            string dataResponse = $"server=localhost;user id=root;password=Amister@9958;persist security info=False;database=ava_db;";
            //string dataResponse = $"server=192.168.0.164;user id=eros;password=102030;persist security info=False;database=ava_db;";

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

        public static bool OpenConnection()
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

        public static bool CloseConnection()
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
