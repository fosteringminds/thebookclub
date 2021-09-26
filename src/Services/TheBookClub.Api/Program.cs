using Autofac;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TheBookClub.Api;
using TheBookClub.Api.Application.Commands.Books;
using TheBookClub.Api.Application.Commands.Subscriptions;
using TheBookClub.Api.Application.Commands.Users;
using TheBookClub.Api.Infrastructure.AutofacModules;
using TheBookClub.Api.Middleware;
using TheBookClub.Api.Queries;
using TheBookClub.Domain.AggregatesModel.BookAggregate;
using TheBookClub.Domain.AggregatesModel.UserAggregate;
using TheBookClub.Infrastructure;
using TheBookClub.Infrastructure.Repositories.Books;
using TheBookClub.Infrastructure.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<SubscribtionManagementContext>();
optionsBuilder.UseSqlite(connectionString, sqliteOptionsAction: sqliteOptions =>
{
    sqliteOptions.MigrationsAssembly("TheBookClub.Api");
});
var ctx = new SubscribtionManagementContext(optionsBuilder.Options);
builder.Services.AddDbContext<SubscribtionManagementContext>();
builder.Services.AddScoped<IUserQueries>(x => new UserQueries(connectionString));
builder.Services.AddScoped<IBookQueries>(x => new BookQueries(connectionString));
builder.Services.AddScoped<IUserRepository>(x => new UserRepository(ctx));
builder.Services.AddScoped<IBookRepository>(x => new BookRepository(ctx));
builder.Services.AddMediatR(typeof(RegisterUserCommandHandler));
builder.Services.AddMediatR(typeof(SaveBookCommandHandler));
builder.Services.AddMediatR(typeof(SubscriptionCommandHandler));

builder.Services.AddCors();
builder.Services.AddControllers();
//builder.Services.AddAuthentication(o => { o.DefaultScheme = "TokenAuthenticationScheme"; });
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TheBookClub.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheBookClub.Api v1"));
//}

app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200"));
app.UseMiddleware<JwtMiddleware>();
//app.UseHttpsRedirection();

//app.UseAuthentication();

app.MapControllers();

app.Run();
