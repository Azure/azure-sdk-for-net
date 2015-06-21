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
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class AvailabilitySetTests
    {
        RecordedDelegatingHandler handler;
        ComputeManagementClient computeClient;
        ResourceManagementClient resourcesClient;

        ResourceGroupCreateOrUpdateResult resourceGroup;

        string subId;
        string location;
        const string testPrefix = "pslibtest";
        string resourceGroupName;

        // These values are configurable in the service, but normal default values are FD = 3 and UD = 5
        // FD values can be 2 or 3
        // UD values are 1 -> 20
        const int nonDefaultFD = 2;
        const int nonDefaultUD = 4;

        const int defaultFD = 3;
        const int defaultUD = 5;

        // These constants for for the out of range tests
        const int FDTooLow = 1;
        const int FDTooHi = 4;
        const int UDTooLow = 0;
        const int UDTooHi = 21;

        [Fact]
        public void TestOperations()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                Initialize();

                try
                {
                    // Attempt to Create Availability Set with out of bounds FD and UD values
                    VerifyInvalidFDUDValuesFail();

                    // Create a Availability Set with default values
                    VerifyDefaultValuesSucceed();

                    // Make sure non default FD and UD values succeed
                    VerifyNonDefaultValuesSucceed();

                    // Updating an Availability Set should fail
                    VerifyUpdateFails();
                }
                finally
                {
                    var deleteResourceGroupResponse = resourcesClient.ResourceGroups.BeginDeleting(resourceGroupName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.Accepted);
                }
            }
        }

        private void Initialize()
        {
            handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            resourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(handler);
            computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(handler);

            subId = computeClient.Credentials.SubscriptionId;
            location = ComputeManagementTestUtilities.DefaultLocation;

            resourceGroupName = TestUtilities.GenerateName(testPrefix);

            resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });
        }

        private void VerifyUpdateFails()
        {
            var availabilitySetName = TestUtilities.GenerateName("asupdateFails");
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Name = availabilitySetName,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                }
            };

            // Create and expect success.
            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, inputAvailabilitySet);
            Assert.True(createOrUpdateResponse.StatusCode == HttpStatusCode.OK);

            try // Modify the FD and expect failure
            {
                inputAvailabilitySet = new AvailabilitySet
                {
                    Location = location,
                    Name = availabilitySetName,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
                    PlatformFaultDomainCount = nonDefaultFD,
                };

                createOrUpdateResponse = null;
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.Forbidden);
                Assert.True(ex.Error.Code == "PropertyChangeNotAllowed");
            }
            Assert.True(createOrUpdateResponse == null);

            try // Modify the UD and expect failure
            {
                inputAvailabilitySet = new AvailabilitySet
                {
                    Location = location,
                    Name = availabilitySetName,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
                    PlatformUpdateDomainCount = nonDefaultUD,
                };

                createOrUpdateResponse = null;
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroupName, inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.Forbidden);
                Assert.True(ex.Error.Code == "PropertyChangeNotAllowed");
            }
            Assert.True(createOrUpdateResponse == null);

            // Clean up
            var deleteOperationResponse = computeClient.AvailabilitySets.Delete(resourceGroupName, availabilitySetName);
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

            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Name = TestUtilities.GenerateName("asnondefault"),
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
                inputAvailabilitySet);

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, nonDefaultFD, nonDefaultUD);
        }

        private void VerifyDefaultValuesSucceed()
        {
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Name = TestUtilities.GenerateName("asdefaultvalues"),
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
            };

            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroupName,
                inputAvailabilitySet);

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, defaultFD, defaultUD);
        }

        private void VerifyInvalidFDUDValuesFail()
        {
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = location,
                Name = TestUtilities.GenerateName("invalidfdud"),
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    },
            };

            // function to test the limits available.       
            inputAvailabilitySet.PlatformFaultDomainCount = FDTooLow;
            AvailabilitySetCreateOrUpdateResponse createOrUpdateResponse = null;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.True(ex.Error.Code == "InvalidParameter");

            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformFaultDomainCount = FDTooHi;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.True(ex.Error.Code == "InvalidParameter");

            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformUpdateDomainCount = UDTooLow;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroupName,
                    inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.True(ex.Error.Code == "InvalidParameter");

            }
            Assert.True(createOrUpdateResponse == null);

            inputAvailabilitySet.PlatformUpdateDomainCount = UDTooHi;
            try
            {
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroupName,
                inputAvailabilitySet);
            }
            catch (Hyak.Common.CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.True(ex.Error.Code == "InvalidParameter");

            }
            Assert.True(createOrUpdateResponse == null);
        }

        private void ValidateResults(AvailabilitySetCreateOrUpdateResponse createOrUpdateResponse, AvailabilitySet inputAvailabilitySet, int expectedFD, int expectedUD)
        {
            string expectedAvailabilitySetId = Helpers.GetAvailabilitySetRef(subId, resourceGroupName, inputAvailabilitySet.Name);

            Assert.True(createOrUpdateResponse.StatusCode == HttpStatusCode.OK);

            Assert.True(createOrUpdateResponse.AvailabilitySet.Name == inputAvailabilitySet.Name);
            Assert.True(createOrUpdateResponse.AvailabilitySet.Location.ToLower() == this.location.ToLower()
                     || createOrUpdateResponse.AvailabilitySet.Location.ToLower() == inputAvailabilitySet.Location.ToLower());

            ValidateAvailabilitySet(inputAvailabilitySet, createOrUpdateResponse.AvailabilitySet, expectedAvailabilitySetId, expectedFD, expectedUD);

            // GET AvailabilitySet
            var getResponse = computeClient.AvailabilitySets.Get(resourceGroupName, inputAvailabilitySet.Name);
            Assert.True(getResponse.StatusCode == HttpStatusCode.OK);
            ValidateAvailabilitySet(inputAvailabilitySet, getResponse.AvailabilitySet, expectedAvailabilitySetId, expectedFD, expectedUD);

            // List AvailabilitySets
            var listResponse = computeClient.AvailabilitySets.List(resourceGroupName);
            Assert.True(listResponse.StatusCode == HttpStatusCode.OK);
            ValidateAvailabilitySet(inputAvailabilitySet, listResponse.AvailabilitySets.FirstOrDefault(x => x.Name == inputAvailabilitySet.Name),
                expectedAvailabilitySetId, expectedFD, expectedUD);

            var listVMSizesResponse = computeClient.AvailabilitySets.ListAvailableSizes(resourceGroupName, inputAvailabilitySet.Name);
            Assert.True(listVMSizesResponse.StatusCode == HttpStatusCode.OK);
            Helpers.ValidateVirtualMachineSizeListResponse(listVMSizesResponse);

            // Delete AvailabilitySet
            var deleteOperationResponse = computeClient.AvailabilitySets.Delete(resourceGroupName, inputAvailabilitySet.Name);
            Assert.True(deleteOperationResponse.StatusCode == HttpStatusCode.OK);
        }


        private void ValidateAvailabilitySet(AvailabilitySet inputAvailabilitySet, AvailabilitySet outputAvailabilitySet, string expectedAvailabilitySetId, int expectedFD, int expectedUD)
        {
            Assert.True(inputAvailabilitySet.Name == outputAvailabilitySet.Name);
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

