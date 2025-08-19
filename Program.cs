using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Diagnostics;
using Wikipedia.Settings;
using Wikipedia.DTOs;
using Wikipedia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<WikipediaApiSettings>(builder.Configuration.GetSection("WikipediaApiSettings"));
builder.Services.AddControllers();
builder.Services.AddHttpClient<IWikipediaService, WikipediaService>();

var app = builder.Build();



app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            await context.Response.WriteAsJsonAsync(new ApiErrorDto(
                $"An unexpected error occurred: {contextFeature.Error.Message}"));
        }
    });

});

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.InjectStylesheet("/swagger-ui/SwaggerDark.css");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
