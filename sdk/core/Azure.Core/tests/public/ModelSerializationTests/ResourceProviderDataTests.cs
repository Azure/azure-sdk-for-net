// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override Func<ResourceProviderData, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ResourceProviderData> FromResponse => response => (ResourceProviderData)response;

        protected override void CompareModels(ResourceProviderData model, ResourceProviderData model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Id, model2.Id);
        }

        protected override string GetExpectedResult(ModelSerializerFormat format) => WirePayload;

        protected override void VerifyModel(ResourceProviderData model, ModelSerializerFormat format)
        {
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Id);
        }
    }
}
