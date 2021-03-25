# Azure REST Bindings for Azure Cognitive Services Text Analytics client library for .NET

Azure.AI.TextAnalytics.Protocol is an experimental library for interacting directly with the REST endpoints for the Azure Cognitive Services Text Analytics service.

At this time, if you are looking to interact with the Azure Cognitive Services Text Analytics service, we recommend using the officially supported [Azure.AI.TextAnalytics](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics) library.

## Getting started

### Install the package

### Prerequisites

### Authenticate the client

To create the client, you can use an `AzureKeyCredential`, with your API Key:

```csharp
TextAnalyticsClient client = new TextAnalyticsClient(new Uri("<endpoint-from-portal>"), new AzureKeyCredential("<api-key-from-portal>"));
```

## Key concepts

Operations on the Text Analytics client consume and produce JSON data. Instead of representing the input and output for an operation with a specific type, the general purpose `JsonData` type is used. `JsonData` makes it easy to build and consume JSON payloads. You can use the [service documentation](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/Languages) to understand the contents of the JSON payloads sent as part of a request or response.  The service exposes the following operations:

- [Detect Language](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/Languages)
- [Entities containing personal information](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesRecognitionPii)
- [Key Phrases](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/KeyPhrases)
- [Linked entities from a well known knowledge base](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesLinking)
- [Named Entity Recognition](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesRecognitionGeneral)
- [Sentiment](https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/Sentiment)

### DynamicRequest/DynamicResponse

`DynamicRequest` and `DynamicResponse` are designed for interacting with JSON Based REST APIs. The `Body` property of a `DynamicRequest` and `DyanmicResponse` is a `JsonData` instance. Clients expose a set of *operations* with three methods per operation (for example, for an operation named GetStudents):

| Name                  | Returns                 | Description                                                               |
|-----------------------|-------------------------|---------------------------------------------------------------------------|
| `GetSentiment`        | `DynamicResponse`       | Synchronously invokes the operation and waits for a response.             |
| `GetSentimentAsync`   | `Task<DynamicResponse>` | Returns a task which represents the eventual response of the operation.   |
| `GetSentimentRequest` | `DynamicRequest`        | Returns a `DynamicRequest` which can be modified and then sent.           |

When using the `<Operation>Request` method, the body of the `DynamicRequest` is initialized to a `JsonData` representing the empty object. You can either modify the body directly or set your own version. For example, let's call the `GetSentiment` API which determines if text is positive or negative.

```C# Snippet:DynamicRequestAndResponse
JsonData body = new JsonData();
JsonData documents = body.SetEmptyArray("documents");
JsonData document = documents.AddEmptyObject();
document["language"] = "en";
document["id"] = "1";
document["text"] = "Great atmosphere. Close to plenty of restaurants, hotels, and transit! Staff are friendly and helpful.";

Response res = client.GetSentiment(RequestContent.Create(body));

if (res.Status != 200 /*OK*/)
{
    // The call failed for some reason, log a message
    Console.Error.WriteLine($"Requested Failed with status {res.Status}: ${res.Content}");
}
else
{
    JsonData responseBody = JsonData.FromBytes(res.Content.ToMemory());
    Console.WriteLine($"Sentiment of document is {(string)responseBody["documents"][0]["sentiment"]}");
}
```

**Note**: You must explicitly check the Status value on the response to understand if the operation was successful. The methods which send a request **do not** throw an exception if the service returns a non 2XX HTTP Status Code.


### JsonData

`JsonData` is a representation of a JSON Document. It is designed to make it easy to interact with REST based services using JSON.

#### Constructing JSON Documents

`JsonData` represents a JSON Value. The zero argument constructor for `JsonData` produces an empty object:

```C# Snippet:DefaultConstructor
var obj = new JsonData();
Console.WriteLine(obj.Kind == JsonValueKind.Object); // prints True
Console.WriteLine(obj.Properties.Count() == 0); // prints True
```

You can also create a `JsonData` from a primitive value:

```C# Snippet:PrimitiveConstructor
var trueValue = new JsonData(true); // represents the document: true
var stringValue = new JsonData("Hello, JsonData"); // represents the document: "Hello, JsonData"
```

Or from an array:

```C# Snippet:ArrayConstructor
var arr = new JsonData(new[] {1, 2, 3}); // represents the document: [1, 2, 3]
```

Or from an arbitrary object that can be serialized with `System.Text.Json` (this includes anonymous types):

```C# Snippet:ObjectConstructor
var doc = new JsonData(new { message = "Hello, JsonData" }); // represents the document: { "message": "Hello, JsonData" }
```

There are a series of `From` methods which can be used to create a `JsonData` from existing JSON text (either as a `string` or from `byte`s):

```C# Snippet:FromXYZ
var docFromString = JsonData.FromString(File.ReadAllText("<path-to-utf8-json-file>"));
var docFromBytes = JsonData.FromBytes(File.ReadAllBytes("<path-to-utf8-json-file>"));
```

