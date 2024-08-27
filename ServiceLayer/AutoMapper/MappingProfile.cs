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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            // Mapping configuration for Product and ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Brand, src => src.MapFrom(src => src.Brand != null ? src.Brand.Name : string.Empty))
                .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                .ForMember(dest => dest.AfterDiscount, opt => opt.Ignore()) // Ignoring read-only property
                .ReverseMap();

            // Mapping configuration for Product and AddProductDto
            CreateMap<Product, AddProductDto>().ReverseMap();

            // Mapping configuration for Order and OrderDto
            CreateMap<Order, OrderDto>().ReverseMap();

            // Mapping configuration for OrderItems and OrderItemDto
            CreateMap<OrderItems, OrderItemDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Product!.Name))
                .ReverseMap();

            // Mapping configuration for Category and CategoryDto
            CreateMap<Category, CategoryDto>().ReverseMap();

            // Mapping configuration for Brand and BrandDto
            CreateMap<Brand, BrandDto>().ReverseMap();

            // Mapping configuration for Cart and CartDto
            CreateMap<Cart, CartDto>().ReverseMap();

            // Mapping configuration for CartItems and CartItemsDto
            CreateMap<CartItems, CartItemsDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Product!.Name))
                .ReverseMap();

            // Mapping configuration for Review and ReviewDto
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Product!.Name))
                .ReverseMap();

            // Mapping configuration for Payment and PaymentDto
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
