if ((xmlOnlyModel == null))
{
    return null;
}
global::Azure.Core.XmlWriterContent content = new global::Azure.Core.XmlWriterContent();
content.XmlWriter.WriteObjectValue(xmlOnlyModel, global::Samples.ModelSerializationExtensions.WireOptions, "TestElement");
return content;
