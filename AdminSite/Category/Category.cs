//using System;

//public class Category
//{
//    private int _id;
//    private string _name;

//    private int SetId()
//    {

//    }

//    private string SetName()
//    {

//    }

//    private DataTable GetAllCategories()
//    {
//        public DataTable GetAllCategories()
//        {
//            DataTable dt = new DataTable();

//            using (SqlConnection conn = GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("SelectAllCategories", conn))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;

//                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                    {
//                        sda.Fill(dt);
//                    }
//                }
//            }

//            return dt;
//        }
//    }
//}
