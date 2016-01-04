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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace SiteRecovery.Tests
{
    public class ExportTests : SiteRecoveryTestsBase
    {
        public void ExportJobTest()
        {
            int timeToWaitInMins = 2;
            int waitBeforeRetryInSec = 1;
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                DateTime from = DateTime.Now.ToUniversalTime() - (new TimeSpan(7, 0, 0, 0));
                DateTime to = DateTime.Now.ToUniversalTime();

                JobQueryParameter jqp = new JobQueryParameter();
                jqp.StartTime = from.ToBinary().ToString();
                jqp.EndTime = to.ToBinary().ToString();
                jqp.AffectedObjectTypes = new List<string>();
                jqp.AffectedObjectTypes.Add("Any");
                jqp.JobStatus = new List<string>();
                jqp.JobStatus.Add("Completed");

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var exportResponse = client.Jobs.Export(jqp, RequestHeaders);

                Assert.True(exportResponse != null, "Export Jobs did not return Job Object");
                Assert.False(string.IsNullOrEmpty(exportResponse.Job.Name), "Job Id Absent");

                JobResponse getJobResponse = null;
                while (stopWatch.Elapsed.Minutes < timeToWaitInMins)
                {
                    getJobResponse = client.Jobs.Get(exportResponse.Job.Name, RequestHeaders);
                    Assert.True(getJobResponse != null, "Get call on export job returned null");
                    if (getJobResponse.Job.Properties.State.Equals("Succeeded"))
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(waitBeforeRetryInSec * 1000);
                }
                stopWatch.Stop();

                Assert.Equal<string>(getJobResponse.Job.Properties.State, "Succeeded");
                Assert.Equal(HttpStatusCode.OK, getJobResponse.StatusCode);
                Assert.True(getJobResponse.Job.Properties.CustomDetails.InstanceType.Equals(
                    "ExportJobDetails"));
                Assert.False(string.IsNullOrEmpty(
                    ((ExportJobDetails)getJobResponse.Job.Properties.CustomDetails).BlobUri));
                Assert.False(string.IsNullOrEmpty(
                    ((ExportJobDetails)getJobResponse.Job.Properties.CustomDetails).SasToken));
            }
        }
    }
}
