#region Snippet:MultiTenant_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample4_MultiTenant
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateVirtualNetworkPeering()
        {
            #region Snippet:MultiTenant_CreateVirtualNetworkPeering
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string tenantId01 = Environment.GetEnvironmentVariable("TENANT_ID_01");
            string tenantId02 = Environment.GetEnvironmentVariable("TENANT_ID_02");
            string subscriptionId01 = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID_01");
            string subscriptionId02 = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID_02");

            // Prepare client and policy for tenant01
            var cred = new ClientSecretCredential(tenantId02, clientId, clientSecret);
            var token = (await cred.GetTokenAsync(new Azure.Core.TokenRequestContext(
                    new[] { "https://management.azure.com/.default" }))).Token;
            var options = new ArmClientOptions();
            var headerPolicy = new AuxiliaryPoilcy(token);
            options.AddPolicy(headerPolicy, HttpPipelinePosition.PerCall);
            var client = new ArmClient(new ClientSecretCredential(tenantId01, clientId, clientSecret), subscriptionId01, options);

            var rg = (await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("sdktestrg01")).Value;
            var vnet = (await rg.GetVirtualNetworks().GetAsync("sdktest01")).Value;
            var data = new VirtualNetworkPeeringData()
            {
                RemoteVirtualNetworkId = new ResourceIdentifier("/subscriptions/<SUBSCRIPTION_ID_02>/resourceGroups/sdktestrg02/providers/Microsoft.Network/virtualNetworks/sdktest02")
            };
            var peer01 = (await vnet.GetVirtualNetworkPeerings().CreateOrUpdateAsync(WaitUntil.Completed, "peer001", data)).Value;

            // Prepare client and policy for tenant02
            cred = new ClientSecretCredential(tenantId01, clientId, clientSecret);
            token = (await cred.GetTokenAsync(new Azure.Core.TokenRequestContext(
                    new[] { "https://management.azure.com/.default" }))).Token;
            options = new ArmClientOptions();
            headerPolicy = new AuxiliaryPoilcy(token);
            options.AddPolicy(headerPolicy, HttpPipelinePosition.PerCall);
            client = new ArmClient(new ClientSecretCredential(tenantId02, clientId, clientSecret), subscriptionId02, options);

            rg = (await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("sdktestrg02")).Value;
            vnet = (await rg.GetVirtualNetworks().GetAsync("sdktest02")).Value;
            data = new VirtualNetworkPeeringData()
            {
                RemoteVirtualNetworkId = new ResourceIdentifier("/subscriptions/<SUBSCRIPTION_ID_01>/resourceGroups/sdktestrg01/providers/Microsoft.Network/virtualNetworks/sdktest01")
            };
            var peer02 = (await vnet.GetVirtualNetworkPeerings().CreateOrUpdateAsync(WaitUntil.Completed, "peer002", data)).Value;
            #endregion Snippet:MultiTenant_CreateVirtualNetworkPeering
        }

    }
}
