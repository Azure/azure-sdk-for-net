// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.IO;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override void CompareModels(ResourceProviderData model, ResourceProviderData model2, string format)
        {
            Assert.AreEqual(model.Id, model2.Id);
        }

        protected override string GetExpectedResult(string format) => WirePayload;

        protected override void VerifyModel(ResourceProviderData model, string format)
        {
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Id);
        }

        [Test]
        public void ProxySerialization()
        {
            var options = new ModelReaderWriterOptions("J");
            options.AddProxy(typeof(ResourceProviderData), new ResourceDataWriteProxy());

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
    }
}
