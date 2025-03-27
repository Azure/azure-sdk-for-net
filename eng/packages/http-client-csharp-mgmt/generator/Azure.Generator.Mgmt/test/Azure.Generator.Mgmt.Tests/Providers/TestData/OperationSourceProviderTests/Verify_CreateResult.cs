using global::System.Text.Json.JsonDocument document = global::System.Text.Json.JsonDocument.Parse(response.ContentStream);
global::Samples.Models.ResponseTypeData data = global::Samples.Models.ResponseTypeData.DeserializeResponseTypeData(document.RootElement, new global::System.ClientModel.Primitives.ModelReaderWriterOptions("W"));
return new global::Samples.ResponseTypeResource(_client, data);
