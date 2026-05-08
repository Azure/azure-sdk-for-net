// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading;
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
        public void Write_ShouldBeSameIfSecondPassThrough(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy(proxy);
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
            options.AddProxy(proxy);
            var model = new JsonModel();
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Write(proxy, options);
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
        public void Read_ShouldBeSameIfSecondPassThrough(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy(proxy);
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
            options.AddProxy(proxy);
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
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
                Assert.AreEqual(passedInProxies!.Count, optionProxies!.Count);
                foreach (var key in passedInProxies.Keys)
                {
                    Assert.IsTrue(optionProxies.ContainsKey(key));
                    Assert.AreEqual(passedInProxies[key], optionProxies[key]);
                }
            }
            else
            {
                Assert.IsTrue(ReferenceEquals(passedInOptions, options));
            }
        }

        private static Dictionary<Type, List<object>>? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return passedInOptions.GetType().GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions) as Dictionary<Type, List<object>>;
        }

        private class JsonModelProxy : IJsonModel<JsonModel>
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

        [Test]
        public void AddProxy_MultipleProxiesForSameType_FormChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // Last registered should be returned (highest priority)
            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy2, resolved);

            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IJsonModel<JsonModel>? jsonResolved));
            Assert.AreSame(proxy2, jsonResolved);
        }

        [Test]
        public void ResolveProxy_ReturnsLastRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy2, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_IJsonModel_ReturnsLastRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IJsonModel<JsonModel>)model);
            Assert.AreSame(proxy2, resolved);
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

            options.AddProxy<JsonModel>(proxy);

            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy, resolved);

            var model = new JsonModel();
            var resolvedFromModel = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy, resolvedFromModel);
        }

        [Test]
        public void TryGetProxy_NoProxies_ReturnsFalse()
        {
            var options = new ModelReaderWriterOptions("J");

            Assert.IsFalse(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? _));
            Assert.IsFalse(options.TryGetProxy<JsonModel>(out IJsonModel<JsonModel>? _));
        }

        [Test]
        public void AddProxy_ChainSharedBetweenCopiedOptions()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // Internal copy shares the same proxy chain
            var copied = new ModelReaderWriterOptions(options);
            Assert.IsTrue(copied.HasProxies);
            Assert.IsTrue(copied.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy2, resolved);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_WithMultipleProxies_UsesLastRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            _optionsMap.Add(proxy2, options);
            ModelReaderWriter.Write(proxy2, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_WithMultipleProxies_UsesLastRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            _optionsMap.Add(proxy2, options);
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
    }
}
