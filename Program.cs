using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Questor.Services;
using questor_challenge.Data;
using questor_challenge.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuestorContext>(options => options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<CommonServices>();
builder.Services.AddTransient<FeeServices>();
builder.Services.AddTransient<BoletoServices>();
builder.Services.AddTransient<BancoServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Questor Challenge", Version = "v1" });
});

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    QuestorContext dbContext = scope.ServiceProvider.GetRequiredService<QuestorContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Questor Challenge - API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
