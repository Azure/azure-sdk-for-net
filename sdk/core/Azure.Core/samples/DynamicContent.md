# Azure SDK Dynamic JSON samples

Some Azure SDK APIs return values that hold raw JSON, for example [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).  JSON content can be accessed using any JSON parser, such as `JsonDocument`, but use of these APIs can result in code that is difficult to read and may obscure the author's intent.  To improve the developer experience, Azure.Core provides a [dynamic](https://learn.microsoft.com/dotnet/csharp/advanced-topics/interop/using-type-dynamic) layer over JSON APIs.

## Accessing Response Content

### Get `dynamic` from response

Dynamic content is obtained from the `Response` return value.

```C# Snippet:AzureCoreGetDynamicJson
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();
```

### Get a JSON property

JSON members are read using dynamic property access.

```C# Snippet:AzureCoreGetDynamicJsonProperty
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();
string name = widget.name;
```

### Set a JSON property

JSON members can be set on the dynamic object.

```C# Snippet:AzureCoreSetDynamicJsonProperty
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();
widget.name = "New Name";
client.SetWidget(RequestContent.Create(widget));
```

### Access an array value

JSON array values are accessed using array indexers.

```C# Snippet:AzureCoreGetDynamicJsonArrayValue
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();

// JSON is `{ "values" : [1, 2, 3] }`
int value = widget.values[0];
```

### Check whether an optional property is present

Optional properties will return null if not present in the JSON content.

```C# Snippet:AzureCoreGetDynamicJsonOptionalProperty
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();

// JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`

// Check whether optional property is present
if (widget.details != null)
{
    string color = widget.details.color;
}
```

### Enumerate a collection

Dynamic JSON objects and arrays are `IEnumerable` and can be iterated over with the `foreach` keyword.

```C# Snippet:AzureCoreEnumerateDynamicJsonObject
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();

// JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`
foreach (dynamic property in widget.details)
{
    PrintWidget(property.Name, property.Value);
}

void PrintWidget(string name, string value)
{
    Console.WriteLine($"Widget has property {name}='{value}'.");
}
```

### Get a property with invalid C# characters in the name

JSON members whose names have characters that are not valid for property names in C# can be accessed using property indexers.

```C# Snippet:AzureCoreGetDynamicPropertyInvalidCharacters
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();

/// JSON is `{ "$id" = "123" }`
string id = widget["$id"];
```

### Working with Azure values

When working with JSON from Azure services, you can learn what properties are available in the JSON response content from the REST API documentation for the service, examples in the protocol method documentation, or by expanding the [Dynamic View](https://learn.microsoft.com/visualstudio/debugger/watch-and-quickwatch-windows) in Visual Studio.

```C# Snippet:AzureCoreUseDynamicDataDefaults
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
string id = widget.Id;
widget.Name = "New Name";
client.SetWidget(RequestContent.Create(widget));
```

If no parameter is passed to `ToDynamicFromJson()`, properties names must exactly match the member names in the JSON content.  Passing `DynamicDataOptions.Default` will enable properties to be accessed using PascalCase property names, and will write any added properties with camelCase names.

### Cast to a POCO type

Dynamic JSON objects can be cast to CLR types using the cast operator.

```C# Snippet:AzureCoreCastDynamicJsonToPOCO
Response response = client.GetWidget();
dynamic content = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

// JSON is `{ "id" : "123", "name" : "Widget" }`
Widget widget = (Widget)content;
```

```C# Snippet:AzureCoreDynamicJsonPOCO
public class Widget
{
    public string Id { get; set; }
    public string Name { get; set; }
}
```

Passing `DynamicDataOptions.Default` will deserialize the type from JSON with case-insensitive property names.

## Setting RequestContent

To author new JSON, it is recommended to [use anonymous types](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md#2-create-and-send-a-request).  When working with Azure services, however, it is common to retrieve a value from from the service, make some changes to it, and send the updated value back to the service.  This is called a "round-trip scenario."

Implementing a round-trip scenario using anonymous types requires copying every JSON property from the response content into the anonyous type, and can be verbose and error prone, as shown below.

```C# Snippet:AzureCoreRoundTripAnonymousType
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();

RequestContent update = RequestContent.Create(
    new
    {
        id = (string)widget.id,
        name = "New Name",
        properties = new object[]
        {
            new { color = "blue" }
        }

        // A forgotten field may be deleted!
    }
);

client.SetWidget(update);
```

To make this common case easier to implement, Dynamic JSON is mutable.  This allows callers that are have a dynamic JSON object to make a few small changes and send the result back to the service, without having to copy the entire type.

```C# Snippet:AzureCoreRoundTripDynamicJson
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
widget.Name = "New Name";
client.SetWidget(RequestContent.Create(widget));
```

Note: The implementation of Azure.Core's dynamic JSON is optimized for round-trip scenarios.  Given the performance goals of its design, using it to author large JSON payloads from scratch is not recommended.
