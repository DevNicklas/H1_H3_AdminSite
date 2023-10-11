namespace AdminSite.Utils
{
    /// <summary>
    /// All stored procedres.
    /// </summary>
    public enum Procedures
    {
        //Products
        InsertProduct,
        SelectProduct,
        DeleteProduct,
        UpdateProduct,
        SelectAllProducts,
        SubtractAmountFromProduct,

        //Orderes
        SelectOrdersByUserID,
        SelectOrderItemsByOrderID,
        CreateOrder,
        DeleteOrderItem,
        CreateOrderItem,
        
        //Category
        InsertCategory,
        UpdateCategory,
        DeleteCategory,
        SelectAllCategories,
        CreateNewCategory,


        //User
        SelectUserIDByUserName,
        DeleteUser,
        InsertNewUser,
        ValidateUser,
        UpdateUser,

        //Misc
        SelectTop5Images,
        InsertSpec
    }
}