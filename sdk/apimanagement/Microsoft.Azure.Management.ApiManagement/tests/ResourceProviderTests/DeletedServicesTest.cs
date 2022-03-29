// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void DeletedServicesTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                var deletedServices = testBase.client.DeletedServices.ListBySubscription();
                Assert.NotNull(deletedServices);

                var firstService = deletedServices.First();
                var serviceDetails = testBase.client.DeletedServices.GetByName(firstService.Name, firstService.Location);
                Assert.NotNull(serviceDetails);
                Assert.NotNull(serviceDetails.Location);
                Assert.NotNull(serviceDetails.ScheduledPurgeDate);
                Assert.NotNull(serviceDetails.ServiceId);
                Assert.Contains(firstService.Name, serviceDetails.ServiceId);
                Assert.NotNull(serviceDetails.DeletionDate);
                Assert.True(serviceDetails.DeletionDate < serviceDetails.ScheduledPurgeDate);

                // Purge the service
                testBase.client.DeletedServices.Purge(firstService.Name, firstService.Location);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    testBase.client.DeletedServices.GetByName(
                        firstService.Name,
                        firstService.Location);
                });
            }
        }
    }
}