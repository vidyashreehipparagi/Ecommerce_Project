using System.Data.SqlClient;

namespace Ecommerce_Project.Models
{
    public class OrderCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public OrderCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int AddOrder(Order order)
        {
            int result = 0;

            string qry = "insert into Orders(Qunatity,id,uid) values(@Qunatity,@id,@uid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Qunatity", order.Quantity);
            //cmd.Parameters.AddWithValue("@Date_time", order.Date_time);
            cmd.Parameters.AddWithValue("@id", order.Id);
            cmd.Parameters.AddWithValue("@uid", order.Uid);


            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }
        public List<Product> MyOrder(int uid)
        {
            List<Product> products = new List<Product>();
            string qry = "select p.*,o.OrderId,o.Qunatity,o.Date_time from Product p join Orders o on o.id=p.id  where o.uid=@uid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@uid", uid);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToDouble(dr["price"]);
                    p.Imageurl = dr["imageUrl"].ToString();
                    p.Cid = Convert.ToInt32(dr["Cid"]);
                    p.OrderId = Convert.ToInt32(dr["OrderId"]);
                    p.Quantity = Convert.ToInt32(dr["Qunatity"]);
                    p.Date_time = Convert.ToDateTime(dr["Date_time"]);
                    products.Add(p);
                }
            }
            con.Close();
            return products;
        }
    }
}
