using AutoMapper;
using DataLayer.Models;
using ServiceLayer.DTOs.ProductDTO;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.CartDTO;
using ServiceLayer.DTOs.OrderDTO;
using ServiceLayer.DTOs.PaymentDTO;
using ServiceLayer.DTOs.UserDTO;

namespace ServiceLayer.AutoMapper
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<RegisterDto,User>().ReverseMap();
            CreateMap<UserDto,User>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Brand, src => src.MapFrom(src => src.Brand!.Name))
                .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Category!.Name))
                .ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemDto>()
                .ForMember(dest=>dest.ProductName,src=>src.MapFrom(src=>src.Product!.Name))
                .ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Brand,BrandDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItems, CartItemsDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Product!.Name))
                .ReverseMap();

         

            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Product!.Name))
                .ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
        }




    }
}
