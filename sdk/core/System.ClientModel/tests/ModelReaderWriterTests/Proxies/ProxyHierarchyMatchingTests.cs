// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ProxyHierarchyMatchingTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void SameInstanceWritesIdenticallyThroughBaseAndDerivedContracts(bool multipleProxyContracts)
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(multipleProxyContracts ? new DualContractProxy() : new NodeProxy());
            var node = new DerivedNode { Name = "docs", Extra = "retained" };

            byte[] expected = ModelReaderWriter.Write(node, options).ToArray();
            CollectionAssert.AreEqual(expected, ModelReaderWriter.Write<BaseNode>(node, options).ToArray());
            CollectionAssert.AreEqual(expected, ModelReaderWriter.Write<object>(node, options).ToArray());
            using var document = JsonDocument.Parse(expected);
            Assert.AreEqual("retained", document.RootElement.GetProperty("extra").GetString());
            Assert.IsTrue(document.RootElement.GetProperty("proxy").GetBoolean());

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new JsonModelConverter(options));
            CollectionAssert.AreEqual(expected, JsonSerializer.SerializeToUtf8Bytes<BaseNode>(node, serializerOptions));
            CollectionAssert.AreEqual(expected, JsonSerializer.SerializeToUtf8Bytes(node, serializerOptions));
            CollectionAssert.AreEqual(expected, WriteBinaryContent<BaseNode>(node, options).ToArray());
            CollectionAssert.AreEqual(expected, WriteBinaryContent(node, options).ToArray());
        }

        [Test]
        public void DecliningProxyLeavesSiblingTypesUntouched()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy());
            var sibling = new OtherNode { Name = "sibling" };

            byte[] expected = ModelReaderWriter.Write<BaseNode>(sibling, ModelReaderWriterOptions.Json).ToArray();
            CollectionAssert.AreEqual(expected, ModelReaderWriter.Write<BaseNode>(sibling, options).ToArray());
            CollectionAssert.AreEqual(expected, ModelReaderWriter.Write<object>(sibling, options).ToArray());
            CollectionAssert.AreEqual(expected, WriteBinaryContent<BaseNode>(sibling, options).ToArray());
        }

        [Test]
        public void HandleAllProxyForBaseTypeHandlesTheWholeHierarchy()
        {
            var proxy = new HandleAllNodeProxy();
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(proxy);

            // Without CanHandle overrides a proxy handles every model and payload.
            var reader = new Utf8JsonReader("{}"u8);
            Assert.IsTrue(proxy.CanHandle(new DerivedNode(), options));
            Assert.IsTrue(proxy.CanHandle(BinaryData.FromString("{}").ToMemory(), options));
            Assert.IsTrue(proxy.CanHandle(ref reader, options));

            foreach (BaseNode node in new BaseNode[] { new BaseNode(), new DerivedNode(), new OtherNode() })
            {
                Assert.AreEqual("{\"handleAll\":true}", ModelReaderWriter.Write(node, options).ToString());
                Assert.AreEqual("{\"handleAll\":true}", ModelReaderWriter.Write<object>(node, options).ToString());
                Assert.AreEqual("{\"handleAll\":true}", WriteBinaryContent(node, options).ToString());
            }
            Assert.AreEqual("{\"handleAll\":true}", ModelReaderWriter.Write(new DerivedNode(), options).ToString());
        }

        [Test]
        public void InterfaceBoundIsExpressedThroughCanHandle()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy(handles: model => model is IMarkedNode));
            var marked = new MarkedNode { Name = "marked" };

            using var document = JsonDocument.Parse(ModelReaderWriter.Write<BaseNode>(marked, options).ToMemory());
            Assert.IsTrue(document.RootElement.GetProperty("proxy").GetBoolean());
            CollectionAssert.AreEqual(
                ModelReaderWriter.Write<BaseNode>(marked, options).ToArray(),
                ModelReaderWriter.Write<object>(marked, options).ToArray());
            var unmarked = new DerivedNode { Name = "unmarked" };
            CollectionAssert.AreEqual(
                ModelReaderWriter.Write(unmarked, ModelReaderWriterOptions.Json).ToArray(),
                ModelReaderWriter.Write(unmarked, options).ToArray());
        }

        [Test]
        public void MostDerivedRegistrationIsConsultedFirst()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy("base"));
            options.Proxies.Add(new DerivedOnlyProxy());

            using var document = JsonDocument.Parse(ModelReaderWriter.Write<BaseNode>(new DerivedNode(), options).ToMemory());
            Assert.AreEqual("derived", document.RootElement.GetProperty("selected").GetString());
            Assert.AreEqual("{\"selected\":\"derived\"}", ModelReaderWriter.Write(new DerivedNode(), options).ToString());
        }

        [Test]
        public void DeclinedDerivedRegistrationFallsBackToBaseRegistration()
        {
            var declining = new DecliningDerivedProxy();
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy("base"));
            options.Proxies.Add(declining);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(new DerivedNode(), options).ToMemory());
            Assert.AreEqual("base", document.RootElement.GetProperty("selected").GetString());
            Assert.AreEqual(1, declining.Checks);
        }

        [Test]
        public void RegistrationsForTheSameTypeFollowRegistrationOrder()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy("first", handles: _ => false));
            options.Proxies.Add(new NodeProxy("second"));
            options.Proxies.Add(new NodeProxy("third"));

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(new DerivedNode(), options).ToMemory());
            Assert.AreEqual("second", document.RootElement.GetProperty("selected").GetString());
        }

        [Test]
        public void ReadsThroughBaseOrDerivedContractUseTheBaseRegistration()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy());

            DerivedNode? derived = ModelReaderWriter.Read<DerivedNode>(BinaryData.FromString("{}"), options);
            BaseNode? asBase = ModelReaderWriter.Read<BaseNode>(BinaryData.FromString("{}"), options);
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new JsonModelConverter(options));
            DerivedNode? converted = JsonSerializer.Deserialize<DerivedNode>("{}", serializerOptions);

            Assert.IsNotNull(derived);
            Assert.AreEqual("created", derived!.Extra);
            Assert.IsInstanceOf<DerivedNode>(asBase);
            Assert.AreEqual("created", ((DerivedNode)asBase!).Extra);
            Assert.IsNotNull(converted);
            Assert.AreEqual("created", converted!.Extra);
        }

        [Test]
        public void IncompatibleDerivedReadFailsExplicitly()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy(createOther: true));

            var exception = Assert.Throws<InvalidOperationException>(
                () => ModelReaderWriter.Read<DerivedNode>(BinaryData.FromString("{}"), options));
            StringAssert.Contains(nameof(DerivedNode), exception!.Message);
            Assert.IsInstanceOf<OtherNode>(ModelReaderWriter.Read<BaseNode>(BinaryData.FromString("{}"), options));
        }

        [Test]
        public void NonGenericRegistrationUsesTheProxyModelType()
        {
            var options = new ModelReaderWriterOptions("J");
            ModelProxy proxy = new NodeProxy();
            options.Proxies.Add(proxy);

            using var other = JsonDocument.Parse(ModelReaderWriter.Write<object>(new OtherNode { Name = "original" }, options).ToMemory());
            Assert.AreEqual("original", other.RootElement.GetProperty("name").GetString());
            Assert.IsFalse(other.RootElement.TryGetProperty("proxy", out _));
            using var derived = JsonDocument.Parse(ModelReaderWriter.Write<object>(new DerivedNode(), options).ToMemory());
            Assert.IsTrue(derived.RootElement.GetProperty("proxy").GetBoolean());
        }

        [Test]
        public void DuplicateRegistrationIsCheckedForEachEntry()
        {
            var proxy = new NodeProxy(handles: _ => false);
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(proxy);
            options.Proxies.Add(proxy);

            ModelReaderWriter.Write<BaseNode>(new OtherNode(), options);
            Assert.AreEqual(2, options.Proxies.Count);
            Assert.AreEqual(2, proxy.Checks);
        }

        [Test]
        public void CollectionsResolveEachElementByItsRuntimeType()
        {
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new NodeProxy());
            var nodes = new List<BaseNode> { new DerivedNode { Name = "docs" }, new OtherNode { Name = "other" } };

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(nodes, options).ToMemory());
            Assert.IsTrue(document.RootElement[0].GetProperty("proxy").GetBoolean());
            Assert.IsFalse(document.RootElement[1].TryGetProperty("proxy", out _));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RecursiveProxyWritesFailWithoutLeakingState(bool mutual)
        {
            var first = new BaseNode();
            var second = mutual ? new BaseNode() : first;
            var options = new ModelReaderWriterOptions("J");
            options.Proxies.Add(new RecursiveProxy(first, second));
            var exception = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(first, options));
            StringAssert.Contains("reenter", exception!.Message);
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void UnregisteredModelsKeepTheirOriginalOutput()
        {
            var node = new DerivedNode { Name = "docs", Extra = "retained" };
            var options = new ModelReaderWriterOptions("J");
            Assert.AreEqual("{\"name\":\"docs\",\"extra\":\"retained\"}", WriteBinaryContent<BaseNode>(node, options).ToString());
            Assert.AreEqual("{\"name\":\"docs\",\"extra\":\"retained\"}", WriteBinaryContent(node, options).ToString());
        }

        public interface IMarkedNode { }

        public class BaseNode : IJsonModel<BaseNode>
        {
            public string Name { get; set; } = "";

            BaseNode IJsonModel<BaseNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new BaseNode();
            BaseNode IPersistableModel<BaseNode>.Create(BinaryData data, ModelReaderWriterOptions options) => new BaseNode();
            string IPersistableModel<BaseNode>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            BinaryData IPersistableModel<BaseNode>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"base\":true}");
            void IJsonModel<BaseNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("name", Name);
                writer.WriteEndObject();
            }
        }

        public sealed class DerivedNode : BaseNode, IJsonModel<DerivedNode>
        {
            public string Extra { get; set; } = "";

            DerivedNode IJsonModel<DerivedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new DerivedNode();
            DerivedNode IPersistableModel<DerivedNode>.Create(BinaryData data, ModelReaderWriterOptions options) => new DerivedNode();
            string IPersistableModel<DerivedNode>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            BinaryData IPersistableModel<DerivedNode>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"derived\":true}");
            void IJsonModel<DerivedNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("name", Name);
                writer.WriteString("extra", Extra);
                writer.WriteEndObject();
            }
        }

        public sealed class OtherNode : BaseNode { }

        public sealed class MarkedNode : BaseNode, IMarkedNode { }

        private sealed class RecursiveProxy : ModelProxy<BaseNode>
        {
            private readonly BaseNode _first;
            private readonly BaseNode _second;

            internal RecursiveProxy(BaseNode first, BaseNode second)
            {
                _first = first;
                _second = second;
            }

            public override BaseNode Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BinaryData Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(ReferenceEquals(options.ProxiedModel, _first) ? _second : _first, options);
        }

        private sealed class HandleAllNodeProxy : ModelProxy<BaseNode>, IJsonModel<BaseNode>
        {
            public BaseNode Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new BaseNode();
            }

            public override BaseNode Create(BinaryData data, ModelReaderWriterOptions options) => new BaseNode();
            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"handleAll\":true}");
            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteBoolean("handleAll", true);
                writer.WriteEndObject();
            }
        }

        private sealed class DerivedOnlyProxy : ModelProxy<DerivedNode>, IJsonModel<DerivedNode>
        {
            public DerivedNode Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new DerivedNode { Extra = "derived" };
            }

            public override DerivedNode Create(BinaryData data, ModelReaderWriterOptions options) => new DerivedNode { Extra = "derived" };
            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"selected\":\"derived\"}");
            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("selected", "derived");
                writer.WriteEndObject();
            }
        }

        private sealed class DecliningDerivedProxy : ModelProxy<DerivedNode>, IJsonModel<DerivedNode>
        {
            public int Checks { get; private set; }

            public override bool CanHandle(DerivedNode model, ModelReaderWriterOptions options)
            {
                Checks++;
                return false;
            }

            public override DerivedNode Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BinaryData Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
            DerivedNode IJsonModel<DerivedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
            void IJsonModel<DerivedNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();
        }

        private class NodeProxy : ModelProxy<BaseNode>, IJsonModel<BaseNode>
        {
            private readonly string _selected;
            private readonly bool _createOther;
            private readonly Func<BaseNode, bool> _handles;

            public NodeProxy(string selected = "default", bool createOther = false, Func<BaseNode, bool>? handles = null)
            {
                _selected = selected;
                _createOther = createOther;
                _handles = handles ?? (model => model is DerivedNode);
            }

            public int Checks { get; private set; }

            public override bool CanHandle(BaseNode model, ModelReaderWriterOptions options)
            {
                Checks++;
                return _handles(model);
            }

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BaseNode Create(BinaryData data, ModelReaderWriterOptions options)
                => _createOther ? new OtherNode() : new DerivedNode { Extra = "created" };
            public override BinaryData Write(ModelReaderWriterOptions options)
            {
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    ((IJsonModel<BaseNode>)this).Write(writer, options);
                }
                return BinaryData.FromBytes(stream.ToArray());
            }

            BaseNode IJsonModel<BaseNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return Create(BinaryData.FromString(document.RootElement.GetRawText()), options);
            }

            void IJsonModel<BaseNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                var node = (BaseNode)options.ProxiedModel!;
                writer.WriteStartObject();
                writer.WriteString("name", node.Name);
                if (node is DerivedNode derived)
                {
                    writer.WriteString("extra", derived.Extra);
                }
                writer.WriteString("selected", _selected);
                writer.WriteBoolean("proxy", true);
                writer.WriteEndObject();
            }
        }

        private sealed class DualContractProxy : NodeProxy, IJsonModel<DerivedNode>
        {
            DerivedNode IJsonModel<DerivedNode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => new DerivedNode { Extra = "variant" };
            DerivedNode IPersistableModel<DerivedNode>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new DerivedNode { Extra = "variant" };
            string IPersistableModel<DerivedNode>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            BinaryData IPersistableModel<DerivedNode>.Write(ModelReaderWriterOptions options)
            {
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    ((IJsonModel<DerivedNode>)this).Write(writer, options);
                }
                return BinaryData.FromBytes(stream.ToArray());
            }
            void IJsonModel<DerivedNode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                var node = (DerivedNode)options.ProxiedModel!;
                writer.WriteStartObject();
                writer.WriteString("name", node.Name);
                writer.WriteString("extra", node.Extra);
                writer.WriteString("selected", "variant");
                writer.WriteBoolean("proxy", true);
                writer.WriteEndObject();
            }
        }
    }
}
