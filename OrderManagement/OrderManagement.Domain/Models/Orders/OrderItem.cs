public class OrderItem : Entity
{
    internal OrderItem(int orderId, int productId, int quantity)
    {
        ValidateProductId(productId);
        ValidateQuantity(quantity);

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem UpdateProductId(int productId)
    {
        ValidateProductId(productId);
        ProductId = productId;
        return this;
    }

    public OrderItem UpdateQuantity(int quantity)
    {
        ValidateQuantity(quantity);
        Quantity = quantity;
        return this;
    }

    private void ValidateProductId(int productId)
    {
        if (productId < OrderModelConstants.OrderItem.MinProductIdLength)
        {
            throw new ArgumentException($"Product ID length must be greater than {OrderModelConstants.OrderItem.MinProductIdLength}.");
        }
    }

    private void ValidateQuantity(int quantity)
    {
        if (quantity < OrderModelConstants.OrderItem.MinQuantity || quantity > OrderModelConstants.OrderItem.MaxQuantity)
        {
            throw new ArgumentException($"Quantity must be between {OrderModelConstants.OrderItem.MinQuantity} and {OrderModelConstants.OrderItem.MaxQuantity}.");
        }
    }
}