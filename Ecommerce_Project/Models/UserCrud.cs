using System.Data.SqlClient;

namespace Ecommerce_Project.Models
{
    public class UserCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public UserCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int AddUser(User user)
        {
            int result = 0;
            string str = "insert into Registration(firstName,lastName,userName,password,confirmpwd,gender,email,phoneNumber,address,city,state,pincode)values(@firstName,@lastName,@userName,@password,@confirmpwd,@gender,@email,@phoneNumber,@address,@city,@state,@pincode)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@firstName",user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@userName", user.UserName);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@confirmpwd", user.Confirmpwd);
            cmd.Parameters.AddWithValue("@gender", user.Gender);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@address", user.Address);
            cmd.Parameters.AddWithValue("@city", user.City);
            cmd.Parameters.AddWithValue("@state", user.State);
            cmd.Parameters.AddWithValue("@pincode", user.Pincode);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public IEnumerable<User> GetAllUser()
        {
            List<User> list = new List<User>();
            string qry = "select * from Registration";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Uid = Convert.ToInt32(dr["uid"]);
                    user.FirstName = dr["firstName"].ToString();
                    user.LastName= dr["lastName"].ToString();
                    user.UserName= dr["userName"].ToString();
                    user.Password = dr["password"].ToString();
                    user.Confirmpwd = dr["confirmpwd"].ToString();
                    user.Gender = dr["gender"].ToString();
                    user.Email= dr["email"].ToString();
                    user.PhoneNumber = dr["phoneNumber"].ToString();
                    user.Address = dr["address"].ToString();
                    user.City = dr["city"].ToString();
                    user.State = dr["state"].ToString();
                    user.Pincode = Convert.ToInt32(dr["pincode"]);
                    user.RoleId = Convert.ToInt32(dr["RoleId"]);


                    list.Add(user);
                }
            }
            con.Close();
            return list;
        }
        public User Login(string username,string password)
        {
            User u= new User();
            string qry = "select * from Registration where username=@userName and password=@password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    u.Uid = Convert.ToInt32(dr["uid"]);
                    //u.FirstName = dr["firstName"].ToString();
                    //u.LastName = dr["lastName"].ToString();
                    u.UserName = dr["userName"].ToString();
                    //u.Password = dr["password"].ToString();
                    //u.Confirmpwd = dr["confirmpwd"].ToString();
                    //u.Gender = dr["gender"].ToString();
                    //u.Email = dr["email"].ToString();
                    //u.PhoneNumber = dr["phoneNumber"].ToString();
                    //u.Address = dr["address"].ToString();
                    //u.City = dr["city"].ToString();
                    //u.State = dr["state"].ToString();
                    //u.Pincode = Convert.ToInt32(dr["pincode"]);
                    u.RoleId = Convert.ToInt32(dr["RoleId"]);

                }
            }
            con.Close();
            return u;
        }



    }
}
