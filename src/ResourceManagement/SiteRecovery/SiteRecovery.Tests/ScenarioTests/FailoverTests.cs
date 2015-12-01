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
    }
}
