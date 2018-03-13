using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace messageBoardUsingASP.Mondels
{
    public class MessageOperate
    {
        string connectionString = "";

        public List<MessageModel> getMessages()
        {
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * From Table";

            List<MessageModel> dataList = new List<MessageModel>();

            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var thisId = Convert.ToInt32();
                var thisName = Convert.ToString();
                var thisMessage = Convert.ToString();
                var thisTime = Convert.ToDateTime();

            
            }
            con.Close();

            return dataList;
            
        }

        public void addMessage(MessageModel data)
        {
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand();

            cmd.CommandText = "";

            cmd.Parameters.Add();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
