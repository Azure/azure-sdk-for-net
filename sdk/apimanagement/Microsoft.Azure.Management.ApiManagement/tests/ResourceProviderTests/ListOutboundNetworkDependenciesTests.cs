// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "jikang")]
        public void GetOutboundNetworkDependencies()
        {
                      Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                // create service
                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);
                var outboundDependencies = testBase.client.OutboundNetworkDependenciesEndpoints.ListByService(testBase.rgName, testBase.serviceName);

                Assert.NotNull(outboundDependencies);
                Assert.Equal(10, outboundDependencies.Value.Count);
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure Storage")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure Active Directory")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure SQL")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure Key Vault")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure Event Hub")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Portal Captcha")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("SSL Certificate Verification")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Azure Monitor")));
                Assert.NotNull(outboundDependencies.Value.Single(d => d.Category.Equals("Windows Activation")));

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);
            }
        }
    }
}