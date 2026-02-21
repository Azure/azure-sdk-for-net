global::System.ClientModel.Primitives.ModelReaderWriterOptions options = new global::System.ClientModel.Primitives.ModelReaderWriterOptions(format);
switch (format)
{
    case "X":
        global::Azure.Core.XmlWriterContent content = new global::Azure.Core.XmlWriterContent();
        content.XmlWriter.WriteObjectValue(this, options, "TestElement");
        return content;
    case "J":
        global::Samples.Utf8JsonRequestContent jsonContent = new global::Samples.Utf8JsonRequestContent();
        jsonContent.JsonWriter.WriteObjectValue(this, options);
        return jsonContent;
    default:
        return global::Azure.Core.RequestContent.Create(this, options);
}
