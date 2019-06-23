using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using XamADALMultiResources.Droid;
using XamADALMultiResources.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DroidLoginProvider))]
namespace XamADALMultiResources.Droid
{
    public class DroidLoginProvider : ILoginProvider
    {
        public Context RootView { get; set; }
        public void Init(Context context)
        {
            RootView = context;
        }
        public async Task<string> LoginAsync()
        {
            return await LoginAndReturnToken();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }


        private async Task<string> LoginAndReturnToken()
        {
            var authContext = new AuthenticationContext(Constants.Authority);
            if (authContext.TokenCache.ReadItems().Any())
            {
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            }

            try
            {
                var authResult = await authContext.AcquireTokenAsync(
               Constants.ResourceApi,
               Constants.ClientId,
               new Uri(Constants.RedirectUri),
               new PlatformParameters((Activity)RootView));

                // Getting AccessToken for Graph API can be done like this
                var authResult22 = await authContext.AcquireTokenSilentAsync(
              Constants.ResourceGraph,
              Constants.ClientId);
                string graphAccessToken = authResult22.AccessToken; // use this to query graph api.

                return authResult.AccessToken; // This is the token to query our web API
            }
            catch (Exception ex)
            {
                return "No result";
            }
        }
    }
}