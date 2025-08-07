Example: Authenticate across tenants
--------------------------------------
For this example, you need the following namespaces:
```C# Snippet:MultiTenant_Namespaces
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

In order to test for multi-tenant, you will need to setup a service principal for another tenant.
1. Enable multi tenant on your SPN.
2. Add the redirect URL under the web (not single page application), e.g. https://www.microsoft.com
3. Using following link to add SPN to tenant2:
    https://login.microsoftonline.com/<Tenant2_ID>/oauth2/authorize?client_id=<Client_ID>&response_type=code&redirect_uri=https%3A%2F%2Fwww.microsoft.com%2F
4. Give enough permission for the SPN in both tenants/subscriptions.
5. Set related environment variables to your machine.

***Create a pipeline policy***

```C# Snippet:Sample_Header_Policy
internal class AuxiliaryPoilcy : HttpPipelineSynchronousPolicy
{
    private static string AUTHORIZATION_AUXILIARY_HEADER = "x-ms-authorization-auxiliary";
    private string _token;

    internal AuxiliaryPoilcy(string token)
    {
        _token = token;
    }

    public override void OnSendingRequest(HttpMessage message)
    {
        string token = "Bearer " + _token;
        if (!message.Request.Headers.TryGetValue(AUTHORIZATION_AUXILIARY_HEADER, out _))
        {
            message.Request.Headers.Add(AUTHORIZATION_AUXILIARY_HEADER, token);
        }
    }
}
```

***Authenticate the client and add token to the header***

```C# Snippet:Enable_Cross_Tenant_Authentication
string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
string tenantId01 = Environment.GetEnvironmentVariable("TENANT_ID_01");
string tenantId02 = Environment.GetEnvironmentVariable("TENANT_ID_02");
string subscriptionId01 = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID_01");

// Prepare client and policy for tenant01
TokenCredential credForTenant01 = new ClientSecretCredential(tenantId01, clientId, clientSecret);
TokenCredential credForTenant02 = new ClientSecretCredential(tenantId02, clientId, clientSecret);

string token = (await credForTenant02.GetTokenAsync(new TokenRequestContext(
        new[] { ArmEnvironment.AzurePublicCloud.DefaultScope }), CancellationToken.None)).Token;
ArmClientOptions options = new ArmClientOptions();
AuxiliaryPoilcy headerPolicy = new AuxiliaryPoilcy(token);
options.AddPolicy(headerPolicy, HttpPipelinePosition.PerCall);
ArmClient client = new ArmClient(credForTenant01, subscriptionId01, options);
```
