// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources.Mock;
using Azure.ResourceManager.Resources.Models;
using Moq;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests.Mock
{
    public class MockTests
    {
        public MockTests() { }

        [Test]
        public async Task MockExtensionMethods()
        {
            // setup the mock for the extension
            var armDeploymentResourceExtensionMock = new Mock<ArmDeploymentResourceExtension>();
            var mockTemplate = BinaryData.FromString("mockTemplate");
            var mockResult = ArmResourcesModelFactory.TemplateHashResult("minifiedTemplate", "mockTemplateHash");
            armDeploymentResourceExtensionMock.Setup(extension => extension.CalculateDeploymentTemplateHashAsync(mockTemplate, default)).Returns(Task.FromResult(Response.FromValue(mockResult, null)));

            // we have to setup the mock for subscriptionResource.GetCachedClient to let it returns the mock of ArmDeploymentResourceExtension
            var tenantResourceMock = new Mock<TenantResource>();
            tenantResourceMock.Setup(sub => sub.GetCachedClient(It.IsAny<Func<ArmClient, ArmDeploymentResourceExtension>>())).Returns(armDeploymentResourceExtensionMock.Object);
            var tenantResource = tenantResourceMock.Object;

            // invoke the mock
            var response = await tenantResource.CalculateDeploymentTemplateHashAsync(mockTemplate);
        }
    }
}
