using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Ajout de l'authentification JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-auth-server.com";  // L'URL de l'Identity Provider
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudiences = new[] { "audience1", "audience2" }, // Audiences attendues
            ValidateIssuerSigningKey = true, // Valider la signature du token
        };
    });

// Ajout de l'autorisation
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadPolicy", policy =>
        policy.RequireClaim("aud", "audience1"));

    options.AddPolicy("WritePolicy", policy =>
        policy.RequireClaim("aud", "audience2"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Minimal API 

app.MapGet("/api/lecture", [Authorize(Policy = "ReadPolicy")] () =>
{
    return Results.Ok("Accès autorisé à la lecture.");
})
.WithName("Lecture")
.WithMetadata(new EndpointMetadata { Description = "Requiert l'audience 'audience1'." });

app.MapPost("/api/ecriture", [Authorize(Policy = "WritePolicy")] () =>
{
    return Results.Ok("Accès autorisé à l'écriture.");
})
.WithName("Ecriture")
.WithMetadata(new EndpointMetadata { Description = "Requiert l'audience 'audience2'." });

app.Run();

//Swagger 

using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SecurityRequirementsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Vérifie si le point d'entrée nécessite l'autorisation
        var authAttributes = context.MethodInfo.DeclaringType?
            .GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>();

        if (authAttributes?.Any() == true)
        {
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            // Ajouter les exigences de sécurité (JWT Bearer)
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                }
            };

            // Ajouter une description pour les politiques
            foreach (var authAttribute in authAttributes)
            {
                if (!string.IsNullOrEmpty(authAttribute.Policy))
                {
                    operation.Description += $"\nRequiert la politique : {authAttribute.Policy}.";
                }
            }
        }
    }
}

