using System.Collections.Generic;
using System.Data.SqlClient; //System.Data是 .net中提供的資料處理API(ADO.NET)
                             //其中SqlClient是負責SQL Server資料庫的API

namespace messageBoardUsingASP.Models
{
    public class MessageOperate
    {   
            // 要連線到的資料庫專屬連接字串
        string connectionString = "Data Source=DESKTOP-1234ABC\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // 查詢所有留言，其結果以串列列表List回傳，每筆內容為物件MessageModel
        public List<MessageModel> SelectAllMessages()
        {
                // 新建立SQL Server資料庫連接物件SqlConnection，並填入要連線資料庫的專屬連接字串connectionString
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand(); // 建立資料庫命令物件Command
            cmd.CommandText = "SELECT * FROM  [MessageTable] "; // 命令內容為"查詢(SELECT) MessageTable資料表中 所有資料(*) "


                // 新建立串列列表List命名為dataList，每筆內容為物件MessageModel
            List<MessageModel> dataList = new List<MessageModel>();
            
            
                // 開啟資料庫連線
            con.Open();
            var reader = cmd.ExecuteReader(); // 使用ExecuteReader執行查詢(SELECT)命令，結果為reader


                // 用while迴圈讀取每筆結果
            while (reader.Read())
            {
                    // thisData為一個新建立MessageModel物件
                MessageModel thisData = new MessageModel();

                thisData.Id = reader.GetInt32(0); // Id為資料表之第0欄，型態為Int整數
                thisData.Name = reader.GetString(1); // Name為資料表之第1欄，型態為String字串
                thisData.Message = reader.GetString(2); // Message為資料表之第2欄，型態為String字串
                thisData.Time = reader.GetDateTime(3); // Time為資料表之第3欄，為DateTimeg時間型態
                
                    // 將thisData物件加入dataList串列列表
                dataList.Add(thisData);
            }

                // 結束資料庫連線
            con.Close(); 

            
                // 將結果回傳
            return dataList;
            
        }

            // 新增一筆留言，內容為物件MessageModel，結果不回傳(void)
        public void InsertMessage(MessageModel data)
        {
                // 新建立SQL Server資料庫連接物件SqlConnection，並填入要連線資料庫的專屬連接字串connectionString
            var con = new SqlConnection(connectionString);
            var cmd = con.CreateCommand(); // 建立資料庫命令物件Command

                // 命令內容為"新增(INSERT) 進 MessageTable資料表，欄位Name為@thisName、欄位Message為@thisMessage、欄位Time為@thisTime "
            cmd.CommandText = "INSERT INTO [MessageTable] ( Name, Message, Time) VALUES ( @thisName, @thisMessage, @thisTime)";

                //使用Parameter保護每筆欄位資料不為駭客的惡意資料
            cmd.Parameters.Add(new SqlParameter("@thisName", data.Name));
            cmd.Parameters.Add(new SqlParameter("@thisMessage", data.Message));
            cmd.Parameters.Add(new SqlParameter("@thisTime", data.Time));

                // 開啟資料庫連線
            con.Open();
            cmd.ExecuteNonQuery(); // 使用ExecuteNonQuery執行新增(INSERT)命令

                // 結束資料庫連線
            con.Close();
        }
    }
}
