using Discount.API.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.API.Repository
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<CouponDto>> GetCoupons();
        Task<CouponDto> GetCouponByName(string productName);
        Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto);
        Task<bool> DeleteCoupon(int couponId);
    }
}
