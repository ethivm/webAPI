//using EasyMemoryCache;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using DNSAPI.Data.ORM.Class;
using DNSAPI.Data.ORM.Interface;
using DNSAPI.Model;
using DNSAPI.Service.Class;
using DNSAPI.Service.Interface;
using DNSAPI.Utils;
using Microsoft.Extensions.Logging;

namespace DNSAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var signingConfigurations = new SigningTokenConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            //var signingtokenConfigurations = new SigningTokenConfigurations();
            //services.AddSingleton(signingtokenConfigurations);

            var tokensConfigurations = new Tokens();
            new ConfigureFromConfigurationOptions<Tokens>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokensConfigurations);
            services.AddSingleton(tokensConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                paramsValidation.ValidateIssuerSigningKey = true;

                paramsValidation.ValidateLifetime = true;

                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddMvcCore()
                .AddApiExplorer();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            //services.AddTransient<ITokenHandler, TokenHandler>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<IMemDetailsService, MemDetailsService>();
            services.AddTransient<IMemPreAppStatusService, MemPreAppStatusService>();
            services.AddTransient<IMemReimpStatusService, MemReimpStatusService>();
            services.AddTransient<ISetReimbClaimService, SetReimbClaimService>();
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            services.AddTransient<IMemDetailsRepository, MemDetailsRepository>();
            services.AddTransient<IMemPreAppStatusRepository, MemPreAppStatusRepository>();
            services.AddTransient<IMemReimpStatusRepository, MemReimpStatusRepository>();
            services.AddTransient<ISetReimbClaimRepository, SetReimbClaimRepository>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<IConfiguration>(Configuration);
           // services.AddSingleton<ICaching, Caching>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                    policy => policy.RequireClaim("MembershipId"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ForSignAPIClient v1");
                if (!env.IsDevelopment())
                {
                    c.RoutePrefix = string.Empty;
                }
            });
        }
    }
}