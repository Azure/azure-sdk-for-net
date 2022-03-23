# Customizing the generated code

## Subclients

There are two categories of clients: service clients and their subclients. Service clients can be instantiated and have the Client suffix. Subclients can only be created by calling factory methods on other clients (commonly on service clients) and do not have the client suffix. The service client is the entry point to the API for an Azure service. Please refer to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients) for more detail information.

There are two tools to organize subclients and service client.

- **Single top-level client**: define one top-level service client with the name <service_name>Client, all other clients will be its subclient.

- **Client hierarchy**: organize the client service and subclients via defining the parent-subclient hierarchy dependency.

**Note**: You can combine those two approaches to define an client hierarchy with one top-level client and its subclient may have sub clients also. 

### Single top-level client

With multiple service clients it may be better to group them all under one top-level client.

<details>

**Generated code before:**

``` C#
//Generated\Client1Client.cs
namespace Azure.Service.SubClients
{
    public partial class Client1Client
    {
        public Client1Client(string endpoint, string cachedParameter, AzureKeyCredential credential, SubClientsClientOptions options = null){}
    }
}

//Generated\Client2Client.cs
namespace Azure.Service.SubClients
{
    public partial class Client2Client
    {
        public Client2Client(string endpoint, AzureKeyCredential credential, SubClientsClientOptions options = null){}
    }
}
```

**Add customize configuration (set single-top-level-client):**

``` md
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
namespace: Azure.Service.SubClients
input-file: $(this-folder)/SubClients.json
data-plane: true
security: AzureKey
security-header-name: Fake-Subscription-Key
single-top-level-client: true
```

**Generated code after:**

``` diff
//Add Top-level-client as service client, Generated\SubClientsClient.cs
namespace Azure.Service.SubClients
{
+   public partial class SubClientsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SubClientsClient for mocking. </summary>
        protected SubClientsClient()
        {
        }

        /// <summary> Initializes a new instance of SubClientsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public SubClientsClient(AzureKeyCredential credential, SubClientsClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new SubClientsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
        }

        /// <summary> Initializes a new instance of Client1. </summary>
        /// <param name="endpoint"> Account endpoint. </param>
        /// <param name="cachedParameter"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="cachedParameter"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="cachedParameter"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Client1 GetClient1Client(string endpoint, string cachedParameter)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(cachedParameter, nameof(cachedParameter));

            return new Client1(ClientDiagnostics, _pipeline, _keyCredential, endpoint, cachedParameter);
        }

        /// <summary> Initializes a new instance of Client2. </summary>
        /// <param name="endpoint"> Account endpoint. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public virtual Client2 GetClient2Client(string endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            return new Client2(ClientDiagnostics, _pipeline, _keyCredential, endpoint);
        }
    }
}

// SubClient: Client1 Generated\Client1.cs
namespace Azure.Service.SubClients
{
-   public partial class Client1Client
+   public partial class Client1
    {
-       protected Client1Client(){}
+       protected Client1(){}
-       public Client1Client(string endpoint, string cachedParameter, AzureKeyCredential credential, SubClientsClientOptions options = null){}
+       internal Client1(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string endpoint, string cachedParameter){}
    }
}

//subclient: Client2 Generated\Client2.cs
namespace Azure.Service.SubClients
{
-   public partial class Client2Client
+   public partial class Client2
    {
-       protected Client2Client()
+       protected Client2()
-       public Client2Client(string endpoint, AzureKeyCredential credential, SubClientsClientOptions options = null){}
+       internal Client2(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string endpoint) {}
    }
}

```

</details>

### Client hierarchy

Each client can be made a subclient of another client (without circular dependency) using CodeGenClientAttribute.ParentClient parameter.
Since CodeGenClientAttribute is applied to the client type, user will explicitly specify new client type name. According to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients), type should have a name without "Client" suffix and an internal constructor. A factory method will be added to the type, specified in ParentClient.

<details>

**Generated code before:**

``` C#
//Generated\Client1Client.cs
namespace Azure.Service.SubClients
{
    public partial class Client1Client
    {
        public Client1Client(string endpoint, string cachedParameter, AzureKeyCredential credential, SubClientsClientOptions options = null){}
    }
}

//Generated\Client2Client.cs
namespace Azure.Service.SubClients
{
    public partial class Client2Client
    {
        public Client2Client(string endpoint, AzureKeyCredential credential, SubClientsClientOptions options = null){}
    }
}
```

**Add client hierarchy customization (Customizations.cs):**

```C#

//Customizations.cs
using Azure.Core;

namespace Azure.Service.SubClients
{
    [CodeGenClient("Client2Client", ParentClient = typeof(Client1Client))]
    public partial class Client2 { }
}
```

**Generated code after:**

```diff
namespace Azure.Service.SubClients
{
-   public partial class SubClientsClientOptions : ClientOptions{}
+   public partial class Client1ClientOptions : ClientOptions{}
}
//Promote Parent client to service client: Client1Client Generated\Client1Client.cs
namespace Azure.Service.SubClients
{
    public partial class Client1Client
    {
-        public Client1Client(string endpoint, string cachedParameter, AzureKeyCredential credential, SubClientsClientOptions options = null)
+        public Client1Client(string endpoint, string cachedParameter, AzureKeyCredential credential, Client1ClientOptions options = null)
+        { }

+
+        /// <summary> Initializes a new instance of Client2. </summary>
+        public virtual Client2 GetClient2Client()
+        { }
+
    }
}

//Sub client: Client2 Generated\Client2.cs
namespace Azure.Service.SubClients
{
-   public partial class Client2Client
+   public partial class Client2
    {
-       protected Client2Client(){}
+       protected Client2(){}
-       public Client2Client(string endpoint, AzureKeyCredential credential, SubClientsClientOptions options = null)
+       internal Client2(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string endpoint){}
    }
}

```

</details>
