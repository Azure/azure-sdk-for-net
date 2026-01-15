# Experimental Feature Diagnostics

This document lists the experimental feature diagnostic IDs used in System.ClientModel to mark APIs that are under development and subject to change.

## SCME0001 - JsonPatch Experimental API

### Description

The `JsonPatch` type and related APIs are experimental features for applying JSON patches to models. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `System.ClientModel.Primitives.JsonPatch`

### Suppression

If you want to use these experimental APIs and accept the risk that they may change, you can suppress the warning:

```csharp
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);SCME0001</NoWarn>
</PropertyGroup>
```

## SCME0002 - Microsoft.Extensions.Configuration Integration Experimental API

### Description

The Microsoft.Extensions.Configuration and Microsoft.Extensions.DependencyInjection integration APIs are experimental features for configuring SDK clients using .NET configuration patterns. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `System.ClientModel.Primitives.ClientSettings`
- `System.ClientModel.Primitives.IClientBuilder`
- `System.ClientModel.Primitives.HostBuilderExtensions`
- `System.ClientModel.Primitives.ConfigurationExtensions`
- `System.ClientModel.Primitives.CredentialSettings`
- `System.ClientModel.Primitives.AuthenticationPolicy.Create` method

### Suppression

If you want to use these experimental APIs and accept the risk that they may change, you can suppress the warning:

```csharp
#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);SCME0002</NoWarn>
</PropertyGroup>
```

### Example Usage

```csharp
#pragma warning disable SCME0002
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

// Add a client using configuration
builder.AddClient<MyClient, MyClientSettings>("MyClient");

var host = builder.Build();
var client = host.Services.GetRequiredService<MyClient>();
#pragma warning restore SCME0002
```
