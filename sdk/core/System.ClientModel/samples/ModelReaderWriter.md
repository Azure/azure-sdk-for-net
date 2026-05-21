
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
Unlike the `PersistableModelProxy` attribute the proxy is only valid for a single instance of `ModelReaderWriterOptions` giving you more flexibility to turn it on or off.

Using a proxy with the following definition

```C# Snippet:Readme_Read_Proxy_ClassStub
public class OutputModelProxy : ModelProxy<OutputModel>, IJsonModel<OutputModel>
```

The example below shows how to read JSON to create a strongly-typed model instance using a proxy.

```C# Snippet:Readme_Read_Proxy
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";

ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
options.AddProxy(new OutputModelProxy());

OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
```

Using a proxy with the following definition

```C# Snippet:Readme_Write_Proxy_ClassStub
public class InputModelProxy : ModelProxy<InputModel>, IJsonModel<InputModel>
```

The example below shows how to write a persistable model using a proxy to `BinaryData`

```C# Snippet:Readme_Write_Proxy
InputModel model = new InputModel();

ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
options.AddProxy(new InputModelProxy());

BinaryData data = ModelReaderWriter.Write(model, options);
```

### Proxy Chain of Responsibility

Multiple proxies can be registered for the same model type to form a chain of responsibility.
Proxies are stored in FIFO order — the **first registered** proxy has the highest priority.

**Write path:** Proxies are consulted first-to-last. Each proxy's `CanHandle(model)` method
is called — the first proxy that returns `true` handles the write. If all proxies decline,
the model serializes itself.

**Read path:** Proxies are consulted first-to-last. Each proxy's `CanHandle(ReadOnlyMemory<byte>)`
method is called — the first proxy that returns `true` handles the read via `Create`.
If all proxies decline, the model itself handles the read as a terminal fallback.

This enables advanced scenarios such as discriminator-based routing, where a proxy can
inspect the incoming data and decide whether it can handle the deserialization.

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
