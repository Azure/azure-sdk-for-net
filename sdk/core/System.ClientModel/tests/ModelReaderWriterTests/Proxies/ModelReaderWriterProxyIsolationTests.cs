// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Collections.Concurrent;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterProxyIsolationTests
    {
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

        [Test]
        public void BinaryContent_ProxyWriteDoesNotMutateCallerOptions()
        {
            using var barrier = new Barrier(1);
            var proxy = new ConcurrentWriteProxy(barrier);
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<PlainTextModel>((IJsonModel<PlainTextModel>)proxy);

            Assert.AreEqual("{\"value\":\"original\"}",
                WriteBinaryContent(new PlainTextModel { Value = "original" }, options));
            Assert.IsNull(options.ProxiedModel);
            Assert.AreNotSame(options, proxy.Observed.ToArray()[0]);
        }

        [Test]
        public void BinaryContent_ConcurrentProxyWritesDoNotShareExecutionState()
        {
            using var barrier = new Barrier(2);
            var proxy = new ConcurrentWriteProxy(barrier);
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<PlainTextModel>((IJsonModel<PlainTextModel>)proxy);

            Task<string> first = Task.Factory.StartNew(
                () => WriteBinaryContent(new PlainTextModel { Value = "first" }, options),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task<string> second = Task.Factory.StartNew(
                () => WriteBinaryContent(new PlainTextModel { Value = "second" }, options),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task.WaitAll(first, second);

            Assert.AreEqual("{\"value\":\"first\"}", first.Result);
            Assert.AreEqual("{\"value\":\"second\"}", second.Result);
            Assert.IsNull(options.ProxiedModel);
            var calls = proxy.Observed.ToArray();
            Assert.AreEqual(2, calls.Length);
            Assert.AreNotSame(options, calls[0]);
            Assert.AreNotSame(options, calls[1]);
            Assert.AreNotSame(calls[0], calls[1]);
        }

        [Test]
        public void BinaryContent_NestedDeferredBodiesDoNotShareProxyState()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)new DeferredBodiesParentProxy());
            options.AddProxy<PlainTextModel>((IJsonModel<PlainTextModel>)new ProxiedValueProxy());

            string json = ModelReaderWriter.Write(new SimpleModel(), options).ToString();

            Assert.AreEqual("[{\"proxied\":\"first\"},{\"proxied\":\"second\"}]", json);
        }

        // Forwards the received core-owned options to two BinaryContent instances and only
        // serializes them after both exist.
        private sealed class DeferredBodiesParentProxy : IJsonModel<SimpleModel>
        {
            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                using BinaryContent first = BinaryContent.Create(new PlainTextModel { Value = "first" }, options);
                using BinaryContent second = BinaryContent.Create(new PlainTextModel { Value = "second" }, options);

                writer.WriteStartArray();
                foreach (BinaryContent content in new[] { first, second })
                {
                    using var stream = new MemoryStream();
                    content.WriteTo(stream);
                    writer.WriteRawValue(stream.ToArray());
                }
                writer.WriteEndArray();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private sealed class ProxiedValueProxy : IJsonModel<PlainTextModel>
        {
            PlainTextModel IJsonModel<PlainTextModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            void IJsonModel<PlainTextModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("proxied"u8, ((PlainTextModel)options.ProxiedModel!).Value);
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
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
    }
}
