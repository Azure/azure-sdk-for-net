// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterOptionsTests
    {
        private static Dictionary<object, ModelReaderWriterOptions> _optionsMap = [];
        [ThreadStatic]
        private static ModelReaderWriterOptions? _defaultOptions;

        [SetUp]
        public void SetUp()
        {
            _defaultOptions = ModelReaderWriterOptions.Json;
        }

        [Test]
        public void Write_ShouldBeSameInstanceIfNull()
        {
            var model = new JsonModel();
            ModelReaderWriter.Write(model);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ShouldBeSameIfNoProxies(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = new JsonModel();
            _optionsMap.Add(model, options);
            ModelReaderWriter.Write(model, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ClonesClientWireOptions(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var newOptions = new ModelReaderWriterOptions(options);
            var model = new JsonModel();
            _optionsMap.Add(proxy, newOptions);
            ModelReaderWriter.Write(model, newOptions);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ShouldBeDifferentIfProxied(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var model = new JsonModel();
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Write(model, options);
        }

        [Test]
        public void Read_ShouldBeSameInstanceIfNull()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeSameIfNoProxies(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            _defaultOptions = options;
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ClonesClientWireOptions(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var newOptions = new ModelReaderWriterOptions(options);
            _optionsMap.Add(proxy, newOptions);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, newOptions);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeDifferentIfProxied(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        [Test]
        public void NestedWrite_PreservesOuterProxiedModel()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<PlainTextModel>((IJsonModel<PlainTextModel>)new NestedWriteProxy());

            BinaryData result = ModelReaderWriter.Write(new PlainTextModel { Value = "outer" }, options);

            Assert.AreEqual("{\"value\":\"outer\"}", result.ToString());
        }

        [Test]
        public void NestedWrite_SameModelType_ModelReaderWriterResolvesChildProxy()
            => AssertNestedProxyWrite(NestedChildWrite.ModelReaderWriter, expectChildProxy: true);

        [Test]
        public void NestedWrite_SameModelType_ResolveProxyResolvesChildProxy()
            => AssertNestedProxyWrite(NestedChildWrite.ResolveProxy, expectChildProxy: true);

        [Test]
        public void NestedWrite_SameModelType_DirectChildWriteBypassesChildProxy()
            => AssertNestedProxyWrite(NestedChildWrite.Direct, expectChildProxy: false);

        [Test]
        public void NestedWrite_SameModelType_DefaultOptionsBypassChildProxy()
            => AssertNestedProxyWrite(NestedChildWrite.DefaultOptions, expectChildProxy: false);

        private static void AssertNestedProxyWrite(NestedChildWrite childWrite, bool expectChildProxy)
        {
            var options = new ModelReaderWriterOptions("J");
            var context = new NestedWriteContext();
            var outerProxy = new NestedNodeProxy("outer", childWrite, context);
            var innerProxy = new NestedNodeProxy("inner", childWrite, context);
            options.AddProxy<NestedNode>(outerProxy);
            options.AddProxy<NestedNode>(innerProxy);
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
            Assert.AreEqual(1, outerProxy.Writer.WriteCount);
            Assert.AreEqual(expectChildProxy ? 1 : 0, innerProxy.Writer.WriteCount);
            Assert.AreSame(options, outerProxy.ObservedOptions);
            Assert.AreSame(context, outerProxy.ObservedContext);
            Assert.AreNotSame(options, outerProxy.Writer.WorkingOptions);
            Assert.IsNull(options.ProxiedModel, "Writing must not mutate the caller's proxy execution state.");

            if (expectChildProxy)
            {
                Assert.AreSame(options, innerProxy.ObservedOptions);
                Assert.AreSame(context, innerProxy.ObservedContext);
                Assert.AreSame(outerProxy.Writer.WorkingOptions, innerProxy.Writer.WorkingOptions);
            }

            if (childWrite == NestedChildWrite.ModelReaderWriter)
            {
                Assert.AreSame(model, outerProxy.Writer.ProxiedModelAfterChild,
                    "A recursive ModelReaderWriter.Write must restore the outer proxy's original model.");
            }
        }

        private enum NestedChildWrite
        {
            ModelReaderWriter,
            ResolveProxy,
            Direct,
            DefaultOptions
        }

        private sealed class NestedWriteContext : ModelReaderWriterContext
        {
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

        private sealed class NestedNodeProxy : ConditionalModelProxy<NestedNode>
        {
            private readonly string _name;
            internal NestedNodeProxyModel Writer => (NestedNodeProxyModel)Model;
            internal ModelReaderWriterOptions? ObservedOptions { get; private set; }
            internal ModelReaderWriterContext? ObservedContext { get; private set; }

            internal NestedNodeProxy(string name, NestedChildWrite childWrite, ModelReaderWriterContext context)
                : base(new NestedNodeProxyModel(name, childWrite, context))
            {
                _name = name;
            }

            public override bool CanHandle(NestedNode model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                if (model.Name != _name)
                {
                    return false;
                }

                ObservedOptions = options;
                ObservedContext = context;
                return true;
            }
        }

        private sealed class NestedNodeProxyModel : IJsonModel<NestedNode>
        {
            private readonly string _name;
            private readonly NestedChildWrite _childWrite;
            private readonly ModelReaderWriterContext _context;
            internal int WriteCount { get; private set; }
            internal ModelReaderWriterOptions? WorkingOptions { get; private set; }
            internal object? ProxiedModelAfterChild { get; private set; }

            internal NestedNodeProxyModel(string name, NestedChildWrite childWrite, ModelReaderWriterContext context)
            {
                _name = name;
                _childWrite = childWrite;
                _context = context;
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

            BinaryData IPersistableModel<NestedNode>.Write(ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            string IPersistableModel<NestedNode>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            NestedNode IJsonModel<NestedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            NestedNode IPersistableModel<NestedNode>.Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();
        }

        [Test]
        public void NestedRead_PreservesOuterProxiedModel()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new NestedReadProxy();
            options.AddProxy<PlainTextModel>((IPersistableModel<PlainTextModel>)proxy);

            PlainTextModel? result = ModelReaderWriter.Read<PlainTextModel>(
                BinaryData.FromString("{\"value\":\"outer\"}"), options);

            Assert.AreEqual("outer", result!.Value);
            Assert.IsNotNull(proxy.BeforeNestedRead);
            Assert.AreSame(proxy.BeforeNestedRead, proxy.AfterNestedRead);
        }

        private sealed class NestedReadProxy : IPersistableModel<PlainTextModel>
        {
            internal object? BeforeNestedRead { get; private set; }
            internal object? AfterNestedRead { get; private set; }

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                BeforeNestedRead = options.ProxiedModel;
                ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);
                AfterNestedRead = options.ProxiedModel;
                return new PlainTextModel { Value = "outer" };
            }

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        [Test]
        public void ClientWireOptions_ConcurrentReadsDoNotShareExecutionState()
        {
            using var barrier = new Barrier(2);
            var proxy = new ConcurrentReadProxy(barrier);
            var userOptions = new ModelReaderWriterOptions("J");
            userOptions.AddProxy<SimpleModel>((IPersistableModel<SimpleModel>)proxy);
            var wireOptions = new ModelReaderWriterOptions("W", userOptions);

            Task first = Task.Factory.StartNew(
                () => ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), wireOptions),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task second = Task.Factory.StartNew(
                () => ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), wireOptions),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task.WaitAll(first, second);

            var calls = proxy.Observed.ToArray();
            Assert.AreEqual(2, calls.Length);
            Assert.AreNotSame(wireOptions, calls[0].Options);
            Assert.AreNotSame(wireOptions, calls[1].Options);
            Assert.AreNotSame(calls[0].Options, calls[1].Options);
            Assert.AreNotSame(calls[0].Model, calls[1].Model);
        }

        [Test]
        public void ClientWireOptions_ConcurrentWritesDoNotShareExecutionState()
        {
            using var barrier = new Barrier(2);
            var proxy = new ConcurrentWriteProxy(barrier);
            var userOptions = new ModelReaderWriterOptions("J");
            userOptions.AddProxy<PlainTextModel>((IJsonModel<PlainTextModel>)proxy);
            var wireOptions = new ModelReaderWriterOptions("W", userOptions);

            Task<string> first = Task.Factory.StartNew(
                () => ModelReaderWriter.Write(new PlainTextModel { Value = "first" }, wireOptions).ToString(),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task<string> second = Task.Factory.StartNew(
                () => ModelReaderWriter.Write(new PlainTextModel { Value = "second" }, wireOptions).ToString(),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task.WaitAll(first, second);

            Assert.AreEqual("{\"value\":\"first\"}", first.Result);
            Assert.AreEqual("{\"value\":\"second\"}", second.Result);
            var calls = proxy.Observed.ToArray();
            Assert.AreEqual(2, calls.Length);
            Assert.AreNotSame(wireOptions, calls[0]);
            Assert.AreNotSame(wireOptions, calls[1]);
            Assert.AreNotSame(calls[0], calls[1]);
        }

        private sealed class ConcurrentWriteProxy : IJsonModel<PlainTextModel>
        {
            private readonly Barrier _barrier;
            internal ConcurrentBag<ModelReaderWriterOptions> Observed { get; } = new();

            internal ConcurrentWriteProxy(Barrier barrier) => _barrier = barrier;

            PlainTextModel IJsonModel<PlainTextModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => new PlainTextModel();

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new PlainTextModel();

            void IJsonModel<PlainTextModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                if (!_barrier.SignalAndWait(TimeSpan.FromSeconds(10)))
                {
                    throw new TimeoutException("Concurrent proxy writes did not overlap.");
                }

                Observed.Add(options);
                writer.WriteStartObject();
                writer.WriteString("value"u8, ((PlainTextModel)options.ProxiedModel!).Value);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private sealed class ConcurrentReadProxy : IPersistableModel<SimpleModel>
        {
            private readonly Barrier _barrier;
            internal ConcurrentBag<(ModelReaderWriterOptions Options, object? Model)> Observed { get; } = new();

            internal ConcurrentReadProxy(Barrier barrier) => _barrier = barrier;

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                if (!_barrier.SignalAndWait(TimeSpan.FromSeconds(10)))
                {
                    throw new TimeoutException("Concurrent proxy reads did not overlap.");
                }

                Observed.Add((options, options.ProxiedModel));
                return new SimpleModel();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private sealed class NestedWriteProxy : IJsonModel<PlainTextModel>
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

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new PlainTextModel();

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString("{}");

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private static void AssertOptions(object model, ModelReaderWriterOptions options)
        {
            _optionsMap.TryGetValue(model, out var passedInOptions);
            passedInOptions ??= _defaultOptions;

            if (passedInOptions!.HasProxies && passedInOptions?.IsCoreOwned == false)
            {
                Assert.IsFalse(ReferenceEquals(passedInOptions, options));
                Assert.IsTrue(options.IsCoreOwned);
                Assert.AreEqual(passedInOptions.Format, options.Format);
                var passedInProxies = GetProxies(passedInOptions);
                var optionProxies = GetProxies(options);
                Assert.IsNotNull(passedInProxies);
                Assert.IsNotNull(optionProxies);
                // Proxies dictionary is shared by reference between original and copy
                Assert.AreSame(passedInProxies, optionProxies);
            }
            else
            {
                Assert.IsTrue(ReferenceEquals(passedInOptions, options));
            }
        }

        private static object? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return typeof(ModelReaderWriterOptions).GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions);
        }

        private class JsonModelProxy : IJsonModel<JsonModel>
        {
            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                using var doc = JsonDocument.ParseValue(ref reader);
                return new JsonModel();
            }

            JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                return "J";
            }

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return BinaryData.FromString("{}");
            }
        }

        [Test]
        public void AddProxy_MultipleProxiesForSameType_FormChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
        }

        [Test]
        public void ResolveProxy_ReturnsFirstRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_IJsonModel_ReturnsFirstRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IJsonModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_NoProxies_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new JsonModel();

            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(model, resolved);
        }

        [Test]
        public void AddProxy_SingleProxy_BehavesLikeBefore()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);

            var model = new JsonModel();
            var resolvedFromModel = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy, resolvedFromModel);
        }

        [Test]
        public void HasProxy_NoProxies_ReturnsFalse()
        {
            var options = new ModelReaderWriterOptions("J");

            Assert.IsFalse(options.TryGetProxy<JsonModel>(ReadOnlyMemory<byte>.Empty, out IPersistableModel<JsonModel>? proxy));
            Assert.IsNull(proxy);
        }

        [Test]
        public void AddProxy_ChainSharedBetweenCopiedOptions()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var copied = new ModelReaderWriterOptions(options);
            Assert.IsTrue(copied.HasProxies);
            Assert.AreSame(GetProxies(options), GetProxies(copied));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_WithMultipleProxies_UsesFirstRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            _optionsMap.Add(proxy1, options);
            ModelReaderWriter.Write(new JsonModel(), options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_WithMultipleProxies_UsesFirstRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            _optionsMap.Add(proxy1, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        private class JsonModel : IJsonModel<JsonModel>
        {
            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                return "J";
            }

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                var format = options.Format == "W" ? ((IPersistableModel<JsonModel>)this).GetFormatFromOptions(options) : options.Format;

                switch (format)
                {
                    case "J":
                        return ModelReaderWriter.Write(this, options);
                    default:
                        throw new FormatException($"The model {nameof(JsonModel)} does not support writing '{options.Format}' format.");
                }
            }
        }

        #region Chain of responsibility read tests

        [Test]
        public void ReadWithChain_SingleProxy_ReturnsProxyResult()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ChainProxy(handleRead: true);
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_ProxyDeclinesWithCanHandle_FallsToModel()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ChainProxy(handleRead: false); // CanHandle returns false = decline
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
            Assert.IsFalse(proxy.CreateWasCalled);
            // Model handled it since proxy declined
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void ReadWithChain_SecondProxyHandlesAfterFirstDeclines()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);  // will decline (tried first, FIFO)
            var proxy2 = new ChainProxy(handleRead: true);   // will handle

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNotNull(result);
            // proxy1 was tried first (first added, FIFO), declined via CanHandle
            Assert.IsFalse(proxy1.CreateWasCalled);
            // proxy2 was tried next, handled it
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_AllProxiesDecline_ModelHandlesIt()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
            // ProxiedModel cleared since model handled it
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void ReadWithChain_NoProxies_ModelHandlesIt()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");

            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReadWithChain_DiscriminatorPattern()
        {
            var options = new ModelReaderWriterOptions("J");
            // Discriminator proxy only handles data containing "special" — registered first (FIFO)
            var discriminatorProxy = new DiscriminatorProxy("special");
            // Default proxy handles everything — registered second (fallback)
            var defaultProxy = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(discriminatorProxy);
            options.AddProxy<SimpleModel>(defaultProxy);

            var model = new SimpleModel();

            // Data with discriminator — discriminatorProxy handles
            var specialData = BinaryData.FromString("{\"type\":\"special\"}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, specialData);
            Assert.IsNotNull(result);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled);

            // Reset
            discriminatorProxy.Reset();
            defaultProxy.Reset();

            // Data without discriminator — discriminatorProxy declines via CanHandle, defaultProxy handles
            var normalData = BinaryData.FromString("{\"type\":\"standard\"}");
            result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, normalData);
            Assert.IsNotNull(result);
            Assert.IsFalse(discriminatorProxy.CreateWasCalled); // CanHandle returned false, Create not called
            Assert.IsTrue(defaultProxy.CreateWasCalled); // handled it
        }

        [Test]
        public void ResolveProxy_Write_UsesCanHandle()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            // Write uses CanHandle — both have CanHandle(SimpleModel) => true,
            // so the first registered (proxy1) is used since it's checked first (FIFO).
            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);
            Assert.AreSame(proxy1.Model, resolved);
        }

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
        public void ConditionalProxy_CanHandle_ReceivesOptions()
        {
            // Proves the proxy condition can depend on the caller-provided options (the derived
            // options type is preserved across the internal core copy).
            var enabled = new FlaggedOptions(useProxy: true);
            var proxyEnabled = new OptionsAwareProxy();
            enabled.AddProxy<SimpleModel>(proxyEnabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), enabled));
            Assert.IsTrue(proxyEnabled.CreateWasCalled, "Proxy should handle when the options flag is on.");

            var disabled = new FlaggedOptions(useProxy: false);
            var proxyDisabled = new OptionsAwareProxy();
            disabled.AddProxy<SimpleModel>(proxyDisabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), disabled));
            Assert.IsFalse(proxyDisabled.CreateWasCalled, "Proxy should decline when the options flag is off.");
        }

        [Test]
        public void FormatAndOptionsConstructor_CopiesRegistrationsAndPreservesProxyOptions()
        {
            var userOptions = new FlaggedOptions(useProxy: true);
            var proxy = new OptionsAwareProxy();
            userOptions.AddProxy<SimpleModel>(proxy);

            var wireOptions = new ModelReaderWriterOptions("W", userOptions);
            SimpleModel? result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), wireOptions);

            Assert.AreEqual("W", wireOptions.Format);
            Assert.IsFalse(wireOptions.IsCoreOwned);
            Assert.AreNotSame(GetProxies(userOptions), GetProxies(wireOptions));
            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled, "The conditional proxy should receive the original derived options.");
        }

        [Test]
        public void FormatAndOptionsConstructor_RejectsNullOptions()
        {
            Assert.Throws<ArgumentNullException>(() => new ModelReaderWriterOptions("W", null!));
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

        /// <summary>
        /// A derived options type carrying a custom flag the proxy conditions on.
        /// </summary>
        private class FlaggedOptions : ModelReaderWriterOptions
        {
            public bool UseProxy { get; }
            public FlaggedOptions(bool useProxy) : base("J") => UseProxy = useProxy;
        }

        /// <summary>
        /// A conditional proxy whose decision depends on the active options.
        /// </summary>
        private class OptionsAwareProxy : ConditionalModelProxy<SimpleModel>
        {
            public OptionsAwareProxy() : base(new TrackingModel()) { }

            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options is FlaggedOptions flagged && flagged.UseProxy;

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options is FlaggedOptions flagged && flagged.UseProxy;
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

        /// <summary>
        /// Simple model without AssertOptions logic, used for chain tests.
        /// </summary>
        private class SimpleModel : IJsonModel<SimpleModel>
        {
            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new SimpleModel();

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);
        }

        /// <summary>
        /// A model that serializes to JSON by default but can be routed to a custom "plain text"
        /// format by a proxy. Used to prove a proxy works with formats other than JSON (note 8).
        /// </summary>
        private class PlainTextModel : IJsonModel<PlainTextModel>
        {
            public string Value { get; set; } = "";

            PlainTextModel IJsonModel<PlainTextModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new PlainTextModel { Value = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString() ?? "" : "" };
            }

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.Parse(data);
                return new PlainTextModel { Value = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString() ?? "" : "" };
            }

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<PlainTextModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("value"u8, Value);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                => BinaryData.FromString($"{{\"value\":\"{Value}\"}}");
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

        private class TrackingModel : IJsonModel<SimpleModel>
        {
            public bool CreateWasCalled { get; private set; }
            public bool WriteWasCalled { get; private set; }
            public object? CapturedProxiedModelOnBinaryCreate { get; private set; }
            public object? CapturedProxiedModelOnReaderCreate { get; private set; }
            public object? CapturedProxiedModelOnWrite { get; private set; }

            public void Reset()
            {
                CreateWasCalled = false;
                WriteWasCalled = false;
                CapturedProxiedModelOnBinaryCreate = null;
                CapturedProxiedModelOnReaderCreate = null;
                CapturedProxiedModelOnWrite = null;
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnBinaryCreate = options.ProxiedModel;
                return new SimpleModel();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnReaderCreate = options.ProxiedModel;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedProxiedModelOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedProxiedModelOnWrite = options.ProxiedModel;
                return BinaryData.FromString("{}");
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A proxy that can be configured to handle or decline reads.
        /// </summary>
        private class ChainProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly bool _handleRead;
            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;
            public bool WriteWasCalled => ((TrackingModel)Model).WriteWasCalled;
            public object? CapturedProxiedModelOnCreate => ((TrackingModel)Model).CapturedProxiedModelOnBinaryCreate ?? ((TrackingModel)Model).CapturedProxiedModelOnReaderCreate;

            public ChainProxy(bool handleRead)
                : base(new TrackingModel())
            {
                _handleRead = handleRead;
            }

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handleRead;

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handleRead;

            public void Reset() => ((TrackingModel)Model).Reset();
        }

        /// <summary>
        /// A proxy that peeks at the data to check for a discriminator value.
        /// </summary>
        private class DiscriminatorProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly string _discriminatorValue;
            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;

            public DiscriminatorProxy(string discriminatorValue)
                : base(new TrackingModel())
            {
                _discriminatorValue = discriminatorValue;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                return BinaryData.FromBytes(data).ToString().Contains($"\"type\":\"{_discriminatorValue}\"");
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return document.RootElement.TryGetProperty("type", out var type) && type.GetString() == _discriminatorValue;
            }

            public void Reset() => ((TrackingModel)Model).Reset();
        }

        /// <summary>
        /// A proxy that captures ProxiedModel at every interaction point (Write, Create(BinaryData), Create(ref reader)).
        /// Used to verify the ProxiedModel contract.
        /// </summary>
        private class ProxiedModelCapturingProxy : IJsonModel<SimpleModel>
        {
            public object? CapturedOnWrite { get; private set; }
            public object? CapturedOnCreateBinaryData { get; private set; }
            public object? CapturedOnCreateReader { get; private set; }
            public List<object?> AllCapturedOnCreateReader { get; } = new();

            public void Reset()
            {
                CapturedOnWrite = null;
                CapturedOnCreateBinaryData = null;
                CapturedOnCreateReader = null;
                AllCapturedOnCreateReader.Clear();
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                CapturedOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CapturedOnCreateBinaryData = options.ProxiedModel;
                return new SimpleModel();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CapturedOnCreateReader = options.ProxiedModel;
                AllCapturedOnCreateReader.Add(options.ProxiedModel);
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            {
                CapturedOnWrite = options.ProxiedModel;
                return BinaryData.FromString("{}");
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        #region ProxiedModel Contract Tests

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyWrite()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.AreSame(model, proxy.CapturedOnWrite,
                "ProxiedModel must be set to the original model when proxy.Write is called, " +
                "so the proxy can read the model's state during serialization.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateBinaryData()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, proxy.CapturedOnCreateBinaryData,
                "ProxiedModel must be set to the original model when proxy.Create(BinaryData) is called, " +
                "so the proxy knows which model instance it is acting on behalf of.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateReader()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.AreSame(model, proxy.CapturedOnCreateReader,
                "ProxiedModel must be set to the original model when proxy.Create(ref reader) is called " +
                "via the reader-based ReadWithChain path.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenNoProxyExists_Write()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleModel();

            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy must return the model itself when no proxy is registered.");
            Assert.IsNull(options.ProxiedModel,
                "ProxiedModel must remain null when no proxy is registered, " +
                "because there is no proxy that needs to access the original model.");
        }

        [Test]
        public void ProxiedModel_IsStillSetAfterSuccessfulProxyRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, options.ProxiedModel,
                "ProxiedModel must remain set to the original model after a proxy successfully handles a read, " +
                "because downstream code may still need to reference the original model.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenAllProxiesDecline_AndModelHandlesRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNull(options.ProxiedModel,
                "ProxiedModel must be cleared (set to null) when all proxies decline and the model handles " +
                "the read itself, because the model is not acting as a proxy — it is the original.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNull(proxy2.CapturedProxiedModelOnCreate,
                "proxy2 was never reached because proxy1 handled — CapturedProxiedModelOnCreate must be null.");
            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the proxy that handles the read " +
                "is called. ProxiedModel must not leak state between chain attempts.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain_ReaderPath()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.IsNull(proxy2.CapturedProxiedModelOnCreate,
                "proxy2 was never reached because proxy1 handled — CapturedProxiedModelOnCreate must be null.");
            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the proxy that handles the read " +
                "in the reader-based chain is called.");
        }

        [Test]
        public void ProxiedModel_IsSetPerElement_InCollection()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var json = "[{},{},{}]";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            int elementCount = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var model = new SimpleModel();
                    options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);
                    elementCount++;

                    Assert.IsNotNull(proxy.CapturedOnCreateReader,
                        $"ProxiedModel must be set when reading element {elementCount} of a collection. " +
                        "Each element must independently set ProxiedModel for the proxy.");
                }
                else if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
            }

            Assert.AreEqual(3, elementCount,
                "Expected 3 elements to be read from the collection.");
        }

        #endregion

        #region JsonModelConverter chain-of-responsibility tests

        [Test]
        public void JsonModelConverter_Read_ChainSecondProxyHandlesAfterFirstDeclines()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);  // declines via CanHandle
            var proxy2 = new ChainProxy(handleRead: true);   // handles

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled,
                "proxy1 should have declined via CanHandle and not had Create called.");
            Assert.IsTrue(proxy2.CreateWasCalled,
                "proxy2 should have handled the read after proxy1 declined.");
        }

        [Test]
        public void JsonModelConverter_Read_AllProxiesDecline_ModelHandles()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Read_DiscriminatorPattern()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new ChainProxy(handleRead: true);

            mrwOptions.AddProxy<SimpleModel>(discriminatorProxy);
            mrwOptions.AddProxy<SimpleModel>(defaultProxy);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            // Discriminator matches — first proxy handles
            var specialResult = JsonSerializer.Deserialize<SimpleModel>("{\"type\":\"special\"}", stjOptions);
            Assert.IsNotNull(specialResult);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled);

            discriminatorProxy.Reset();
            defaultProxy.Reset();

            // Discriminator doesn't match — first declines, second handles
            var normalResult = JsonSerializer.Deserialize<SimpleModel>("{\"type\":\"other\"}", stjOptions);
            Assert.IsNotNull(normalResult);
            Assert.IsFalse(discriminatorProxy.CreateWasCalled);
            Assert.IsTrue(defaultProxy.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Write_UsesChainCanHandle()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false); // declines
            var proxy2 = new SelectiveWriteProxy(canWrite: true);  // handles

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var model = new SimpleModel();
            string json = JsonSerializer.Serialize<IJsonModel<object>>((IJsonModel<object>)(object)model, stjOptions);

            Assert.IsFalse(proxy1.WriteWasCalled,
                "proxy1 should have declined via CanHandle(model) on the write path.");
            Assert.IsTrue(proxy2.WriteWasCalled,
                "proxy2 should have handled the write after proxy1 declined.");
        }

        #endregion

        #region ResolveProxy write path with CanHandle declining

        [Test]
        public void ResolveProxy_Write_FirstDeclinesSecondHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(proxy2.Model, resolved,
                "ResolveProxy should skip proxy1 (CanHandle=false) and return proxy2's model.");
        }

        [Test]
        public void ResolveProxy_Write_AllDecline_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy should return the model itself when all proxies decline.");
        }

        [Test]
        public void ResolveProxy_IJsonModel_FirstDeclinesSecondHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)model);

            Assert.AreSame((IJsonModel<SimpleModel>)proxy2.Model, resolved,
                "IJsonModel ResolveProxy should skip proxy1 (CanHandle=false) and return proxy2's model.");
        }

        #endregion

        #region Non-generic ReadWithChain (Type overload)

        [Test]
        public void ReadWithChain_NonGeneric_SecondProxyHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            var result = options.ReadWithChain(typeof(SimpleModel), (IJsonModel<object>)(object)model, ref reader);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_NonGeneric_AllDecline_ModelHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            var result = options.ReadWithChain(typeof(SimpleModel), (IJsonModel<object>)(object)model, ref reader);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
        }

        #endregion

        #region Collection read with chain

        [Test]
        public void CollectionRead_WithChain_PerElementDiscrimination()
        {
            var options = new ModelReaderWriterOptions("J");
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(discriminatorProxy);
            options.AddProxy<SimpleModel>(defaultProxy);

            // Read a list where elements differ — the chain should route per-element
            var json = "[{\"type\":\"special\"},{\"type\":\"other\"},{\"type\":\"special\"}]";
            var result = ModelReaderWriter.Read<List<SimpleModel>>(BinaryData.FromString(json), options);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result!.Count);
        }

        #endregion

        #region WS3 Medium-severity regression tests

        [Test]
        public void AddProxy_NullProxy_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((ConditionalModelProxy<SimpleModel>)null!));
        }

        [Test]
        public void ResolveProxy_NullModel_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)null!));
        }

        [Test]
        public void AddProxy_OnDefaultJsonOptions_ThrowsInvalidOperationException()
        {
            var proxy = new ChainProxy(handleRead: true);
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriterOptions.Json.AddProxy<SimpleModel>(proxy));
        }

        [Test]
        public void AddProxy_OnDefaultXmlOptions_ThrowsInvalidOperationException()
        {
            var proxy = new ChainProxy(handleRead: true);
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriterOptions.Xml.AddProxy<SimpleModel>(proxy));
        }

        [Test]
        public void ResolveProxy_NonGeneric_SkipsConditionalProxyWithoutJsonModel()
        {
            var options = new ModelReaderWriterOptions("J");
            // First proxy handles (CanHandle=true) but its model is persistable-only (not IJsonModel),
            // so the JSON write path must skip it instead of throwing.
            var persistableOnly = new PersistableOnlyConditionalProxy();
            var jsonProxy = new ChainProxy(handleRead: true);
            options.AddProxy<SimpleModel>(persistableOnly);
            options.AddProxy<SimpleModel>(jsonProxy);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy((IJsonModel<object>)(object)model);

            Assert.AreSame(jsonProxy.Model, resolved,
                "Non-generic ResolveProxy should skip the persistable-only conditional proxy and return the JSON proxy's model.");
        }

        /// <summary>
        /// A model implementation that only supports the persistable (non-JSON) path.
        /// </summary>
        private class PersistableOnlyModel : IPersistableModel<SimpleModel>
        {
            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new SimpleModel();
            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
        }

        /// <summary>
        /// A conditional proxy whose held model does not implement IJsonModel.
        /// </summary>
        private class PersistableOnlyConditionalProxy : ConditionalModelProxy<SimpleModel>
        {
            public PersistableOnlyConditionalProxy() : base(new PersistableOnlyModel()) { }

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;
        }

        #endregion

        /// <summary>
        /// A proxy that can be configured to accept or decline write via CanHandle(model).
        /// Used to test the write-path chain-of-responsibility where first proxy declines.
        /// </summary>
        private class SelectiveWriteProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly bool _canWrite;
            public bool WriteWasCalled => ((TrackingModel)Model).WriteWasCalled;

            public SelectiveWriteProxy(bool canWrite)
                : base(new TrackingModel())
            {
                _canWrite = canWrite;
            }

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _canWrite;
        }

        #endregion
    }
}
