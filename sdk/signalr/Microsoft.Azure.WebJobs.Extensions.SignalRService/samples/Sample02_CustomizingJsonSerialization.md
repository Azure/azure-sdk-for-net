# Customizing JSON serialization

The messages sent to SignalR clients are serialized into JSON. By default, the JSON library used is `Newtonsoft.Json` for "transient" transport type (the default one), and `System.Text.Json` for "persistent" transport type. If you want to customize the JSON serialization, you could set the `SignalROptions.JsonObjectSerializer` with [dependency injection](https://learn.microsoft.com/azure/azure-functions/functions-dotnet-dependency-injection#register-services). The `SignalROptions.JsonObjectSerializer` will be applied to all the service transport types. See the samples below:

## Use `System.Text.Json` library

The following sample specifies `System.Text.Json` library as the JSON serialization library and also uses CamelCase as the property naming policy.
```C# Snippet:SystemTextJsonCustomization
public class SystemTextJsonStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.Configure<SignalROptions>(o => o.JsonObjectSerializer = new JsonObjectSerializer(
            new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
    }
}
```

## Use `Newtonsoft.Json` library

The following sample specifies `Newtonsoft.Json` library as the JSON serialization library and also uses CamelCase as the property naming policy.
```C# Snippet:NewtonsoftJsonCustomization
public class NewtonsoftJsonStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.Configure<SignalROptions>(o => o.JsonObjectSerializer = new NewtonsoftJsonObjectSerializer(
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }
        ));
    }
}
```