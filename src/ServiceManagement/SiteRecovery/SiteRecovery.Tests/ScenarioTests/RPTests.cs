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

using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace SiteRecovery.Tests
{
    public class RPTests : SiteRecoveryTestsBase
    {
        public void GetRPTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                JobQueryParameter jqp = new JobQueryParameter();
                var responseRP = client.RecoveryPlan.List(RequestHeaders);
                var response = client.RecoveryPlan.Get(responseRP.RecoveryPlans[0].ID, RequestHeaders);

                Assert.NotNull(response.RecoveryPlan);
                Assert.NotNull(response.RecoveryPlan.ID);
                Assert.NotNull(response.RecoveryPlan.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_PFO_Failback_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpPlannedFailoverRequest request = new RpPlannedFailoverRequest();
                    request.FailoverDirection = "RecoveryToPrimary";
                    request.ReplicationProvider = "HyperVReplicaAzure";
                    AzureFailbackInput fbInput = new AzureFailbackInput();
                    fbInput.CreateRecoveryVmIfDoesntExist = true;
                    fbInput.SkipDataSync = true;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailbackInput>
                        (fbInput);
                    response = client.RecoveryPlan.RecoveryPlanPlannedFailover(
                        rp.ID,
                        request,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing planned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_PFO_E2A_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpPlannedFailoverRequest request = new RpPlannedFailoverRequest();
                    request.FailoverDirection = "PrimaryToRecovery";
                    request.ReplicationProvider = "HyperVReplicaAzure";
                    AzureFailoverInput foInput = new AzureFailoverInput();
                    foInput.VaultLocation = VaultLocation;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>
                        (foInput);
                    response = client.RecoveryPlan.RecoveryPlanPlannedFailover(
                        rp.ID,
                        request,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing unplanned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_UFO_E2A_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpUnplannedFailoverRequest request = new RpUnplannedFailoverRequest();
                    request.FailoverDirection = "PrimaryToRecovery";
                    request.ReplicationProvider = "HyperVReplicaAzure";
                    AzureFailoverInput foInput = new AzureFailoverInput();
                    foInput.VaultLocation = VaultLocation;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>
                        (foInput);
                    response = client.RecoveryPlan.RecoveryPlanUnplannedFailover(
                        rp.ID,
                        request,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing unplanned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_Commit_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    response = client.RecoveryPlan.Commit(
                        rp.ID,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing commit failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_Reprotect_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    response = client.RecoveryPlan.Reprotect(
                        rp.ID,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing commit failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RP_TFO_E2A_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpTestFailoverRequest request = new RpTestFailoverRequest();
                    request.NetworkID = "ID";
                    request.NetworkType = "Type";
                    request.FailoverDirection = "PrimaryToRecovery";
                    request.ReplicationProvider = "HyperVReplicaAzure";
                    AzureFailoverInput foInput = new AzureFailoverInput();
                    foInput.VaultLocation = VaultLocation;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>
                        (foInput);
                    response = client.RecoveryPlan.RecoveryPlanTestFailover(
                        rp.ID,
                        request,
                        requestHeaders);
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing unplanned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
