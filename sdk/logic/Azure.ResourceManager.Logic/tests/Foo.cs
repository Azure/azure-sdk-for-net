using Azure.Core;
using Azure.Core.Pipeline;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace MgmtTest
{
    public class Foo : IJsonModel<Foo>
    {
        public BinaryData? Content { get; set; }

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(Content));
            writer.WriteRawValue(Content);
            writer.WriteEndObject();
        }

        public Foo Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public BinaryData Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options);
        }

        public Foo Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
