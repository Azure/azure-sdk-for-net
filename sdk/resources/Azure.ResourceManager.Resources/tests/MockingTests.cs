// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Testing;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Tests
{
    public class MockingTests
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

        [Test]
        public async Task MockingTestUsingAzureMock()
        {
            var mock = new AzureMock<TenantResource>();

            var mockTemplate = BinaryData.FromString("mockTemplate");
            var mockResult = ArmResourcesModelFactory.TemplateHashResult("a", "b");
            mock.Setup(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default))
                .Returns(Response.FromValue(mockResult, null));

            var tenant = mock.Object;
            var r = tenant.CalculateDeploymentTemplateHash(mockTemplate, default);
            Assert.AreEqual("a", r.Value.MinifiedTemplate);
            Assert.AreEqual("b", r.Value.TemplateHash);

            var asyncResult = await tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default);
            Assert.IsNull(asyncResult);
        }

        [Test]
        public async Task MockingTestUsingPublicClients()
        {
            var extensionMock = new Mock<TenantResourceExtensionClient>();

            var mockTemplate = BinaryData.FromString("mockTemplate");
            var mockResult = new TemplateHashResult("a", "b");
            extensionMock.Setup(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default))
                .Returns(Response.FromValue(mockResult, null));

            var mock = new Mock<TenantResource>();
            mock.Setup(tenant => tenant.GetCachedClient(It.IsAny<Func<ArmClient, TenantResourceExtensionClient>>())).Returns(extensionMock.Object);
            var tenant = extensionMock.Object;

            var r = tenant.CalculateDeploymentTemplateHash(mockTemplate, default);
            Assert.AreEqual("a", r.Value.MinifiedTemplate);
            Assert.AreEqual("b", r.Value.TemplateHash);

            var asyncResult = await tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default);
            Assert.IsNull(asyncResult);
        }

        [Test]
        public async Task MockingArmDeploymentCollection()
        {
            var rgMock = new AzureMock<ResourceGroupResource>();
            var collectionMock = new AzureMock<ArmDeploymentCollection>();
            var lroMock = new AzureMock<ArmOperation<ArmDeploymentResource>>();
            var resourceMock = new AzureMock<ArmDeploymentResource>();
            resourceMock.Setup(resource => resource.GetAsync(default)).ReturnsAsync(Response.FromValue(resourceMock.Object, null));

            var resourceId = ArmDeploymentResource.CreateResourceIdentifier($"/subscriptions/{Guid.NewGuid()}", "myDeployment");
            var resourceData = ArmResourcesModelFactory.ArmDeploymentData(resourceId);

            resourceMock.Setup(resource => resource.Data).Returns(resourceData);
            lroMock.Setup(lro => lro.Value).Returns(resourceMock.Object);
            var content = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental));
            collectionMock.Setup(deployment => deployment.CreateOrUpdateAsync(WaitUntil.Completed, It.IsAny<string>(), content, default)).ReturnsAsync(lroMock.Object);

            rgMock.Setup(rg => rg.GetArmDeployments()).Returns(collectionMock.Object);

            var rg = rgMock.Object;
            var deploymentCollection = rg.GetArmDeployments();
            var lro = await deploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment", content);
            var resource = lro.Value;

            Assert.IsNotNull(resource);
            Assert.AreEqual(resourceId, resource.Data.Id);
        }
    }
}
