using Attendance.Shared.DTOs.Requests;
using Attendance.Shared.DTOs.Responses;
using Attendance.Shared.Models;

using AutoMapper;

namespace Attendance.Shared.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Users
        CreateMap<User, UserResponseDto>();
        CreateMap<UserRequestDto, User>();
    }
}