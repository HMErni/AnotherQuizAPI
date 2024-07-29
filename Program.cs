using AnotherQuizAPI.Data;
using AnotherQuizAPI.Data.QuizIemRepo;
using AnotherQuizAPI.Data.QuizListRepo;
using AnotherQuizAPI.Data.ResultRepo;
using AnotherQuizAPI.Data.UserRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Repositories
builder.Services.AddScoped<IQuizItemRepo, QuizItemRepo>();
builder.Services.AddScoped<IQuizListRepo, QuizListRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IResultRepo, ResultRepo>();

// DBConnection
builder.Services.AddDbContext<QuizDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
