// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Moq;
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
            var deploymentCollectionMock = new AzureMock<ArmDeploymentCollection>();
            var deploymentLroMock = new AzureMock<ArmOperation<ArmDeploymentResource>>();
            var deploymentMock = new AzureMock<ArmDeploymentResource>();
            var appCollectionMock = new AzureMock<ArmApplicationCollection>();
            var appLroMock = new AzureMock<ArmOperation<ArmApplicationResource>>();
            var appMock = new AzureMock<ArmApplicationResource>();

            deploymentMock.Setup(resource => resource.GetAsync(default)).ReturnsAsync(Response.FromValue(deploymentMock.Object, null));

            var deploymentId = ArmDeploymentResource.CreateResourceIdentifier($"/subscriptions/{Guid.NewGuid()}", "myDeployment");
            var deploymentData = ArmResourcesModelFactory.ArmDeploymentData(deploymentId);

            deploymentMock.Setup(resource => resource.Data).Returns(deploymentData);
            deploymentLroMock.Setup(lro => lro.Value).Returns(deploymentMock.Object);

            appMock.Setup(resource => resource.GetAsync(default)).ReturnsAsync(Response.FromValue(appMock.Object, null));
            var appId = ArmApplicationResource.CreateResourceIdentifier(Guid.NewGuid().ToString(), "myRg", "myApplication");
            var appData = ArmResourcesModelFactory.ArmApplicationData(appId);
            appMock.Setup(resource => resource.Id).Returns(appId);
            appMock.Setup(resource => resource.Data).Returns(appData);

            appLroMock.Setup(lro => lro.Value).Returns(appMock.Object);

            var content = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental));
            deploymentCollectionMock.Setup(collection => collection.CreateOrUpdateAsync(WaitUntil.Completed, It.IsAny<string>(), content, default)).ReturnsAsync(deploymentLroMock.Object);

            appCollectionMock.Setup(collection => collection.CreateOrUpdateAsync(WaitUntil.Completed, It.IsAny<string>(), appData, default)).ReturnsAsync(appLroMock.Object);

            rgMock.Setup(rg => rg.GetArmDeployments()).Returns(deploymentCollectionMock.Object);
            rgMock.Setup(rg => rg.GetArmApplications()).Returns(appCollectionMock.Object);
            // TODO -- cannot directly mock this because we do not have a `GetArmApplicationAsync` method on the extension client
            //rgMock.Setup(rg => rg.GetArmApplicationAsync(It.IsAny<string>(), default)).ReturnsAsync(Response.FromValue(appMock.Object, null));

            var rg = rgMock.Object;
            var deploymentCollection = rg.GetArmDeployments();
            var lro = await deploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment", content);
            var deployment = lro.Value;
            var appCollection = rg.GetArmApplications();
            var appLro = await appCollection.CreateOrUpdateAsync(WaitUntil.Completed, "myApplication", appData);
            var app = appLro.Value;

            Assert.IsNotNull(deployment);
            Assert.AreEqual(deploymentId, deployment.Data.Id);
            Assert.IsNotNull(app);
            Assert.AreEqual(appId, app.Id);
            Assert.AreEqual(appId, app.Data.Id);
        }
    }
}
