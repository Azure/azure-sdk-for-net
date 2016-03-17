//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class AvailabilitySetTests : VMTestBase
    {
        RecordedDelegatingHandler handler;
        ComputeManagementClient computeClient;
        ResourceManagementClient resourcesClient;

        ResourceGroup resourceGroup;

        string subId;
        string location;
        const string testPrefix = TestPrefix;
        string resourceGroupName;

        // These values are configurable in the service, but normal default values are FD = 3 and UD = 5
        // FD values can be 2 or 3
        // UD values are 1 -> 20
        const int nonDefaultFD = 2;
        const int nonDefaultUD = 4;

        const int defaultFD = 3;
        const int defaultUD = 5;

        // These constants for for the out of range tests
        const int FDTooLow = 0;
        const int FDTooHi = 4;
        const int UDTooLow = 0;
        const int UDTooHi = 21;

        [Fact]
        public void TestOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Initialize(context);

                try
                {
                    // Attempt to Create Availability Set with out of bounds FD and UD values
                    VerifyInvalidFDUDValuesFail();

                    // Create a Availability Set with default values
                    VerifyDefaultValuesSucceed();

                    // Make sure non default FD and UD values succeed
                    VerifyNonDefaultValuesSucceed();

                    // Updating an Availability Set should fail
                    //VerifyUpdateFails();
                }
                finally
                {
                    resourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        private void Initialize(MockContext context)
        {
            handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            resourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(context, handler);
            computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context, handler);

            subId = computeClient.SubscriptionId;
            location = ComputeManagementTestUtilities.DefaultLocation;

            resourceGroupName = ComputeManagementTestUtilities.GenerateName(testPrefix);

            resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { resourceGroupName, DateTime.UtcNow.ToString("u") } }
                });
        }

        private void VerifyUpdateFails()
        {
            var availabilitySetName = ComputeManagementTestUtilities.GenerateName("asupdateFails");
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                }
            };

            // Create and expect success.
            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, availabilitySetName, inputAvailabilitySet);

            try // Modify the FD and expect failure
            {
                inputAvailabilitySet = new AvailabilitySet
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
                    PlatformFaultDomainCount = nonDefaultFD,
                };

                createOrUpdateResponse = null;
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, availabilitySetName, inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.Forbidden);
            }
            Assert.True(createOrUpdateResponse == null);

            try // Modify the UD and expect failure
            {
                inputAvailabilitySet = new AvailabilitySet
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
                    PlatformUpdateDomainCount = nonDefaultUD,
                };

                createOrUpdateResponse = null;
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, availabilitySetName, inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.Forbidden);
            }
            Assert.True(createOrUpdateResponse == null);

            // Clean up
            computeClient.AvailabilitySets.Delete(resourceGroupName, availabilitySetName);
        }

        private void VerifyNonDefaultValuesSucceed()
        {
            // Negative tests for a bug in 5.0.0 that read-only fields have side-effect on the request body
            var testStatus = new InstanceViewStatus
            {
                Code = "test",
                DisplayStatus = "test",
                Message = "test"
            };

            string inputAvailabilitySetName = ComputeManagementTestUtilities.GenerateName("asnondefault");
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
                PlatformFaultDomainCount = nonDefaultFD,
                PlatformUpdateDomainCount = nonDefaultUD,
                Statuses = new List<InstanceViewStatus>()
                {
                    testStatus
                }
            };

            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroupName,
                inputAvailabilitySetName,
                inputAvailabilitySet);

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, inputAvailabilitySetName, nonDefaultFD, nonDefaultUD);
        }

        private void VerifyDefaultValuesSucceed()
        {
            var inputAvailabilitySetName = ComputeManagementTestUtilities.GenerateName("asdefaultvalues");
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
            };

            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroupName,
                inputAvailabilitySetName,
                inputAvailabilitySet);

            // List AvailabilitySets
            string expectedAvailabilitySetId = Helpers.GetAvailabilitySetRef(subId, resourceGroupName, inputAvailabilitySetName);
            var listResponse = computeClient.AvailabilitySets.List(resourceGroupName);
            ValidateAvailabilitySet(inputAvailabilitySet, listResponse.FirstOrDefault(x => x.Name == inputAvailabilitySetName),
                inputAvailabilitySetName, expectedAvailabilitySetId, defaultFD, defaultUD);

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, inputAvailabilitySetName, defaultFD, defaultUD);
        }

        private void VerifyInvalidFDUDValuesFail()
        {
            var inputAvailabilitySetName = ComputeManagementTestUtilities.GenerateName("invalidfdud");
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
            };

            // function to test the limits available.       
            inputAvailabilitySet.PlatformFaultDomainCount = FDTooLow;
            AvailabilitySet createOrUpdateResponse = null;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySetName,
                    inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformFaultDomainCount = FDTooHi;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySetName,
                    inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);

            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformUpdateDomainCount = UDTooLow;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySetName,
                    inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);

            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformUpdateDomainCount = UDTooHi;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroupName,
                inputAvailabilitySetName,
                inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);

            }
            Assert.True(createOrUpdateResponse == null);
        }

        private void ValidateResults(AvailabilitySet createOrUpdateResponse, AvailabilitySet inputAvailabilitySet, string inputAvailabilitySetName, int expectedFD, int expectedUD)
        {
            string expectedAvailabilitySetId = Helpers.GetAvailabilitySetRef(subId, resourceGroupName, inputAvailabilitySetName);

            Assert.True(createOrUpdateResponse.Name == inputAvailabilitySetName);
            Assert.True(createOrUpdateResponse.Location.ToLower() == this.location.ToLower()
                     || createOrUpdateResponse.Location.ToLower() == inputAvailabilitySet.Location.ToLower());

            ValidateAvailabilitySet(inputAvailabilitySet, createOrUpdateResponse, inputAvailabilitySetName, expectedAvailabilitySetId, expectedFD, expectedUD);

            // GET AvailabilitySet
            var getResponse = computeClient.AvailabilitySets.Get(resourceGroupName, inputAvailabilitySetName);
            ValidateAvailabilitySet(inputAvailabilitySet, getResponse, inputAvailabilitySetName, expectedAvailabilitySetId, expectedFD, expectedUD);

            // List VM Sizes
            var listVMSizesResponse = computeClient.AvailabilitySets.ListAvailableSizes(resourceGroupName, inputAvailabilitySetName);
            Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

            // Delete AvailabilitySet
            computeClient.AvailabilitySets.Delete(resourceGroupName, inputAvailabilitySetName);
        }


        private void ValidateAvailabilitySet(AvailabilitySet inputAvailabilitySet, AvailabilitySet outputAvailabilitySet, string inputAvailabilitySetName, string expectedAvailabilitySetId, int expectedFD, int expectedUD)
        {
            Assert.True(inputAvailabilitySetName == outputAvailabilitySet.Name);
            Assert.True(outputAvailabilitySet.Type == ApiConstants.ResourceProviderNamespace + "/" + ApiConstants.AvailabilitySets);

            Assert.True(outputAvailabilitySet != null);
            Assert.True(outputAvailabilitySet.PlatformFaultDomainCount == expectedFD);
            Assert.True(outputAvailabilitySet.PlatformUpdateDomainCount == expectedUD);

            Assert.NotNull(inputAvailabilitySet.Tags);
            Assert.NotNull(outputAvailabilitySet.Tags);

            foreach (var tag in inputAvailabilitySet.Tags)
            {
                string key = tag.Key;
                Assert.True(inputAvailabilitySet.Tags[key] == outputAvailabilitySet.Tags[key]);
            }

            // TODO: Dev work corresponding to setting status is not yet checked in.
            //Assert.NotNull(outputAvailabilitySet.Properties.Id);
            //Assert.True(expectedAvailabilitySetIds.ToLowerInvariant() == outputAvailabilitySet.Properties.Id.ToLowerInvariant());
        }
    }
}

