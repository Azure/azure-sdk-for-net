using global::Azure.Response response = result;
global::System.BinaryData data = response.Content;
using global::System.Text.Json.JsonDocument document = global::System.Text.Json.JsonDocument.Parse(data);
return global::Samples.Models.Foo.DeserializeFoo(document.RootElement.GetProperty("someResultPath"), global::Samples.ModelSerializationExtensions.WireOptions);
