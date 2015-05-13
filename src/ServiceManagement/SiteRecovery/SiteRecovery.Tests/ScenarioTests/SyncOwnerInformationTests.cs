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
    public class SyncOwnerInformationTests : SiteRecoveryTestsBase
    {
        public void SyncOwnerInformationTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);
                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.Protected == true)
                        {
                            response = client.ProtectionEntity.SyncOwnerInformation(pe.ProtectionContainerId, pe.ID, requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing Sync Owner Information operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
