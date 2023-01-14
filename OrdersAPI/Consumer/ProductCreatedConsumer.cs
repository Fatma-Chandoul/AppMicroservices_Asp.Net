using MassTransit;
using OrdersAPI.Data;
using Shared;

namespace OrdersAPI.Consumer
{
    public class ProductCreatedConsumer :IConsumer<ProductCreated>

    {
        private readonly OrdersAPIContext ordersAPIContext;
        public ProductCreatedConsumer(OrdersAPIContext ordersAPIContext)
        {
            this.ordersAPIContext = ordersAPIContext;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {

            var newProduct = new Product
            {
                Name = context.Message.Name
            };
            ordersAPIContext.Add(newProduct);
            await ordersAPIContext.SaveChangesAsync();
        }
    }
}
