using System;

public class Product
{
    private int _id;
    private byte _category;
    private int _quantity;
    private string _name;
    private int _price;
    private string _description;

    public Product

    private int SetId()
    {

    }

    private byte SetCategory ()
    {

    }

    private int SetQuantity()
    {

    }

    private string SetName()
    {

    }

    private int SetPrice()
    {

    }

    private string SetDescription()
    {

    }

    public DataTable GetAllProducts()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand("GetAllProducts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }

        return dt;
    }
}
