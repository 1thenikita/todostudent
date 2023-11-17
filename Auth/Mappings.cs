using AutoMapper;
using TodoStudent.Auth.Entities;
using TodoStudent.Shared.EditModels;
using TodoStudent.Shared.ViewModels;

namespace TodoStudent.Auth;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<UserViewModel, UserEditModel>().ReverseMap();
        CreateMap<UserViewModel, UserEntity>().ReverseMap();
        CreateMap<UserEditModel, UserEntity>().ReverseMap();
    }   
}