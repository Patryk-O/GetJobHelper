using GetJobHelper.API.DBContexts;
using GetJobHelper.API.Repositories;
using GetJobHelper.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GetJobDBContext>(options =>
{
    options.UseInMemoryDatabase("GetJobHelper");
});
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddCors(options =>
        options.AddPolicy(name: "AllowGetJobHelpelWeb", policy =>
        {
            policy.WithOrigins("https://localhost:7088", "https://www.localhost:7088");
        })
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowGetJobHelpelWeb");
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
