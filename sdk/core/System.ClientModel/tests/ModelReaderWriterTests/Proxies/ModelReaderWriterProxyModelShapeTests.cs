// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.IO;
using System.Text.Json;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterProxyModelShapeTests
    {
        [Test]
        public void Read_StructModel_ConditionalProxy_Handles()
        {
            // Regression: a conditional proxy over a value-type (struct) model used to throw
            // InvalidCastException because variance does not apply to value types. After removing
            // IConditionalProxy / the where T : class constraint, it must route through the proxy.
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<StructModel>(new StructConditionalProxy(handle: true));

            StructModel? result = ModelReaderWriter.Read<StructModel>(BinaryData.FromString("{\"number\":1}"), options);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(999, result!.Value.Number); // proxy sentinel proves it handled the read
        }

        [Test]
        public void Read_StructModel_ConditionalProxy_Declines_FallsToModel()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<StructModel>(new StructConditionalProxy(handle: false));

            StructModel? result = ModelReaderWriter.Read<StructModel>(BinaryData.FromString("{\"number\":42}"), options);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(42, result!.Value.Number); // declined; the struct model read itself
        }

        [Test]
        public void Read_StructModel_DirectProxy_Handles()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<StructModel>((IJsonModel<StructModel>)new StructModelProxy());

            StructModel? result = ModelReaderWriter.Read<StructModel>(BinaryData.FromString("{\"number\":1}"), options);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(999, result!.Value.Number);
        }

        [Test]
        public void Write_StructModel_ConditionalProxy_Handles()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<StructModel>(new StructConditionalProxy(handle: true));

            var model = new StructModel { Number = 1 };
            var data = ModelReaderWriter.Write(model, options);

            Assert.AreEqual("{\"number\":999}", data.ToString());
        }

        [Test]
        public void ConditionalProxy_CustomPlainTextFormat_WritesPlainText()
        {
            // A proxy can take over for a caller-defined, non-JSON format. When the "PT" (plain text)
            // format is chosen, the proxy writes a plain-text representation instead of JSON.
            var options = new ModelReaderWriterOptions("PT");
            options.AddProxy<PlainTextModel>(new PlainTextFormatProxy());

            BinaryData data = ModelReaderWriter.Write(new PlainTextModel { Value = "hello" }, options);

            Assert.AreEqual("PlainText: hello", data.ToString());
        }

        [Test]
        public void ConditionalProxy_CustomPlainTextFormat_RoundTrips()
        {
            var options = new ModelReaderWriterOptions("PT");
            options.AddProxy<PlainTextModel>(new PlainTextFormatProxy());

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
            options.AddProxy<PlainTextModel>(new PlainTextFormatProxy());

            BinaryData data = ModelReaderWriter.Write(new PlainTextModel { Value = "hello" }, options);

            Assert.AreEqual("{\"value\":\"hello\"}", data.ToString());
        }

        [TestCase("J", false)]
        [TestCase("J", true)]
        [TestCase("W", false)]
        [TestCase("W", true)]
        public void Write_PersistableOnlyProxyOverridesJsonModel(string format, bool conditional)
        {
            var options = new ModelReaderWriterOptions(format, ModelReaderWriterReflectionContext.Default);
            var proxy = new PersistableWriteProxy("J");
            var conditionalProxy = new PersistableWriteConditionalProxy(proxy);
            if (conditional)
            {
                options.AddProxy<PlainTextModel>(conditionalProxy);
            }
            else
            {
                options.AddProxy<PlainTextModel>(proxy);
            }
            var model = new PlainTextModel { Value = "hello" };
            const string expected = "{\"value\":\"proxied: hello\"}";

            Assert.AreEqual(expected, ModelReaderWriter.Write(model, options).ToString());
            Assert.AreEqual(expected, WriteBinaryContent(model, options));
            Assert.AreEqual(2, proxy.WriteCount);
            Assert.AreEqual(conditional ? 2 : 0, conditionalProxy.CanHandleCount);
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void Write_UsesSelectedProxyWireFormat()
        {
            var options = new ModelReaderWriterOptions("W");
            var proxy = new PersistableWriteProxy("PT");
            options.AddProxy<PlainTextModel>(proxy);
            var model = new PlainTextModel { Value = "hello" };

            Assert.AreEqual("proxied: hello", ModelReaderWriter.Write(model, options).ToString());
            using BinaryContent content = BinaryContent.Create(model, options);
            Assert.IsNull(content.MediaType);
            using var stream = new MemoryStream();
            content.WriteTo(stream);
            Assert.AreEqual("proxied: hello", BinaryData.FromBytes(stream.ToArray()).ToString());
            Assert.AreEqual(2, proxy.WriteCount);
            Assert.IsNull(options.ProxiedModel);
        }

        private sealed class PersistableWriteProxy : IPersistableModel<PlainTextModel>
        {
            private readonly string _wireFormat;
            internal int WriteCount { get; private set; }

            internal PersistableWriteProxy(string wireFormat) => _wireFormat = wireFormat;

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => _wireFormat;

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
            {
                WriteCount++;
                string value = ((PlainTextModel)options.ProxiedModel!).Value;
                string format = options.Format == "W" ? _wireFormat : options.Format;
                return BinaryData.FromString(format == "J"
                    ? $"{{\"value\":\"proxied: {value}\"}}"
                    : $"proxied: {value}");
            }
        }

        private sealed class PersistableWriteConditionalProxy : ConditionalModelProxy<PlainTextModel>
        {
            internal int CanHandleCount { get; private set; }

            internal PersistableWriteConditionalProxy(PersistableWriteProxy model) : base(model) { }

            public override bool CanHandle(PlainTextModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                CanHandleCount++;
                return true;
            }
        }

        /// <summary>
        /// A conditional proxy that takes over only when the caller-chosen format is "PT" (plain text),
        /// producing a plain-text representation instead of JSON. The condition reads
        /// <see cref="ModelReaderWriterOptions.Format"/>, proving a proxy can key on the format.
        /// </summary>
        private class PlainTextFormatProxy : ConditionalModelProxy<PlainTextModel>
        {
            public PlainTextFormatProxy() : base(new PlainTextFormatModel()) { }

            public override bool CanHandle(PlainTextModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options.Format == "PT";

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options.Format == "PT";

            private class PlainTextFormatModel : IPersistableModel<PlainTextModel>
            {
                private const string Prefix = "PlainText: ";

                PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                {
                    string s = data.ToString();
                    return new PlainTextModel { Value = s.StartsWith(Prefix, StringComparison.Ordinal) ? s.Substring(Prefix.Length) : s };
                }

                BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                    => BinaryData.FromString($"{Prefix}{((PlainTextModel)options.ProxiedModel!).Value}");

                string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "PT";
            }
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
        /// A proxy model for <see cref="StructModel"/> that always produces a sentinel value.
        /// </summary>
        private class StructModelProxy : IJsonModel<StructModel>
        {
            StructModel IJsonModel<StructModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new StructModel { Number = 999 };
            }

            StructModel IPersistableModel<StructModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new StructModel { Number = 999 };

            string IPersistableModel<StructModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<StructModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("number"u8, 999);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<StructModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{\"number\":999}");
        }

        /// <summary>
        /// A conditional proxy over the value-type <see cref="StructModel"/>.
        /// </summary>
        private class StructConditionalProxy : ConditionalModelProxy<StructModel>
        {
            private readonly bool _handle;

            public StructConditionalProxy(bool handle) : base(new StructModelProxy())
            {
                _handle = handle;
            }

            public override bool CanHandle(StructModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handle;
            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handle;
            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handle;
        }
    }
}
