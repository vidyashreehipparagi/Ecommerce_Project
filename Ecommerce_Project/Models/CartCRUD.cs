using System.Data.SqlClient;

namespace Ecommerce_Project.Models
{
    public class CartCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CartCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int AddTOCart(Cart cart)
        {
            int result = 0;

            string qry = "insert into Cart values (@id,@uid,@Qunatity)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", cart.Id);
            cmd.Parameters.AddWithValue("@uid", cart.Uid);
            cmd.Parameters.AddWithValue("@Qunatity", cart.Quantity);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result ;

        }
        public List<Product> ViewCart(int uid)
        {
            List<Product> products = new List<Product>();
            string qry = "select p.*, c.Qunatity,c.CartId from Product p join Cart c on c.id=p.id where c.uid=@uid";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@uid", uid);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToDouble(dr["price"]);
                    p.Imageurl = dr["imageUrl"].ToString();
                    p.Quantity = Convert.ToInt32(dr["Qunatity"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);
                    products.Add(p);
                }
            }
            con.Close();
            return products ;
        }
        public int DeleteCart(int CartId)
        {
            int result = 0;

            string qry = " delete from Cart where CartId=@CartId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@CartId", CartId);
           
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }

    }
}
