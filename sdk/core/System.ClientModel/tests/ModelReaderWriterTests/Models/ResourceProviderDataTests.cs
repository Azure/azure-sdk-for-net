// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        protected override void CompareModels(ResourceProviderData model, ResourceProviderData model2, string format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Namespace, model2.Namespace);
            Assert.AreEqual(model.RegistrationState, model2.RegistrationState);
            Assert.AreEqual(model.RegistrationPolicy, model2.RegistrationPolicy);
            Assert.AreEqual(model.ProviderAuthorizationConsentState, model2.ProviderAuthorizationConsentState);
            Assert.AreEqual(model.ResourceTypes.Count, model2.ResourceTypes.Count);
        }

        protected override string GetExpectedResult(string format) => WirePayload;

        protected override void VerifyModel(ResourceProviderData model, string format)
        {
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Id);
        }

        [Test]
        public void ValideStjIntegration()
        {
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() }
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var modelFromMrw = ModelReaderWriter.Read<ResourceProviderData>(BinaryData.FromString(WirePayload));

            Assert.IsNotNull(modelFromStj);
            Assert.IsNotNull(modelFromMrw);

            CompareModels(modelFromStj!, modelFromMrw!, "J");
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.AreEqual(WirePayload, stjResult);
        }

        [Test]
        public void ValidatePrettyPrintWithStj()
        {
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() },
                WriteIndented = true,
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.AreEqual(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-TwoSpaces.json")).TrimEnd(), stjResult);
        }

        [Test]
        public void ValidateCapitalizationIsIgnored()
        {
#if NET8_0_OR_GREATER
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() },
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.AreEqual(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-TwoSpaces.json")).TrimEnd(), stjResult);
#endif
        }

        [Test]
        public void ProxySerialization()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy(new ResourceProviderDataProxy());

            var model = ModelReaderWriter.Read<ResourceProviderData>(BinaryData.FromString(WirePayload));
            Assert.NotNull(model);
            var binaryData = ModelReaderWriter.Write(model!, options);
            Assert.AreEqual(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed-MissingId.json")).TrimEnd(), binaryData.ToString());
            Assert.AreNotEqual(WirePayload, binaryData.ToString());

            var model2 = ModelReaderWriter.Read<ResourceProviderData>(binaryData, options);
            Assert.NotNull(model2);
            Assert.NotNull(model2!.Id);
            Assert.AreEqual("TestValue", model2.Id);

            Assert.AreEqual(model!.Namespace, model2.Namespace);
            Assert.AreEqual(model.RegistrationPolicy, model2.RegistrationPolicy);
            Assert.AreEqual(model.RegistrationState, model2.RegistrationState);
            Assert.AreEqual(model.ResourceTypes.Count, model2.ResourceTypes.Count);
        }

        [Test]
        public void ProxyWithStjSerialization()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy(new ResourceProviderDataProxy());

            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter(options) }
            };

            var model = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            Assert.NotNull(model);
            var json = JsonSerializer.Serialize(model, stjOptions);
            Assert.AreEqual(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed-MissingId.json")).TrimEnd(), json);
            Assert.AreNotEqual(WirePayload, json);

            var model2 = JsonSerializer.Deserialize<ResourceProviderData>(json, stjOptions);
            Assert.NotNull(model2);
            Assert.NotNull(model2!.Id);
            Assert.AreEqual("TestValue", model2.Id);
            Assert.AreEqual(model!.Namespace, model2.Namespace);
            Assert.AreEqual(model.RegistrationPolicy, model2.RegistrationPolicy);
            Assert.AreEqual(model.RegistrationState, model2.RegistrationState);
            Assert.AreEqual(model.ResourceTypes.Count, model2.ResourceTypes.Count);
        }

        [Test]
        public void ProxySerializationOfNestedType()
        {
            var options = new ModelReaderWriterOptions("J");
            //this is a nested type of ResourceProviderData
            options.AddProxy(new ProviderResourceTypeProxy());

            var model = ModelReaderWriter.Read<ResourceProviderData>(BinaryData.FromString(WirePayload));
            Assert.NotNull(model);
            var binaryData = ModelReaderWriter.Write(model!, options);
            Assert.AreEqual(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed-With-x.json")).TrimEnd(), binaryData.ToString());
            Assert.AreNotEqual(WirePayload, binaryData.ToString());

            var model2 = ModelReaderWriter.Read<ResourceProviderData>(binaryData, options);
            Assert.NotNull(model2);
            Assert.AreEqual(model!.Id, model2!.Id);
            Assert.AreEqual(model.Namespace, model2.Namespace);
            Assert.AreEqual(model.RegistrationPolicy, model2.RegistrationPolicy);
            Assert.AreEqual(model.RegistrationState, model2.RegistrationState);
            Assert.AreEqual(model.ResourceTypes.Count, model2.ResourceTypes.Count);
        }
    }
}
