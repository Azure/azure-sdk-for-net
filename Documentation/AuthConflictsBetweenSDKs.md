# Bridging gap between old and new SDKs

Authentication conflicts can happen due to mixing old SDKs* and new SDKs*. SDKs that depend on  The credential types created by the new authentication library (Microsoft.Rest.ClientRuntime.Azure.Authentication, type = ServiceClientCredentials)  are incompatible with the credential types  used in older SDKs (Microsoft.Azure.Common, type = SubscriptionCloudCredentials). The problem is that using two different authentication libraries will require you to authenticate twice, which is a painful experience.   

Recommended solution
To bridge this gap, the following adapter allows you to use the new credentials with clients that require the older credential type.

Here’s the code for adapter
```
public class SubscriptionCredentialsAdapter : SubscriptionCloudCredentials
{
    ServiceClientCredentials _credentials;
    string _subscriptionId;
 
    public SubscriptionCredentialsAdapter(ServiceClientCredentials wrapped, string subscriptionId)
    {
        _credentials = wrapped;
        _subscriptionId = subscriptionId;
    }
    
    public override string SubscriptionId
    {
        get { return _subscriptionId; }
    }
 
    public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
       return _credentials.ProcessHttpRequestAsync(request, cancellationToken);
    }
}
```

Here is how you can use the adapter
```
var creds = UserTokenProvider.LoginWithPromptAsync(new ActiveDirectoryClientSettings(ClientId, new Uri(RedirectUri))).GetAwaiter().GetResult();
var subClient = new SubscriptionClient(creds);
var subscriptions = subClient.Subscriptions.List();
var insightClient = new HDInsightManagementClient(new SubscriptionCredentialsAdapter(creds, subscriptions.First().SubscriptionId));
var clusters = insightClient.Clusters.List();
```

Another solution would be to use the version of resource manager library that is based on Microsoft.Azure.Common. It can be found [here](https://www.nuget.org/packages/Microsoft.Azure.Management.Resources/).

* Old SDKs - The SDKs that depend on Microsoft.Azure.Common 
* New SDKs - The SDKs that depend on Microsoft.Rest.ClientRuntime.Azure
