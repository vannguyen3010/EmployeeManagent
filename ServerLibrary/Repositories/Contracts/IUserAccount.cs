﻿using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Response;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> LoginAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
        Task<List<ManagerUser>> GetUsers();
        Task<GeneralResponse> UpdateUsers(ManagerUser user);
        Task<List<SystemRole>> GetRoles();
        Task<GeneralResponse> DeleteUser(int id);
        Task<string> GetUserImage(int id);
        Task<bool> UpdateProfile(UserProfile profile);
    }
}
