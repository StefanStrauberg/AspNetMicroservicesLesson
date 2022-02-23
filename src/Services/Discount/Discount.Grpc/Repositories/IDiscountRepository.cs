﻿using Discount.Grpc.Entities;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> Get(string name);
        Task<bool> Create(Coupon coupon);
        Task<bool> Update(Coupon coupon);
        Task<bool> Delete(string name);
    }
}
