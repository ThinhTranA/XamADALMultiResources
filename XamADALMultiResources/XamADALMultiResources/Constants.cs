using System;
using System.Collections.Generic;
using System.Text;

namespace XamADALMultiResources
{
    public class Constants
    {
        public const string ClientId = "3e6610fc-3a37-452d-bb2d-60bf17229096"; // Put your mobile app ClientId
        public const string Authority = "https://login.windows.net/common/"; // Default authority for Azure AD
        public const string ResourceApi = "https://backendtestapi.azurewebsites.net/"; // Put your API ClientId
        public const string ResourceGraph = "https://graph.windows.net/"; // Put your API ClientId
        public const string RedirectUri = "https://backendtestapi.azurewebsites.net/.auth/login/aad/callback"; // Put your mobile app Redirect Uri (declared in Azure AD Apps)
        public const string ApiUri = "https://woodenmoose-authsample-api.azurewebsites.net/api/"; // Put you API actual URL
    }
}
