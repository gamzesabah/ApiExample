using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> CreateOrder(Guid userId);
        IDataResult<Order> GetOrderById(Guid orderId);
        IDataResult<IEnumerable<Order>> GetUserOrders(Guid userId);
        IResult UpdateOrderStatus(Guid orderId, string status);
        IDataResult<decimal> GetOrderTotal(Guid orderId);
        IResult CancelOrder(Guid orderId);
        IDataResult<IEnumerable<Order>> GetAllOrders();
        IDataResult<IEnumerable<Order>> GetOrdersByStatus(string status);
    }
}
