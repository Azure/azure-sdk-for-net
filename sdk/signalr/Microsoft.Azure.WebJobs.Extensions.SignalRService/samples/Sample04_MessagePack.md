# MessagePack Hub Protocol

[MessagePack hub protocol](https://learn.microsoft.com/aspnet/core/signalr/messagepackhubprotocol?view=aspnetcore-7.0) is a built-in SignalR hub protocol which is faster and compacter than JSON hub protocol. You can enable MessagePack hub protocol in SignalR extensions to support MessagePack clients. MessagePack hub protocol works for both persistent mode and transient mode.

> For transient mode, by default the service side converts JSON payload to MessagePack payload and it's the legacy way to support MessagePack. However, we recommend you to add a MessagePack hub protocol explicitly as the behavior of legacy way is not exactly the same as self-hosted SignalR.

You have two options to enable MessagePack hub protocol.

1. Update application settings
2. Update .NET code

## Option 1: Update application settings

For your Azure functions app, add the following app setting to your Azure functions:
```
Azure__SignalR__HubProtocol__MessagePack__Enabled = true
```

If you run the app locally, you should add the setting to your `local.settings.json` file and replace the `__` with `:` in the key name.
```json
{
    "Values": {
        "Azure:SignalR:HubProtocol:MessagePack:Enabled": "true",
    }
}

```

## Option 2: Update .NET code

Use the following code to enable MessagePack hub protocol:
```C# Snippet:MessagePackCustomization
public class MessagePackStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.Configure<SignalROptions>(o => o.MessagePackHubProtocol = new MessagePackHubProtocol());
    }
}
```