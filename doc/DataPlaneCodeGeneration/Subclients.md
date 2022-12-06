# Customizing the generated code

## Subclients

Autorest requires each operation in swagger file to define a unique string parameter `operationId` (this is different from [official OpenAPI specification](https://swagger.io/docs/specification/paths-and-operations/#operationId)). If parameter value contains underscore, then the part after underscore will be treated as operation name, and the part before underscore will be treated as the name of the operation group which this operation belongs to. Otherwise, operation will be attributed to the group without a name::

```js
"paths": {
  "/namedgroup/op": {
    "get": {
      "operationId": "NamedGroup_Op1",
    }
  },
  "/nogroup/op": {
    "get": {
      "operationId": "Op2",
    }
  }
}
```

For each operation group, **autorest.csharp** generates individual client type called using `<operationGroupName>Client` format when group has a name or `<serviceName>Client` format when group name is empty.

```cs
public partial class NamedGroupClient
{
    public virtual async Task<Response> Op1Async(RequestContext options = null);
    public virtual Response Op1(RequestContext options = null);
}
```

```cs
public partial class MyServiceClient
{
    public virtual async Task<Response> Op2Async(RequestContext options = null);
    public virtual Response Op2(RequestContext options = null);
}
```

As above, one Azure service maybe be exposed to .NET developers as more than one clients that is not easy for .NET developers to discover and find out the right starting point to call Azure services with the Azure SDK. To resolve this, we can export only one service client in its main namespace as the main starting point for developers via [subclient feature](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients).

We organize those clients into two categories: **service clients** and their **subclients**. Service clients can be instantiated and have the Client suffix. Subclients can only be created by calling factory methods on other clients (commonly on service clients) and do not have the client suffix. The service client is the entry point to the API for an Azure service. Please refer to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients) for more detail information.

There are two ways to organize subclients and service client.

- **Single top-level client**: define one top-level service client with the name <service_name>Client, all other clients will be its subclient.

- **Client hierarchy**: organize the client service and subclients via defining the parent-subclient hierarchy dependency.

**Note**: You can combine those two ways to define an client hierarchy with one top-level client and its subclient may have sub clients also.

In Following chapters, we will use [purview Account](https://github.com/Azure/azure-rest-api-specs/blob/b2bddfe2e59b5b14e559e0433b6e6d057bcff95d/specification/purview/data-plane/Azure.Analytics.Purview.Account/preview/2019-11-01-preview/account.json) as example.

### Single top-level client

With multiple service clients it may be better to group them all under one top-level client.

<details>

**Generate Code, and generated code is:**

``` C#
//Generated\AccountsClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class AccountsClient
    {
        public AccountsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}

//Generated\CollectionsClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class CollectionsClient
    {
        public CollectionsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}

//Generated\ResourceSetRulesClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class ResourceSetRulesClient
    {
        public ResourceSetRulesClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}
```

**Add customize configuration:**

Add `single-top-level-client: true` in the autorest configuration.

``` md
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: PurviewAccount
namespace: Azure.Analytics.Purview.Account
input-file: $(this-folder)/account.json
data-plane: true
security: AzureKey
security-header-name: Fake-Subscription-Key
single-top-level-client: true
```

**Regenerate the code, and Generated code after:**

``` diff
//Add Top-level-client as service client, Generated\PurviewAccountClient.cs
namespace Azure.Analytics.Purview.Account
{
+   public partial class PurviewAccountClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://purview.azure.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PurviewAccountClient for mocking. </summary>
        protected PurviewAccountClient()
        {
        }

        /// <summary> Initializes a new instance of PurviewAccountClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public PurviewAccountClient(TokenCredential credential, PurviewAccountClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PurviewAccountClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
        }

        /// <summary> Initializes a new instance of Accounts. </summary>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public virtual Accounts GetAccountsClient(string endpoint, string apiVersion = "2019-11-01-preview")
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Accounts(ClientDiagnostics, _pipeline, _tokenCredential, endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Collections. </summary>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public virtual Collections GetCollectionsClient(string endpoint, string apiVersion = "2019-11-01-preview")
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Collections(ClientDiagnostics, _pipeline, _tokenCredential, endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of ResourceSetRules. </summary>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public virtual ResourceSetRules GetResourceSetRulesClient(string endpoint, string apiVersion = "2019-11-01-preview")
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new ResourceSetRules(ClientDiagnostics, _pipeline, _tokenCredential, endpoint, apiVersion);
        }
    }
}

// SubClient: Accounts Generated\Accounts.cs
namespace Azure.Analytics.Purview.Account
{
-   public partial class AccountsClient
+   public partial class Accounts
    {
-       protected AccountsClient(){}
+       protected Accounts(){}
-       public AccountsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+       internal Accounts(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, string endpoint, string apiVersion)
    }
}

//subclient: Collections Generated\Collections.cs
namespace Azure.Analytics.Purview.Account
{
-   public partial class CollectionsClient
+   public partial class Collections
    {
-       protected CollectionsClient()
+       protected Collections()
-       public CollectionsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+       internal Collections(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, string endpoint, string apiVersion) {}
    }
}

//subclient: ResourceSetRules Generated\ResourceSetRules.cs
namespace Azure.Analytics.Purview.Account
{
-   public partial class ResourceSetRulesClient
+   public partial class ResourceSetRules
    {
-       protected ResourceSetRulesClient()
+       protected ResourceSetRules()
-       public ResourceSetRulesClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+       internal ResourceSetRules(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, string endpoint, string apiVersion) {}
    }
}

```

</details>

### Client hierarchy

Each client can be made a subclient of another client (without circular dependency) using CodeGenClientAttribute.ParentClient parameter.
Since CodeGenClientAttribute is applied to the client type, user will explicitly specify new client type name. According to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients), type should have a name without "Client" suffix and an internal constructor. A factory method will be added to the type, specified in ParentClient.

<details>

**Generate Code, and Generated code is:**

``` C#
//Generated\AccountsClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class AccountsClient
    {
        public AccountsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}

//Generated\CollectionsClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class CollectionsClient
    {
        public CollectionsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}

//Generated\ResourceSetRulesClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class ResourceSetRulesClient
    {
        public ResourceSetRulesClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
    }
}
```

**Add client hierarchy customization (Customizations.cs):**

```C#

//Customizations.cs
using Azure.Core;

namespace Azure.Analytics.Purview.Account
{
    [CodeGenClient("CollectionsClient", ParentClient = typeof(AccountsClient))]
    public partial class Collections { }
    [CodeGenClient("ResourceSetRulesClient", ParentClient = typeof(AccountsClient))]
    public partial class ResourceSetRules { }
}
```

**Regenerate code, and Generated code after:**

```diff
namespace Azure.Analytics.Purview.Account
{
-   public partial class PurviewAccountClientOptions : ClientOptions
+   public partial class AccountsClientOptions : ClientOptions
}
//Promote Parent client to service client: AccountsClient Generated\AccountsClient.cs
namespace Azure.Analytics.Purview.Account
{
    public partial class AccountsClient
    {
-        public AccountsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+        public AccountsClient(string endpoint, TokenCredential credential, AccountsClientOptions options = null){}

+
+        /// <summary> Initializes a new instance of Client2. </summary>
+        public virtual Collections GetCollectionsClient()
+        { }
+
+        public virtual ResourceSetRules GetResourceSetRulesClient()
+        { }
    }
}

//Subclient: Collections Generated\Collections.cs
namespace Azure.Analytics.Purview.Account
{
-   public partial class CollectionsClient
+   public partial class Collections
    {
-       protected CollectionsClient(){}
+       protected Collections(){}
-       public CollectionsClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+       internal Collections(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, string endpoint, string apiVersion){}
    }
}

//Subclient: ResourceSetRules Generated\ResourceSetRules.cs
namespace Azure.Analytics.Purview.Account
{
-   public partial class ResourceSetRulesClient
+   public partial class ResourceSetRules
    {
-       protected ResourceSetRulesClient(){}
+       protected ResourceSetRules(){}
-       public ResourceSetRulesClient(string endpoint, TokenCredential credential, PurviewAccountClientOptions options = null){}
+       internal ResourceSetRules(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, string endpoint, string apiVersion){}
    }
}

```

</details>
