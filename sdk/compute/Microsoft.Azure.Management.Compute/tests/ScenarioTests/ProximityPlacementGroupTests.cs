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
    public class ProximityPlacementGroupTests : VMTestBase
    {
        ResourceGroup m_resourceGroup1;

        string m_baseResourceGroupName;
        string m_resourceGroup1Name;

        [Fact]
        [Trait("Name", "TestProximityPlacementGroupsOperations")]
        public void TestProximityPlacementGroupsOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                try
                {
                    EnsureClientsInitialized(context);
                    Initialize(context);

                    //Verify proximityPlacementGroups operation
                    VerifyPutPatchGetAndDeleteWithDefaultValues_Success();

                    //VerifyPutPatchGetAndDeleteWithNonDefaultValues_Success(); comment due to Ultra PPG no longer supported from backend

                    VerifyPutPatchGetAndDeleteWithInvalidValues_Failure();

                    // Make sure proximityPlacementGroup across resource groups are listed successfully and 
                    // proximityPlacementGroups in a resource groups are listed successfully
                    VerifyListProximityPlacementGroups();

                    VerifyProximityPlacementGroupColocationStatusView();
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(m_resourceGroup1Name);
                }
            }
        }

        private void Initialize(MockContext context)
        {
            m_baseResourceGroupName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            m_resourceGroup1Name = m_baseResourceGroupName + "_1";

            m_resourceGroup1 = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                m_resourceGroup1Name,
                new ResourceGroup
                {
                    Location = m_location,
                    Tags = new Dictionary<string, string>() { { m_resourceGroup1Name, DateTime.UtcNow.ToString("u") } }
                });
        }

        private void VerifyPutPatchGetAndDeleteWithDefaultValues_Success()
        {
            var proximityPlacementGroupName = ComputeManagementTestUtilities.GenerateName("testppg");
            var tags = new Dictionary<string, string>()
            {
                { "RG", "rg"},
                { "testTag", "1"}
            };

            var inputProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = tags
            };

            var expectedProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = tags,
                ProximityPlacementGroupType = ProximityPlacementGroupType.Standard
            };

            VerifyPutPatchGetAndDeleteOperations_Scenarios(inputProximityPlacementGroup, expectedProximityPlacementGroup);
        }

        private void VerifyPutPatchGetAndDeleteWithNonDefaultValues_Success()
        {
            var tags = new Dictionary<string, string>()
            {
                { "RG", "rg"},
                { "testTag", "1"}
            };

            var inputProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = tags,
                ProximityPlacementGroupType = ProximityPlacementGroupType.Ultra
            };

            var expectedProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = tags,
                ProximityPlacementGroupType = ProximityPlacementGroupType.Ultra
            };

            VerifyPutPatchGetAndDeleteOperations_Scenarios(inputProximityPlacementGroup, expectedProximityPlacementGroup);
        }

        private void VerifyPutPatchGetAndDeleteOperations_Scenarios(ProximityPlacementGroup inputProximityPlacementGroup,
            ProximityPlacementGroup expectedProximityPlacementGroup)
        {
            var proximityPlacementGroupName = ComputeManagementTestUtilities.GenerateName("testppg");

            // Create and expect success.
            ProximityPlacementGroup outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(m_resourceGroup1Name, proximityPlacementGroupName, inputProximityPlacementGroup);

            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, proximityPlacementGroupName);

            // Update and expect success.
            inputProximityPlacementGroup.Tags.Add("UpdateTag1", "updateValue1");
            outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(m_resourceGroup1Name, proximityPlacementGroupName, inputProximityPlacementGroup);
            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, proximityPlacementGroupName);

            // Get and expect success.
            outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(m_resourceGroup1Name, proximityPlacementGroupName);
            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, proximityPlacementGroupName);

            // Put and expect failure
            try
            {
                //Updating ProximityPlacementGroupType in inputProximityPlacementGroup for a Update call.
                if (expectedProximityPlacementGroup.ProximityPlacementGroupType == ProximityPlacementGroupType.Standard)
                {
                    inputProximityPlacementGroup.ProximityPlacementGroupType = ProximityPlacementGroupType.Ultra;
                }
                else
                {
                    inputProximityPlacementGroup.ProximityPlacementGroupType = ProximityPlacementGroupType.Standard;
                }

                outProximityPlacementGroup = null;
                outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(m_resourceGroup1Name, proximityPlacementGroupName, inputProximityPlacementGroup);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Conflict)
                {
                    Assert.Equal("Changing property 'proximityPlacementGroup.properties.proximityPlacementGroupType' is not allowed.", ex.Message, StringComparer.OrdinalIgnoreCase);
                }
                else if (ex.Response.StatusCode == HttpStatusCode.BadRequest)
                {
                    Assert.Equal("The value of parameter proximityPlacementGroup.properties.proximityPlacementGroupType is invalid.", ex.Message, StringComparer.OrdinalIgnoreCase);
                }
                else
                {
                    Console.WriteLine($"Expecting HttpStatusCode { HttpStatusCode.Conflict} or { HttpStatusCode.BadRequest}, while actual HttpStatusCode is { ex.Response.StatusCode}.");
                    throw; 
                }
            }
            Assert.True(outProximityPlacementGroup == null, "ProximityPlacementGroup in response should be null.");

            //Patch and expect success
            ProximityPlacementGroupUpdate proximityPlacementGroupUpdate = new ProximityPlacementGroupUpdate()
            {
                Tags = inputProximityPlacementGroup.Tags
            };
            //Note: Same Tags object is referred in proximityPlacementGroupUpdate and expectedProximityPlacementGroup, 
            //hence this will also update tags in expectedProximityPlacementGroup.
            proximityPlacementGroupUpdate.Tags.Add("UpdateTag2", "updateValue2");
            outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Update(m_resourceGroup1Name, proximityPlacementGroupName, proximityPlacementGroupUpdate.Tags);
            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, proximityPlacementGroupName);

            // Clean up
            m_CrpClient.ProximityPlacementGroups.Delete(m_resourceGroup1Name, proximityPlacementGroupName);
        }

        private void VerifyPutPatchGetAndDeleteWithInvalidValues_Failure()
        {
            var ProximityPlacementGroupName = ComputeManagementTestUtilities.GenerateName("testppg");
            var inputProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = "",
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
            };
            // Put and expect failure
            ProximityPlacementGroup expectedProximityPlacementGroup = null;

            void CreateAndExpectFailure()
            {
                try
                {
                    // Create and expect success.
                    expectedProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(
                        m_resourceGroup1Name, ProximityPlacementGroupName, inputProximityPlacementGroup);
                }
                catch (CloudException ex)
                {
                    Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest, $"Expecting HttpStatusCode {HttpStatusCode.BadRequest}, while actual HttpStatusCode is {ex.Response.StatusCode}.");
                }
                Assert.True(expectedProximityPlacementGroup == null);
            }

            //Verify failure when location is invalid
            CreateAndExpectFailure();

            //Verify failure when ProximityPlacementGroupType is invalid
            inputProximityPlacementGroup.Location = m_location;
            inputProximityPlacementGroup.ProximityPlacementGroupType = "Invalid";
            CreateAndExpectFailure();

            //Verify success when ProximityPlacementGroup is valid
            inputProximityPlacementGroup.ProximityPlacementGroupType = ProximityPlacementGroupType.Standard;
            expectedProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(
                m_resourceGroup1Name, ProximityPlacementGroupName, inputProximityPlacementGroup);

            ValidateProximityPlacementGroup(inputProximityPlacementGroup, expectedProximityPlacementGroup, ProximityPlacementGroupName);

            // Get and expect success.
            expectedProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(m_resourceGroup1Name, ProximityPlacementGroupName);
            ValidateProximityPlacementGroup(inputProximityPlacementGroup, expectedProximityPlacementGroup, ProximityPlacementGroupName);

            // Clean up
            m_CrpClient.ProximityPlacementGroups.Delete(m_resourceGroup1Name, ProximityPlacementGroupName);
        }

        private void VerifyProximityPlacementGroupColocationStatusView()
        {
            var ppgName = ComputeManagementTestUtilities.GenerateName("testppg");
            string asName = ComputeManagementTestUtilities.GenerateName("testas");
            string vmssName = ComputeManagementTestUtilities.GenerateName("testvmss");
            string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

            var inputProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                ProximityPlacementGroupType = ProximityPlacementGroupType.Standard
            };

            var expectedProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                ProximityPlacementGroupType = ProximityPlacementGroupType.Standard
            };

            // Create and expect success.
            ProximityPlacementGroup outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(m_resourceGroup1Name, ppgName, inputProximityPlacementGroup);

            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, ppgName);

            VirtualMachine inputVM;
            VirtualMachine outVM = CreateVM(m_resourceGroup1Name, asName, storageAccountName, imageRef, out inputVM, hasManagedDisks: true, hasDiffDisks: false, vmSize: "Standard_A1_v2",
                osDiskStorageAccountType: "Standard_LRS", dataDiskStorageAccountType: "Standard_LRS", writeAcceleratorEnabled: false, zones: null, ppgName: ppgName, diskEncryptionSetId: null);

            // Get and expect success.
            outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(m_resourceGroup1Name, ppgName, includeColocationStatus : "true");
            InstanceViewStatus expectedInstanceViewStatus = new InstanceViewStatus
            {
                Code = "ColocationStatus/Aligned",
                Level = StatusLevelTypes.Info,
                DisplayStatus = "Aligned",
                Message = "All resources in the proximity placement group are aligned."
            };

            expectedProximityPlacementGroup = new ProximityPlacementGroup(
                m_location,
                tags: new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                proximityPlacementGroupType: ProximityPlacementGroupType.Standard,
                virtualMachines: new List<SubResourceWithColocationStatus> { new SubResourceWithColocationStatus(outVM.Id) },
                availabilitySets: new List<SubResourceWithColocationStatus> { new SubResourceWithColocationStatus(outVM.AvailabilitySet.Id) });

            ValidateProximityPlacementGroup(expectedProximityPlacementGroup, outProximityPlacementGroup, ppgName);
            ValidateColocationStatus(expectedInstanceViewStatus, outProximityPlacementGroup.ColocationStatus);
        }

        // Make sure proximityPlacementGroup across resource groups are listed successfully and proximityPlacementGroups in a resource groups are listed successfully
        private void VerifyListProximityPlacementGroups()
        {
            string resourceGroup2Name = m_baseResourceGroupName + "_2";
            string baseInputProximityPlacementGroupName = ComputeManagementTestUtilities.GenerateName("testppg");
            string proximityPlacementGroup1Name = baseInputProximityPlacementGroupName + "_1";
            string proximityPlacementGroup2Name = baseInputProximityPlacementGroupName + "_2";

            try
            {
                ProximityPlacementGroup inputProximityPlacementGroup1 = new ProximityPlacementGroup
                {
                    Location = m_location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG1", "rg1"},
                        {"testTag", "1"},
                    },
                };
                ProximityPlacementGroup outputProximityPlacementGroup1 = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(
                    m_resourceGroup1Name,
                    proximityPlacementGroup1Name,
                    inputProximityPlacementGroup1);

                m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroup2Name,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { resourceGroup2Name, DateTime.UtcNow.ToString("u") } }
                    });

                ProximityPlacementGroup inputProximityPlacementGroup2 = new ProximityPlacementGroup
                {
                    Location = m_location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG2", "rg2"},
                        {"testTag", "2"},
                    },
                };
                ProximityPlacementGroup outputProximityPlacementGroup2 = m_CrpClient.ProximityPlacementGroups.CreateOrUpdate(
                    resourceGroup2Name,
                    proximityPlacementGroup2Name,
                    inputProximityPlacementGroup2);

                //verify proximityPlacementGroup across resource groups are listed successfully
                IPage<ProximityPlacementGroup> response = m_CrpClient.ProximityPlacementGroups.ListBySubscription();
                Assert.True(response.NextPageLink == null, "NextPageLink should be null in response.");

                int validationCount = 0;

                foreach (ProximityPlacementGroup proximityPlacementGroup in response)
                {
                    if (proximityPlacementGroup.Name == proximityPlacementGroup1Name)
                    {
                        //PPG is created using default value, updating the default value in input for validation of expected returned value.
                        inputProximityPlacementGroup1.ProximityPlacementGroupType = ProximityPlacementGroupType.Standard;
                        ValidateResults(outputProximityPlacementGroup1, inputProximityPlacementGroup1, m_resourceGroup1Name, proximityPlacementGroup1Name);
                        validationCount++;
                    }
                    else if (proximityPlacementGroup.Name == proximityPlacementGroup2Name)
                    {
                        //PPG is created using default value, updating the default value in input for validation of expected returned value.
                        inputProximityPlacementGroup2.ProximityPlacementGroupType = ProximityPlacementGroupType.Standard;
                        ValidateResults(outputProximityPlacementGroup2, inputProximityPlacementGroup2, resourceGroup2Name, proximityPlacementGroup2Name);
                        validationCount++;
                    }
                }

                Assert.True(validationCount == 2, "Not all ProximityPlacementGroups are returned in response.");

                //verify proximityPlacementGroups in a resource groups are listed successfully
                response = m_CrpClient.ProximityPlacementGroups.ListByResourceGroup(m_resourceGroup1Name);
                ValidateResults(outputProximityPlacementGroup1, inputProximityPlacementGroup1, m_resourceGroup1Name, proximityPlacementGroup1Name);

                response = m_CrpClient.ProximityPlacementGroups.ListByResourceGroup(resourceGroup2Name);
                ValidateResults(outputProximityPlacementGroup2, inputProximityPlacementGroup2, resourceGroup2Name, proximityPlacementGroup2Name);

            }
            finally
            {
                m_ResourcesClient.ResourceGroups.Delete(resourceGroup2Name);
                // Delete ProximityPlacementGroup
                m_CrpClient.ProximityPlacementGroups.Delete(m_resourceGroup1Name, proximityPlacementGroup1Name);
            }
        }

        private void ValidateResults(ProximityPlacementGroup outputProximityPlacementGroup, ProximityPlacementGroup inputProximityPlacementGroup,
            string resourceGroupName, string inputProximityPlacementGroupName)
        {
            string expectedProximityPlacementGroupId = Helpers.GetProximityPlacementGroupRef(m_subId, resourceGroupName, inputProximityPlacementGroupName);

            Assert.True(outputProximityPlacementGroup.Name == inputProximityPlacementGroupName, "ProximityPlacementGroup.Name mismatch between request and response.");
            Assert.True(outputProximityPlacementGroup.Location.ToLower() == this.m_location.ToLower()
                     || outputProximityPlacementGroup.Location.ToLower() == inputProximityPlacementGroup.Location.ToLower(),
                     "ProximityPlacementGroup.Location mismatch between request and response.");

            ValidateProximityPlacementGroup(inputProximityPlacementGroup, outputProximityPlacementGroup, inputProximityPlacementGroupName);

            // GET ProximityPlacementGroup
            var getResponse = m_CrpClient.ProximityPlacementGroups.Get(resourceGroupName, inputProximityPlacementGroupName);
            ValidateProximityPlacementGroup(inputProximityPlacementGroup, getResponse, inputProximityPlacementGroupName);
        }

        private void ValidateProximityPlacementGroup(ProximityPlacementGroup expectedProximityPlacementGroup, ProximityPlacementGroup outputProximityPlacementGroup,
            string expectedProximityPlacementGroupName)
        {

            Assert.True(outputProximityPlacementGroup != null, "ProximityPlacementGroup is null in response.");
            Assert.True(expectedProximityPlacementGroupName == outputProximityPlacementGroup.Name, "ProximityPlacementGroup.Name in response mismatch with expected value.");
            Assert.True(
                outputProximityPlacementGroup.Type == ApiConstants.ResourceProviderNamespace + "/" + ApiConstants.ProximityPlacementGroups,
                "ProximityPlacementGroup.Type in response mismatch with expected value.");

            Assert.True(
                expectedProximityPlacementGroup.ProximityPlacementGroupType == outputProximityPlacementGroup.ProximityPlacementGroupType,
                "ProximityPlacementGroup.ProximityPlacementGroupType in response mismatch with expected value.");

            void VerifySubResource(IList<Microsoft.Azure.Management.Compute.Models.SubResourceWithColocationStatus> inResource, 
                IList<Microsoft.Azure.Management.Compute.Models.SubResourceWithColocationStatus> outResource, string subResourceTypeName)
            {
                if (inResource == null)
                {
                    Assert.True(outResource == null || outResource.Count == 0, $"{subResourceTypeName} reference in response should be null/empty.");
                }
                else
                {
                    List<string> inResourceIds = inResource.Select(input => input.Id).ToList();
                    List<string> outResourceIds = outResource.Select(output => output.Id).ToList();
                    Assert.True(inResourceIds.Count == outResourceIds.Count, $"Number of {subResourceTypeName} reference in response do not match with expected value.");
                    Assert.True(0 == inResourceIds.Except(outResourceIds, StringComparer.OrdinalIgnoreCase).ToList().Count, $"Response has some unexpected {subResourceTypeName}.");
                }
            }

            VerifySubResource(expectedProximityPlacementGroup.AvailabilitySets, outputProximityPlacementGroup.AvailabilitySets, "AvailabilitySet");
            VerifySubResource(expectedProximityPlacementGroup.VirtualMachines, outputProximityPlacementGroup.VirtualMachines, "VirtualMachine");
            VerifySubResource(expectedProximityPlacementGroup.VirtualMachineScaleSets, outputProximityPlacementGroup.VirtualMachineScaleSets, "VirtualMachineScaleSet");

            Assert.True(expectedProximityPlacementGroup.Tags != null, "Expected ProximityPlacementGroup tags should not be null.");
            Assert.True(outputProximityPlacementGroup.Tags != null, "ProximityPlacementGroup tags in response should not be null.");
            Assert.True(expectedProximityPlacementGroup.Tags.Count == outputProximityPlacementGroup.Tags.Count, "Number of tags in response do not match with expected value.");

            foreach (var tag in expectedProximityPlacementGroup.Tags)
            {
                string key = tag.Key;
                Assert.True(expectedProximityPlacementGroup.Tags[key] == outputProximityPlacementGroup.Tags[key], "Unexpected ProximityPlacementGroup tag is found in response.");
            }
        }

        void ValidateColocationStatus(InstanceViewStatus expectedColocationStatus, InstanceViewStatus actualColocationStatus)
        {
            Assert.True(expectedColocationStatus.Code == actualColocationStatus.Code, "ColocationStatus code do not match with expected value.");
            Assert.True(expectedColocationStatus.Level == actualColocationStatus.Level, "ColocationStatus level do not match with expected value.");
            Assert.True(expectedColocationStatus.DisplayStatus == actualColocationStatus.DisplayStatus, "ColocationStatus display status do not match with expected value.");
            Assert.True(expectedColocationStatus.Message == actualColocationStatus.Message, "ColocationStatus message do not match with expected value.");
        }
    }
}


