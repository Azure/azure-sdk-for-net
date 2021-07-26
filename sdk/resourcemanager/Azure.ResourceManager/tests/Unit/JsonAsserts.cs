using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
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

        public static JsonElement AssertSerializes(IUtf8JsonSerializable serializable)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                serializable.Write(writer);
            }

            return JsonDocument.Parse(memoryStream.ToArray()).RootElement;
        }
    }
}
