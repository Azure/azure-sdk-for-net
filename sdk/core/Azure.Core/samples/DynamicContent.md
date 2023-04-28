# Azure SDK Dynamic JSON samples

Azure SDK client [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md) take `RequestContent` as an input parameter and return `Response` as their return type.  These types hold raw JSON content that can be accessed using Base Class Library (BCL) types such as `JsonDocument`, but use of these APIs can result in code that is difficult to read and obscures the author's intent.  To improve the developer experience, Azure.Core provides a [dynamic](https://learn.microsoft.com/dotnet/csharp/advanced-topics/interop/using-type-dynamic) layer over JSON APIs.

## Accessing Response Content

### Get `dynamic` from response

Dynamic content is obtained from the `Response` return value.

```C# Snippet:AzureCoreGetDynamicJson
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
```

### Get a JSON property

JSON members are read using dynamic property access.

```C# Snippet:AzureCoreGetDynamicJsonProperty
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
string name = widget.Name;
```

You can learn what properties are available in the JSON response content from the REST API documentation for the service, examples in the protocol method documentation, or by expanding the [Dynamic View](https://learn.microsoft.com/visualstudio/debugger/watch-and-quickwatch-windows) in Visual Studio.

If no parameter is passed to `ToDynamicFromJson()`, properties names must exactly match the member names in the JSON content.  Passing `DynamicDataOptions.Default` will enable properties to be accessed using PascalCase property names, and will write any added properties with camelCase names.

### Set a JSON property

JSON members can be set on the dynamic object.

```C# Snippet:AzureCoreSetDynamicJsonProperty
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
widget.Name = "New Name";
```

### Access an array value

JSON array values are accessed using array indexers.

```C# Snippet:AzureCoreGetDynamicJsonArrayValue
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

// JSON is "{ values = [1, 2, 3] }"
int value = widget.Values[0];
```

### Check whether an optional property is present

Optional properties will return null if not present in the JSON content.

```C# Snippet:AzureCoreGetDynamicJsonOptionalProperty
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

// Check whether optional property is present
if (widget.Properties != null)
{
    string color = widget.Properties.Color;
}
```

### Enumerate a collection

Dynamic JSON objects and arrays are `IEnumerable` and can be iterated over with the `foreach` keyword.

```C# Snippet:AzureCoreEnumerateDynamicJsonObject
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

foreach (dynamic property in widget.Properties)
{
    UpdateWidget(property.Name, property.Value);
}

void UpdateWidget(string name, string value)
{
    Console.WriteLine($"Widget has property {name}='{value}'.");
}
```

### Cast to a POCO type

Dynamic JSON objects can be cast to CLR types using the cast operator.

```C# Snippet:AzureCoreCastDynamicJsonToPOCO
Response response = await client.GetWidgetAsync("123");
dynamic content = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
Widget widget = (Widget)content;
```

```C# Snippet:AzureCoreDynamicJsonPOCO
public class Widget
{
    public string Name { get; set; }
}
```

### Get a property with invalid C# characters in the name

JSON members whose names have characters that are not valid for property names in C# can be accessed using property indexers.

```C# Snippet:AzureCoreGetDynamicPropertyInvalidCharacters
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

/// JSON is """{ $id = "foo" }"""
string id = widget["$id"];
```

## Round-tripping values

To author new JSON, it is recommended to [use anonymous types](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md#2-create-and-send-a-request).  When working with Azure services, however, it is common to retrieve a value from from the service, make some changes to it, and send the updated value back to the service.  This is called a "round-trip scenario."

Implementing a round-trip scenario using anonymous types requires copying every JSON property from the response content into the anonyous type, and can be verbose and error prone, as shown below.

```C# Snippet:AzureCoreRoundTripAnonymousType
Response response = client.GetWidget("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

RequestContent update = RequestContent.Create(
    new
    {
        id = (string)widget.Id,
        name = "New Name",
        properties = new object[]
        {
            new { color = "blue" }
        }

        // A forgotten field may be deleted!
    }
);
await client.SetWidgetAsync((string)widget.Id, update);
```

To make this common case easier to implement, Dynamic JSON is mutable.  This allows callers that are have a dynamic JSON object to make a few small changes and send the result back to the service, without having to copy the entire type.

```C# Snippet:AzureCoreRoundTripDynamicJson
Response response = client.GetWidget("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

widget.Name = "New Name";

await client.SetWidgetAsync((string)widget.Id, RequestContent.Create(widget));
```

Note: The implementation of Azure.Core's dynamic JSON is optimized for round-trip scenarios.  Given the performance goals of its design, using it to author large JSON payloads from scratch is not recommended.
