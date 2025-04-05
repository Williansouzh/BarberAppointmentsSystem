using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BarberFlow.API.DTOs;
using BarberFlow.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BarberFlow.API.Controllers;

public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authentication;
    private readonly IConfiguration _configuration;

    public TokenController(
        IAuthenticate authentication, 
        IConfiguration configuration)
    {
        _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
        _configuration = configuration;
    }

    [HttpPost("CreateUser")]

    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult> CreateUser([FromBody] LoginUserDTO userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid client request");
        var result = await _authentication.RegisterUser(userDto.Email, userDto.Password);
        if (!result)
            return BadRequest("User already exists");
        return Ok();
    }
    [HttpPost("Login")]
    public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginUserDTO userLoginDto)
    {
        if (userLoginDto == null)
            return BadRequest("Invalid client request");
        var result = await _authentication.Authenticate(userLoginDto.Email, userLoginDto.Password);
        if (!result)
            return Unauthorized();
        var token = GenerateToken(userLoginDto);
        return Ok();
    }
    private UserTokenDTO GenerateToken(LoginUserDTO userInfo)
    {
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim("meuvalor", "oque voce quiser"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey= new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        
        var credentials = new SigningCredentials(
            privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddHours(2);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);
        return new UserTokenDTO()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
