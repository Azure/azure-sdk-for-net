// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Testing;

namespace Azure.ResourceManager.Resources.Tests
{
    public class MockingTests
    {
        [Test]
        public async Task TestUsingExtensionMethod()
        {
            var mock = new Mock<TenantResource>();

            var mockTemplate = BinaryData.FromString("mockTemplate");

            var mockResult = new TemplateHashResult("a", "b");
            mock.SetupAzureExtensionMethod(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default))
                .Returns(Response.FromValue(mockResult, null));
            //.Throws(new Exception());

            //mock.Setup(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default)).Returns(Response.FromValue(mockResult, null));

            var tenant = mock.Object;
            var r = tenant.CalculateDeploymentTemplateHash(mockTemplate, default);
            Assert.AreEqual("a", r.Value.MinifiedTemplate);
            Assert.AreEqual("b", r.Value.TemplateHash);

            var asyncResult = await tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default);
            Assert.IsNull(asyncResult);
            //mock.Setup(sub => sub.GetCachedClient(It.IsAny<Func<ArmClient, TenantResourceExtensionClient>>()));//.Returns(armDeploymentResourceExtensionMock.Object);

            //Assert.Throws<Exception>(() => tenant.GetArmDeployment("", default));
        }

        [Test]
        public async Task TestUsingAzureMock()
        {
            var mock = new AzureMock<TenantResource>();

            var mockTemplate = BinaryData.FromString("mockTemplate");

            var mockResult = new TemplateHashResult("a", "b");
            mock.Setup(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default))
                .Returns(Response.FromValue(mockResult, null));
            //.Throws(new Exception());

            //mock.Setup(tenantResource => tenantResource.CalculateDeploymentTemplateHash(mockTemplate, default)).Returns(Response.FromValue(mockResult, null));

            var tenant = mock.Object;
            var r = tenant.CalculateDeploymentTemplateHash(mockTemplate, default);
            Assert.AreEqual("a", r.Value.MinifiedTemplate);
            Assert.AreEqual("b", r.Value.TemplateHash);

            var asyncResult = await tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default);
            Assert.IsNull(asyncResult);
            //mock.Setup(sub => sub.GetCachedClient(It.IsAny<Func<ArmClient, TenantResourceExtensionClient>>()));//.Returns(armDeploymentResourceExtensionMock.Object);

            //Assert.Throws<Exception>(() => tenant.GetArmDeployment("", default));
        }
    }
}
