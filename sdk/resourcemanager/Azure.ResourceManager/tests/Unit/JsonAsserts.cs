using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

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

        public static void AssertConverterSerialization(string expected, object model, JsonSerializerOptions options = default)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                JsonSerializer.Serialize(writer, model, options);
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
