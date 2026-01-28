# Experimental Feature Diagnostics

This document lists the experimental feature diagnostic IDs used in System.ClientModel to mark APIs that are under development and subject to change.

## SCME0001 - JsonPatch Experimental API

### Description

The `JsonPatch` type and related APIs are experimental features for applying JSON patches to models. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `System.ClientModel.Primitives.JsonPatch`

### Example Usage

See [JsonPatch.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/JsonPatch.md) for detailed examples.

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
- `System.ClientModel.Primitives.ConfigurationExtensions`
- `System.ClientModel.Primitives.CredentialSettings`
- `System.ClientModel.Primitives.AuthenticationPolicy.Create` method
- `System.ClientModel.Primitives.ClientPipelineOptions` constructor that accepts `IConfigurationSection`

### Example Usage

See [ConfigurationAndDependencyInjection.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md) for detailed examples.

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

## SCME0003 - JsonModel<T> Experimental API

### Description

The `JsonModel<T>` abstract base class is an experimental feature that provides a simplified way to implement `IJsonModel<T>` for JSON serialization and deserialization. This API is subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `System.ClientModel.Primitives.JsonModel<T>`

### Example Usage

```csharp
#pragma warning disable SCME0003
public class MyModel : JsonModel<MyModel>
{
    public string Name { get; set; }

    protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", Name);
        writer.WriteEndObject();
    }

    protected override MyModel CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        // Read and return model from JSON
        // ...
    }
}
#pragma warning restore SCME0003
```

### Suppression

If you want to use these experimental APIs and accept the risk that they may change, you can suppress the warning:

```csharp
#pragma warning disable SCME0003 // Type is for evaluation purposes only and is subject to change or removal in future updates.
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);SCME0003</NoWarn>
</PropertyGroup>
```
