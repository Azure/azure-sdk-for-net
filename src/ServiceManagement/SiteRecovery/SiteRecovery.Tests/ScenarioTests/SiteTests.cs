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
    public class SiteTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void DeleteSiteTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                SiteResponse siteResponse = null;
                JobResponse jobResponse = null;
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var responseSites = client.Sites.List(RequestHeaders);
                foreach (var site in responseSites.Sites)
                {
                    siteResponse = client.Sites.Get(site.ID, RequestHeaders);
                    if (siteResponse.Site.Name == "TestSite123_HyperVSite")
                    {
                        jobResponse = client.Sites.Delete(siteResponse.Site.ID, RequestHeaders);
                        break;
                    }
                }

                Assert.NotNull(siteResponse.Site);
                Assert.NotNull(siteResponse.Site.ID);
                Assert.NotNull(siteResponse.Site.Name);
                Assert.Equal(HttpStatusCode.OK, siteResponse.StatusCode);

                Assert.NotNull(jobResponse.Job);
                Assert.NotNull(jobResponse.Job.ID);
                Assert.NotNull(jobResponse.Job.Name);
                Assert.Equal(HttpStatusCode.OK, jobResponse.StatusCode);

            }
        }

        [Fact]
        public void CreateSiteTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var responseSite = client.Sites.List(RequestHeaders);
                SiteCreationInput input = new SiteCreationInput();
                input.Name = "TestSite123_HyperVSite";
                input.FabricType = "HyperVSite";
                var response = client.Sites.Create(
                    input, 
                    RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.NotNull(response.Job.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
