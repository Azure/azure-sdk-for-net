// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Azure.ResourceManager.Moq;

namespace Azure.ResourceManager.Resources.Tests
{
    /// <summary>
    /// This class contains the ways of mocking that we do not recommend
    /// </summary>
    public class OldMockingTests
    {
        [Test]
        public async Task MockingTestUsingExtensionMethod()
        {
            var mock = new Mock<TenantResource>();

            var mockTemplate = BinaryData.FromString("mockTemplate");
            var mockResult = ArmResourcesModelFactory.TemplateHashResult("a", "b");
            mock.SetupAzureExtensionMethod(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default))
                .Returns(Response.FromValue(mockResult, null));

            var tenant = mock.Object;
            var r = tenant.CalculateDeploymentTemplateHash(mockTemplate, default);
            Assert.AreEqual("a", r.Value.MinifiedTemplate);
            Assert.AreEqual("b", r.Value.TemplateHash);

            var asyncResult = await tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default);
            Assert.IsNull(asyncResult);
        }
    }
}
