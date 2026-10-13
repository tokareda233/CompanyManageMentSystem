using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CompanyManageMentSystem.Data;
using CompanyManageMentSystem.DTOs.Auth;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CompanyManageMentSystem.Repo.Implementation
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _conf;
        public AuthRepo(AppDbContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        public async Task<string> Login(LoginDTO dto)
        {
            var u= await _context.Users.FirstOrDefaultAsync(x=>x.Email == dto.Email);

            if (u == null) { return null; }

            if (u.Password == dto.Password)
            {
                return GenerateToken(u);
            }

            return null;
        }

        public async Task<bool> Register(RegisterDTO dto)
        {
            var u =await _context.Users.AnyAsync(x=>x.Email==dto.Email);
            if (u) { return false; }

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                Role = dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;

        }

        private string GenerateToken(User user)
        {

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_conf["JWT:Key"]));

            var sinig = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenObj = new JwtSecurityToken(

                issuer: _conf["JWT:Issuer"],
                audience: _conf["JWT:Audiance"],
                claims: claim,
                signingCredentials: sinig,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_conf["JWT:ExpirationInHours"]))

                );
           
            var token =new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return token;


        }
    }
}
