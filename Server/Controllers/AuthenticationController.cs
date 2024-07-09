﻿using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(Login user)
        {
            if (user is null) return BadRequest("Model is empty");
            var result = await accountInterface.LoginAsync(user);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if(token == null) return BadRequest("Model is empty");
            var result = await accountInterface.RefreshTokenAsync(token);
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await accountInterface.GetUsers();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(ManagerUser managerUser)
        {
            var result = await accountInterface.UpdateUsers(managerUser);
            return Ok(result);
        }
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var users = await accountInterface.GetRoles();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await accountInterface.DeleteUser(id);
            return Ok(result);
        }
    }
}
