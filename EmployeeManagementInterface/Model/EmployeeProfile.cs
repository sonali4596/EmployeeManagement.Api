using AutoMapper;
using EmployeeManagement.Model;

namespace EmployeeManagementInterface.Model
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<MasterEmployee, MasterEmployeeEdit>()
                .ForMember(dest => dest.ConfirmEmail,
                           opt => opt.MapFrom(src => src.Email));
            CreateMap<MasterEmployeeEdit, MasterEmployee>();
        }

    }
}
