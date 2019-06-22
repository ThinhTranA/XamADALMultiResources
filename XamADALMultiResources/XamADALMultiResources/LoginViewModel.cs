using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

using XamADALMultiResources.Services;

namespace XamADALMultiResources
{
    public class LoginViewModel: BaseViewModel
    {
        public Command LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            var graphAccessToken = await DependencyService.Get<ILoginProvider>().LoginAsync();

            
        }
    }
}
