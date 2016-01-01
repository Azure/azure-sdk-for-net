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

                var rpName = Guid.NewGuid().ToString();
                var fabrics = client.Fabrics.List(RequestHeaders).Fabrics.ToList();

                CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
                input.Properties = new CreateRecoveryPlanInputProperties();
                input.Properties.FailoverDeploymentModel = "None";
                input.Properties.PrimaryFabricId = fabrics.First().Id;
                input.Properties.RecoveryFabricId = fabrics.First().Id;

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

        [Fact]
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
                    .ProtectionContainers.ToList();
                var vms = new List<string>()
                { 
                    "replicationFabrics/" + fabrics.First().Name + 
                    "/replicationProtectionContainers/" + containers.First().Name +
                    "/replicationProtectedItems/e078b286-f168-45be-a729-d9021e1d28b2" 
                };
                ////client.ReplicationProtectedItem.List(
                ////    fabrics.First().Name,
                ////    containers.First().Name,
                ////    RequestHeaders)
                ////.ReplicationProtectedItems.ToList();

                // Create two recovery plans.
                var rpName1 = Guid.NewGuid().ToString();
                var rpName2 = Guid.NewGuid().ToString();
                var input1 = GetCreateInput1(fabrics.First().Id, vms.First());
                var input2 = GetCreateInput2(fabrics.First().Id, vms.First());

                client.RecoveryPlan.Create(rpName1, input1, RequestHeaders);
                client.RecoveryPlan.Create(rpName2, input2, RequestHeaders);

                // Ensure both the recovery plans are present in enumerate as well as get.
                var rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                var rp1 = client.RecoveryPlan.Get(rpName1, RequestHeaders).RecoveryPlan;
                var rp2 = client.RecoveryPlan.Get(rpName2, RequestHeaders).RecoveryPlan;

                Assert.True(rps.Find(x => x.Name == rpName1) != null);
                Assert.True(rps.Find(x => x.Name == rpName2) != null);

                ValidateCreateInput1(rp1, fabrics.First().Id, vms.First());
                ValidateCreateInput2(rp2, fabrics.First().Id, vms.First());

                // Update the recovery plan with new content.
                client.RecoveryPlan.Update(
                    rpName1,
                    new UpdateRecoveryPlanInput()
                    {
                        Properties = new UpdateRecoveryPlanInputProperties()
                        {
                            Groups = GetCreateInput2(fabrics.First().Id, vms.First()).Properties.Groups
                        }
                    },
                    RequestHeaders);

                rp1 = client.RecoveryPlan.Get(rpName1, RequestHeaders).RecoveryPlan;
                ValidateCreateInput2(rp1, fabrics.First().Id, vms.First());

                // Delete the recovery plans and ensure they are no longer present in enumerate.
                client.RecoveryPlan.Delete(rpName1, RequestHeaders);

                rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                Assert.True(rps.Find(x => x.Name == rpName1) == null);

                client.RecoveryPlan.Delete(rpName2, RequestHeaders);

                rps = client.RecoveryPlan.List(RequestHeaders).RecoveryPlans.ToList();
                Assert.True(rps.Find(x => x.Name == rpName2) == null);
            }
        }

        private static CreateRecoveryPlanInput GetCreateInput1(string fabricId, string vmId)
        {
            CreateRecoveryPlanInput input = new CreateRecoveryPlanInput();
            input.Properties = new CreateRecoveryPlanInputProperties();
            input.Properties.FailoverDeploymentModel = "None";
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = fabricId;
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupName = "G1",
                GroupType = "Boot",
                ReplicationProtectedItems = new List<string>()
                        {
                            vmId
                        },
                StartGroupActions = new List<RecoveryPlanAction>()
                        {
                            new RecoveryPlanAction()
                            {
                                ActionName = "S1",
                                FailoverTypesList = new List<string>() { "PlannedFailover" },
                                FailoverDirectionsList = new List<string>() { "PrimaryToRecovery" },
                                CustomDetails = new RecoveryPlanScriptActionDetails()
                                {
                                    InstanceType = "ScriptActionDetails",
                                    FabricLocation = "Recovery",
                                    ScriptPath = "path1",
                                    Timeout = null
                                }
                            }
                        },
                EndGroupActions = new List<RecoveryPlanAction>()
                        {
                            new RecoveryPlanAction()
                            {
                                ActionName = "M1",
                                FailoverTypesList = new List<string>() { "UnplannedFailover" },
                                FailoverDirectionsList = new List<string>() { "RecoveryToPrimary" },
                                CustomDetails = new RecoveryPlanManualActionDetails()
                                {
                                    InstanceType = "ManualActionDetails",
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
            input.Properties.FailoverDeploymentModel = "None";
            input.Properties.PrimaryFabricId = fabricId;
            input.Properties.RecoveryFabricId = fabricId;
            input.Properties.Groups = new List<RecoveryPlanGroup>();
            input.Properties.Groups.Add(new RecoveryPlanGroup()
            {
                GroupName = "G2",
                GroupType = "Shutdown",
                ReplicationProtectedItems = new List<string>()
                {
                },
                StartGroupActions = new List<RecoveryPlanAction>()
                        {
                            new RecoveryPlanAction()
                            {
                                ActionName = "S2",
                                FailoverTypesList = new List<string>() { "PlannedFailover" },
                                FailoverDirectionsList = new List<string>() { "PrimaryToRecovery" },
                                CustomDetails = new RecoveryPlanScriptActionDetails()
                                {
                                    InstanceType = "ScriptActionDetails",
                                    FabricLocation = "Primary",
                                    ScriptPath = "path2",
                                    Timeout = null
                                }
                            },
                            new RecoveryPlanAction()
                            {
                                ActionName = "M2",
                                FailoverTypesList = new List<string>() { "UnplannedFailover" },
                                FailoverDirectionsList = new List<string>() { "RecoveryToPrimary" },
                                CustomDetails = new RecoveryPlanManualActionDetails()
                                {
                                    InstanceType = "ManualActionDetails",
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
            Assert.True(rp.Properties.FailoverDeploymentModel == "None");
            Assert.True(rp.Properties.Groups.Last().GroupName == "G1");
            Assert.True(rp.Properties.Groups.Last().GroupType == "Boot");
            Assert.True(rp.Properties.Groups.Last().ReplicationProtectedItems.Count == 1);
            Assert.True(vmId.Contains(rp.Properties.Groups.Last().ReplicationProtectedItems[0]));

            Assert.True(rp.Properties.Groups.Last().StartGroupActions.Count == 1);
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].ActionName == "S1");
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].FailoverTypesList.Count == 1);
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].FailoverTypesList[0] == "PlannedFailover");
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].FailoverDirectionsList.Count == 1);
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].FailoverDirectionsList[0] == "PrimaryToRecovery");
            Assert.True(rp.Properties.Groups.Last().StartGroupActions[0].CustomDetails.InstanceType == "ScriptActionDetails");

            Assert.True(rp.Properties.Groups.Last().EndGroupActions.Count == 1);
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].ActionName == "M1");
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].FailoverTypesList.Count == 1);
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].FailoverTypesList[0] == "UnplannedFailover");
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].FailoverDirectionsList.Count == 1);
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].FailoverDirectionsList[0] == "RecoveryToPrimary");
            Assert.True(rp.Properties.Groups.Last().EndGroupActions[0].CustomDetails.InstanceType == "ManualActionDetails");
        }

        private static void ValidateCreateInput2(
            RecoveryPlan rp,
            string fabricId,
            string vmId)
        {
            Assert.True(rp.Properties.PrimaryFabricId == fabricId);
            Assert.True(rp.Properties.RecoveryFabricId == fabricId);
            Assert.True(rp.Properties.FailoverDeploymentModel == "None");

            Assert.True(rp.Properties.Groups[0].GroupType == "Shutdown");
            Assert.True(rp.Properties.Groups[0].ReplicationProtectedItems.Count == 0);

            Assert.True(rp.Properties.Groups[0].StartGroupActions.Count == 2);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].ActionName == "S2");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverTypesList.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverTypesList[0] == "PlannedFailover");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverDirectionsList.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].FailoverDirectionsList[0] == "PrimaryToRecovery");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[0].CustomDetails.InstanceType == "ScriptActionDetails");

            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].ActionName == "M2");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverTypesList.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverTypesList[0] == "UnplannedFailover");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverDirectionsList.Count == 1);
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].FailoverDirectionsList[0] == "RecoveryToPrimary");
            Assert.True(rp.Properties.Groups[0].StartGroupActions[1].CustomDetails.InstanceType == "ManualActionDetails");
        }
    }
}
