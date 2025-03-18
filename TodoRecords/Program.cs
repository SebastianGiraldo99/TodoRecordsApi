using Microsoft.EntityFrameworkCore;
using TodoRecords.AppServices;
using TodoRecords.DBContext;
using TodoRecords.IAppServices;
using TodoRecords.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseInMemoryDatabase("TodoRecordsDb"), ServiceLifetime.Scoped
);

builder.Services.AddScoped(typeof(ITodoRecordAppService<>), typeof(TodoRecordAppService<>));

builder.Services.AddCors( options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("http://localhost:4100").AllowAnyMethod().AllowAnyHeader();

    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    dbContext.Database.EnsureCreated(); 
}


app.Run();
