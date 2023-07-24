// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Moq;
using Azure.Core;
using System.Collections.Generic;

namespace Azure.ResourceManager.Resources.Tests
{
    public class MockingTests
    {
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

        /// <summary>
        /// This scenario is starting from ResourceGroupResource
        /// 1. get the ArmDeploymentCollection from the resource group
        /// 2. create an ArmDeploymentResource instance
        /// 3. get the ArmApplicationCollection from the resource group
        /// 4. create an ArmApplicationResource instance
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This scenario is starting from ArmClient
        /// 1. get the ArmDeploymentResource by id from the client
        /// 2. call ExportTemplateAsync and get the result
        /// 3. get the ArmApplicationResource by id from the client
        /// 4. call RefreshPermissionsAsync (it does not returns any result other than the status code)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task MockingGetResourceOnArmClient_WithoutAzureMock()
        {
            // the data we use
            var subscriptionId = Guid.NewGuid().ToString();
            var deploymentResourceId = ArmDeploymentResource.CreateResourceIdentifier($"/subscriptions/{subscriptionId}", "myDeployment");
            var scriptResourceId = ArmDeploymentScriptResource.CreateResourceIdentifier(subscriptionId, "myRg", "myScript");
            // the result
            var exportResult = ArmResourcesModelFactory.ArmDeploymentExportResult(BinaryData.FromString("{ \"dummy\": \"ok\" }"));
            IEnumerable<AzureLocation> locations = new[] { AzureLocation.WestUS, AzureLocation.EastUS };

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            var armDeploymentMock = new Mock<ArmDeploymentResource>();
            var scriptMock = new Mock<ArmDeploymentScriptResource>();
            // COMMENT: this is a real big issue when we mock GetResourceClient, its signature does not take a resource therefore we cannot easily make it to return two different instances with different ids.
            armClientMock.Setup(client => client.GetResourceClient(It.IsAny<Func<ArmDeploymentResource>>())).Returns(armDeploymentMock.Object);
            armDeploymentMock.Setup(ad => ad.ExportTemplateAsync(default)).ReturnsAsync(Response.FromValue(exportResult, null));
            armDeploymentMock.Setup(ad => ad.Id).Returns(deploymentResourceId);
            // COMMENT: but since it takes a generic parameter, it is possible to return different type of instances.
            armClientMock.Setup(client => client.GetResourceClient(It.IsAny<Func<ArmDeploymentScriptResource>>())).Returns(scriptMock.Object);
            scriptMock.Setup(s => s.Id).Returns(scriptResourceId);
            scriptMock.Setup(s => s.GetAvailableLocationsAsync(default)).ReturnsAsync(Response.FromValue(locations, null));

            var client = armClientMock.Object;
            var deploymentResource = client.GetArmDeploymentResource(deploymentResourceId);

            Assert.AreEqual(deploymentResourceId, deploymentResource.Id);

            var result = await deploymentResource.ExportTemplateAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(exportResult.Template, result.Value.Template);

            var scriptResource = client.GetArmDeploymentScriptResource(scriptResourceId);

            Assert.AreEqual(scriptResourceId, scriptResource.Id);

            var locationResults = await scriptResource.GetAvailableLocationsAsync();

            Assert.IsNotNull(locationResults);
            Assert.AreEqual(locations, locationResults.Value);
        }