#### Modifying `JsonData`

If a `JsonData` represents an Array or Object, existing values or properties can be modified, and new values or properties can be added:

##### Modifying Objects

To modify an object, you can use either the indexer, or the `Set` instance method:

```C# Snippet:ModifyObjects
var doc = new JsonData() ;// represents the document: {}
doc["message"] = "Hello, JsonData"; // doc now represents the document { "message": "Hello, JsonData" }
doc.Set("message", "This works, too!"); // doc now represents the document { "message": "This works, too!" }
```

In addition, you can use `SetEmptyObject` and `SetEmptyArray` to add a property with an empty array or object as a value. These methods return the newly created value, so you can modify it:

```C# Snippet:SetEmpty
var doc = new JsonData(); // represents the document: {}
var wrapped = doc.SetEmptyObject("wrapped"); // doc now represents the document { "wrapped": { } }
wrapped["message"] = "Hello, JsonData!"; // doc now represents the document { "wrapped": { "message": "This works, too!" } }
```

**Note**: The type of the indexer property is `JsonData`. While there are implicit conversions from primitive CLR values and `string` to `JsonData`, there isn't one for objects, so you may need to explicitly call `new JsonData(<value>)` when assigning to the indexer property.

##### Modifying Arrays

To modify an array, use the indexer:

```C# Snippet:ArraySetIndexer
var doc = new JsonData(new[] { "Hello, JsonData!" }); // represents the document [ "Hello, JsonData!" ]
doc[0] = "This works!"; // represents the document [ "This works!" ]
```

To add a new value to the end of the array, use the `Add` method:

```C# Snippet:ArrayAdd
var doc = new JsonData(new string[] {}); // represents the document [ ]
doc.Add("This works!"); // represents the document [ "This works!" ]
```

There are also helper methods for adding an empty array or object to the end of this array:

```C# Snippet:AddEmpty
var doc = new JsonData(new object[] {}); // represents the document: [ ]
var wrapped = doc.AddEmptyObject(); // doc now represents the document [ { } ]
wrapped["message"] = "Hello, JsonData!"; // doc now represents the document [ { "message": "This works, too!" } ]
```

**Note**: The type of the indexer property is `JsonData`. While there are implicit conversions from primitive CLR values and `string` to `JsonData`, there isn't one for objects, so you may need to explicitly call `new JsonData(<value>)` when assigning to the indexer property.

#### Reading JSON Documents

There are multiple ways to read data from a `JsonData`

##### Using DOM APIs

If a `JsonData` represents a primitive value or a string, you can cast to the corresponding CLR type:

```C# Snippet:CLRCasts
var oneDoc = new JsonData(1);           // represents the document: 1
int oneValue = (int)oneDoc;             // works, oneValue is 1

var stringDoc = new JsonData("hello");  // represents the document: "hello"
string stringValue = (string)stringDoc;     // works, stringValue is the string "hello"
```

If the `JsonData` represents an object, you can use the `Properties` property to list all the properties of an object:

```C# Snippet:PropertiesProperty
var objectDoc = new JsonData(new { key1 = "one", key2 = "two" }); // represents the document: { "key1": "one", "key2": "two" }
// the loop prints
// key1
// key2
foreach (string propertyName in objectDoc.Properties)
{
    Console.WriteLine(propertyName);
}
```

And you can fetch a specific property by name, using the indexer:

```C# Snippet:GetPropertyIndexer
var objectDoc = new JsonData(new { key1 = "one", key2 = "two" });
Console.WriteLine(objectDoc["key1"]); // prints "one"
```

Or by using `Get`, which will return "null" if the object does not have a property by that name (compared to the indexer which would throw an `InvalidOperationException` is the property was not present):

```C# Snippet:GetPropertyWithGet
var objectDoc = new JsonData(new { key1 = "one", key2 = "two" }); // represents the document: { "key1": "one", "key2": "two" }
Console.WriteLine(objectDoc.Get("key1"));               // prints "one"
Console.WriteLine(objectDoc.Get("missingKey") == null); // prints "true"
Console.WriteLine(objectDoc["missingKey"]);              // throws InvalidOperationException.
```

Arrays are similar to Objects, you can use the indexer to fetch a specific element from the array:

```C# Snippet:ArrayIndexer
var arrayDoc = new JsonData(new[] { "Hello", "JsonData" }); // represents the document: [ "Hello", "JsonData" ]
Console.WriteLine(arrayDoc[0]);   // prints "Hello"
Console.WriteLine(arrayDoc[1]);   // prints "JsonData"
```

You can also use the `Items` property to get an `IEnumerable<JsonData>`, which you can use to enumerate the values:

```C# Snippet:ItemsProperty
var arrayDoc = new JsonData(new[] { "Hello", "JsonData" }); // represents the document: [ "Hello", "JsonData" ]
foreach (JsonData item in arrayDoc.Items)
{
    Console.WriteLine((string)item);
}
```

