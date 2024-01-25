// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class PortalTests : TestBase
    {
        [Fact]
        [Trait("owner", "jikang")]
        public async Task CreateListUpdatePortalRevision()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();
                var revisionId = TestUtilities.GenerateName("revisionId");
                var portalRevisionContract = new PortalRevisionContract
                {
                    Description = new string('a', 99),
                    IsCurrent = true
                };

                // create portal revision 
                var portalRevision = await testBase.client.PortalRevision.CreateOrUpdateAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    revisionId,
                    portalRevisionContract);

                Assert.NotNull(portalRevision);
                Assert.True(portalRevision.IsCurrent);
                Assert.Equal("completed", portalRevision.Status);

                //get 
                var getPortalRevision = testBase.client.PortalRevision.Get(
                    testBase.rgName,
                    testBase.serviceName,
                    revisionId);

                Assert.NotNull(getPortalRevision);
                Assert.True(portalRevision.IsCurrent);
                Assert.Equal("completed", portalRevision.Status);

                var updateDescription = "Updated " + portalRevisionContract.Description;

                var updatedResult = await testBase.client.PortalRevision.UpdateAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    revisionId,
                    new PortalRevisionContract { Description = updateDescription },
                    "*");

                Assert.NotNull(updatedResult);
                Assert.True(portalRevision.IsCurrent);
                Assert.Equal("completed", updatedResult.Status);
                Assert.Equal(updateDescription, updatedResult.Description);

                //list
                var listPortalRevision = testBase.client.PortalRevision.ListByService(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(listPortalRevision);
            }
        }
    }
}
