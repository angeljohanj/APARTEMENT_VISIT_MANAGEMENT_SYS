using APARTEMENT_VISIT_MANAGEMENT_SYS.Models;
using System.Data.SqlClient;
using System.Data;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Data
{
    public class AptData
    {
        public List<ApartmentModel> ListApartments()
        {
            var oApt = new List<ApartmentModel>();

            var connection = new DataConnection();
            using(var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_ListApartments", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read()) {
                        oApt.Add(new ApartmentModel
                        {
                            AptId = Convert.ToInt32(dReader["AptId"]),
                            AptNum = dReader["AptNum"].ToString(),
                            AptBldg = dReader["AptBldg"].ToString(),
                            AptStatus = dReader["AptStatus"].ToString(),
                        }) ;
                    }
                }
                conn.Close();
            }
            return oApt;
        }
        public bool SaveApartment(ApartmentModel oApt)
        {
            bool ans;
            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_SaveApartment", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("AptNum", oApt.AptNum);
                    sqlCmd.Parameters.AddWithValue("AptBldg", oApt.AptBldg);
                    sqlCmd.Parameters.AddWithValue("AptStatus", oApt.AptStatus);
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    ans = true;
                }
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);
                ans = false;
            }
            return ans;
        }
        public ApartmentModel GetApartment(int aptId)
        {
            ApartmentModel oApt = new ApartmentModel();
            var connection = new DataConnection();
            using(var conn = new SqlConnection(connection.GetString()))
            {
                conn.Open();
                var sqlCmd = new SqlCommand("sp_GetApartment", conn);
                sqlCmd.Parameters.AddWithValue("AptId", aptId);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                using(var dReader = sqlCmd.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        oApt.AptId = Convert.ToInt32(dReader["AptId"]);
                        oApt.AptNum = dReader["AptNum"].ToString();
                        oApt.AptBldg = dReader["AptBldg"].ToString();
                        oApt.AptStatus = dReader["AptStatus"].ToString();
                    }
                }
                conn.Close();
            }
            return oApt;
        }
        public bool DeleteApt (int aptId)
        {
            bool ans;
            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_DeleteApartment", conn);
                    sqlCmd.Parameters.AddWithValue("AptId", aptId);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    ans = true;
                }
            }catch(Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(err);
                ans = false;
            }
            return ans;  
        }
        public bool EditApt(ApartmentModel oApt)
        {
            bool ans;
            try
            {
                var connection = new DataConnection();
                using(var conn = new SqlConnection(connection.GetString()))
                {
                    conn.Open();
                    var sqlCmd = new SqlCommand("sp_EditApartment", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("AptId", oApt.AptId);
                    sqlCmd.Parameters.AddWithValue("AptNum", oApt.AptNum);
                    sqlCmd.Parameters.AddWithValue("AptBldg", oApt.AptBldg);
                    sqlCmd.Parameters.AddWithValue("AptStatus", oApt.AptStatus);
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    ans = true;
                }
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
