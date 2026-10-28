// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterOptionsPassThroughTests
    {
        [SetUp]
        public void SetUp()
        {
            PassThroughOptionsTracker.DefaultOptions = ModelReaderWriterOptions.Json;
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
            PassThroughOptionsTracker.OptionsMap.Add(model, options);
            ModelReaderWriter.Write(model, options);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void Write_WithNullContextWithoutProxies_PreservesLegacyBehavior(bool nonGeneric)
        {
            var model = new PlainTextModel { Value = "legacy" };

            BinaryData data = nonGeneric
                ? ModelReaderWriter.Write((object)model, ModelReaderWriterOptions.Json, null!)
                : ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, null!);

            Assert.AreEqual("{\"value\":\"legacy\"}", data.ToString());
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
            PassThroughOptionsTracker.OptionsMap.Add(proxy, newOptions);
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
            PassThroughOptionsTracker.OptionsMap.Add(proxy, options);
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
            PassThroughOptionsTracker.DefaultOptions = options;
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
            PassThroughOptionsTracker.OptionsMap.Add(proxy, newOptions);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, newOptions);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeDifferentIfProxied(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            PassThroughOptionsTracker.OptionsMap.Add(proxy, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
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

            PassThroughOptionsTracker.OptionsMap.Add(proxy1, options);
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

            PassThroughOptionsTracker.OptionsMap.Add(proxy1, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }
    }
}
