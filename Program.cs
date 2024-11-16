using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using MoroccoCities.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin() 
            .AllowAnyMethod() 
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Morocco Cities API",
        Description = """
            <div>
                <strong><div>Information about API</div> </strong>
                <i>This API provides information about cities in Morocco.</i>
                <h3>Terms of Use API:</h3>
                <ul>
                    <li>The API is completely free to use.</li>
                    <li>No authentication is required for access.</li>
                    <li>Use the API responsibly to avoid overloading the server.</li>
                    <li>Sharing the API with others is encouraged!</li>
                </ul>                
                <h3>Sponsors:</h3>
                <p>
                    This API is proudly sponsored by:
                </p>
                <ul>
                    <li><strong>GolDev:</strong> Empowering developers with free tools and resources.</li>
                    <li><a href="https://www.goldev.dev/hamza-mouddakir/" target="_blank">Hamza Mouddakir</a>" Mouddakir! If you'd like to sponsor, contact us at <a href="mailto:hamzamouddakur@gmail.com">hamzamouddakur@gmail.com</a>.</li>
                </ul>
            </div>
            """,
        Contact = new OpenApiContact
        {
            Name = "Hamza Mouddakir",
            Email = "hamzamouddakur@gmail.com",
            Url = new Uri("https://www.goldev.dev/hamza-mouddakir")
        }
    });

});

var app = builder.Build();
//app.UseStaticFiles();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/swagger/v1/swagger.json", "Morocco Cities API v1");
        //options.RoutePrefix = string.Empty; // Makes Swagger UI the root page
    });
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
