using Admin.Business.Interfaces;
using Admin.Business.Services;
using Admin.Commons.Settings;
using Admin.Data;
using Admin.Data.Interfaces;
using Admin.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
IConfigurationBuilder configBuilder = new ConfigurationBuilder();
IConfigurationRoot root = configBuilder.Build();

//App settings0
var settings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

//Context
var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

//Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<TinkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TinkUsDatabase")));


builder.Configuration.AddJsonFile("appsettings.json",
        optional: true,
        reloadOnChange: true);

//Authorization
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
   .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
   .RequireAuthenticatedUser().Build());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwtOptions =>
{
    jwtOptions.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = async (x) =>
        {
            Console.WriteLine(x);
        }
    };
    jwtOptions.Authority = $"https://login.microsoftonline.com/{settings.AzureB2C.Tenant}/v2.0";
    jwtOptions.Audience = settings.AzureB2C.ClientId;
    jwtOptions.TokenValidationParameters.ValidIssuer = $"https://sts.windows.net/{settings.AzureB2C.Tenant}/";
});


//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers(
    opt =>
    {
        opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    }
);


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
app.UseCors("AllowMyOrigin");
app.MapControllers();
app.Run();
