using AutoMapper;
using TodoStudent.Shared.EditModels;
using TodoStudent.Shared.ViewModels;

namespace TodoStudent.Shared;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<UserViewModel, UserEditModel>().ReverseMap();
    }
}