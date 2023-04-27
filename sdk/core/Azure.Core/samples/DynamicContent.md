# Azure SDK Dynamic JSON samples

Azure SDK client [protocol methods](ProtocolMethods.md) do not take or return model types.  JSON response content can be accessed using Base Class Library (BCL) types such as `JsonDocument`, but use of these APIs can result in code that is difficult to read and obscures the author's intent.  To improve the developer experience, Azure.Core provides a dynamic layer over JSON APIs.

## Accessing Response Content

### Get `dynamic` from response

Dynamic content is obtained from the `Response` return value.

```C# Snippet:AzureCoreGetDynamicJson
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
```

### Get a JSON property

JSON properties are read using dynamic member access.

```C# Snippet:AzureCoreGetDynamicJsonProperty
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
string name = widget.Name;
```

### Check whether an optional property is present

Optional properties are checked for null.

```C# Snippet:AzureCoreGetDynamicJsonOptionalProperty
Response response = await client.GetWidgetAsync("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

// Check whether optional property is present
if (widget.Properties != null)
{
    string color = widget.Properties.Color;
}
```

### Collections can be enumerated

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

## Setting Request Content

Authoring JSON from scratch to pass as inputs to protocol methods is [done using anonymous types](ProtocolMethods.md#2-create-and-send-a-request).  When working with Azure services, however, it is common to retrieve a value from from the service, make some changes to it, and send the updated value back to the service.  This is called a "round-trip scenario."

Implementing a round-trip scenario using anonymous types requires copying every JSON property from the response content into the anonyous type, which can be verbose and error prone, as shown below.

```C# Snippet:AzureCoreRoundTripAnonymousType
Response response = client.GetWidget("123");
dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

RequestContent update = RequestContent.Create(
    new
    {
        Id = (string)widget.Id,
        Name = "New Name"

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

await client.SetWidgetAsync((string)widget.Id, RequestContent.Create((object)widget));
```

Note: The implementation of Azure.Core's dynamic JSON is optimized for round-trip scenarios.  Given the performance goals of its design, using it to author large JSON values from scratch is not recommended.  For more details, please see [Blog post on MutableJsonDocument and DynamicJson].
