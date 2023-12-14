// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Client.Data;
using ClientModel.Tests.Client.Models.ResourceManager.Resources;
using NUnit.Framework;
using System.IO;

namespace ClientModel.Tests.ModelReaderWriterTests.Models
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
    }
}
