using DataRepository.DataRepositoryEntities;
using DataRepository.GateWay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace VaccinationAppointmentVerificationWebAPI.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute :ActionFilterAttribute, IActionFilter
    {
        DbConext dbConext;



        private IConfiguration _configuration;
       // {
            //get
            //{
            //    return (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            //}
       // }
        public override void OnActionExecuting(ActionExecutingContext
                                           context)
        {
            SystemSettingsRepository systemsettingsrepository;

            var user = context.HttpContext.User;
            _configuration= (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            var token = context.HttpContext.Request.Query["Token"];
            dbConext = new DbConext();
            if(token=="")
            {
                // throw new UnauthorizedAccessException("Invalid Token");

                context.Result = new UnauthorizedResult();

            }
            systemsettingsrepository = dbConext.SystemSettings.FirstOrDefault();
            if(systemsettingsrepository==null)
            {
                //throw new UnauthorizedAccessException("Invalid Token");
                context.Result = new UnauthorizedResult();
                ////context.HttpContext.Response.StatusCode = 401;
                //return;
            }
            if (token!= systemsettingsrepository.Token)
            {
                // throw new UnauthorizedAccessException("Invalid Token");
                context.Result = new UnauthorizedResult();
               // return;
            }
            //if (!user.Identity.IsAuthenticated)
            //    return;

           // var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]));
           // var validations = new TokenValidationParameters
           // {
           //     ValidateIssuerSigningKey = true,
           //     IssuerSigningKey = mySecurityKey,
           //     ValidateIssuer = true,
           //     ValidateAudience = true,
           //     ValidateLifetime = false,
           //     // Add these...
           //     ValidIssuer = _configuration["Jwt:Issuer"],
           //     ValidAudience = _configuration["Jwt:Audience"]
           // };
           // //if (authHeader.Value.First().StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
           //// {
           //    // var token = authHeader.Value.First().Substring("bearer ".Length).Trim();
           //     var tokenHandler = new JwtSecurityTokenHandler();
           //     tokenHandler.ValidateToken(token, validations, out SecurityToken validatedToken);
           //     if (validatedToken.ValidTo < DateTime.UtcNow)
           //         throw new UnauthorizedAccessException("Invalid Token");
           // //}
        }
    }
}
