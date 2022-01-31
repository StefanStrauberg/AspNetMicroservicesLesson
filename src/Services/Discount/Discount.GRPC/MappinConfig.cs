using AutoMapper;
using Discount.GRPC.Models;
using Discount.GRPC.Models.Dto;

namespace Discount.GRPC
{
    public class MappinConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto,Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
