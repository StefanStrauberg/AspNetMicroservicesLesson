using AutoMapper;
using Discount.GRPC.Models;
using Discount.GRPC.Models.Dto;
using Discount.GRPC.Protos;

namespace Discount.GRPC
{
    public class MappinConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon,CouponModel>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
