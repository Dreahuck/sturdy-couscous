using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.Events = new CertificateAuthenticationEvents
        {
            OnCertificateValidated = context =>
            {
                // Validation supplémentaire du certificat
                context.Principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, context.ClientCertificate.Subject) }, CertificateAuthenticationDefaults.AuthenticationScheme));
                context.Success();
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/your-endpoint", [Authorize] (HttpContext httpContext) =>
{
    // Votre logique de traitement POST
});

app.Run();
