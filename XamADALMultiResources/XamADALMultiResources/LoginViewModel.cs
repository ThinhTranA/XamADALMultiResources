using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

using XamADALMultiResources.Services;
using System.Net.Http;

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
            var apiAccessToken = await DependencyService.Get<ILoginProvider>().LoginAsync();


            using (var client = new HttpClient())
            {
                var url = string.Format(Constants.ResourceApi + "/api/GetCases/GetAllCases");
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", apiAccessToken);
                HttpResponseMessage response = await client.SendAsync(message);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contentBody = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<IEnumerable<CaseDetail>>(contentBody);
                }
                else
                {
                   // return Enumerable.Empty<CaseDetail>();
                }

            }
        }
    }
}
