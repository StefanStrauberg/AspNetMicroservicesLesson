using AutoMapper;
using Discount.API.DbContexts;
using Discount.API.Models;
using Discount.API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DiscountRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto)
        {
            var coupon = _mapper.Map<Coupon>(couponDto);
            if (coupon.Id > 0)
            {
                _db.Coupons.Update(coupon);
            }
            else
            {
                _db.Coupons.Add(coupon);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<CouponDto>(coupon);
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

        public async Task<CouponDto> GetCouponByName(string productName)
        {
            var coupon = await _db.Coupons.Where(x => x.ProductName == productName).FirstOrDefaultAsync();
            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
