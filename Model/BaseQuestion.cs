using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Runtime.Intrinsics.X86;

namespace coreApi_QusAns.Model
{
    public class BaseQuestion
    {
        [DataMember(Order =1)]
        public int QuestionID { get; set; }
        [DataMember (Order =2)]
        public string? Category { get; set; }
        [DataMember (Order =3)]
        public string? Question { get; set; }

        [DataMember (Order =3)]
        public string? MakeBy { get; set; } 

        [DataMember (Order =3)]
        public DateTime? MakeDate { get; set; }

                


        public static List<BaseQuestion> listQuestion()
        {
            List<BaseQuestion> lstQuestion = new List<BaseQuestion>();
            DataTable dataTable = new DataTable();

            string ConnString = DBConnection.getDBConstring();

            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "dbo.sp_OST_Question";
            cmd.Parameters.Clear();
            //cmd.Parameters.Add(new SqlParameter("@UserName", this.UserName));
            //cmd.Parameters.Add(new SqlParameter("@Password", this.Password));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            connection.Close();
            // link u sintex



            if (dataTable.Rows.Count > 0)
            {
                var pData = (from p in dataTable.AsEnumerable()
                                 // where p.Field<string>("Name") == this.UserName && p.Field<string>("Password") == this.Password
                             select new
                             {
                                 QuestionID = p.Field<int>("QuestionID"),
                                 Category = p.Field<string>("Category"),
                                 Question = p.Field<string>("Question"),
                                 MakeBy = p.Field<string>("MakeBy"),
                                 MakeDate = p.Field<DateTime?>("MakeDate"),
                                

                             }).ToList();
                foreach (var obj in pData)
                {
                    BaseQuestion baseQuestion = new BaseQuestion();
                    baseQuestion.QuestionID = obj.QuestionID;
                    baseQuestion.Category = obj.Category;
                    baseQuestion.Question = obj.Question;
                    baseQuestion.MakeBy = obj.MakeBy;
                    baseQuestion.MakeDate = obj.MakeDate;
                    lstQuestion.Add(baseQuestion);   
                }

            }
            return lstQuestion;

        }

        public static BaseQuestion? singleQuestion(int QuestionID)
        {
            DataTable dataTable = new DataTable();
            string ConnString = DBConnection.getDBConstring();

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.sp_singleQuestion", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@QuestionID", QuestionID));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            if (dataTable.Rows.Count > 0)
            {
                var p = dataTable.Rows[0];

                return new BaseQuestion
                {
                    QuestionID = p.Field<int>("QuestionID"),
                    Category = p.Field<string>("Category"),
                    Question = p.Field<string>("Question"),
                    MakeBy = p.Field<string>("MakeBy"),
                    MakeDate = p.IsNull("MakeDate") ? null : p.Field<DateTime?>("MakeDate")
                };
            }

            return null;
        }
        public static bool deleteQuestion(int QuestionID)
        {
            DataTable dataTable = new DataTable();
            string ConnString = DBConnection.getDBConstring();

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.sp_deleteQuestion", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@QuestionID", QuestionID));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            int rowsAffect = dataTable.Rows.Count;
            return rowsAffect > 0;

            
        }public static bool updateQuestion(BaseQuestion baseQuestion)
        {
            DataTable dataTable = new DataTable();
            string ConnString = DBConnection.getDBConstring();

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.sp_updateQuestion", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@QuestionID", baseQuestion.QuestionID));
                    cmd.Parameters.Add(new SqlParameter("@Question", baseQuestion.Question));
                    cmd.Parameters.Add(new SqlParameter("@MakeBy", baseQuestion.MakeBy));
                    

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            int rowsAffect = dataTable.Rows.Count;
            return rowsAffect > 0;

            
        }



    }
}
