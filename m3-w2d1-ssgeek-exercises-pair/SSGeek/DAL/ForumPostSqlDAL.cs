using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ForumPostSqlDAL : IForumPostDAL
    {
        string connectionString = @"Data Source=DESKTOP-6JSSBN8\SQLEXPRESS;Initial Catalog=ForumPost;Integrated Security=True;";
        string SQL_GetAllPosts = "SELECT id, username, subject, message, post_date FROM forum_post;";
        string SQL_SaveNewPost = "INSERT INTO forum_post (username, subject, message, post_date) VALUES (@username, @subject, @message, getdate());";
        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> result = new List<ForumPost>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllPosts, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ForumPost f = new ForumPost();
                        f.Id = Convert.ToInt32(reader["id"]);
                        f.Username = Convert.ToString(reader["username"]);
                        f.Subject = Convert.ToString(reader["subject"]);
                        f.Message = Convert.ToString(reader["message"]);
                        f.PostDate = Convert.ToDateTime(reader["post_date"]);

                        result.Add(f);
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log and throw the exception
                throw new NotImplementedException();
            }

            return result;

        }

        public bool SaveNewPost(ForumPost post)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewPost, conn);

                    cmd.Parameters.AddWithValue("@username", post.Username);
                    cmd.Parameters.AddWithValue("@subject", post.Subject);
                    cmd.Parameters.AddWithValue("@message", post.Message);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0) ? true : false;
                }
            }
            catch (SqlException ex)
            {
                //Log and throw the exception
                throw new NotImplementedException();
            }
        }
    }
}