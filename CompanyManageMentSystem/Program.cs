
using CompanyManageMentSystem.Data;
using CompanyManageMentSystem.Repo.Implementation;
using CompanyManageMentSystem.Repo.Interface;
using CompanyManageMentSystem.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CompanyManageMentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkk>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeProjectRepo,EmployeeProjectRepo>();
            builder.Services.AddScoped<IAuthRepo,AuthRepo>();


            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer= true,
                    ValidateAudience= true,
                    ValidateIssuerSigningKey= true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audiance"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"])),
                };

            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
