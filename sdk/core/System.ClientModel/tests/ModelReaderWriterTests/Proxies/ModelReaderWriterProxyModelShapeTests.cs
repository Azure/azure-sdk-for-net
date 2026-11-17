// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Text.Json;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterProxyModelShapeTests
    {
        // The 999 case is a regression: a proxy that overrides CanHandle for a value-type (struct) model used to
        // throw InvalidCastException because variance does not apply to value types. Proxies have no
        // where T : class constraint, so it must route through the proxy.
        // A handling proxy produces the 999 sentinel; a declining proxy falls through to the struct model itself.
        [TestCase(true, 1, 999, TestName = "Read_StructModel_Proxy_Handles")]
        [TestCase(false, 42, 42, TestName = "Read_StructModel_Proxy_Declines_FallsToModel")]
        public void Read_StructModel_Proxy(bool handle, int input, int expected)
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new StructModelProxy(handle));

            StructModel? result = ModelReaderWriter.Read<StructModel>(BinaryData.FromString($"{{\"number\":{input}}}"), options);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expected, result!.Value.Number);
        }

        [Test]
        public void Write_StructModel_Proxy_Handles()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new StructModelProxy(handle: true));

            var model = new StructModel { Number = 1 };
            var data = ModelReaderWriter.Write(model, options);

            Assert.AreEqual("{\"number\":999}", data.ToString());
        }

        [Test]
        public void ConditionalProxy_CustomPlainTextFormat_RoundTrips()
        {
            // A proxy can take over for a caller-defined, non-JSON format. When the "PT" (plain text)
            // format is chosen, the proxy writes a plain-text representation instead of JSON.
            var options = new ModelReaderWriterOptions("PT");
            options.Proxies.Add(new PlainTextFormatProxy());

            BinaryData data = ModelReaderWriter.Write(new PlainTextModel { Value = "world" }, options);
            PlainTextModel? read = ModelReaderWriter.Read<PlainTextModel>(data, options);

            Assert.AreEqual("PlainText: world", data.ToString());
            Assert.IsNotNull(read);
            Assert.AreEqual("world", read!.Value);
        }

        [Test]
        public void ConditionalProxy_CustomPlainTextFormat_DeclinesForJsonFormat()
        {
            // The same proxy declines when the format is not "PT", so the base model writes JSON.
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new PlainTextFormatProxy());

            BinaryData data = ModelReaderWriter.Write(new PlainTextModel { Value = "hello" }, options);

            Assert.AreEqual("{\"value\":\"hello\"}", data.ToString());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_PersistableOnlyProxyOverridesJsonModel(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new PersistableWriteProxy("J");
            options.Proxies.Add(proxy);
            var model = new PlainTextModel { Value = "hello" };
            const string expected = "{\"value\":\"proxied: hello\"}";

            Assert.AreEqual(expected, ModelReaderWriter.Write(model, options).ToString());
            Assert.AreEqual(expected, WriteBinaryContent(model, options).ToString());
            Assert.AreEqual(2, proxy.WriteCount);
            Assert.AreEqual(2, proxy.CanHandleCount);
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void Write_UsesSelectedProxyWireFormat()
        {
            var options = new ModelReaderWriterOptions("W");
            var proxy = new PersistableWriteProxy("PT");
            options.Proxies.Add(proxy);
            var model = new PlainTextModel { Value = "hello" };

            Assert.AreEqual("proxied: hello", ModelReaderWriter.Write(model, options).ToString());
            using BinaryContent content = BinaryContent.Create(model, options);
            Assert.IsNull(content.MediaType);
            Assert.AreEqual("proxied: hello", WriteToBinaryData(content).ToString());
            Assert.AreEqual(2, proxy.WriteCount);
            Assert.IsNull(options.ProxiedModel);
        }

        private sealed class PersistableWriteProxy : ModelProxy<PlainTextModel>
        {
            private readonly string _wireFormat;
            internal int WriteCount { get; private set; }
            internal int CanHandleCount { get; private set; }

            internal PersistableWriteProxy(string wireFormat) => _wireFormat = wireFormat;

            public override bool CanHandle(PlainTextModel model, ModelReaderWriterOptions options)
            {
                CanHandleCount++;
                return true;
            }

            public override PlainTextModel Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => _wireFormat;

            public override BinaryData Write(ModelReaderWriterOptions options)
            {
                WriteCount++;
                string value = ((PlainTextModel)options.ProxiedModel!).Value;
                string format = options.Format == "W" ? _wireFormat : options.Format;
                return BinaryData.FromString(format == "J"
                    ? $"{{\"value\":\"proxied: {value}\"}}"
                    : $"proxied: {value}");
            }
        }

        /// <summary>
        /// A proxy that takes over only when the caller-chosen format is "PT" (plain text),
        /// producing a plain-text representation instead of JSON. The condition reads
        /// <see cref="ModelReaderWriterOptions.Format"/>, proving a proxy can key on the format.
        /// </summary>
        private class PlainTextFormatProxy : ModelProxy<PlainTextModel>
        {
            private const string Prefix = "PlainText: ";

            public override bool CanHandle(PlainTextModel model, ModelReaderWriterOptions options)
                => options.Format == "PT";

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
                => options.Format == "PT";

            public override PlainTextModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                string s = data.ToString();
                return new PlainTextModel { Value = s.StartsWith(Prefix, StringComparison.Ordinal) ? s.Substring(Prefix.Length) : s };
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
                => BinaryData.FromString($"{Prefix}{((PlainTextModel)options.ProxiedModel!).Value}");

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "PT";
        }

        /// <summary>
        /// A value-type (struct) model used to verify proxies work for structs (no where T : class).
        /// </summary>
        private struct StructModel : IJsonModel<StructModel>
        {
            public int Number { get; set; }

            StructModel IJsonModel<StructModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new StructModel { Number = doc.RootElement.TryGetProperty("number", out var n) ? n.GetInt32() : 0 };
            }

            StructModel IPersistableModel<StructModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.Parse(data);
                return new StructModel { Number = doc.RootElement.TryGetProperty("number", out var n) ? n.GetInt32() : 0 };
            }

            string IPersistableModel<StructModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<StructModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("number"u8, Number);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<StructModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString($"{{\"number\":{Number}}}");
        }

        /// <summary>
        /// A proxy over the value-type <see cref="StructModel"/> that produces a sentinel value when it handles the model.
        /// </summary>
        private class StructModelProxy : ModelProxy<StructModel>, IJsonModel<StructModel>
        {
            private readonly bool _handle;

            public StructModelProxy(bool handle)
            {
                _handle = handle;
            }

            public override bool CanHandle(StructModel model, ModelReaderWriterOptions options) => _handle;
            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options) => _handle;
            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => _handle;

            StructModel IJsonModel<StructModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new StructModel { Number = 999 };
            }

            public override StructModel Create(BinaryData data, ModelReaderWriterOptions options)
                => new StructModel { Number = 999 };

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<StructModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("number"u8, 999);
                writer.WriteEndObject();
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{\"number\":999}");
        }
    }
}
