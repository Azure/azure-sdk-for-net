using global::Azure.Response response = result;
using global::System.Text.Json.JsonDocument document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return global::Samples.Models.Foo.DeserializeFoo(document.RootElement.GetProperty("someResultPath"), global::Samples.ModelSerializationExtensions.WireOptions);
