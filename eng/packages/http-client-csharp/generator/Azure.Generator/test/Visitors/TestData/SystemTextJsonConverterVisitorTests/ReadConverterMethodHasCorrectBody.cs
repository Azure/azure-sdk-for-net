using global::System.Text.Json.JsonDocument document = global::System.Text.Json.JsonDocument.ParseValue(ref reader);
return DeserializeTestModel(document.RootElement, global::Samples.ModelSerializationExtensions.WireOptions);
