using AutoMapper;
using DataAcces.BseEntities;
using DTO;

namespace Services.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserContactsDTO>()
                .ForMember(m => m.Contact, x => x.MapFrom(x => x.Contact));

            CreateMap<UserDTO, User>();


            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();




            CreateMap<UserRole, UserRoleDTO>()
                       .ForMember(m => m.UserName, x => x.MapFrom(x => x.User.Name))
                       .ForMember(m => m.RoleName, x => x.MapFrom(x => x.Role.Name));

            CreateMap<UserRoleDTO, UserRole>();



        }
    }
}
