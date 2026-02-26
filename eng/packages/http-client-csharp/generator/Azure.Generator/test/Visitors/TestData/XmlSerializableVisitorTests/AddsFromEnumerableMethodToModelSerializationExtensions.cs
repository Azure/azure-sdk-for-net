global::Azure.Core.XmlWriterContent content = new global::Azure.Core.XmlWriterContent();
content.XmlWriter.WriteStartElement(rootNameHint);
foreach (T item in enumerable)
{
    content.XmlWriter.WriteObjectValue(item, global::Samples.ModelSerializationExtensions.WireOptions, childNameHint);
}
content.XmlWriter.WriteEndElement();
return content;
