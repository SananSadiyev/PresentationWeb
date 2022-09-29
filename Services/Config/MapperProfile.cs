using AutoMapper;
using DataAcces.BseEntities;
using DTO;
using System.Linq;

namespace Services.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();

            CreateMap<User, UserContactsDTO>()
                .ForMember(x => x.Contact, y => y.MapFrom(src => src.Contacts));

            CreateMap<User, UserDTO>();


            CreateMap<ContactDTO, Contact>();

            CreateMap<Contact, ContactDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>();



            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleDTO>();

            CreateMap<CartDTO, Cart>();

            CreateMap<Cart, CartDTO>()
                .ForMember(m => m.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Product.Name));



            CreateMap<UserRoleDTO, UserRole>();


            CreateMap<UserRole, UserRoleDTO>()
                 .ForMember(m => m.UserName, opt => opt.MapFrom(src => src.User.Name))
                 .ForMember(m => m.RoleName, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<User, UserRoleDTO>()
         .ForMember(m => m.UserName, opt => opt.MapFrom(src => src.Name))
         .ForMember(m => m.RoleName, opt => opt.MapFrom(src => src.Role.First().Name))

         .ForMember(m => m.UserId, opt => opt.MapFrom(src => src.Id))
         .ForMember(m => m.RoleId, opt => opt.MapFrom(src => src.Role.First().Id));





        }
    }
}
