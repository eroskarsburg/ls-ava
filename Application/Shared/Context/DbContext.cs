using MySql.Data.MySqlClient;

namespace Application.Shared.Context
{
    public class DbContext
    {
        public static MySqlConnection Connection;

        public static void DBConnect() => Initialize();

        public static void Initialize()
        {
            string dataResponse = $"server=localhost;user id=root;password=Amister@9958;persist security info=False;database=ava_db;";
            //string dataResponse = $"server=192.168.0.164;user id=eros;password=102030;persist security info=False;database=ava_db;";
            try
            {
                Connection = new MySqlConnection();
                Connection.ConnectionString = dataResponse;
            }
            catch (MySqlException ex) { throw new Exception($"{ex.Message} \n {ex.StackTrace}"); }
        }

        public static bool OpenConnection()
        {
            try { Connection.Open(); return true; }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
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
            try { Connection.Close(); return true; }
            catch (MySqlException ex) { throw new Exception($"{ex.Message} \n {ex.StackTrace}"); }
        }
    }
}
