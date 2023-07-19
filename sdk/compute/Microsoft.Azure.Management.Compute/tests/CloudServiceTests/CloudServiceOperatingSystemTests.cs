// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class CloudServiceOperatingSystemTests : CloudServiceTestsBase
    {
        [Fact]
        [Trait("Name", "Test_CloudServiceOperatingSystemOperations")]
        public void Test_CloudServiceOperatingSystemOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // List OS versions by location
                IPage<OSVersion> osVersionsInLocation = m_CrpClient.CloudServiceOperatingSystems.ListOSVersions("westus2");

                // Ensure result is not empty
                Assert.NotEmpty(osVersionsInLocation);

                // Ensure results contain mandatory fields
                Assert.DoesNotContain(
                    osVersionsInLocation,
                    x => string.IsNullOrWhiteSpace(x.Properties.Family) ||
                         string.IsNullOrWhiteSpace(x.Properties.FamilyLabel) ||
                         string.IsNullOrWhiteSpace(x.Properties.Version) ||
                         string.IsNullOrWhiteSpace(x.Properties.Label));

                // List OS families by location
                IPage<OSFamily> osFamiliesInLocation = m_CrpClient.CloudServiceOperatingSystems.ListOSFamilies("westus2");

                // Ensure result is not empty
                Assert.NotEmpty(osFamiliesInLocation);

                // Ensure results contain mandatory fields
                Assert.DoesNotContain(
                    osFamiliesInLocation,
                    x => string.IsNullOrWhiteSpace(x.Properties.Name) ||
                         string.IsNullOrWhiteSpace(x.Properties.Label));
            }
        }
    }
}
