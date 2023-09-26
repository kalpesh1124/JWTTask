using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace JWTTask.Models
{
    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            MVC0705DBEntities obj = new  MVC0705DBEntities();
            var userdata = obj.spCheckLogin(context.UserName, context.Password).FirstOrDefault();
            if (userdata != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userdata.roleName));
                identity.AddClaim(new Claim(ClaimTypes.Name, userdata.employeeCode));
                identity.AddClaim(new Claim(ClaimTypes.Email, userdata.emailAddress));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, userdata.mobileNumber));


                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                context.Rejected();
            }
        }

    }
}