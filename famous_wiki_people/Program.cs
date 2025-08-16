using WikiPeople.Settings;
using WikiPeople.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<WikipediaApiSettings>(builder.Configuration.GetSection("WikipediaApi"));
builder.Services.AddScoped<WikipediaService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        option.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
    
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

