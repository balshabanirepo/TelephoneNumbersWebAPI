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
              
            }
            if (token!= systemsettingsrepository.Token)
            {
                // throw new UnauthorizedAccessException("Invalid Token");
                context.Result = new UnauthorizedResult();
               // return;
            }
          
        }
    }
}
