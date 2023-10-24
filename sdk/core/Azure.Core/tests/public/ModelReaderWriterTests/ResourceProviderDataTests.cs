// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.ClientModel;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override void CompareModels(ResourceProviderData model, ResourceProviderData model2, ModelReaderWriterFormat format)
        {
            Assert.AreEqual(model.Id, model2.Id);
        }

        protected override string GetExpectedResult(ModelReaderWriterFormat format) => WirePayload;

        protected override void VerifyModel(ResourceProviderData model, ModelReaderWriterFormat format)
        {
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Id);
        }
    }
}
