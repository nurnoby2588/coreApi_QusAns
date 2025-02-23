using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;

namespace coreApi_QusAns.Model
{
    public class ErrorLog
    {
        public static void SaveErrorLog(string formScreen, string ErrorDec )
        {
            string ConnString = DBConnection.getDBConstring();
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "dbo.spErrorLog";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@EventRaiseScreen", formScreen));
            cmd.Parameters.Add(new SqlParameter("@ErrorDec", ErrorDec));

        
            cmd.CommandTimeout = 0;


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
    }
}
