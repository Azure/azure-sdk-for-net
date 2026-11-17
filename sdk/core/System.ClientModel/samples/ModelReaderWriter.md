
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

In more advanced scenarios a library user might want to override the behavior of how a model is read or written. In this case you can derive a proxy from `ModelProxy<T>`, implement the serialization methods on it (JSON proxies also implement `IJsonModel<T>`), and add it to `ModelReaderWriterOptions.Proxies`. The proxy only applies to the `ModelReaderWriterOptions` instance it's added to, giving you more flexibility to turn it on or off.

For a client that uses `ClientPipelineOptions`, add a proxy to the client options' `ModelProxies` **before constructing the client**. The collection becomes read-only once the client pipeline is created:

```C# Snippet:Readme_ClientOptions_ModelProxies
var clientOptions = new ClientPipelineOptions();
clientOptions.ModelProxies.Add(new OutputModelProxy());
// Pass clientOptions to the generated client constructor.
```

This works when the client adds the proxies from `ModelProxies` to the `ModelReaderWriterOptions` it uses during serialization and deserialization, including for request bodies; support in published generated clients requires the separate generator change. An Azure client that installs its own proxy internally needs no additional customer registration.

```C# Snippet:Readme_Options_Copy_For_Body
var options = new ModelReaderWriterOptions("J");
foreach (ModelProxy proxy in clientOptions.ModelProxies)
{
    options.Proxies.Add(proxy);
}
using BinaryContent content = BinaryContent.Create(model, options);
```

The direct `ModelReaderWriterOptions` examples below are for standalone model serialization rather than client construction.

### Unconditional Proxy

A proxy that doesn't override `CanHandle` handles every model and payload of the type it's registered for, including derived types. Derive from `ModelProxy<T>` and add it to `Proxies`.

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
options.Proxies.Add(new OutputModelProxy());

OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
```

Using a proxy with the following definition

```C# Snippet:Readme_Write_Proxy_ClassStub
public class InputModelProxy : ModelProxy<InputModel>, IJsonModel<InputModel>
```

The example below shows how to write a persistable model using a proxy to `BinaryData`. On the write path, call `ResolveProxy` to get the proxy (or the model itself if none matches),
then write through the returned interface.

```C# Snippet:Readme_Write_Proxy
InputModel model = new InputModel();

ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
options.Proxies.Add(new InputModelProxy());

// ResolveProxy returns the proxy if one is registered, otherwise the model itself.
IJsonModel<InputModel> resolved = options.ResolveProxy((IJsonModel<InputModel>)model);
BinaryData data = ((IPersistableModel<InputModel>)resolved).Write(options);
```

### Conditional proxy

A conditional proxy inspects the data or model before deciding whether to handle it. Override the `CanHandle` methods of `ModelProxy<T>`; each returns `true` by default, so override every one whose payloads or models the proxy should decline. JSON proxies also implement `IJsonModel<T>`. On writes, `options.ProxiedModel` is the original model being serialized, not the proxy.

```C# Snippet:Readme_Conditional_Proxy
public class DerivedModelProxy : ModelProxy<BaseModel>, IJsonModel<BaseModel>
{
    // Only handle if the JSON contains "kind": "derived"
    public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
    {
        using var doc = JsonDocument.Parse(data);
        return doc.RootElement.TryGetProperty("kind", out var kind)
            && kind.GetString() == "derived";
    }

    public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        Utf8JsonReader copy = reader;
        using var doc = JsonDocument.ParseValue(ref copy);
        return doc.RootElement.TryGetProperty("kind", out var kind)
            && kind.GetString() == "derived";
    }

    public override bool CanHandle(BaseModel model, ModelReaderWriterOptions options) => model is DerivedModel;

    public override BaseModel Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using var doc = JsonDocument.Parse(data);
        return new DerivedModel();
    }

    BaseModel IJsonModel<BaseModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        return new DerivedModel();
    }

    void IJsonModel<BaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // options.ProxiedModel is the original DerivedModel being written.
        writer.WriteStartObject();
        writer.WriteString("kind", "derived");
        writer.WriteEndObject();
    }

    public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"kind\":\"derived\"}");
    public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
