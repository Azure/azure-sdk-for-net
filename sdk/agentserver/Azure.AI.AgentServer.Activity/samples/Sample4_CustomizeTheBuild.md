# Sample 4: Customize the Build

The default `ActivityServer.Create(...)` path builds the whole Microsoft 365 Agents SDK stack from the environment, but every piece is overridable through `ActivityServerOptions`. Leave a property unset to use the built-in default.

| Option | Overrides |
|---|---|
| `Storage` | The turn-state storage backend (default: in-memory). |
| `Connections` | The outbound-auth token provider (default: Foundry managed-identity connections). |
| `ConnectionConfiguration` | The `CONNECTIONS__*` mapping (default: derived from the Foundry-native identity). |
| `ConfigureServices` | A callback to register any additional services before the SDK defaults. |

## Override the storage backend

The default in-memory store is fine for local development, but conversation state is not durable or shared across instances. Supply your own `IStorage` for production.

```C# Snippet:Activity_Sample4_Storage
// Override just the storage backend; the host builds the rest of the stack from the
// environment. Leave Storage unset to use the default in-memory store.
var host = ActivityServer.Create(options =>
{
    options.Storage = new MemoryStorage();
});

host.Run(args);
```

## Register additional services

`ConfigureServices` runs before the Microsoft 365 Agents SDK registers its defaults, and the SDK only adds a default when a service is not already present — so anything you register here wins. Use it to plug in a custom adapter, authorization, or channel-service factory.

```C# Snippet:Activity_Sample4_ConfigureServices
// Register additional services (a custom adapter, authorization, channel-service
// factory, ...) before the Microsoft 365 Agents SDK defaults are added. Anything
// registered here takes precedence over the SDK defaults.
var host = ActivityServer.Create(options =>
{
    options.ConfigureServices = services =>
    {
        services.AddSingleton<IStorage, MemoryStorage>();
    };
});

host.Run(args);
```

## Next steps

- [Injected Application](Sample6_InjectedApplication.md) — build the entire `AgentApplication` yourself.
