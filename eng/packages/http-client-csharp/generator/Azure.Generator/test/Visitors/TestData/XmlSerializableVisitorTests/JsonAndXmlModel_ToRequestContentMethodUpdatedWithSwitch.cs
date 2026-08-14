global::System.ClientModel.Primitives.ModelReaderWriterOptions options = new global::System.ClientModel.Primitives.ModelReaderWriterOptions(format);
switch (format)
{
    case "X":
        global::Azure.Core.XmlWriterContent content = new global::Azure.Core.XmlWriterContent();
        content.XmlWriter.WriteObjectValue(this, options, "TestElement");
        return content;
    case "J":
        return global::Azure.Core.RequestContent.Create(this, options);
    default:
        return global::Azure.Core.RequestContent.Create(this, options);
}
