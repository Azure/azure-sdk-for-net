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
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace SiteRecovery.Tests.ScenarioTests
{
    public class RecoveryPlanTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void RecoveryPlan_ValidateNames()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var rpName = "rpTest";
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();
                var containers =
                    client.ProtectionContainer.List(
                        fabrics.First().Name,
                        RequestHeaders)
                    .ProtectionContainers
                    .ToList();
                var vms =
                    client.ReplicationProtectedItem.List(
                        fabrics.First().Name,
                        containers.First().Name,
                        RequestHeaders)
                    .ReplicationProtectedItems
                    .ToList();

                var input = GetE2AInput(fabrics.First().Id, vms.First().Id);

                client.RecoveryPlan.Create(rpName, input, RequestHeaders);

                try
                {
                    client.RecoveryPlan.Create(rpName, input, RequestHeaders);
                }
                catch (CloudException ex)
                {
                    Assert.True(ex.Error.OriginalMessage.Contains("ArmResourceNameNotAvailable"));
                }
            }
        }

        public void RecoveryPlan_ValidateCRUD()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();
                var containers =
                    client.ProtectionContainer.List(
                        fabrics.First().Name,
                        RequestHeaders)
                    .ProtectionContainers
                    .ToList();
                var vms = 
                    client.ReplicationProtectedItem.List(
                        fabrics.First().Name,
                        containers.First().Name,
                        RequestHeaders)
                    .ReplicationProtectedItems
                    .ToList();

                // Create two recovery plans.
                var rpName1 = Guid.NewGuid().ToString();
                var rpName2 = Guid.NewGuid().ToString();
                var input1 = GetCreateInput1(fabrics.First().Id, vms.First().Id);
                var input2 = GetCreateInput2(fabrics.First().Id, vms.First().Id);

                client.RecoveryPlan.Create(rpName1, input1, RequestHeaders);
                client.RecoveryPlan.Create(rpName2, input2, RequestHeaders);

                // Ensure both the recovery plans are present in enumerate as well as get.
                var rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                var rp1 = client.RecoveryPlan.Get(rpName1, RequestHeaders).RecoveryPlan;
                var rp2 = client.RecoveryPlan.Get(rpName2, RequestHeaders).RecoveryPlan;

                Assert.True(rps.Find(x => x.Name == rpName1) != null);
                Assert.True(rps.Find(x => x.Name == rpName2) != null);

                ValidateCreateInput1(rp1, fabrics.First().Id, vms.First().Id);
                ValidateCreateInput2(rp2, fabrics.First().Id, vms.First().Id);

                // Update the recovery plan with new content.
                client.RecoveryPlan.Update(
                    rpName1,
                    new UpdateRecoveryPlanInput()
                    {
                        Properties = new UpdateRecoveryPlanInputProperties()
                        {
                            Groups = GetCreateInput2(fabrics.First().Id, vms.First().Id).Properties.Groups
                        }
                    },
                    RequestHeaders);

                rp1 = client.RecoveryPlan.Get(rpName1, RequestHeaders).RecoveryPlan;
                ValidateCreateInput2(rp1, fabrics.First().Id, vms.First().Id);

                // Delete the recovery plans and ensure they are no longer present in enumerate.
                client.RecoveryPlan.Delete(rpName1, RequestHeaders);

                rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                Assert.True(rps.Find(x => x.Name == rpName1) == null);

                client.RecoveryPlan.Delete(rpName2, RequestHeaders);

                rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                Assert.True(rps.Find(x => x.Name == rpName2) == null);
            }
        }

        public void RecoveryPlan_ValidateE2A()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();
                var containers =
                    client.ProtectionContainer.List(
                        fabrics.First().Name,
                        RequestHeaders)
                    .ProtectionContainers
                    .ToList();
                var vms = 
                    client.ReplicationProtectedItem.List(
                        fabrics.First().Name,
                        containers.First().Name,
                        RequestHeaders)
                    .ReplicationProtectedItems
                    .ToList();

                // Create one recovery plan.
                var rpName = "Test-" + Guid.NewGuid().ToString();
                var input = GetE2AInput(fabrics.First().Id, vms.First().Id);
                client.RecoveryPlan.Create(rpName, input, RequestHeaders);

                // Test failover.
                var tfoInput = new RecoveryPlanTestFailoverInput()
                {
                    Properties = new RecoveryPlanTestFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery",
                        NetworkType = "NoNetworkAttachAsInput",
                        ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                        {
                            new RecoveryPlanHyperVReplicaAzureFailoverInput()
                            {
                                VaultLocation = "Southeast Asia"
                            }
                        }
                    }
                };
                client.RecoveryPlan.TestFailover(rpName, tfoInput, RequestHeaders);

                // Planned failover.
                var pfoInput = new RecoveryPlanPlannedFailoverInput()
                {
                    Properties = new RecoveryPlanPlannedFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery",
                        ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                        {
                            new RecoveryPlanHyperVReplicaAzureFailoverInput()
                            {
                                VaultLocation = "Southeast Asia"
                            }
                        }
                    }
                };
                client.RecoveryPlan.PlannedFailover(rpName, pfoInput, RequestHeaders);

                // Commit failover.
                client.RecoveryPlan.CommitFailover(rpName, RequestHeaders);

                // Planned failback.
                var fbInput = new RecoveryPlanPlannedFailoverInput()
                {
                    Properties = new RecoveryPlanPlannedFailoverInputProperties()
                    {
                        FailoverDirection = "RecoveryToPrimary",
                        ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                        {
                            new RecoveryPlanHyperVReplicaAzureFailbackInput()
                            {
                                DataSyncOption = "ForSyncronization",
                                RecoveryVmCreationOption = "NoAction"
                            }
                        }
                    }
                };
                client.RecoveryPlan.PlannedFailover(rpName, fbInput, RequestHeaders);

                // Commit failover.
                client.RecoveryPlan.CommitFailover(rpName, RequestHeaders);

                // Reverse replicate.
                client.RecoveryPlan.Reprotect(rpName, RequestHeaders);

                // Unplanned failover.
                var ufoInput = new RecoveryPlanUnplannedFailoverInput()
                {
                    Properties = new RecoveryPlanUnplannedFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery",
                        SourceSiteOperations = "NotRequired",
                        ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                        {
                            new RecoveryPlanHyperVReplicaAzureFailoverInput()
                            {
                                VaultLocation = "Southeast Asia"
                            }
                        }
                    }
                };
                client.RecoveryPlan.UnplannedFailover(rpName, ufoInput, RequestHeaders);
            }
        }

        public void RecoveryPlan_ValidateE2E()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();
                var containers =
                    client.ProtectionContainer.List(
                        fabrics.First().Name,
                        RequestHeaders)
                    .ProtectionContainers
                    .ToList();
                var vms = 
                    client.ReplicationProtectedItem.List(
                        fabrics.First().Name,
                        containers.First().Name,
                        RequestHeaders)
                    .ReplicationProtectedItems
                    .ToList();

                // Create one recovery plan.
                var rpName = "Test-" + Guid.NewGuid().ToString();
                var input = GetE2EInput(fabrics.First().Id, vms.First().Id);
                client.RecoveryPlan.Create(rpName, input, RequestHeaders);

                // Test failover.
                var tfoInput = new RecoveryPlanTestFailoverInput()
                {
                    Properties = new RecoveryPlanTestFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery",
                        NetworkType = "NoNetworkAttachAsInput"
                    }
                };
                client.RecoveryPlan.TestFailover(rpName, tfoInput, RequestHeaders);

                // Planned failover.
                var pfoInput = new RecoveryPlanPlannedFailoverInput()
                {
                    Properties = new RecoveryPlanPlannedFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery"
                    }
                };
                client.RecoveryPlan.PlannedFailover(rpName, pfoInput, RequestHeaders);

                // Commit failover.
                client.RecoveryPlan.CommitFailover(rpName, RequestHeaders);

                // Reverse replicate.
                client.RecoveryPlan.Reprotect(rpName, RequestHeaders);

                // Unplanned failover.
                var ufoInput = new RecoveryPlanUnplannedFailoverInput()
                {
                    Properties = new RecoveryPlanUnplannedFailoverInputProperties()
                    {
                        FailoverDirection = "RecoveryToPrimary",
                        SourceSiteOperations = "NotRequired"
                    }
                };
                client.RecoveryPlan.UnplannedFailover(rpName, ufoInput, RequestHeaders);

                // Reverse replicate.
                client.RecoveryPlan.Reprotect(rpName, RequestHeaders);
            }
        }

        [Fact]
        public void RecoveryPlan_ValidateGetProtectedItemsInRecoveryPlan()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();
                var containers =
                    client.ProtectionContainer.List(
                        fabrics.First().Name,
                        RequestHeaders)
                    .ProtectionContainers
                    .ToList();
                var vms = 
                    client.ReplicationProtectedItem.List(
                        fabrics.First().Name,
                        containers.First().Name,
                        RequestHeaders)
                    .ReplicationProtectedItems
                    .ToList();

                // Create recovery plans.
                var rpName1 = "Test-1";
                var input1 = GetE2AInput(fabrics.First().Id, vms.First().Id);
                client.RecoveryPlan.Create(rpName1, input1, RequestHeaders);

                var rpName2 = "Test-2";
                var input2 = GetE2AInput(fabrics.First().Id, vms.Last().Id);
                client.RecoveryPlan.Create(rpName2, input2, RequestHeaders);

                // Validate that the correct VMs are returned.
                var vms1 = client.ReplicationProtectedItem.ListAll(
                    null,
                    new ProtectedItemsQueryParameter()
                    {
                        RecoveryPlanName = rpName1
                    },
                    RequestHeaders);
                Assert.True(vms1.ReplicationProtectedItems.Count == 1);
                Assert.True(vms1.ReplicationProtectedItems[0].Id == vms.First().Id);

                var vms2 = client.ReplicationProtectedItem.ListAll(
                    null,
                    new ProtectedItemsQueryParameter()
                    {
                        RecoveryPlanName = rpName2
                    },
                    RequestHeaders);
                Assert.True(vms2.ReplicationProtectedItems.Count == 1);
                Assert.True(vms2.ReplicationProtectedItems[0].Id == vms.Last().Id);
            }
        }

        private static CreateRecoveryPlanInput GetE2AInput(string fabricId, string vmId)
        {
            CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
            input.Properties = new CreateRecoveryPlanInputProperties();
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = "microsoft azure";
            input.Properties.FailoverDeploymentModel = "Classic";
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupType = "Boot",
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>()
                        {
                            new RecoveryPlanProtectedItem()
                            {
                                Id = vmId
                            }
                        }
            });

            return input;
        }

        private static CreateRecoveryPlanInput GetE2EInput(string fabricId, string vmId)
        {
            CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
            input.Properties = new CreateRecoveryPlanInputProperties();
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = fabricId;
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupType = "Boot",
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>()
                        {
                            new RecoveryPlanProtectedItem()
                            {
                                Id = vmId
                            }
                        }
            });

            return input;
        }

        private static CreateRecoveryPlanInput GetCreateInput1(string fabricId, string vmId)
        {
            CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
            input.Properties = new CreateRecoveryPlanInputProperties();
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = fabricId;
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupType = "Boot",
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>()
                        {
                            new RecoveryPlanProtectedItem()
                            {
                                Id = vmId
                            }
                        },
                StartGroupActions = new List<RecoveryPlanAction>()
                        {
                            new RecoveryPlanAction()
                            {
                                ActionName = "S1",
                                FailoverTypes = new List<string>() { "PlannedFailover" },
                                FailoverDirections = new List<string>() { "PrimaryToRecovery" },
                                CustomDetails = new RecoveryPlanScriptActionDetails()
                                {
                                    FabricLocation = "Recovery",
                                    Path = "path1",
                                    Timeout = null
                                }
                            }
                        },
                EndGroupActions = new List<RecoveryPlanAction>()
                        {
                            new RecoveryPlanAction()
                            {
                                ActionName = "M1",
                                FailoverTypes = new List<string>() { "UnplannedFailover" },
                                FailoverDirections = new List<string>() { "RecoveryToPrimary" },
                                CustomDetails = new RecoveryPlanManualActionDetails()
                                {
                                    Description = "desc1"
                                }
                            }
                        }
            });

            return input;
        }

        private static CreateRecoveryPlanInput GetCreateInput2(string fabricId, string vmId)
        {
            CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
            input.Properties = new CreateRecoveryPlanInputProperties();
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = fabricId;
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupType = "Shutdown",
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>()
                {
                    new RecoveryPlanProtectedItem()
                    {
                        Id = vmId
                    }
                },
                StartGroupActions = new List<RecoveryPlanAction>()
                {
                    new RecoveryPlanAction()
                    {
                        ActionName = "S2",
                        FailoverTypes = new List<string>() { "PlannedFailover" },
                        FailoverDirections = new List<string>() { "PrimaryToRecovery" },
                        CustomDetails = new RecoveryPlanScriptActionDetails()
                        {
                            FabricLocation = "Primary",
                            Path = "path2",
                            Timeout = null
                        }
                    },
                    new RecoveryPlanAction()
                    {
                        ActionName = "M2",
                        FailoverTypes = new List<string>() { "UnplannedFailover" },
                        FailoverDirections = new List<string>() { "RecoveryToPrimary" },
                        CustomDetails = new RecoveryPlanManualActionDetails()
                        {
                            Description = "desc2"
                        }
                    }
                },
                EndGroupActions = new List<RecoveryPlanAction>()
                {
                }
            });

            return input;
        }

        private static void ValidateCreateInput1(
            RecoveryPlan rp,
            string fabricId,
            string vmId)
        {
            Assert.True(rp.Properties.PrimaryFabricId == fabricId);
            Assert.True(rp.Properties.RecoveryFabricId == fabricId);

            Assert.True(rp.Properties.Groups.Count == 3);
            Assert.True(rp.Properties.Groups[0].GroupType == "Shutdown");
            Assert.True(rp.Properties.Groups[0].ReplicationProtectedItems.Count == 0);
            Assert.True(rp.Properties.Groups[1].GroupType == "Failover");
            Assert.True(rp.Properties.Groups[1].ReplicationProtectedItems.Count == 0);

            Assert.True(rp.Properties.Groups[2].GroupType == "Boot");
            Assert.True(rp.Properties.Groups[2].ReplicationProtectedItems.Count == 1);
            Assert.True(rp.Properties.Groups[2].ReplicationProtectedItems[0].Id == vmId);

            Assert.True(rp.Properties.Groups[2].StartGroupActions.Count == 1);
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].ActionName == "S1");
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].FailoverTypes.Count == 1);
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].FailoverTypes[0] == "PlannedFailover");
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].FailoverDirections.Count == 1);
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].FailoverDirections[0] == "PrimaryToRecovery");
            Assert.True(rp.Properties.Groups[2].StartGroupActions[0].CustomDetails.InstanceType == "ScriptActionDetails");

            Assert.True(rp.Properties.Groups[2].EndGroupActions.Count == 1);
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].ActionName == "M1");
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].FailoverTypes.Count == 1);
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].FailoverTypes[0] == "UnplannedFailover");
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].FailoverDirections.Count == 1);
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].FailoverDirections[0] == "RecoveryToPrimary");
            Assert.True(rp.Properties.Groups[2].EndGroupActions[0].CustomDetails.InstanceType == "ManualActionDetails");

            RecoveryPlanScriptActionDetails scriptAction =
                rp.Properties.Groups[2].StartGroupActions[0].CustomDetails as RecoveryPlanScriptActionDetails;
            Assert.True(scriptAction.Path == "path1");
            Assert.True(scriptAction.FabricLocation == "Recovery");

            RecoveryPlanManualActionDetails manualAction =
                rp.Properties.Groups[2].EndGroupActions[0].CustomDetails as RecoveryPlanManualActionDetails;
            Assert.True(manualAction.Description == "desc1");
        }

        private static void ValidateCreateInput2(
            RecoveryPlan rp,
            string fabricId,
            string vmId)
        {
            Assert.True(rp.Properties.PrimaryFabricId == fabricId);
            Assert.True(rp.Properties.RecoveryFabricId == fabricId);

            Assert.True(rp.Properties.Groups.Count == 2);
            Assert.True(rp.Properties.Groups[0].GroupType == "Shutdown");
            Assert.True(rp.Properties.Groups[0].ReplicationProtectedItems.Count == 0);

            Assert.True(rp.Properties.Groups[1].GroupType == "Failover");
            Assert.True(rp.Properties.Groups[1].ReplicationProtectedItems.Count == 0);

            Assert.True(rp.Properties.Groups[0].StartGroupActions.Count == 2);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].ActionName == "S2");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverTypes.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverTypes[0] == "PlannedFailover");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverDirections.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverDirections[0] == "PrimaryToRecovery");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].CustomDetails.InstanceType == "ScriptActionDetails");

            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].ActionName == "M2");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverTypes.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverTypes[0] == "UnplannedFailover");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverDirections.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverDirections[0] == "RecoveryToPrimary");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].CustomDetails.InstanceType == "ManualActionDetails");

            RecoveryPlanScriptActionDetails scriptAction =
                rp.Properties.Groups[0].StartGroupActions[0].CustomDetails as RecoveryPlanScriptActionDetails;
            Assert.True(scriptAction.Path == "path2");
            Assert.True(scriptAction.FabricLocation == "Primary");

            RecoveryPlanManualActionDetails manualAction =
                rp.Properties.Groups[0].StartGroupActions[1].CustomDetails as RecoveryPlanManualActionDetails;
            Assert.True(manualAction.Description == "desc2");
        }
    }
}
