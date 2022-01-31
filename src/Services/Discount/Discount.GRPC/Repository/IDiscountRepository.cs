using Discount.GRPC.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.GRPC.Repository
{
    public interface IDiscountRepository
    {
        Task<CouponDto> GetCouponByName(string productName);
        Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto);
        Task<bool> DeleteCoupon(int couponId);
    }
}
