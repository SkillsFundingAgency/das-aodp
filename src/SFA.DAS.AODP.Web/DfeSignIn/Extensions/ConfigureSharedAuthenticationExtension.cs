using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SFA.DAS.AODP.Web.DfeSignIn.Extensions
{
    public static class ConfigureSharedAuthenticationExtension
    {
        public static void AddAuthenticationCookie(
            this AuthenticationBuilder services,
            string cookieName,
            string signedOutCallbackPath,
            string resourceEnvironmentName
     )
        {
            services.AddCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/error/403");
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.Cookie.Name = cookieName;
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.CookieManager = new ChunkingCookieManager { ChunkSize = 3000 };
                options.LogoutPath = new PathString(signedOutCallbackPath);
           
            });
        }
    }
}