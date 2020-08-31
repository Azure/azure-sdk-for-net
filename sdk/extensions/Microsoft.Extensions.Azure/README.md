# Azure client library integration for ASP.NET Core

Microsoft.Extensions.Azure.Core provides shared primitives to integrate Azure clients with ASP.NET Core [dependency injection][dependency_injection] and [configuration][configuration] systems.

[Source code][source_root] | [Package (NuGet)][package]

## Getting started

### Install the package

Install the ASP.NET Core integration library using [NuGet][nuget]:

```
dotnet add package Microsoft.Extensions.Azure
```

### Register clients

Make a call to `AddAzureClients` in your app's `ConfigureServices` method. You can use the provided builder to register client instances with your dependency injection container.

```C# Snippet:ConfigureServices
public void ConfigureServices(IServiceCollection services)
{
    // Registering policy to use in ConfigureDefaults later
    services.AddSingleton<DependencyInjectionEnabledPolicy>();

    services.AddAzureClients(builder => {
        // Register blob service client and initialize it using the KeyVault section of configuration
        builder.AddSecretClient(Configuration.GetSection("KeyVault"))
            // Set the name for this client registration
            .WithName("NamedBlobClient")
            // Set the credential for this client registration
            .WithCredential(new ClientSecretCredential("<tenant_id>", "<client_id>", "<client_secret>"))
            // Configure the client options
            .ConfigureOptions(options => options.Retry.MaxRetries = 10);

        // Adds a secret client using the provided endpoint and default credential set later
        builder.AddSecretClient(new Uri("http://my.keyvault.com"));

        // Configures environment credential to be used by default for all clients that require TokenCredential
        // and doesn't override it on per registration level
        builder.UseCredential(new EnvironmentCredential());

        // This would use configuration for auth and client settings
        builder.ConfigureDefaults(Configuration.GetSection("Default"));

        // Configure global retry mode
        builder.ConfigureDefaults(options => options.Retry.Mode = RetryMode.Exponential);

        // Advanced configure global defaults
        builder.ConfigureDefaults((options, provider) =>  options.AddPolicy(provider.GetService<DependencyInjectionEnabledPolicy>(), HttpPipelinePosition.PerCall));

        // Register blob service client and initialize it using the Storage section of configuration
        builder.AddBlobServiceClient(Configuration.GetSection("Storage"))
                .WithVersion(BlobClientOptions.ServiceVersion.V2019_02_02);
    });
}
```

### Inject clients

To use the client request the client type from any place that supports Dependency Injection (constructors, Configure calls, `@inject` razor definitions etc.)

```C# Snippet:Inject
public void Configure(IApplicationBuilder app, SecretClient secretClient, IAzureClientFactory<BlobServiceClient> blobClientFactory)
```

### Create named instances

If client is registered as a named client inject `IAzureClientFactory<T>` and call `CreateClient` passing the name:

```C# Snippet:ResolveNamed
BlobServiceClient blobServiceClient = blobClientFactory.CreateClient("NamedBlobClient");
```

Configuration file used in the sample above:

``` json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  },
  "AllowedHosts": "*",
  "Default": {
    "ClientId": "<client_id>",
    "ClientSecret": "<client_secret>",
    "TenantId": "<tenant_id>",

    "TelemetryPolicy": {
      "ApplicationId": "AppId"
    }
  },
  "KeyVault": {
    "VaultUri": "<vault_uri>"
  },
  "Storage": {
    "serviceUri": "<service_uri>",
    "credential": {
      "accountName": "<account_name>",
      "accountKey": "<account_key>"
    }
  }
}
```

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.


<!-- LINKS -->
[source_root]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Microsoft.Extensions.Azure/
[nuget]: https://www.nuget.org/
[package]: https://www.nuget.org/packages/Microsoft.Extensions.Azure/
[configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.0
[dependency_injection]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0