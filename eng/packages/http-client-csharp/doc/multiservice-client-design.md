# Multi-Service Client Design

## Table of Contents

1. [Motivation](#motivation)
2. [Design Overview](#design-overview)
3. [Sample TypeSpec](#sample-typespec)
4. [Generated API Surface](#generated-api-surface)
5. [Usage Examples](#usage-examples)
6. [Notes](#notes)

## Motivation

TypeSpec recently [added support](https://azure.github.io/typespec-azure/docs/howtos/generate-client-libraries/03client/#one-client-from-multiple-services) defining a spec with multiple services for a single client. This design provides the ability for Azure data plane & Unbranded SDKs to interact with multiple services through a unified library. It enables generating a library that aggregates multiple independently-versioned services.

## Design Overview

### Approach

The multi-service SDK generation follows these principles:

1. **Independent Top-Level Clients**: Each service gets its own top-level client with public constructors.
2. **Per-Client Options**: Each service client has its own `ClientOptions` type with its service version enum
3. **Independent Versioning**: Each service client maintains its own API version, configured via its respective client options

Per the TypeSpec guidelines, all services being merged must share the same endpoint and authentication method.

### Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                   Service.MultiService                      │
├─────────────────────────────┬───────────────────────────────┤
│  ServiceA Namespace         │  ServiceB Namespace           │
├─────────────────────────────┼───────────────────────────────┤
│  FooClient                  │  BarClient                    │
│  - Own HttpPipeline         │  - Own HttpPipeline           │
│  - Own ClientDiagnostics    │  - Own ClientDiagnostics      │
│  - ServiceA API version     │  - ServiceB API version       │
├─────────────────────────────┼───────────────────────────────┤
│  FooClientOptions           │  BarClientOptions             │
│  - ServiceVersion enum      │  - ServiceVersion enum        │
├─────────────────────────────┼───────────────────────────────┤
│  Models: FooModel           │  Models: BarModel             │
└─────────────────────────────┴───────────────────────────────┘
```

## Sample TypeSpec

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
    @scenario
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

## Generated API Surface

This section shows the public API shape for the multi-service library.

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

**Key API Patterns:**
- Each service has its own top-level client (`FooClient`, `BarClient`) with public constructors
- Each client has its own `ClientOptions` type with a `ServiceVersion` enum
- Clients are independently constructible without requiring a parent client

## Usage Examples

### Basic Usage with Default API Versions

```csharp
using System;
using System.Threading.Tasks;
using Azure;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;

// Create clients directly with default options (latest versions)
var fooClient = new FooClient(new Uri("https://example.azure.com"));
var barClient = new BarClient(new Uri("https://example.azure.com"));

// Call operations
Response<FooModel> fooResponse = await fooClient.TestAsync();
Console.WriteLine($"ServiceA FooProp: {fooResponse.Value.FooProp}");

Response<BarModel> barResponse = await barClient.TestAsync();
Console.WriteLine($"ServiceB BarProp: {barResponse.Value.BarProp}");
```

### Configuring Specific API Versions

```csharp
using System;
using Azure;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;
using static Service.MultiService.ServiceA.FooClientOptions;
using static Service.MultiService.ServiceB.BarClientOptions;

// Configure specific version for ServiceA
var fooOptions = new FooClientOptions(ServiceVersion.Av1);
var fooClient = new FooClient(new Uri("https://example.azure.com"), fooOptions);

// Configure specific version for ServiceB
var barOptions = new BarClientOptions(ServiceVersion.Bv2);
var barClient = new BarClient(new Uri("https://example.azure.com"), barOptions);

// Operations will use the configured versions
Response<FooModel> fooResponse = await fooClient.TestAsync();
Response<BarModel> barResponse = await barClient.TestAsync();
```

## Notes

- The high level design applies to both Azure-branded and unbranded data-plane clients.