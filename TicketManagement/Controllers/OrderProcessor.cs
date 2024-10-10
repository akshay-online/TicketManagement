namespace TicketManagement.Controllers
{
    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // Validate order details
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (string.IsNullOrEmpty(order.CustomerName))
            {
                throw new ArgumentException("Customer name is required");
            }

            if (order.Items == null || order.Items.Count == 0)
            {
                throw new ArgumentException("Order must have at least one item");
            }

            // Log the order details
            Console.WriteLine($"Processing order for {order.CustomerName}");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"Item: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }

            // Calculate total price
            double totalPrice = 0;
            foreach (var item in order.Items)
            {
                totalPrice += item.Quantity * item.Price;
            }

            Console.WriteLine($"Total price: {totalPrice}");

            // Apply discount if applicable
            if (order.DiscountCode != null && order.DiscountCode == "SAVE10")
            {
                totalPrice *= 0.9;
                Console.WriteLine("Applied 10% discount. New total price: " + totalPrice);
            }

            // Validate payment
            if (string.IsNullOrEmpty(order.PaymentMethod))
            {
                throw new ArgumentException("Payment method is required");
            }

            if (order.PaymentMethod == "CreditCard")
            {
                if (string.IsNullOrEmpty(order.CreditCardNumber))
                {
                    throw new ArgumentException("Credit card number is required for payment");
                }
                Console.WriteLine("Processing credit card payment...");
            }
            else if (order.PaymentMethod == "PayPal")
            {
                if (string.IsNullOrEmpty(order.PayPalEmail))
                {
                    throw new ArgumentException("PayPal email is required for payment");
                }
                Console.WriteLine("Processing PayPal payment...");
            }
            else
            {
                throw new ArgumentException("Unknown payment method");
            }

            // Finalize order
            Console.WriteLine("Order processed successfully");
        }
    }

    public class Order
    {
        public string CustomerName { get; set; }
        public string PayPalEmail { get; set; }
        public string PaymentMethod { get; set; }
        public string CreditCardNumber { get; set; }
        public string DiscountCode { get; set; }
        public List<Items> Items { get; set; }
        
    }
    public class Items
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

}
