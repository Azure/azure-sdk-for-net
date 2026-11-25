// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    /// <summary>
    /// Behavior of the <see cref="ModelReaderWriterOptions.Proxies"/> and
    /// <see cref="ClientPipelineOptions.ModelProxies"/> collections.
    /// </summary>
    public class ModelProxyCollectionTests
    {
        private static readonly BinaryData AnimalJson = BinaryData.FromString("{\"name\":\"payload\"}");

        [Test]
        public void Insert_AtStartTakesPriorityOverEarlierProxiesForTheSameType()
        {
            var options = new ModelReaderWriterOptions("J");
            var first = new LabelProxy("first");
            var second = new LabelProxy("second");
            var inserted = new LabelProxy("inserted");
            options.Proxies.Add(first);
            options.Proxies.Add(second);

            options.Proxies.Insert(0, inserted);

            Assert.That(options.Proxies, Is.EqualTo(new ModelProxy[] { inserted, first, second }));
            Assert.AreSame(inserted, options.ResolveProxy((IJsonModel<Animal>)new Animal()));
            Assert.AreEqual("inserted", GetLabel(ModelReaderWriter.Write(new Animal(), options)));
            Assert.AreEqual("inserted", ModelReaderWriter.Read<Animal>(AnimalJson, options)!.Name);
            Assert.AreEqual(0, first.WriteCount + first.CreateCount);
        }

        [TestCaseSource(nameof(MutationsAfterUse))]
        public void Mutation_AfterUseTakesEffectOnNextOperation(Action<IList<ModelProxy>> mutate, string? expectedLabel)
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new LabelProxy("first"));
            options.Proxies.Add(new LabelProxy("second"));
            Assert.AreEqual("first", GetLabel(ModelReaderWriter.Write(new Animal(), options)));
            Assert.AreEqual("first", ModelReaderWriter.Read<Animal>(AnimalJson, options)!.Name);

            mutate(options.Proxies);

            var model = new Animal { Name = "original" };
            if (expectedLabel is null)
            {
                Assert.AreSame(model, options.ResolveProxy((IJsonModel<Animal>)model));
                Assert.AreEqual("{\"name\":\"original\"}", ModelReaderWriter.Write(model, options).ToString());
                Assert.AreEqual("payload", ModelReaderWriter.Read<Animal>(AnimalJson, options)!.Name);
            }
            else
            {
                Assert.AreEqual(expectedLabel, GetLabel(ModelReaderWriter.Write(model, options)));
                Assert.AreEqual(expectedLabel, ModelReaderWriter.Read<Animal>(AnimalJson, options)!.Name);
            }
        }

        private static IEnumerable<TestCaseData> MutationsAfterUse()
        {
            yield return MutationCase("Insert_AfterUseTakesEffectOnNextOperation", "inserted",
                proxies => proxies.Insert(0, new LabelProxy("inserted")));
            yield return MutationCase("Remove_AfterUseTakesEffectOnNextOperation", "second",
                proxies => Assert.IsTrue(proxies.Remove(proxies[0])));
            yield return MutationCase("RemoveAt_AfterUseTakesEffectOnNextOperation", "second",
                proxies => proxies.RemoveAt(0));
            yield return MutationCase("RemoveAll_AfterUseRestoresOriginalSerialization", null, proxies =>
            {
                ModelProxy first = proxies[0];
                Assert.IsTrue(proxies.Remove(first));
                proxies.RemoveAt(0);
                Assert.That(proxies, Is.Empty);
                Assert.IsFalse(proxies.Remove(first));
            });
            yield return MutationCase("Clear_AfterUseTakesEffectOnNextOperation", null, proxies =>
            {
                proxies.Clear();
                Assert.That(proxies, Is.Empty);
            });
            yield return MutationCase("IndexerReplacement_AfterUseTakesEffectOnNextOperation", "replacement", proxies =>
            {
                var replacement = new LabelProxy("replacement");
                proxies[0] = replacement;
                Assert.AreSame(replacement, proxies[0]);
            });
            // Replacing with a proxy for an unrelated type removes that registration for Animal.
            yield return MutationCase("IndexerReplacementWithUnrelatedType_AfterUseTakesEffectOnNextOperation", "second",
                proxies => proxies[0] = new TrackingModel());
        }

        private static TestCaseData MutationCase(string name, string? expectedLabel, Action<IList<ModelProxy>> mutate)
            => new TestCaseData(mutate, expectedLabel).SetName(name);

        [TestCase(false)]
        [TestCase(true)]
        public void Proxies_OnDefaultOptionsAreReadOnly(bool xml)
        {
            ModelReaderWriterOptions defaultOptions = xml ? ModelReaderWriterOptions.Xml : ModelReaderWriterOptions.Json;
            var proxy = new LabelProxy("proxy");

            Assert.IsTrue(defaultOptions.Proxies.IsReadOnly);
            Assert.Throws<InvalidOperationException>(() => defaultOptions.Proxies.Add(proxy));
            Assert.Throws<InvalidOperationException>(() => defaultOptions.Proxies.Insert(0, proxy));
            Assert.Throws<InvalidOperationException>(() => defaultOptions.Proxies.Clear());
            Assert.That(defaultOptions.Proxies, Is.Empty);
        }

        [Test]
        public void Proxies_RejectNullItems()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new LabelProxy("proxy");
            Assert.IsFalse(options.Proxies.IsReadOnly);

            Assert.Throws<ArgumentNullException>(() => options.Proxies.Add(null!));
            options.Proxies.Add(proxy);
            Assert.Throws<ArgumentNullException>(() => options.Proxies.Insert(0, null!));
            Assert.Throws<ArgumentNullException>(() => options.Proxies[0] = null!);

            Assert.That(options.Proxies, Is.EqualTo(new ModelProxy[] { proxy }));
        }

        [Test]
        public void ClientOptionsClone_CopiesProxiesIntoAnIndependentMutableCollection()
        {
            var clientOptions = new ClientPipelineOptions();
            var first = new LabelProxy("first");
            var second = new LabelProxy("second");
            clientOptions.ModelProxies.Add(first);
            clientOptions.ModelProxies.Add(second);
            ClientPipeline.Create(clientOptions);

            ClientPipelineOptions clone = clientOptions.Clone();

            Assert.IsFalse(clone.ModelProxies.IsReadOnly);
            Assert.AreNotSame(clientOptions.ModelProxies, clone.ModelProxies);
            Assert.That(clone.ModelProxies, Is.EqualTo(new ModelProxy[] { first, second }));

            clone.ModelProxies.RemoveAt(0);
            clone.ModelProxies.Add(new LabelProxy("third"));

            Assert.That(clientOptions.ModelProxies, Is.EqualTo(new ModelProxy[] { first, second }));
            Assert.AreEqual(2, clone.ModelProxies.Count);
            Assert.AreSame(second, clone.ModelProxies[0]);
        }

        [Test]
        public void BinaryContent_UsesProxiesPresentAtCreation()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new LabelProxy("created"));
            var model = new Animal { Name = "parent", Child = new Animal { Name = "child" } };
            using BinaryContent content = BinaryContent.Create(model, options);

            options.Proxies.Clear();
            options.Proxies.Add(new LabelProxy("changed"));

            using JsonDocument written = JsonDocument.Parse(WriteToBinaryData(content).ToMemory());
            Assert.AreEqual("created", written.RootElement.GetProperty("label").GetString());
            Assert.AreEqual("created", written.RootElement.GetProperty("child").GetProperty("label").GetString());

            using BinaryContent later = BinaryContent.Create(model, options);
            using JsonDocument laterWritten = JsonDocument.Parse(WriteToBinaryData(later).ToMemory());
            Assert.AreEqual("changed", laterWritten.RootElement.GetProperty("label").GetString());
            Assert.AreEqual("changed", laterWritten.RootElement.GetProperty("child").GetProperty("label").GetString());
        }

        private static string? GetLabel(BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return document.RootElement.TryGetProperty("label", out JsonElement label) ? label.GetString() : null;
        }

        public class Animal : IJsonModel<Animal>
        {
            public string Name { get; set; } = "";

            public Animal? Child { get; set; }

            void IJsonModel<Animal>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("name"u8, Name);
                if (Child is not null)
                {
                    writer.WritePropertyName("child"u8);
                    ((IJsonModel<Animal>)Child).Write(writer, options);
                }
                writer.WriteEndObject();
            }

            Animal IJsonModel<Animal>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new Animal { Name = document.RootElement.GetProperty("name").GetString()! };
            }

            BinaryData IPersistableModel<Animal>.Write(ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            Animal IPersistableModel<Animal>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.Parse(data);
                return new Animal { Name = document.RootElement.GetProperty("name").GetString()! };
            }

            string IPersistableModel<Animal>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        // Handles every Animal (no CanHandle overrides). Writes its label and resolves nested children through
        // the received options; reads produce an Animal named after the label.
        private sealed class LabelProxy : ModelProxy<Animal>, IJsonModel<Animal>
        {
            private readonly string _label;

            public LabelProxy(string label) => _label = label;

            public int WriteCount { get; private set; }

            public int CreateCount { get; private set; }

            void IJsonModel<Animal>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteCount++;
                var animal = (Animal)options.ProxiedModel!;
                writer.WriteStartObject();
                writer.WriteString("label"u8, _label);
                if (animal.Child is not null)
                {
                    writer.WritePropertyName("child"u8);
                    options.ResolveProxy((IJsonModel<Animal>)animal.Child).Write(writer, options);
                }
                writer.WriteEndObject();
            }

            Animal IJsonModel<Animal>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                CreateCount++;
                return new Animal { Name = _label };
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
            {
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    ((IJsonModel<Animal>)this).Write(writer, options);
                }
                return BinaryData.FromBytes(stream.ToArray());
            }

            public override Animal Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateCount++;
                return new Animal { Name = _label };
            }

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}
