using System.Collections.Generic;
using System.Data.SqlClient;

namespace messageBoardUsingASP.Models
{
    public class MessageOperate
    {
        string connectionString = "Data Source=DESKTOP-5O49JHS\\SQLEXPRESS;Initial Catalog=MVCtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<MessageModel> SelectAllMessages()
        {
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM  [Table] ";

            List<MessageModel> dataList = new List<MessageModel>();
            
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MessageModel thisData = new MessageModel();
                thisData.Id = reader.GetInt32(0);
                thisData.Name = reader.GetString(1);
                thisData.Message = reader.GetString(2);
                thisData.Time = reader.GetDateTime(3);

                dataList.Add(thisData);
            }
            con.Close();

            return dataList;
            
        }

        public void InsertMessage(MessageModel data)
        {
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO [Table] ( Name, Message, Time) VALUES ( @thisName, @thisMessage, @thisTime)";

            cmd.Parameters.Add(new SqlParameter("@thisName", data.Name));
            cmd.Parameters.Add(new SqlParameter("@thisMessage", data.Message));
            cmd.Parameters.Add(new SqlParameter("@thisTime", data.Time));
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