        /// <summary>
        /// This scenario is starting from ArmClient
        /// 1. Get the first instance of ArmDeploymentResource using the first id from the client
        /// 2. Get the second instance of ArmDeploymentResource using the second id from the client
        /// 3. Call ExportTemplateAsync on both of them
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task MockingGetMultipleResourcesOnArmClient_WithoutAzureMock()
        {
            // TODO -- this cannot pass now, until we fix GetResourceClient
            // the data we use
            var subscriptionId = Guid.NewGuid().ToString();
            var armDeploymentId1 = ArmDeploymentResource.CreateResourceIdentifier($"/subscriptions/{subscriptionId}", "myDeployment1");
            var armDeploymentId2 = ArmDeploymentResource.CreateResourceIdentifier($"/subscriptions/{subscriptionId}", "myDeployment2");
            // the result
            var exportResult1 = ArmResourcesModelFactory.ArmDeploymentExportResult(BinaryData.FromString("{ \"dummy\": \"ok\" }"));
            var exportResult2 = ArmResourcesModelFactory.ArmDeploymentExportResult(BinaryData.FromString("{ \"dummy\": \"not_ok\" }"));

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            var armDeploymentMock1 = new Mock<ArmDeploymentResource>();
            var armDeploymentMock2 = new Mock<ArmDeploymentResource>();
            // COMMENT: this is a real big issue when we mock GetResourceClient, its signature does not take a resource therefore we cannot easily make it to return two different instances with different ids.
            armClientMock.Setup(client => client.GetResourceClient(It.IsAny<Func<ArmDeploymentResource>>())).Returns(armDeploymentMock1.Object);
            armDeploymentMock1.Setup(ad => ad.Id).Returns(armDeploymentId1);
            armDeploymentMock1.Setup(ad => ad.ExportTemplateAsync(default)).ReturnsAsync(Response.FromValue(exportResult1, null));
            // COMMENT: but since it takes a generic parameter, it is possible to return different type of instances.
            armClientMock.Setup(client => client.GetResourceClient(It.IsAny<Func<ArmDeploymentResource>>())).Returns(armDeploymentMock2.Object);
            armDeploymentMock2.Setup(ad => ad.Id).Returns(armDeploymentId2);
            armDeploymentMock2.Setup(ad => ad.ExportTemplateAsync(default)).ReturnsAsync(Response.FromValue(exportResult2, null));

            var client = armClientMock.Object;
            var deploymentResource1 = client.GetArmDeploymentResource(armDeploymentId1);

            Assert.AreEqual(armDeploymentId1, deploymentResource1.Id);

            var result1 = await deploymentResource1.ExportTemplateAsync();

            Assert.IsNotNull(result1);
            Assert.AreEqual(exportResult1.Template, result1.Value.Template);

            var deploymentResource2 = client.GetArmDeploymentResource(armDeploymentId2);

            // this will fail
            Assert.AreEqual(armDeploymentId2, deploymentResource2.Id);

            var result2 = await deploymentResource2.ExportTemplateAsync();

            Assert.IsNotNull(result2);
            Assert.AreEqual(exportResult2.Template, result2.Value.Template);
        }

        /// <summary>
        /// This scenario is starting from ArmClient
        /// 1. Get the first instance of ArmDeploymentResource using the first id from the client
        /// 2. Get the second instance of ArmDeploymentResource using the second id from the client
        /// 3. Call ExportTemplateAsync on both of them
        /// </summary>
        [Test]
        public void MockingGetMultipleResourcesOnArmClient_WithoutAzureMock_FixedByGetCachedClient()
        {
            // the data we use
            var subscriptionId = Guid.NewGuid().ToString();
            var appId1 = ArmApplicationResource.CreateResourceIdentifier(subscriptionId, "myRg", "myApp1");
            var appId2 = ArmApplicationResource.CreateResourceIdentifier(subscriptionId, "myRg", "myApp2");
            // the result
            var exportResult1 = ArmResourcesModelFactory.ArmDeploymentExportResult(BinaryData.FromString("{ \"dummy\": \"ok\" }"));
            var exportResult2 = ArmResourcesModelFactory.ArmDeploymentExportResult(BinaryData.FromString("{ \"dummy\": \"not_ok\" }"));

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            var appMock1 = new Mock<ArmApplicationResource>();
            var appMock2 = new Mock<ArmApplicationResource>();
            armClientMock.Setup(client => client.GetCachedClient(appId1, It.IsAny<Func<ResourceIdentifier, ArmApplicationResource>>())).Returns(appMock1.Object);
            appMock1.Setup(app => app.Id).Returns(appId1);
            armClientMock.Setup(client => client.GetCachedClient(appId2, It.IsAny<Func<ResourceIdentifier, ArmApplicationResource>>())).Returns(appMock2.Object);
            appMock2.Setup(ad => ad.Id).Returns(appId2);

            var client = armClientMock.Object;
            var appResource1 = client.GetArmApplicationResource(appId1);

            Assert.AreEqual(appId1, appResource1.Id);

            var appResource2 = client.GetArmApplicationResource(appId2);

            Assert.AreEqual(appId2, appResource2.Id);

            Assert.IsFalse(appResource1 == appResource2);
        }

