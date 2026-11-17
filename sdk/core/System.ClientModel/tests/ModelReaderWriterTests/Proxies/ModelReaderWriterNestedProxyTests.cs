// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterNestedProxyTests
    {
        [Test]
        public void NestedWrite_PreservesOuterProxiedModel()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NestedWriteProxy());

            BinaryData result = ModelReaderWriter.Write(new PlainTextModel { Value = "outer" }, options);

            Assert.AreEqual("{\"value\":\"outer\"}", result.ToString());
        }

        [TestCase(NestedChildWrite.ModelReaderWriter, true, TestName = "NestedWrite_SameModelType_ModelReaderWriterResolvesChildProxy")]
        [TestCase(NestedChildWrite.ResolveProxy, true, TestName = "NestedWrite_SameModelType_ResolveProxyResolvesChildProxy")]
        [TestCase(NestedChildWrite.Direct, false, TestName = "NestedWrite_SameModelType_DirectChildWriteBypassesChildProxy")]
        [TestCase(NestedChildWrite.DefaultOptions, false, TestName = "NestedWrite_SameModelType_DefaultOptionsBypassChildProxy")]
        public void NestedWrite_SameModelType(NestedChildWrite childWrite, bool expectChildProxy)
        {
            var options = new ModelReaderWriterOptions("J");
            var context = new NestedWriteContext();
            var outerProxy = new NestedNodeProxy("outer", childWrite, context);
            var innerProxy = new NestedNodeProxy("inner", childWrite, context);
            options.Proxies.Add(outerProxy);
            options.Proxies.Add(innerProxy);
            var model = new NestedNode { Name = "outer", Child = new NestedNode { Name = "inner" } };

            BinaryData result = ModelReaderWriter.Write(model, options, context);

            using JsonDocument document = JsonDocument.Parse(result.ToMemory());
            JsonElement outer = document.RootElement;
            JsonElement inner = outer.GetProperty("child");
            Assert.AreEqual("outer-proxy", outer.GetProperty("writer").GetString());
            Assert.AreEqual("outer", outer.GetProperty("name").GetString());
            Assert.AreEqual(expectChildProxy ? "inner-proxy" : "model", inner.GetProperty("writer").GetString());
            Assert.AreEqual("inner", inner.GetProperty("name").GetString());
            Assert.AreEqual(JsonValueKind.Null, inner.GetProperty("child").ValueKind);
            Assert.AreEqual(1, outerProxy.WriteCount);
            Assert.AreEqual(expectChildProxy ? 1 : 0, innerProxy.WriteCount);
            Assert.AreSame(options, outerProxy.ObservedOptions);
            Assert.AreNotSame(options, outerProxy.WorkingOptions);
            Assert.IsNull(options.ProxiedModel, "Writing must not mutate the caller's proxy execution state.");

            if (expectChildProxy)
            {
                Assert.AreSame(options, innerProxy.ObservedOptions);
                Assert.AreSame(outerProxy.WorkingOptions, innerProxy.WorkingOptions);
            }

            if (childWrite == NestedChildWrite.ModelReaderWriter)
            {
                Assert.AreSame(model, outerProxy.ProxiedModelAfterChild,
                    "A recursive ModelReaderWriter.Write must restore the outer proxy's original model.");
            }
        }

        [Test]
        public void NestedRead_PreservesOuterProxiedModel()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new NestedReadProxy();
            options.Proxies.Add(proxy);

            PlainTextModel? result = ModelReaderWriter.Read<PlainTextModel>(
                BinaryData.FromString("{\"value\":\"outer\"}"), options);

            Assert.AreEqual("outer", result!.Value);
            Assert.IsNotNull(proxy.BeforeNestedRead);
            Assert.AreSame(proxy.BeforeNestedRead, proxy.AfterNestedRead);
        }

        public enum NestedChildWrite
        {
            ModelReaderWriter,
            ResolveProxy,
            Direct,
            DefaultOptions
        }

        private sealed class NestedNode : IJsonModel<NestedNode>
        {
            public string Name { get; set; } = "";
            public NestedNode? Child { get; set; }

            void IJsonModel<NestedNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("writer"u8, "model");
                writer.WritePropertyName("child"u8);
                if (Child is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IJsonModel<NestedNode>)Child).Write(writer, options);
                }
                writer.WriteString("name"u8, Name);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<NestedNode>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            string IPersistableModel<NestedNode>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            NestedNode IJsonModel<NestedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            NestedNode IPersistableModel<NestedNode>.Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();
        }

        private sealed class NestedNodeProxy : ModelProxy<NestedNode>, IJsonModel<NestedNode>
        {
            private readonly string _name;
            private readonly NestedChildWrite _childWrite;
            private readonly ModelReaderWriterContext _context;
            internal ModelReaderWriterOptions? ObservedOptions { get; private set; }
            internal int WriteCount { get; private set; }
            internal ModelReaderWriterOptions? WorkingOptions { get; private set; }
            internal object? ProxiedModelAfterChild { get; private set; }

            internal NestedNodeProxy(string name, NestedChildWrite childWrite, ModelReaderWriterContext context)
            {
                _name = name;
                _childWrite = childWrite;
                _context = context;
            }

            public override bool CanHandle(NestedNode model, ModelReaderWriterOptions options)
            {
                if (model.Name != _name)
                {
                    return false;
                }

                ObservedOptions = options;
                return true;
            }

            void IJsonModel<NestedNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteCount++;
                WorkingOptions = options;
                // ResolveProxy updates ProxiedModel; retain this node across streaming child writes.
                var model = (NestedNode)options.ProxiedModel!;
                writer.WriteStartObject();
                writer.WriteString("writer"u8, $"{_name}-proxy");
                writer.WritePropertyName("child"u8);
                if (model.Child is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    switch (_childWrite)
                    {
                        case NestedChildWrite.ModelReaderWriter:
                            writer.WriteRawValue(ModelReaderWriter.Write(model.Child, options, _context).ToMemory().Span);
                            break;
                        case NestedChildWrite.ResolveProxy:
                            options.ResolveProxy((IJsonModel<NestedNode>)model.Child).Write(writer, options);
                            break;
                        case NestedChildWrite.Direct:
                            ((IJsonModel<NestedNode>)model.Child).Write(writer, options);
                            break;
                        case NestedChildWrite.DefaultOptions:
                            writer.WriteRawValue(ModelReaderWriter.Write(model.Child, ModelReaderWriterOptions.Json, _context).ToMemory().Span);
                            break;
                    }
                }
                ProxiedModelAfterChild = options.ProxiedModel;
                writer.WriteString("name"u8, model.Name);
                writer.WriteEndObject();
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            NestedNode IJsonModel<NestedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            public override NestedNode Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();
        }

        private sealed class NestedReadProxy : ModelProxy<PlainTextModel>
        {
            internal object? BeforeNestedRead { get; private set; }
            internal object? AfterNestedRead { get; private set; }

            public override PlainTextModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                BeforeNestedRead = options.ProxiedModel;
                ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);
                AfterNestedRead = options.ProxiedModel;
                return new PlainTextModel { Value = "outer" };
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private sealed class NestedWriteProxy : ModelProxy<PlainTextModel>, IJsonModel<PlainTextModel>
        {
            PlainTextModel IJsonModel<PlainTextModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => new PlainTextModel();

            void IJsonModel<PlainTextModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                ModelReaderWriter.Write(new SimpleModel(), options);
                writer.WriteStartObject();
                writer.WriteString("value"u8, ((PlainTextModel)options.ProxiedModel!).Value);
                writer.WriteEndObject();
            }

            public override PlainTextModel Create(BinaryData data, ModelReaderWriterOptions options)
                => new PlainTextModel();

            public override BinaryData Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}
