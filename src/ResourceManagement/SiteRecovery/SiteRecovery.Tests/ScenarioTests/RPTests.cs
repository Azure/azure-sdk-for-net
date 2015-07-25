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
using System.Runtime.Serialization;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace SiteRecovery.Tests
{
    public class RPTests : SiteRecoveryTestsBase
    {
        /// <summary>
        /// This is the class which defines the Azure failover input.
        /// </summary>
        [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
        public class AzureFailoverInput
        {
            /// <summary>
            /// Gets or sets the Vault Location.
            /// </summary> 
            [DataMember]
            public string VaultLocation { get; set; }

            /// <summary>
            /// Gets or sets the Primary KEK certificate PFX in Base-64 encoded form.
            /// </summary>
            [DataMember]
            public string PrimaryKekCertificatePfx { get; set; }

            /// <summary>
            /// Gets or sets the Secondary (rolled over) KEK certificate PFX in Base-64 encoded form.
            /// </summary>
            [DataMember]
            public string SecondaryKekCertificatePfx { get; set; }
        }

        /// <summary>
        /// This is the class which defines the Azure failback input.
        /// </summary>
        [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
        public class AzureFailbackInput
        {
            /// <summary>
            /// Identifier to specify whether datasync should be skipped or not.
            /// </summary>
            [DataMember]
            public bool SkipDataSync { get; set; }

            /// <summary>
            /// Identifier to specify whether datasync should create VM on premise in case VM is not available there.
            /// This is applicable only in case of failback.
            /// </summary>
            [DataMember]
            public bool CreateRecoveryVmIfDoesntExist { get; set; }
        }

        [Fact]
        public void GetRPTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                JobQueryParameter jqp = new JobQueryParameter();
                var responseRP = client.RecoveryPlan.List(RequestHeaders);
                var response = client.RecoveryPlan.Get(responseRP.RecoveryPlans[0].Id, RequestHeaders);

                Assert.NotNull(response.RecoveryPlan);
                Assert.NotNull(response.RecoveryPlan.Id);
                Assert.NotNull(response.RecoveryPlan.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void RP_PFO_Failback_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                // JobResponse response = new JobResponse();
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
                    var response = client.RecoveryPlan.RecoveryPlanPlannedFailover(
                        rp.Id,
                        request,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }

        [Fact]
        public void RP_PFO_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                // JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpPlannedFailoverRequest request = new RpPlannedFailoverRequest();
                    request.FailoverDirection = "PrimaryToRecovery";
                    request.ReplicationProvider = "HyperVReplica";
                    request.ReplicationProviderSettings = null;
                    var response = client.RecoveryPlan.RecoveryPlanPlannedFailover(
                        rp.Id,
                        request,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }

        [Fact]
        public void RP_UFO_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                // JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpUnplannedFailoverRequest request = new RpUnplannedFailoverRequest();
                    request.FailoverDirection = "RecoveryToPrimary";
                    request.ReplicationProvider = "HyperVReplica";
                    request.ReplicationProviderSettings = null;

                    var response = client.RecoveryPlan.RecoveryPlanUnplannedFailover(
                        rp.Id,
                        request,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }

        [Fact]
        public void RP_Commit_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                // JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    var response = client.RecoveryPlan.Commit(
                        rp.Id,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }

        [Fact]
        public void RP_Reprotect_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                // JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    var response = client.RecoveryPlan.Reprotect(
                        rp.Id,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }

        [Fact]
        public void RP_TFO_Test()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responseRP = client.RecoveryPlan.List(RequestHeaders);

                //JobResponse response = new JobResponse();
                foreach (var rp in responseRP.RecoveryPlans)
                {
                    RpTestFailoverRequest request = new RpTestFailoverRequest();
                    request.NetworkID = "ID";
                    request.NetworkType = "Type";
                    request.FailoverDirection = "PrimaryToRecovery";
                    request.ReplicationProvider = "HyperVReplicaAzure";
                    request.ReplicationProviderSettings = null;
                    var response = client.RecoveryPlan.RecoveryPlanTestFailover(
                        rp.Id,
                        request,
                        requestHeaders);

                    Assert.Equal(response.Status, Microsoft.Azure.OperationStatus.Succeeded);
                }
            }
        }
    }
}
