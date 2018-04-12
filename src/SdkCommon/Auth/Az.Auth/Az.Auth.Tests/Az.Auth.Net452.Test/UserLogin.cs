namespace Az.Auth.Net452.Test
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserLogin: TestBase
    {  
        public UserLogin() : base()
        {

        }

        [Theory(Skip = "Interactive tests")]
        [InlineData("AADTenant=<tenantId>;" +
                "HttpRecorderMode=Record;" +
                "Environment=Custom;" +
                "ResourceManagementUri=https://management.microsoftazure.de/;" +
                "ServiceManagementUri=https://management.core.cloudapi.de/;" +
                "GalleryUri=https://gallery.cloudapi.de/;" +
                "GraphUri=https://graph.cloudapi.de/;" +
                "AADAuthUri=https://login.microsoftonline.de/;" +
                "IbizaPortalUri=http://portal.microsoftazure.de/;" +
                "RdfePortalUri=https://management.core.cloudapi.de/;" +
                "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
                "AADTokenAudienceUri=https://management.core.cloudapi.de/"
            )]
        public void InteractiveUserLogin(string cnnStr)
        {
            LiteralCnnString = cnnStr;
            ServiceClientCredentials svcClientCred = null;
            svcClientCred = UserTokenProvider.LoginWithPromptAsync( this.TenantId, GetADClientSettings(), ActiveDirectoryServiceSettings.AzureGermany, () => { return TaskScheduler.FromCurrentSynchronizationContext(); }).GetAwaiter().GetResult();
            Assert.NotNull(svcClientCred);
        }


        [Theory(Skip = "Interactive tests")]
        [InlineData("AADTenant=<tenantId>;" +
                "UserId=<userId>;" +
                "Password=<pwd>;" +
                "ServicePrincipal=1950a258-227b-4e31-a9cf-717495945fc2;" +
               "HttpRecorderMode=Record;" +
               "Environment=Custom;" +
               "ResourceManagementUri=https://management.microsoftazure.de/;" +
               "ServiceManagementUri=https://management.core.cloudapi.de/;" +
               "GalleryUri=https://gallery.cloudapi.de/;" +
               "GraphUri=https://graph.cloudapi.de/;" +
               "AADAuthUri=https://login.microsoftonline.de/;" +
               "IbizaPortalUri=http://portal.microsoftazure.de/;" +
               "RdfePortalUri=https://management.core.cloudapi.de/;" +
               "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
               "AADTokenAudienceUri=https://management.core.cloudapi.de/"
           )]
        public void SilentUserLogin(string cnnStr)
        {
            LiteralCnnString = cnnStr;
            ServiceClientCredentials svcClientCred = null;
            svcClientCred = UserTokenProvider.LoginSilentAsync(this.ClientId, this.TenantId, this.UserName, this.Password, ActiveDirectoryServiceSettings.AzureGermany).GetAwaiter().GetResult();
            Assert.NotNull(svcClientCred);
        }

        public ActiveDirectoryClientSettings GetADClientSettings()
        {
            ActiveDirectoryClientSettings adClient = new ActiveDirectoryClientSettings()
            {
                ClientId = this.ClientId,
                ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                PromptBehavior = PromptBehavior.Always
            };

            return adClient;
        }
    }
}
