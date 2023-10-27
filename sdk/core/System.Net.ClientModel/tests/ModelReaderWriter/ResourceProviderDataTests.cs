// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.IO;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Tests.Client;
using System.Net.ClientModel.Tests.Client.ResourceManager.Resources;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override Func<ResourceProviderData?, MessageBody> ToPipelineContent => model => model;

        protected override Func<Result?, ResourceProviderData> FromResult => response => (ResourceProviderData)response;

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
