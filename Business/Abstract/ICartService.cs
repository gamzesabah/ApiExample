using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICartService
    {
        IDataResult<Cart> GetCartByUserId(Guid userId);
        IDataResult<CartItem> AddItemToCart(Guid userId, Guid productId, int quantity);
        IResult UpdateCartItemQuantity(Guid userId, Guid productId, int quantity);
        IResult RemoveItemFromCart(Guid userId, Guid productId);
        IResult ClearCart(Guid userId);
        IDataResult<decimal> GetCartTotal(Guid userId);
    }
}
