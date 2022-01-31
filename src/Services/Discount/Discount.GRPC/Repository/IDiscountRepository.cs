using Discount.GRPC.Models;
using System.Threading.Tasks;

namespace Discount.GRPC.Repository
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetCouponByName(string productName);
        Task<Coupon> CreateUpdateCoupon(Coupon couponDto);
        Task<bool> DeleteCoupon(int couponId);
    }
}
