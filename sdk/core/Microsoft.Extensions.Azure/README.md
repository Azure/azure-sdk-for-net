# Azure client integration for ASP.NET Core

Microsoft.Extensions.Azure.Core provides shared primitives to integrate Azure clients with ASP.NET Core dependency injection and configuration systems.

[Source code][source_root] | [Package (NuGet)][package]

## Installing

Install the ASP.NET Core integration library using [NuGet][nuget]:

```
dotnet add package Microsoft.Extensions.Azure
```

## Usage Scenarios and Samples

Use add `AddAzureClients` call to you `ConfigureServices` method. You can use provided builder to register client instances with dependency injection container.

```C# Snippet:ConfigureServices
public void ConfigureServices(IServiceCollection services)
{
    // Registering policy to use in ConfigureDefaults later
    services.AddSingleton<DependencyInjectionEnabledPolicy>();

    services.AddAzureClients(builder => {

        builder.AddSecretClient(Configuration.GetSection("KeyVault"))
            .WithName("Default")
            .WithCredential(new DefaultAzureCredential())
            .ConfigureOptions(options => options.Retry.MaxRetries = 10);

        builder.AddSecretClient(new Uri("http://my.keyvault.com"));

        builder.UseCredential(new DefaultAzureCredential());

        // This would use configuration for auth and client settings
        builder.ConfigureDefaults(Configuration.GetSection("Default"));

        // Configure global defaults
        builder.ConfigureDefaults(options => options.Retry.Mode = RetryMode.Exponential);

        // Advanced configure global defaults
        builder.ConfigureDefaults((options, provider) =>  options.AddPolicy(provider.GetService<DependencyInjectionEnabledPolicy>(), HttpPipelinePosition.PerCall));

        builder.AddBlobServiceClient(Configuration.GetSection("Storage"))
                .WithVersion(BlobClientOptions.ServiceVersion.V2019_02_02);
    });
}
```

<!-- LINKS -->
[source_root]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Microsoft.Extensions.Azure/
[nuget]: https://www.nuget.org/
[package]: https://www.nuget.org/packages/Microsoft.Extensions.Azure/