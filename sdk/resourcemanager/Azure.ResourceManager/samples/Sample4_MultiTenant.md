Example: Authenticate across tenants
--------------------------------------
For this example, you need the following namespaces:
```C# Snippet:MultiTenant_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;
```

Indorder to test for multi tenant, you will need to setup service principal for another tenant.
1. Enable multi tenant on your SPN.
2. Add the redirect URL under the web (not single page application), e.g. https://www.microsoft.com
3. Using following link to add SPN to tenant2:
    https://login.microsoftonline.com/<Tenant2_ID>/oauth2/authorize?client_id=<Client_ID>&response_type=code&redirect_uri=https%3A%2F%2Fwww.microsoft.com%2F
4. Give enough permission for the SPN in both tenants/subscriptions.
5. Set related environment variables to your machine.

Following code uses Virtual Network Peering to demonstrate how to authenticate across tenants

***Create a pipeline policy***

```C# Snippet:Sample_Header_Policy
using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Tests.Samples
{
    public class AuxiliaryPoilcy : HttpPipelineSynchronousPolicy
    {
        private static String AUTHORIZATION_AUXILIARY_HEADER = "x-ms-authorization-auxiliary";
        private string Token { get; set; }

        public AuxiliaryPoilcy(string token)
        {
            Token = token;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            string token = "Bearer " + Token;
            if (!message.Request.Headers.TryGetValue(AUTHORIZATION_AUXILIARY_HEADER, out _))
            {
                message.Request.Headers.Add(AUTHORIZATION_AUXILIARY_HEADER, token);
            }
        }
    }
}
```

***Authenticate the client and add token to the header***

```C# Snippet:MultiTenant_CreateVirtualNetworkPeering
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
```
