using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Compliance.Classification;
using Redactor.Demo;
using Redactor.Demo.Redactors;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Logging.EnableRedaction();

builder.Services.AddRedaction(o =>
{
    o.SetRedactor<AsteriskRedactor>(new DataClassificationSet(DataTaxonomy.SensitiveData));
});

builder.Services.AddDbContext<DemoDbContext>(o =>
    o.UseInMemoryDatabase("DemoDb"));

var app = builder.Build();

app.UseHttpsRedirection();

UserEndpoints.Map(app);

app.Run();