        /// <summary>
        /// This scenario is starting from ArmClient
        /// 1. Get the first instance of TemplateSpecResource using the first id from the client
        /// 2. Get the second instance of TemplateSpecResource using the second id from the client
        /// 3. Call ExportTemplateAsync on both of them
        /// </summary>
        [Test]
        public void MockingGetMultipleResourcesOnArmClient_WithoutAzureMock_FixedByArmClientExtensionClient()
        {
            // the data we use
            var subscriptionId = Guid.NewGuid().ToString();
            var specId1 = TemplateSpecResource.CreateResourceIdentifier(subscriptionId, "myRg", "mySpec1");
            var specId2 = TemplateSpecResource.CreateResourceIdentifier(subscriptionId, "myRg", "mySpec2");

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            var specMock1 = new Mock<TemplateSpecResource>();
            var specMock2 = new Mock<TemplateSpecResource>();
            // setup the Ids
            specMock1.Setup(spec => spec.Id).Returns(specId1);
            specMock2.Setup(spec => spec.Id).Returns(specId2);
            // mock the corresponding extension client
            var armClientExtension = new Mock<ArmClientExtensionClient>();
            // mock the GetCachedClient method on the extendee
            armClientMock.Setup(client => client.GetCachedClient(It.IsAny<Func<ArmClient, ArmClientExtensionClient>>())).Returns(armClientExtension.Object);
            // mock the same method on the extension client instead
            armClientExtension.Setup(e => e.GetTemplateSpecResource(specId1)).Returns(specMock1.Object);
            armClientExtension.Setup(e => e.GetTemplateSpecResource(specId2)).Returns(specMock2.Object);

            var client = armClientMock.Object;
            var specResource1 = client.GetTemplateSpecResource(specId1);

            Assert.AreEqual(specId1, specResource1.Id);

            var specResource2 = client.GetTemplateSpecResource(specId2);

            Assert.AreEqual(specId2, specResource2.Id);

            Assert.IsFalse(specResource1 == specResource2);
        }

