# Multi-Service Client Design

## Table of Contents

1. [Motivation](#motivation)
2. [Design Overview](#design-overview)
3. [Scenario 1: Combined Client with Sub-Clients](#scenario-1-combined-client-with-sub-clients)
4. [Scenario 2: Single Root Client with All Operations](#scenario-2-single-root-client-with-all-operations)
5. [Alternative: Independent Top-Level Clients](#alternative-independent-top-level-clients)
6. [Notes](#notes)

## Motivation

TypeSpec recently [added support](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/#one-client-from-multiple-services) defining a spec with multiple services for a single client. This design provides the ability for Azure data plane & Unbranded SDKs to interact with multiple services through a single client library. It enables generating a unified client that aggregates multiple independently-versioned services, sharing common infrastructure (HTTP pipeline, authentication, diagnostics).

## Design Overview

The multi-service SDK generation follows these principles:

1. **Combined Client**: A root client that aggregates multiple services, either with sub-clients or with all operations directly on the root client
2. **Independent Versioning**: Each service maintains its own API version enum, configurable via client options
3. **Shared Infrastructure**: HTTP pipeline, diagnostics, and endpoint are shared across all services

Per the TypeSpec guidelines, all services being merged must share the same endpoint and authentication method.

Depending on how your TypeSpec is structured, the generator produces different client shapes:
- **Scenario 1**: Operations defined in `interface` blocks → Root client with sub-clients
- **Scenario 2**: Operations defined directly in namespaces → Single root client with all operations

## Scenario 1: Combined Client with Sub-Clients

This scenario generates a root client with factory methods to access service-specific sub-clients. Each sub-client contains the operations for its respective service.

### Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                      CombinedClient                         │
│  - Shared HttpPipeline                                      │
│  - Shared ClientDiagnostics                                 │
│  - Per-service API version strings                          │
├─────────────────────────────────────────────────────────────┤
│  GetFooClient()              │  GetBarClient()              │
│  └─► Foo (sub-client)        │  └─► Bar (sub-client)        │
│       Namespace: ServiceA    │       Namespace: ServiceB    │
│       Operations: Test()     │       Operations: Test()     │
│       Models: FooModel       │       Models: BarModel       │
└─────────────────────────────────────────────────────────────┘
```

### Sample TypeSpec

The following TypeSpec defines a multi-service package with two versioned services:

### main.tsp

```tsp
import "@typespec/versioning";
import "@typespec/http";

using Versioning;
using Http;
using Spector;

namespace Service.MultiService;

/*
 * First service definition in a multi-service package with versioning
 */
@versioned(VersionsA)
namespace ServiceA {
  enum VersionsA {
    av1,
    av2,
  }

  model FooModel {
    fooProp: string;
  }

  @route("foo")
  interface Foo {
    @route("/test")
    test(@query("api-version") apiVersion: VersionsA): FooModel;
  }
}

/**
 * Second service definition in a multi-service package with versioning
 */
@versioned(VersionsB)
namespace ServiceB {
  enum VersionsB {
    bv1,
    bv2,
  }

  model BarModel {
    barProp: string;
  }

  @route("bar")
  interface Bar {
    @route("/test")
    test(@query("api-version") apiVersion: VersionsB): BarModel;
  }
}
```

### client.tsp

```tsp
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";
import "@typespec/spector";
import "@typespec/http";
import "@typespec/versioning";

using Azure.ClientGenerator.Core;
using Spector;
using Versioning;

@client({
  service: [Service.MultiService.ServiceA, Service.MultiService.ServiceB],
})
namespace Service.MultiService.Combined;
```

**Key Points:**
- The `@client` decorator with `service: [...]` array declares a multi-service client
- Each service maintains its own versioning enum (`VersionsA`, `VersionsB`)

### Generated API Surface

This section shows the public API shape for the multi-service library.

```csharp
namespace Service.MultiService.Combined {
    public class CombinedClient {
        protected CombinedClient();
        public CombinedClient(Uri endpoint);
        public CombinedClient(Uri endpoint, CombinedClientOptions options);
        public virtual HttpPipeline Pipeline { get; }
        public virtual Bar GetBarClient();
        public virtual Foo GetFooClient();
    }
    public class CombinedClientOptions : ClientOptions {
        public CombinedClientOptions(ServiceAVersion serviceAVersion = ServiceAVersion.Av2, ServiceBVersion serviceBVersion = ServiceBVersion.Bv2);
        public enum ServiceAVersion {
            Av1 = 1,
            Av2 = 2,
        }
        public enum ServiceBVersion {
            Bv1 = 1,
            Bv2 = 2,
        }
    }
}
namespace Service.MultiService.ServiceA {
    public class Foo {
        protected Foo();
        public virtual HttpPipeline Pipeline { get; }
        public virtual Response Test(RequestContext context);
        public virtual Response<FooModel> Test(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestAsync(RequestContext context);
        public virtual Task<Response<FooModel>> TestAsync(CancellationToken cancellationToken = default);
    }
    public class FooModel : IJsonModel<FooModel>, IPersistableModel<FooModel> {
        public FooModel(string fooProp);
        public string FooProp { get; }
        public static explicit operator FooModel(Response response);
        public static implicit operator RequestContent(FooModel fooModel);
    }
}
namespace Service.MultiService.ServiceB {
    public class Bar {
        protected Bar();
        public virtual HttpPipeline Pipeline { get; }
        public virtual Response Test(RequestContext context);
        public virtual Response<BarModel> Test(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestAsync(RequestContext context);
        public virtual Task<Response<BarModel>> TestAsync(CancellationToken cancellationToken = default);
    }
    public class BarModel : IJsonModel<BarModel>, IPersistableModel<BarModel> {
        public BarModel(string barProp);
        public string BarProp { get; }
        public static explicit operator BarModel(Response response);
        public static implicit operator RequestContent(BarModel barModel);
    }
}
```

**Key API Patterns:**
- `CombinedClient` is the entry point with factory methods (`GetFooClient()`, `GetBarClient()`)
- `CombinedClientOptions` exposes per-service version enums
- Sub-clients (`Foo`, `Bar`) have the operations.

### Usage Examples

#### Basic Usage with Default API Versions

```csharp
using System;
using System.Threading.Tasks;
using Azure;
using Service.MultiService.Combined;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;

// Create the combined client with default options (latest versions)
var client = new CombinedClient(new Uri("https://example.azure.com"));

// Get sub-clients for each service
Foo fooClient = client.GetFooClient();
Bar barClient = client.GetBarClient();

// Call operations
Response<FooModel> fooResponse = await fooClient.TestAsync();
Console.WriteLine($"ServiceA FooProp: {fooResponse.Value.FooProp}");

Response<BarModel> barResponse = await barClient.TestAsync();
Console.WriteLine($"ServiceB BarProp: {barResponse.Value.BarProp}");
```

#### Configuring Specific API Versions

```csharp
using System;
using Azure;
using Service.MultiService.Combined;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;
using static Service.MultiService.Combined.CombinedClientOptions;

// Configure specific versions for each service
var options = new CombinedClientOptions(
    serviceAVersion: ServiceAVersion.Av1,  // Specific version for ServiceA
    serviceBVersion: ServiceBVersion.Bv2   // Specific version for ServiceB
);

var client = new CombinedClient(new Uri("https://example.azure.com"), options);

// Operations will use the configured versions
Foo fooClient = client.GetFooClient();
Bar barClient = client.GetBarClient();

Response<FooModel> fooResponse = await fooClient.TestAsync();
Response<BarModel> barResponse = await barClient.TestAsync();
```

## Scenario 2: Single Root Client with All Operations

This scenario generates a single root client that contains all operations from all services directly, without sub-clients.

### Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                      CombinedClient                         │
│  - Shared HttpPipeline                                      │
│  - Shared ClientDiagnostics                                 │
│  - Per-service API version strings                          │
├─────────────────────────────────────────────────────────────┤
│  Operations:                                                │
│    - TestOne()                                              │
│    - TestTwo()                                              │
├─────────────────────────────────────────────────────────────┤
│  Models:                                                    │
│    - FooModel (Namespace: ServiceA.Models)                  │
│    - BarModel (Namespace: ServiceB.Models)                  │
└─────────────────────────────────────────────────────────────┘
```

### Sample TypeSpec

The following TypeSpec defines a multi-service package where operations are defined at the namespace level:

#### main.tsp

```tsp
import "@typespec/versioning";
import "@typespec/http";

using Versioning;
using Http;

namespace Service.MultiService;

/*
 * First service definition in a multi-service package with versioning
 */
@versioned(VersionsA)
namespace ServiceA {
  enum VersionsA {
    av1,
    av2,
  }

  model FooModel {
    fooProp: string;
  }

  @route("/test")
  op testOne(@query("api-version") apiVersion: VersionsA): FooModel;
}

/**
 * Second service definition in a multi-service package with versioning
 */
@versioned(VersionsB)
namespace ServiceB {
  enum VersionsB {
    bv1,
    bv2,
  }

  model BarModel {
    barProp: string;
  }

  @route("/test")
  op testTwo(@query("api-version") apiVersion: VersionsB): BarModel;
}
```

#### client.tsp

```tsp
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

@client({
  service: [Service.MultiService.ServiceA, Service.MultiService.ServiceB],
})
namespace Service.MultiService.Combined;
```

**Key Points:**
- Operations are defined directly in the namespace (not within an `interface`)
- The `@client` decorator with `service: [...]` array still declares a multi-service client
- All operations are merged into the single root client

### Generated API Surface

This section shows the public API shape for the single root client scenario.

```csharp
namespace Service.MultiService.Combined {
    public class CombinedClient {
        protected CombinedClient();
        public CombinedClient(Uri endpoint);
        public CombinedClient(Uri endpoint, CombinedClientOptions options);
        public virtual HttpPipeline Pipeline { get; }
        // ServiceA operation
        public virtual Response TestOne(RequestContext context);
        public virtual Response<FooModel> TestOne(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestOneAsync(RequestContext context);
        public virtual Task<Response<FooModel>> TestOneAsync(CancellationToken cancellationToken = default);
        // ServiceB operation
        public virtual Response TestTwo(RequestContext context);
        public virtual Response<BarModel> TestTwo(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestTwoAsync(RequestContext context);
        public virtual Task<Response<BarModel>> TestTwoAsync(CancellationToken cancellationToken = default);
    }
    public class CombinedClientOptions : ClientOptions {
        public CombinedClientOptions(ServiceAVersion serviceAVersion = ServiceAVersion.Av2, ServiceBVersion serviceBVersion = ServiceBVersion.Bv2);
        public enum ServiceAVersion {
            Av1 = 1,
            Av2 = 2,
        }
        public enum ServiceBVersion {
            Bv1 = 1,
            Bv2 = 2,
        }
    }
}
namespace Service.MultiService.ServiceA {
    public class FooModel : IJsonModel<FooModel>, IPersistableModel<FooModel> {
        public FooModel(string fooProp);
        public string FooProp { get; }
        public static explicit operator FooModel(Response response);
        public static implicit operator RequestContent(FooModel fooModel);
    }
}
namespace Service.MultiService.ServiceB {
    public class BarModel : IJsonModel<BarModel>, IPersistableModel<BarModel> {
        public BarModel(string barProp);
        public string BarProp { get; }
        public static explicit operator BarModel(Response response);
        public static implicit operator RequestContent(BarModel barModel);
    }
}
```

**Key API Patterns:**
- `CombinedClient` contains all operations directly (`TestOne()`, `TestTwo()`)
- No sub-clients are generated
- `CombinedClientOptions` still exposes per-service version enums
- Models remain in their respective service namespaces

### Usage Examples

#### Basic Usage with Default API Versions

```csharp
using System;
using System.Threading.Tasks;
using Azure;
using Service.MultiService.Combined;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;

// Create the combined client with default options (latest versions)
var client = new CombinedClient(new Uri("https://example.azure.com"));

// Call operations directly on the root client
Response<FooModel> fooResponse = await client.TestOneAsync();
Console.WriteLine($"ServiceA FooProp: {fooResponse.Value.FooProp}");

Response<BarModel> barResponse = await client.TestTwoAsync();
Console.WriteLine($"ServiceB BarProp: {barResponse.Value.BarProp}");
```

#### Configuring Specific API Versions

```csharp
using System;
using System.Threading.Tasks;
using Azure;
using Service.MultiService.Combined;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;
using static Service.MultiService.Combined.CombinedClientOptions;

// Configure specific versions for each service
var options = new CombinedClientOptions(
    serviceAVersion: ServiceAVersion.Av1,  // Specific version for ServiceA
    serviceBVersion: ServiceBVersion.Bv2   // Specific version for ServiceB
);

var client = new CombinedClient(new Uri("https://example.azure.com"), options);

// Operations will use the configured versions
Response<FooModel> fooResponse = await client.TestOneAsync();
Response<BarModel> barResponse = await client.TestTwoAsync();
```

## Alternative: Independent Top-Level Clients

In some scenarios, you may want each service to have its own independent top-level client with public constructors, rather than using a combined client with sub-clients. This can be achieved using the `@client` decorator.

### TypeSpec Configuration

To generate independent top-level clients, you can update the `client.tsp` to use the `@client` decorator as shown below:

```tsp
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";
import "@typespec/spector";
import "@typespec/http";
import "@typespec/versioning";

using Azure.ClientGenerator.Core;
using Spector;
using Versioning;

namespace Service.MultiService.Combined {
  @client({
    service: ServiceA
  })
  @clientNamespace("Service.MultiService.ServiceA")
  interface FooClient extends ServiceA.Foo {
  }
 
  @client({
    service: ServiceB
  })
  @clientNamespace("Service.MultiService.ServiceB")
  interface BarClient extends ServiceB.Bar {
  }
}
```

**Key Points:**
- The `@client` decorator on each interface indicates that each should be an independently constructible top-level client
- Each client is independently instantiable. No combined parent client is generated
- The `@clientNamespace` decorator controls which namespace each client is generated into
- Each service client gets its own `ClientOptions` type with its service version enum

### Generated API Surface

With the `@client` decorator, the generated API surface changes to:

```csharp
namespace Service.MultiService.ServiceA {
    public class FooClient {
        protected FooClient();
        public FooClient(Uri endpoint);
        public FooClient(Uri endpoint, FooClientOptions options);
        public virtual HttpPipeline Pipeline { get; }
        public virtual Response Test(RequestContext context);
        public virtual Response<FooModel> Test(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestAsync(RequestContext context);
        public virtual Task<Response<FooModel>> TestAsync(CancellationToken cancellationToken = default);
    }
    public class FooClientOptions : ClientOptions {
        public FooClientOptions(ServiceVersion version = ServiceVersion.Av2);
        public enum ServiceVersion {
            Av1 = 1,
            Av2 = 2,
        }
    }
    public class FooModel : IJsonModel<FooModel>, IPersistableModel<FooModel> {
        public FooModel(string fooProp);
        public string FooProp { get; }
        public static explicit operator FooModel(Response response);
        public static implicit operator RequestContent(FooModel fooModel);
    }
}
namespace Service.MultiService.ServiceB {
    public class BarClient {
        protected BarClient();
        public BarClient(Uri endpoint);
        public BarClient(Uri endpoint, BarClientOptions options);
        public virtual HttpPipeline Pipeline { get; }
        public virtual Response Test(RequestContext context);
        public virtual Response<BarModel> Test(CancellationToken cancellationToken = default);
        public virtual Task<Response> TestAsync(RequestContext context);
        public virtual Task<Response<BarModel>> TestAsync(CancellationToken cancellationToken = default);
    }
    public class BarClientOptions : ClientOptions {
        public BarClientOptions(ServiceVersion version = ServiceVersion.Bv2);
        public enum ServiceVersion {
            Bv1 = 1,
            Bv2 = 2,
        }
    }
    public class BarModel : IJsonModel<BarModel>, IPersistableModel<BarModel> {
        public BarModel(string barProp);
        public string BarProp { get; }
        public static explicit operator BarModel(Response response);
        public static implicit operator RequestContent(BarModel barModel);
    }
}
```

## Notes

- The high level design applies to both Azure-branded and unbranded clients.