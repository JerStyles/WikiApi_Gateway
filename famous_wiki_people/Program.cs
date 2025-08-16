using Wikipedia.Services;
using Wikipedia.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.Configure<WikipediaApiSettings>(builder.Configuration.GetSection("WikipediaApi"));
builder.Services.AddScoped<WikipediaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
