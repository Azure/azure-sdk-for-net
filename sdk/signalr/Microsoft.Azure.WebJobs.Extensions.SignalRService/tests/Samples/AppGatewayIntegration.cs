using System;
using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public class AppGatewayIntegration
    {
        #region Snippet:AppGatewayIntegration
        public class AppGatewayStartup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.Configure<SignalROptions>(o => o.ServiceEndpoints.Add(
                    new ServiceEndpoint(new Uri(""),
                                            new DefaultAzureCredential(),
                                            serverEndpoint: new Uri("https://<url-to-app-gateway>"),
                                            clientEndpoint: new Uri("https://<url-to-app-gateway>"))));
            }
        }
        #endregion
    }
}
