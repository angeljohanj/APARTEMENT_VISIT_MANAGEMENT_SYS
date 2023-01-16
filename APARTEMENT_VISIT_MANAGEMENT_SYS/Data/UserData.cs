using System.Data.SqlClient;
using System.Data;
using APARTEMENT_VISIT_MANAGEMENT_SYS.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Data
{
    public class UserData
    {

        public UserModel Validate(string email, string pass)
        {
            var oUser = new UserModel();

            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_ValidateUser", conn);
                    sqlCmd.Parameters.AddWithValue("Email", email);
                    sqlCmd.Parameters.AddWithValue("UserPassword", pass);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    using(var dReader = sqlCmd.ExecuteReader())
                    {
                        if (dReader.Read())
                        {
                            oUser.UserId = Convert.ToInt32(dReader["UserId"]);
                            oUser.Username = dReader["Username"].ToString();
                            oUser.Role = dReader["Role"].ToString();
                        }
                        else
                        {
                            oUser = null;
                        }
                        
                    }
                    conn.Close();
                }
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);                
            }

            return oUser;
        }
        public List<UserModel> ListUsers()
        {
            var oUsers = new List<UserModel>();

            var connection = new DataConnection();

            using (var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_ListUsers", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oUsers.Add(new UserModel
                        {
                            UserId = Convert.ToInt32(dReader["UserId"]),
                            Username = dReader["Username"].ToString(),
                            UserPassword = dReader["UserPassword"].ToString(),
                            ContactNum = dReader["ContactNum"].ToString(),
                            Email = dReader["Email"].ToString(),
                            RegDate = dReader["RegDate"].ToString(),
                            Role = dReader["Role"].ToString()
                        }); 
                    }
                }
                conn.Close();
            }
            return oUsers;
        }

        public UserModel GetUser (int UserId)
        {
            var oUser = new UserModel();
            var connection = new DataConnection();

            using(var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_GetUser", conn);
                sqlCmd.Parameters.AddWithValue("UserId", UserId);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                
                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oUser.UserId = Convert.ToInt32( dReader["UserId"] );
                        oUser.Username = dReader["Username"].ToString();
                        oUser.UserPassword = dReader["UserPassword"].ToString();
                        oUser.ContactNum = dReader["ContactNum"].ToString();
                        oUser.Email = dReader["Email"].ToString();
                        oUser.RegDate = dReader["RegDate"].ToString();
                        oUser.Role = dReader["Role"].ToString();
                    }
                }
                conn.Close();
            }
            return oUser;
        }

        public bool SaveUser(UserModel oUser)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using (var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SaveUser", conn);
                    sqlCmd.Parameters.AddWithValue("Username", oUser.Username);
                    sqlCmd.Parameters.AddWithValue("UserPassword", oUser.UserPassword);
                    sqlCmd.Parameters.AddWithValue("ContactNum", oUser.ContactNum);
                    sqlCmd.Parameters.AddWithValue("Email", oUser.Email);
                    sqlCmd.Parameters.AddWithValue("RegDate", oUser.RegDate);
                    sqlCmd.Parameters.AddWithValue("Role", oUser.Role);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                }
                ans = true;
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);
                ans = false;
            }
            return ans;
        }

        public bool EditUser(UserModel oUser)
        {
            bool ans;

            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_EditUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserId", oUser.UserId);
                    sqlCmd.Parameters.AddWithValue("Username", oUser.Username);
                    sqlCmd.Parameters.AddWithValue("UserPassword", oUser.UserPassword);
                    sqlCmd.Parameters.AddWithValue("ContactNum", oUser.ContactNum);
                    sqlCmd.Parameters.AddWithValue("Email", oUser.Email);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                }
                ans = true;
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);
                ans = false;
            }

            return ans;
        }
        public bool SoftDeleteUser(int userId)
        {
            bool ans;
            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SoftDeleteUser", conn);
                    sqlCmd.Parameters.AddWithValue("UserId", userId);
                    sqlCmd.CommandType= CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                }
                ans = true;
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);
                ans = false;
            }
            return ans;
        }
    }
}
