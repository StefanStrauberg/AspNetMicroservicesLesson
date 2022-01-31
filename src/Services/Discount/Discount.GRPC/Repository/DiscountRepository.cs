using Discount.GRPC.DbContexts;
using Discount.GRPC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.GRPC.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _db;

        public DiscountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Coupon> CreateUpdateCoupon(Coupon coupon)
        {
            if (coupon.Id > 0)
            {
                _db.Coupons.Update(coupon);
            }
            else
            {
                _db.Coupons.Add(coupon);
            }
            await _db.SaveChangesAsync();
            return coupon;
        }

        public async Task<bool> DeleteCoupon(int couponId)
        {
            try
            {
                var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.Id == couponId);
                if (coupon == null)
                {
                    return false;
                }
                _db.Coupons.Remove(coupon);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Coupon> GetCouponByName(string productName)
        {
            var coupon = await _db.Coupons.Where(x => x.ProductName == productName).FirstOrDefaultAsync();
            return coupon;
        }
    }
}
