# Configuration and Dependency Injection

This document demonstrates how to use the configuration and dependency injection
features in `System.ClientModel`.

> [!NOTE]
> For each of the examples using environment variable configuration the name is derived from the convention defined [here](https://learn.microsoft.com/dotnet/core/extensions/configuration-providers#environment-variable-configuration-provider).

## Table of Contents

- [Simple Configuration Example](#simple-configuration-example)
- [Advanced Configuration Example](#advanced-configuration-example)
- [Simple Dependency Injection Example](#simple-dependency-injection-example)
- [Keyed Services Example](#keyed-services-example)
- [Overriding Credentials Example](#overriding-credentials-example)
- [Configuration Reference Syntax](#configuration-reference-syntax)

## Simple Configuration Example

The simplest way to configure a client is to use the `GetClientSettings<T>` extension
method with your application's configuration.  The sample here will load a configuration
file named `appsettings.json` and also load the API key from an environment variable.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://api.example.com",
    "Credential": {
      "CredentialSource": "ApiKey",
      // "Key" is loaded from environment variable MyClient__Credential__Key
    }
  }
}
```

```C# Snippet:SimpleConfigurationExample
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");

MyClientSettings settings = configuration.GetClientSettings<MyClientSettings>("MyClient");
MyClient client = new(settings);
```

## Advanced Configuration Example

This example shows more advanced configuration options including pipeline options,
retry settings, and logging.  Any public properties on the settings class can be set
via configuration as long as the name and location match.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://api.example.com",
    "Credential": {
      "CredentialSource": "ApiKey"
      // "Key" is loaded from environment variable MyClient__Credential__Key
    },
    "Options": {
      "NetworkTimeout": "00:00:30",
      "EnableDistributedTracing": true",
      "ClientLoggingOptions": {
        "EnableLogging": true,
        "MessageContentSizeLimit": 2048
      }
    }
  }
}
```

```C# Snippet:AdvancedConfigurationExample
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");
configuration.AddEnvironmentVariables();

MyClientSettings settings = configuration.GetClientSettings<MyClientSettings>("MyClient");
MyClient client = new(settings);
```

## Simple Dependency Injection Example

Use the `AddClient` extension method to register your client with the dependency injection container.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://api.example.com",
    "Credential": {
      "CredentialSource": "ApiKey"
      // "Key" is loaded from environment variable MyClient__Credential__Key
    }
  }
}
```

```C# Snippet:SimpleDependencyInjectionExample
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddClient<MyClient, MyClientSettings>("MyClient");

IServiceProvider provider = builder.Services.BuildServiceProvider();

MyClient client = provider.GetRequiredService<MyClient>();
```

## Keyed Services Example

Register multiple instances of the same client type with different configurations using keyed services.

**appsettings.json:**
```json
{
  "Client1": {
    "Endpoint": "https://api1.example.com",
    "Credential": {
      "CredentialSource": "ApiKey"
      // "Key" is loaded from environment variable Client1__Credential__Key
    }
  },
  "Client2": {
    "Endpoint": "https://api2.example.com",
    "Credential": {
      "CredentialSource": "ApiKey"
      // "Key" is loaded from environment variable Client2__Credential__Key
    }
  }
}
```

```C# Snippet:KeyedServicesExample
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedClient<MyClient, MyClientSettings>("client1", "Client1");
builder.AddKeyedClient<MyClient, MyClientSettings>("client2", "Client2");

IServiceProvider provider = builder.Services.BuildServiceProvider();

MyClient client1 = provider.GetRequiredKeyedService<MyClient>("client1");
MyClient client2 = provider.GetRequiredKeyedService<MyClient>("client2");
```

## Overriding Credentials Example

Override credentials from configuration programmatically using the `PostConfigure` method.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://api.example.com",
    "Credential": {
      "CredentialSource": "TokenCredential",
      "AdditionalProperties": {
        "Scope": "https://api.example.com/.default"
      }
    }
  }
}
```

```C# Snippet:OverridingCredentialsExample
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddClient<MyClient, MyClientSettings>("MyClient")
    .PostConfigure(settings => settings.CredentialObject = new MyTokenProvider());

IServiceProvider provider = builder.Services.BuildServiceProvider();

MyClient client = provider.GetRequiredService<MyClient>();
```

## Configuration Reference Syntax

Use reference syntax to avoid duplicating configuration values across multiple sections.
Reference another configuration value using a `$` followed by the path to the section
you want to reference.  This makes it easier to maintain and update shared settings in one place.

**appsettings.json:**
```json
{
  "Shared": {
    "Credential": {
      "CredentialSource": "ApiKey"
      // "Key" is loaded from environment variable Shared__Credential__Key
    }
  },
  "Client1": {
    "Endpoint": "https://api1.example.com",
    "Credential": "$Shared:Credential"
  },
  "Client2": {
    "Endpoint": "https://api2.example.com",
    "Credential": "$Shared:Credential"
  }
}
```

```C# Snippet:ReferenceSyntaxExample
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedClient<MyClient, MyClientSettings>("client1", "Client1");
builder.AddKeyedClient<MyClient, MyClientSettings>("client2", "Client2");

IServiceProvider provider = builder.Services.BuildServiceProvider();

MyClient client1 = provider.GetRequiredKeyedService<MyClient>("client1");
MyClient client2 = provider.GetRequiredKeyedService<MyClient>("client2");
```
