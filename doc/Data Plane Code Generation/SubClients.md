# Customizing the generated code

## Subclients

There are two categories of clients: service clients and their subclients. Service clients can be instantiated and have the Client suffix. Subclients can only be created by calling factory methods on other clients (commonly on service clients) and do not have the client suffix. The service client is the entry point to the API for an Azure service. Please refer to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients) for more detail information.

There are two approaches to organize subclients and service client.

- **Single top-level client**: define one top-level service client with the name <service_name>Client, all other clients will be its subclient.

- **client hierarchy**: organize the client service and subclients via defining the parent-subclient hierarchy dependency.

**Note**: You can combine those two approaches to define an client hierarchy with one top-level client and its subclient may have sub clients also. 

### Single top-level client

With multiple service clients it may be better to group them all under one top-level client.

<details>

**Generated code before:**

``` C#
//Generated\RootClient.cs
namespace Azure.Service.SubClients
{
    public partial class RootClient
    {
        public RootClient(string cachedParameter, AzureKeyCredential credential, Uri endpoint = null, SubClientsClientOptions options = null){}
    }
}

//Generated\ParameterClient.cs
namespace Azure.Service.SubClients
{
    public partial class ParameterClient
    {
        public ParameterClient(AzureKeyCredential credential, Uri endpoint = null, SubClientsClientOptions options = null){}
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

```C#
//Top-level-client Generated\SubClientsClient.cs
namespace Azure.Service.SubClients
{
    public partial class SubClientsClient
    {
        public SubClientsClient(AzureKeyCredential credential, Uri endpoint = null, SubClientsClientOptions options = null){}
    }
    private Parameter _cachedParameter;

    public virtual Root GetRootClient(string cachedParameter)
    {
        Argument.AssertNotNullOrEmpty(cachedParameter, nameof(cachedParameter));

        return new Root(ClientDiagnostics, _pipeline, _keyCredential, cachedParameter, _endpoint);
    }

    public virtual Parameter GetParameterClient()
    {
        return Volatile.Read(ref _cachedParameter) ?? Interlocked.CompareExchange(ref _cachedParameter, new Parameter(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedParameter;
    }
}

// SubClient: Root Generated\Root.cs
namespace Azure.Service.SubClients
{
    public partial class Root
    {
        internal Root(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string cachedParameter, Uri endpoint){}
    }
}

//subclient: Parameter Generated\Parameter.cs
namespace Azure.Service.SubClients
{
    public partial class Parameter
    {
        internal Parameter(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, Uri endpoint) {}
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
//Generated\RootClient.cs
namespace Azure.Service.SubClients
{
    public partial class RootClient
    {
        public RootClient(string cachedParameter, AzureKeyCredential credential, Uri endpoint = null, SubClientsClientOptions options = null){}
    }
}

//Generated\ParameterClient.cs
namespace Azure.Service.SubClients
{
    public partial class ParameterClient
    {
        public ParameterClient(AzureKeyCredential credential, Uri endpoint = null, SubClientsClientOptions options = null){}
    }
}
```

**Define client hierarchy customization:**

```C#

//Customizations.cs
using Azure.Core;

namespace Azure.Service.SubClients
{
    [CodeGenClient("ParameterClient", ParentClient = typeof(RootClient))]
    public partial class Parameter { }
}
```

**Generated code after:**

```c#
//Parent client: RootClient Generated\RootClient.cs
namespace Azure.Service.SubClients
{
    public partial class RootClient
    {
        private readonly string _cachedParameter;
        public RootClient(string cachedParameter, AzureKeyCredential credential, Uri endpoint = null, RootClientOptions options = null){}
    }

    private Parameter _cachedParameter0;
    public virtual Parameter GetParameterClient()
    {
        return Volatile.Read(ref _cachedParameter0) ?? Interlocked.CompareExchange(ref _cachedParameter0, new Parameter(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedParameter0;
    }
}

//Sub client: Parameter Generated\Parameter.cs
namespace Azure.Service.SubClients
{
    public partial class Parameter
    {
        internal Parameter(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, Uri endpoint){}
    }
}


```

</details>