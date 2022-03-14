# Customizing the generated code

## SubClients

Previously, the code generator would generate a publicly constructible client type for each operation group. This leads to many top level clients which can lead to user confusion, because it is not clear which client is the "entry point" to the service. The Sub Clients feature allows a way to configure the code generator such that it does not generate publicly constructible clients for certain operation groups and instead generates a factory method on a different client which can be used to construct the client (which reuses the same underlying HttpPipeline).

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
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/SubClients-LowLevel.json
data-plane: true
security: AzureKey
security-header-name: Fake-Subscription-Key
single-top-level-client: true
```

**Generated code after:**

``` C#
//Top-level-client Generated\SubClientsClient
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

Each client can be made a subclient of another client (without circular dependency) using CodeGenClientAttribute.ParentClient parameter. Since CodeGenClientAttribute is applied to the client type, user will explicitly specify new client type name. According to guideline, type should have a name without "Client" suffix and an internal constructor. autorest.csharp will add a factory method to the type, specified in ParentClient.

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