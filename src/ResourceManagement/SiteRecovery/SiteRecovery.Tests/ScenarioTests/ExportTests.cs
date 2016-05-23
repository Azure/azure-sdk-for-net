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
        [Fact]
        public void ExportJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                JobQueryParameter jqp = new JobQueryParameter();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var exportJobResponse = (JobOperationResponse)client.Jobs.Export(jqp, RequestHeaders);

                Assert.True(exportJobResponse != null, "Export Jobs did not return Job Object");
                Assert.False(string.IsNullOrEmpty(exportJobResponse.Job.Name), "Job Id Absent");

                stopWatch.Stop();

                Assert.Equal<string>(exportJobResponse.Job.Properties.State, "Succeeded");
                Assert.Equal(HttpStatusCode.OK, exportJobResponse.StatusCode);
                Assert.True(exportJobResponse.Job.Properties.CustomDetails.InstanceType.Equals(
                    "ExportJobDetails"));
                Assert.False(string.IsNullOrEmpty(
                    ((ExportJobDetails)exportJobResponse.Job.Properties.CustomDetails).BlobUri));
                Assert.False(string.IsNullOrEmpty(
                    ((ExportJobDetails)exportJobResponse.Job.Properties.CustomDetails).SasToken));
            }
        }
    }
}
