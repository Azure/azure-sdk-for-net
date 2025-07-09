using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

#nullable enable

namespace Azure.ResourceManager.Tests
{
    internal static class JsonAsserts
    {
        public static void AssertSerialization(string expected, IUtf8JsonSerializable serializable)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                serializable.Write(writer);
            }

            var text = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.AreEqual(expected, text);
        }

        public static void AssertConverterSerialization<T>(string expected, T model, ModelReaderWriterOptions? options = null)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                var jsonModel = model as IJsonModel<T>;
                jsonModel?.Write(writer, options ?? new ModelReaderWriterOptions("W"));
            }

            var text = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.AreEqual(expected, text);
        }

        public static JsonElement AssertSerializes(IUtf8JsonSerializable serializable)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                serializable.Write(writer);
            }

            using var jsonDocument = JsonDocument.Parse(memoryStream.ToArray());
            return jsonDocument.RootElement;
        }
    }
}
