
# System.ClientModel-based ModelReaderWriter samples

## Read and write persistable models

Client library authors can implement the `IPersistableModel<T>` or `IJsonModel<T>` interfaces on strongly-typed model implementations.  If they do, end-users of service clients can then read and write those models in cases where they need to persist them to a backing store.

The example below shows how to write a persistable model to `BinaryData`.

```C# Snippet:Readme_Write_Simple
InputModel model = new InputModel();
BinaryData data = ModelReaderWriter.Write(model);
```

The example below shows how to read JSON to create a strongly-typed model instance.

```C# Snippet:Readme_Read_Simple
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";
OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json));
```

## Read and Write with System.Text.Json

Client library users can use any model that implements `IJsonModel<T>` with `JsonSerializer` by using the `JsonModelConverter` provided.  Add this converter to your `JsonSerializerOptions` and `JsonSerializer` will use the logic defined by `IJsonModel<T>`.

The example below shows how to serialize an `IJsonModel<T>` with `JsonSerializer`

```C# Snippet:Readme_Stj_Write_Sample
JsonSerializerOptions options = new JsonSerializerOptions()
{
    Converters = { new JsonModelConverter() }
};

InputModel model = new InputModel();
string data = JsonSerializer.Serialize(model);
```

The example below shows how to deserialize an `IJsonModel<T>` with `JsonSerializer`

```C# Snippet:Readme_Stj_Read_Sample
JsonSerializerOptions options = new JsonSerializerOptions()
{
    Converters = { new JsonModelConverter() }
};

string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";
OutputModel? model = JsonSerializer.Deserialize<OutputModel>(json, options);
```

## Using a Proxy

In more advanced scenarios a library user might want to override the behavior of how a model is read or written.
In this case you can implement your own class which implements the same interface, either `IPersistableModel<T>` or `IJsonModel<T>`, and register it with the `ModelReaderWriterOptions`.
The proxy is only valid for a single instance of `ModelReaderWriterOptions` giving you more flexibility to turn it on or off.

### Direct Proxy (unconditional override)

A direct proxy always handles the type it's registered for. Simply implement `IJsonModel<T>` (or `IPersistableModel<T>`) and register it.

Using a proxy with the following definition

```C# Snippet:Readme_Read_Proxy_ClassStub
public class OutputModelProxy : IJsonModel<OutputModel>
```

The example below shows how to read JSON to create a strongly-typed model instance using a proxy.

```C# Snippet:Readme_Read_Proxy
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";

ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
options.AddProxy<OutputModel>((IJsonModel<OutputModel>)new OutputModelProxy());

OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
```

Using a proxy with the following definition

```C# Snippet:Readme_Write_Proxy_ClassStub
public class InputModelProxy : IJsonModel<InputModel>
```

The example below shows how to write a persistable model using a proxy to `BinaryData`.
On the write path, call `ResolveProxy` to get the proxy (or the model itself if none matches),
then write through the returned interface.

```C# Snippet:Readme_Write_Proxy
InputModel model = new InputModel();

ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
options.AddProxy<InputModel>((IJsonModel<InputModel>)new InputModelProxy());

// ResolveProxy returns the proxy if one is registered, otherwise the model itself.
IJsonModel<InputModel> resolved = options.ResolveProxy((IJsonModel<InputModel>)model);
BinaryData data = ModelReaderWriter.Write((IPersistableModel<InputModel>)resolved, options);
```

### Conditional Proxy (discriminator routing)

A conditional proxy inspects the data before deciding whether to handle it.
Extend `ConditionalModelProxy<T>` and override `CanHandle` to implement discriminator-based routing.

```csharp
public class DerivedModelProxy : ConditionalModelProxy<BaseModel>
{
    public DerivedModelProxy() : base(new DerivedModelImpl()) { }

    // Only handle if the JSON contains "kind": "derived"
    public override bool CanHandle(ReadOnlyMemory<byte> data)
    {
        using var doc = JsonDocument.Parse(data);
        return doc.RootElement.TryGetProperty("kind", out var kind)
            && kind.GetString() == "derived";
    }

    public override bool CanHandle(BaseModel model) => model is DerivedModel;
}
```

### Proxy Chain of Responsibility

Multiple proxies can be registered for the same model type to form a chain of responsibility.
Proxies are stored in FIFO order — the **first registered** proxy has the highest priority.

**Write path:** Call `options.ResolveProxy(model)` — proxies are consulted first-to-last.
Each conditional proxy's `CanHandle(model)` method is called; the first that returns `true`
handles the write. Direct proxies always match. If nothing matches, the model itself is returned.

**Read path:** Use `ModelReaderWriter.Read<T>(data, options)` — proxies are consulted
first-to-last internally. Each conditional proxy's `CanHandle(ReadOnlyMemory<byte>)` is called;
the first that returns `true` handles the read. If all proxies decline, the model deserializes itself.

```C# Snippet:Readme_Proxy_Chain
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";
ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");

// Higher-priority proxy registered first — consulted first in the chain
options.AddProxy(new OutputModelProxyOverride());

// Base library registers a fallback proxy
options.AddProxy(new OutputModelProxy());

OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
```