        /// <summary>
        /// </summary>
        [Test]
        public async Task MockingScopeResourcesOnArmClient_WithoutAzureMock_FixedByArmClientExtensionClient()
        {
            // the data we use
            var scope1 = SubscriptionResource.CreateResourceIdentifier(Guid.NewGuid().ToString());
            var scope2 = ResourceGroupResource.CreateResourceIdentifier(Guid.NewGuid().ToString(), "myRg");
            var deploymentId1 = ArmDeploymentResource.CreateResourceIdentifier(scope1, "myDeployment1");
            var deploymentId2 = ArmDeploymentResource.CreateResourceIdentifier(scope2, "myDeployment2");
            var content1 = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Complete));
            var content2 = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental));

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            var collectionMock1 = new Mock<ArmDeploymentCollection>();
            var collectionMock2 = new Mock<ArmDeploymentCollection>();
            var deploymentMock1 = new Mock<ArmDeploymentResource>();
            var deploymentMock2 = new Mock<ArmDeploymentResource>();
            var lroMock1 = new Mock<ArmOperation<ArmDeploymentResource>>();
            var lroMock2 = new Mock<ArmOperation<ArmDeploymentResource>>();
            // setup the Ids
            deploymentMock1.Setup(spec => spec.Id).Returns(deploymentId1);
            deploymentMock2.Setup(spec => spec.Id).Returns(deploymentId2);
            // mock the corresponding extension client
            var armClientExtension = new Mock<ArmClientExtensionClient>();
            // mock the GetCachedClient method on the extendee
            armClientMock.Setup(client => client.GetCachedClient(It.IsAny<Func<ArmClient, ArmClientExtensionClient>>())).Returns(armClientExtension.Object);
            // mock the same method on the extension client instead
            armClientExtension.Setup(e => e.GetArmDeployments(scope1)).Returns(collectionMock1.Object);
            armClientExtension.Setup(e => e.GetArmDeployments(scope2)).Returns(collectionMock2.Object);
            // mock the create or update on the collections
            collectionMock1.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment1", content1, default)).ReturnsAsync(lroMock1.Object);
            collectionMock2.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment2", content2, default)).ReturnsAsync(lroMock2.Object);
            // mock the lros so that we could get results
            lroMock1.Setup(l => l.Value).Returns(deploymentMock1.Object);
            lroMock2.Setup(l => l.Value).Returns(deploymentMock2.Object);

            var client = armClientMock.Object;
            var collection1 = client.GetArmDeployments(scope1);
            var lro1 = await collection1.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment1", content1);
            var resource1 = lro1.Value;

            Assert.AreEqual(deploymentId1, resource1.Id);

            var collection2 = client.GetArmDeployments(scope2);
            var lro2 = await collection2.CreateOrUpdateAsync(WaitUntil.Completed, "myDeployment2", content2);
            var resource2 = lro2.Value;

            Assert.AreEqual(deploymentId2, resource2.Id);

            Assert.IsFalse(resource1 == resource2);
        }

        /// <summary>
        /// </summary>
        [Test]
        public void MockingScopeOperationsOnArmClient_WithoutAzureMock_FixedByArmClientExtensionClient()
        {
            // the data we use
            var scope1 = SubscriptionResource.CreateResourceIdentifier(Guid.NewGuid().ToString());
            var scope2 = ResourceGroupResource.CreateResourceIdentifier(Guid.NewGuid().ToString(), "myRg");
            var template1 = BinaryData.FromObjectAsJson(new
            {
                something = "not_ok"
            });
            var template2 = BinaryData.FromObjectAsJson(new
            {
                everything = "ok"
            });
            var result1 = ArmResourcesModelFactory.TemplateHashResult("okaydokey");
            var result2 = ArmResourcesModelFactory.TemplateHashResult("not-okaydokey");

            // setup the mocking
            // the ArmClient
            var armClientMock = new Mock<ArmClient>();
            // mock the corresponding extension client
            var armClientExtension = new Mock<ArmClientExtensionClient>();
            // mock the GetCachedClient method on the extendee
            armClientMock.Setup(client => client.GetCachedClient(It.IsAny<Func<ArmClient, ArmClientExtensionClient>>())).Returns(armClientExtension.Object);
            // mock the same method on the extension client instead
            armClientExtension.Setup(e => e.CalculateDeploymentTemplateHash(scope1, template1, default)).Returns(Response.FromValue(result1, null));
            armClientExtension.Setup(e => e.CalculateDeploymentTemplateHash(scope2, template2, default)).Returns(Response.FromValue(result2, null));

            var client = armClientMock.Object;
            var response1 = client.CalculateDeploymentTemplateHash(scope1, template1);

            Assert.AreEqual(result1, response1.Value);

            var response2 = client.CalculateDeploymentTemplateHash(scope2, template2);

            Assert.AreEqual(result2, response2.Value);

            Assert.IsFalse(response1 == response2);
        }
    }
}
