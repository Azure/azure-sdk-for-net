// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
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

        ResourceGroup resourceGroup1;
        ResourceGroup resourceGroup2;

        string subId;
        string location;
        string baseResourceGroupName;
        string resourceGroup1Name;

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
                try
                {
                    EnsureClientsInitialized(context);
                    Initialize(context);

                    // Attempt to Create Availability Set with out of bounds FD and UD values
                    VerifyInvalidFDUDValuesFail();

                    // Create a Availability Set with default values
                    VerifyDefaultValuesSucceed();

                    // Make sure non default FD and UD values succeed
                    VerifyNonDefaultValuesSucceed();

                    // Updating an Availability Set should fail
                    //VerifyUpdateFails();

                    // Make sure availability sets across resource groups are listed successfully
                    VerifyListAvailabilitySetsInSubscription();
                }
                finally
                {
                    resourcesClient.ResourceGroups.Delete(resourceGroup1Name);
                }
            }
        }

        private void Initialize(MockContext context)
        {
            handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            resourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(context, handler);
            computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context, handler);

            subId = computeClient.SubscriptionId;
            location = m_location;

            baseResourceGroupName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            resourceGroup1Name = baseResourceGroupName + "_1";

            resourceGroup1 = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroup1Name,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { resourceGroup1Name, DateTime.UtcNow.ToString("u") } }
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
            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroup1Name, availabilitySetName, inputAvailabilitySet);

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
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroup1Name, availabilitySetName, inputAvailabilitySet);
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
                createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(resourceGroup1Name, availabilitySetName, inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.Forbidden);
            }
            Assert.True(createOrUpdateResponse == null);

            // Clean up
            computeClient.AvailabilitySets.Delete(resourceGroup1Name, availabilitySetName);
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
                PlatformUpdateDomainCount = nonDefaultUD
            };

            var createOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
                resourceGroup1Name,
                inputAvailabilitySetName,
                inputAvailabilitySet);

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, resourceGroup1Name, inputAvailabilitySetName, nonDefaultFD, nonDefaultUD);
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
                resourceGroup1Name,
                inputAvailabilitySetName,
                inputAvailabilitySet);

            // List AvailabilitySets
            string expectedAvailabilitySetId = Helpers.GetAvailabilitySetRef(subId, resourceGroup1Name, inputAvailabilitySetName);
            var listResponse = computeClient.AvailabilitySets.List(resourceGroup1Name);
            ValidateAvailabilitySet(inputAvailabilitySet, listResponse.FirstOrDefault(x => x.Name == inputAvailabilitySetName),
                inputAvailabilitySetName, expectedAvailabilitySetId, defaultFD, defaultUD);

            AvailabilitySetUpdate updateParams = new AvailabilitySetUpdate()
            {
                Tags = inputAvailabilitySet.Tags
            };

            string updateKey = "UpdateTag";
            updateParams.Tags.Add(updateKey, "updateValue");
            createOrUpdateResponse = computeClient.AvailabilitySets.Update(resourceGroup1Name, inputAvailabilitySetName, updateParams);

            Assert.True(createOrUpdateResponse.Tags.ContainsKey(updateKey));

            // This call will also delete the Availability Set
            ValidateResults(createOrUpdateResponse, inputAvailabilitySet, resourceGroup1Name, inputAvailabilitySetName, defaultFD, defaultUD);
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
                    resourceGroup1Name,
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
                    resourceGroup1Name,
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
                    resourceGroup1Name,
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
                resourceGroup1Name,
                inputAvailabilitySetName,
                inputAvailabilitySet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);

            }
            Assert.True(createOrUpdateResponse == null);
        }

        private void ValidateResults(AvailabilitySet outputAvailabilitySet, AvailabilitySet inputAvailabilitySet, string resourceGroupName, string inputAvailabilitySetName, int expectedFD, int expectedUD)
        {
            string expectedAvailabilitySetId = Helpers.GetAvailabilitySetRef(subId, resourceGroupName, inputAvailabilitySetName);

            Assert.True(outputAvailabilitySet.Name == inputAvailabilitySetName);
            Assert.True(outputAvailabilitySet.Location.ToLower() == this.location.ToLower()
                     || outputAvailabilitySet.Location.ToLower() == inputAvailabilitySet.Location.ToLower());

            ValidateAvailabilitySet(inputAvailabilitySet, outputAvailabilitySet, inputAvailabilitySetName, expectedAvailabilitySetId, expectedFD, expectedUD);

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

        // Make sure availability sets across resource groups are listed successfully
        private void VerifyListAvailabilitySetsInSubscription()
        {
            string resourceGroup2Name = baseResourceGroupName + "_2";
            string baseInputAvailabilitySetName = ComputeManagementTestUtilities.GenerateName("asdefaultvalues");
            string availabilitySet1Name = baseInputAvailabilitySetName + "_1";
            string availabilitySet2Name = baseInputAvailabilitySetName + "_2";

            try
            {
                AvailabilitySet inputAvailabilitySet1 = new AvailabilitySet
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG1", "rg1"},
                        {"testTag", "1"},
                    },
                };
                AvailabilitySet outputAvailabilitySet1 = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroup1Name,
                    availabilitySet1Name,
                    inputAvailabilitySet1);

                resourceGroup2 = resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroup2Name,
                    new ResourceGroup
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>() { { resourceGroup2Name, DateTime.UtcNow.ToString("u") } }
                    });

                AvailabilitySet inputAvailabilitySet2 = new AvailabilitySet
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG2", "rg2"},
                        {"testTag", "2"},
                    },
                };
                AvailabilitySet outputAvailabilitySet2 = computeClient.AvailabilitySets.CreateOrUpdate(
                    resourceGroup2Name,
                    availabilitySet2Name,
                    inputAvailabilitySet2);

                IPage<AvailabilitySet> response = computeClient.AvailabilitySets.ListBySubscription();
                Assert.Null(response.NextPageLink);

                int validationCount = 0;

                foreach (AvailabilitySet availabilitySet in response)
                {
                    if (availabilitySet.Name == availabilitySet1Name)
                    {
                        ValidateResults(outputAvailabilitySet1, inputAvailabilitySet1, resourceGroup1Name, availabilitySet1Name, defaultFD, defaultUD);
                        validationCount++;
                    }
                    else if (availabilitySet.Name == availabilitySet2Name)
                    {
                        ValidateResults(outputAvailabilitySet2, inputAvailabilitySet2, resourceGroup2Name, availabilitySet2Name, defaultFD, defaultUD);
                        validationCount++;
                    }
                }

                Assert.True(validationCount == 2);
            }
            finally
            {
                resourcesClient.ResourceGroups.Delete(resourceGroup2Name);
            }
        }
    }
}

