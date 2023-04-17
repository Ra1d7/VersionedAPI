using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => {

var Title = "Versioned API";
var Description = "This is an example of what a versioned API would be like";
var terms = new Uri("https://localhost:7221");
var Contact = new OpenApiContact()
{
    Email = "thmrgb2@gmail.com",
    Url = terms,
    Name = "Moath Tar (Raid7)"
};
var license = new OpenApiLicense()
{
    Name = "My test License",
    Url = terms,
};

    opts.SwaggerDoc("v2", new OpenApiInfo() { Title = $"{Title} v2", Contact = Contact, Description = Description, TermsOfService = terms,License = license, Version = "v2" });
    opts.SwaggerDoc("v1", new OpenApiInfo() { Title = $"{Title} v1", Contact = Contact, Description = Description,TermsOfService = terms,License = license,Version = "v1"});

});
builder.Services.AddApiVersioning(opts => { 

    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.DefaultApiVersion = new ApiVersion(1, 0);
    opts.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(opts => {
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => {

        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
