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
            return await LoginWithGraphResource();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }


        private async Task<string> LoginWithGraphResource()
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

                var authResult22 = await authContext.AcquireTokenSilentAsync(
              Constants.ResourceGraph,
              Constants.ClientId);

                return authResult.AccessToken;
            }
            catch (Exception ex)
            {
                return "No result";
            }
        }
    }
}