Combined, this provides a nice way to access values.  Consider the `JsonData` that represents the document:

```json
{
  "students": [
      {
          "name": "Matt",
          "address": [ "1 Microsoft Way", "Building 18", "Redmond, WA, 98034" ]
      },
      {
          "name": "Bill",
          "address": [ "1 Microsoft Way", "Building 34", "Redmond, WA, 98034" ]
      }
  ]
}
```

You can access the inner values with ease:

```C# Snippet:DOMAccess
JsonData doc = JsonData.FromString(/* a string representing the above document */);
Console.WriteLine(doc["students"][0]["name"]); // prints "Matt"
Console.WriteLine(doc["students"][1]["address"][1]); // prints "Building 34"
```

##### Using `dynamic`

You may also use the `dynamic` keyword with `JsonData`. It allows you to write `doc.propertyName` instead of `doc["propertyName"]`:

```C# Snippet:Dynamic
dynamic doc = JsonData.FromString(/* a string representing the above document */);
Console.WriteLine(doc.students[0].name); // prints "Matt"
Console.WriteLine(doc.students[1].address[1]); // prints "Building 34"
```

And you can cast back to a CLR type as you might expect:

```C# Snippet:DynamicCast
dynamic doc = JsonData.FromString(/* a string representing the above document */);
string name = (string)doc.students[0].name; // name is set to the string "Matt"
string address = (string) doc.students[1].address[1]; // address is set to the string "Building 34"
```

##### Conversions to and from POCOs

As we saw earlier, `JsonData` can be constructed from an arbitrary CLR object. When this happens, the object is serialized using `System.Text.Json`. You can also convert a `JsonData` *to* a CLR object:

Imagine we have the following class definition:

```C# Snippet:ModelTypeDefinition
public class Student
{
    public string name { get; }
    public string address { get; }
}
```

Then we can convert to it:

```C# Snippet:ConvertToModel
JsonData doc = JsonData.FromString(/* a string representing the above document */);
Student[] students = doc["students"].To<Student[]>();
Console.WriteLine(students.Length); // prints 2
Console.WriteLine(students[0].name); // prints "Matt"
```

And since `System.Text.Json` is used for the deserialization, you can customize your model classes to give nicer names than what might be in the JSON:

```C# Snippet:ModelTypeDefinitionWithPropertyNames
public class Student
{
    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("address")]
    public string Address { get; }
}
```

And then use nicer names in our code:

```C# Snippet:ConvertToModelWithPropertyNames
JsonData doc = JsonData.FromString(/* a string representing the above document */);
Student[] students = doc["students"].To<Student[]>();
Console.WriteLine(students.Length); // prints 2
Console.WriteLine(students[0].Name); // prints "Matt"
```

##### `ToString()`

The implementation of `ToString()` works as follows:

- If the document represents a primitive value (number, boolean, or string), the value is converted to it's corresponding CLR type, and `ToString()` is called on that.
- If the document represents an array or object, the documented is converted into a JSON string using System.Text.Json's default configuration and the string is returned.
- If the document represents a single null value, The string `<null>` is returned.

```C# Snippet:JsonDataToString
Console.WriteLine(new JsonData(1)); // prints 1
Console.WriteLine(new JsonData(true)); // prints True
Console.WriteLine(new JsonData(null)); // prints <null>
Console.WriteLine(new JsonData("Hello, JsonData")); // prints Hello, JsonData
```

You may also use `ToJsonString` to get a string representation of the JSON document. The behavior is slightly different than `ToString()` because this method always returns valid JSON:

```C# Snippet:JsonDataToJsonString
Console.WriteLine(new JsonData(1).ToJsonString()); // prints 1
Console.WriteLine(new JsonData(true).ToJsonString()); // prints true
Console.WriteLine(new JsonData(null).ToJsonString()); // prints null
Console.WriteLine(new JsonData("Hello, JsonData").ToJsonString()); // prints "Hello, JsonData"
```

## Examples

### Detect Language

```C# Snippet:DetectLanguagesSample
TextAnalyticsClient client = new TextAnalyticsClient(new Uri("<endpoint-from-portal>"), new AzureKeyCredential("<api-key-from-portal>"));
dynamic body = new JsonData();

body.documents = new JsonData[3];
body.documents[0] = new JsonData();
body.documents[0].countryHint = "US";
body.documents[0].id = "1";
body.documents[0].text = "Hello world";

body.documents[1] = new JsonData();
body.documents[1].id = "2";
body.documents[1].text = "Bonjour tout le monde";

body.documents[2] = new JsonData();
body.documents[2].id = "3";
body.documents[2].text = "La carretera estaba atascada. Había mucho tráfico el día de ayer.";

Response res = client.GetLanguages(RequestContent.Create(body));

Console.WriteLine($"Status is {res.Status} and the body of the response is: {res.Content})");
```

## Troubleshooting

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
