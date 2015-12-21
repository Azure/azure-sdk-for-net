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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;
using System;


namespace SiteRecovery.Tests
{
    public class FailoverTests : SiteRecoveryTestsBase
    {
        public void E2EFailover()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";

                var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);

                PlannedFailoverInputProperties pfoProp = new PlannedFailoverInputProperties()
                {
                    FailoverDirection = "PrimaryToRecovery",
                    //ProviderConfigurationSettings = new ProviderSpecificFailoverInput()
                };

                PlannedFailoverInput pfoInput = new PlannedFailoverInput()
                {
                    Properties = pfoProp
                };

                var failoverExecution = client.ReplicationProtectedItem.PlannedFailover(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, pfoInput, RequestHeaders);
            }
        }

	public void CommitFailover()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";

                var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);

                var commitResp = client.ReplicationProtectedItem.CommitFailover(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, RequestHeaders);
            }
        }

        public void RR()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";

                var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);

                var commitResp = client.ReplicationProtectedItem.Reprotect(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, new ReverseReplicationInput(), RequestHeaders);
            }
        }

        public void E2ETFO()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";

                var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);

                TestFailoverInputProperties tfoProp = new TestFailoverInputProperties()
                {
                    FailoverDirection = "RecoveryToPrimary",
                    ProviderSpecificDetails = new ProviderSpecificFailoverInput()
                };

                TestFailoverInput tfoInput = new TestFailoverInput()
                {
                    Properties = tfoProp
                };

                DateTime startTfoTime = DateTime.UtcNow;

                var tfoResp = client.ReplicationProtectedItem.TestFailover(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, tfoInput, RequestHeaders);

                Job tfoJob = MonitoringHelper.GetJobId(
                        MonitoringHelper.TestFailoverJobName,
                        startTfoTime,
                        client,
                        RequestHeaders);

                ResumeJobParamsProperties resJobProp = new ResumeJobParamsProperties()
                {
                    Comments = "ResumeTfo"
                };

                ResumeJobParams resumeJobParams = new ResumeJobParams()
                {
                    Properties = resJobProp
                };

                var resumeJob = client.Jobs.Resume(tfoJob.Name, resumeJobParams, RequestHeaders);
            }
        }

        public void E2EUFO()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";

                var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);

                UnplannedFailoverInputProperties ufoProp = new UnplannedFailoverInputProperties()
                {
                    FailoverDirection = "RecoveryToPrimary",
                    SourceSiteOperations = "NotRequired",
                    ProviderSpecificDetails = new ProviderSpecificFailoverInput()
                };

                UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
                {
                    Properties = ufoProp
                };

                var ufoResp = client.ReplicationProtectedItem.UnplannedFailover(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, ufoInput, RequestHeaders);
            }
        }

        public void ApplyRecoveryPoint()
        {
            using (UndoContext context = UndoContext.Current)
           {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var fabrics = client.Fabrics.List(RequestHeaders);

                Fabric selectedFabric = null;
                ProtectionContainer selectedContainer = null;

                foreach (var fabric in fabrics.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
                    {
                        selectedFabric = fabric;
                        break;
                    }
                }

                var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

                foreach (var container in containers.ProtectionContainers)
                {
                    if (container.Properties.ProtectedItemCount > 0
                        && container.Properties.Role.Equals("Primary"))
                    {
                        selectedContainer = container;
                        break;
                    }
                }

                string fabricId = selectedFabric.Name;
                string containerId = selectedContainer.Name;

                if (selectedContainer != null)
                {
                    var pgs = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);
                    var rps = client.RecoveryPoint.List(fabricId, containerId, pgs.ReplicationProtectedItems[0].Name, RequestHeaders);

                    ApplyRecoveryPointInputProperties applyRpProp = new ApplyRecoveryPointInputProperties()
                    {
                        RecoveryPointId = rps.RecoveryPoints[rps.RecoveryPoints.Count - 2].Id,
                        ProviderSpecificDetails = new HyperVReplicaAzureApplyRecoveryPointInput()
                        {
                            VaultLocation = "SoutheastAsia"
                        }
                    };

                    ApplyRecoveryPointInput applyRpInput = new ApplyRecoveryPointInput()
                    {
                        Properties = applyRpProp
                    };

                    var applyRpResp = client.ReplicationProtectedItem.ApplyRecoveryPoint(
                        fabricId,
                        containerId,
                        pgs.ReplicationProtectedItems[0].Name,
                        applyRpInput,
                        RequestHeaders);
                }
                else
                {
                    throw new System.Exception("Container not found.");
                }
            }
        }

        public void VMwareAzureV2UnplannedFailover()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var protectedItemsResponse = client.ReplicationProtectedItem.List(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    RequestHeaders);
                Assert.NotNull(protectedItemsResponse);
                Assert.NotEmpty(protectedItemsResponse.ReplicationProtectedItems);

                var protectedItem = protectedItemsResponse.ReplicationProtectedItems[0];
                Assert.NotNull(protectedItem.Properties.ProviderSpecificDetails);

                var vmWareAzureV2Details = protectedItem.Properties.ProviderSpecificDetails
                    as VMwareAzureV2ProviderSpecificSettings;
                Assert.NotNull(vmWareAzureV2Details);

                UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
                {
                    Properties = new UnplannedFailoverInputProperties()
                    {
                        FailoverDirection = "PrimaryToRecovery",
                        ProviderSpecificDetails = new VMWareAzureV2FailoverProviderInput 
                        { 
                            RecoveryPointId = "",
                            VaultLocation = "Southeast Asia"
                        },
                        SourceSiteOperations = ""
                    }
                };

                var failoverExecution = client.ReplicationProtectedItem.UnplannedFailover(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    protectedItem.Name, 
                    ufoInput, 
                    RequestHeaders);
            }
        }
    }
}