```

Proxies work with a library's generated `ModelReaderWriterContext`; pass it to `ModelReaderWriter` or `JsonModelConverter` as usual for AOT-compatible serialization:

```C# Snippet:Readme_Proxy_Explicit_Context
var options = new ModelReaderWriterOptions("J");
options.Proxies.Add(new DerivedModelProxy());
BinaryData data = ModelReaderWriter.Write(model, options, MyProjectContext.Default);
```

#### Multiple proxies and the chain of responsibility

Multiple proxies can be added for the same model type to form a chain of responsibility. Proxies for the same type are used in the order they appear in `Proxies`. A proxy that doesn't override `CanHandle` always matches, so proxies after it for the same type are not consulted.

For each candidate proxy:
- Its `CanHandle` method is called; if it returns `true` then this proxy is used or returned.
- If nothing matches, the model itself is used or returned.

```C# Snippet:Readme_Proxy_Chain
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";
ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");

// Higher-priority proxy added first — consulted first in the chain
options.Proxies.Add(new OutputModelProxyOverride());

// Base library adds a fallback proxy
options.Proxies.Add(new OutputModelProxy());

OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json), options);
```

#### Derived models

A proxy derived from `ModelProxy<T>` is considered for `T` and every type derived from it; use `CanHandle` to select the derived types it applies to.

**Write path:** Call `options.ResolveProxy(model)`. Proxies for the model's runtime type are consulted first, then proxies for each of its base classes, so the same instance produces identical output whether it is written as `BaseModel` or `DerivedModel`. Interfaces implemented by a model are not consulted; to restrict a proxy to models implementing an interface, check for it in `CanHandle`.

**Read path:** Use `ModelReaderWriter.Read<T>(data, options)`. Matching starts at the requested model type `T` and continues through its base classes. A proxy selected for a base class must return a model assignable to `T`; otherwise an `InvalidOperationException` is thrown.

Resolving through a different generic contract than the proxy's `T` may return an adapter rather than the proxy instance itself; rely on serialization behavior, not reference identity.

### Writing nested models with proxies

Proxy registration does not automatically intercept every model in an object graph.
Each model or proxy serializer that writes child models must use a proxy-aware path
and forward the working `ModelReaderWriterOptions` it receives. This applies even
when the parent and child have the same model type.

Calling a child's original `IJsonModel<T>.Write` method directly bypasses its proxy,
even if the options are forwarded. Using `ModelReaderWriterOptions.Json` or omitting
the options from a child `ModelReaderWriter.Write` call also loses the registered
proxies.

For streaming JSON, resolve the child's proxy before writing it:
`options.ResolveProxy((IJsonModel<TChild>)child).Write(writer, options)`.
Resolution updates `options.ProxiedModel` to the child, or clears it if no proxy
matches. It does not restore the parent's value afterward, so capture the parent
in a local variable before resolving children.

For example, suppose `Node` implements `IJsonModel<Node>` and has `Name` and
`Node? Child` properties. The following method belongs to a proxy for `Node`:

```C# Snippet:Readme_Nested_Proxy_Write
void IJsonModel<Node>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
{
    Node parent = (Node)options.ProxiedModel!;

    writer.WriteStartObject();
    writer.WritePropertyName("child");
    if (parent.Child is null)
    {
        writer.WriteNullValue();
    }
    else
    {
        options.ResolveProxy((IJsonModel<Node>)parent.Child).Write(writer, options);
    }

    // Use the captured parent: ProxiedModel may now refer to the child or be null.
    writer.WriteString("name", parent.Name);
    writer.WriteEndObject();
}
```

Both proxy-aware dispatch and forwarding the received options are required at
each level where nested proxy behavior is expected. This is a requirement for
authors of model and proxy serializers, not an extra step for callers that
register proxies and use a client.

When the appropriate `ModelReaderWriterContext` is available, recursively calling
`ModelReaderWriter.Write(child, options, context)` is another proxy-aware path.
That call saves and restores the parent's proxy execution state, but returns
`BinaryData` rather than writing directly to the existing `Utf8JsonWriter`.
