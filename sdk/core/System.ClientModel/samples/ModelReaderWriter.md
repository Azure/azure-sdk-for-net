
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