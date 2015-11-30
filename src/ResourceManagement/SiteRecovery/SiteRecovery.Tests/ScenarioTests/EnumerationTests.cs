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

using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery.Models;


namespace SiteRecovery.Tests
{
    public class EnumerationTests : SiteRecoveryTestsBase
    {
        private const string RecoveryservicePrefix = "RecoveryServices";

        [Fact]
        public void EnumerateServersTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Servers.List(RequestHeaders);

                Assert.True(response.Servers.Count > 0, "Servers count can't be less than 1");
                Assert.True(
                    response.Servers.All(
                    server => !string.IsNullOrEmpty(server.Name)),
                    "Server name can't be null or empty");
                Assert.True(
                    response.Servers.All(
                    server => !string.IsNullOrEmpty(server.Id)),
                    "Server Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateProtectedContainerTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.ProtectionContainer.List(RequestHeaders);

                Assert.True(
                    response.ProtectionContainers.Count > 0,
                    "Protection containers count can't be less than 1");
                Assert.True(
                    response.ProtectionContainers.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)),
                    "Protection Container name can't be null or empty");
                Assert.True(
                    response.ProtectionContainers.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Id)),
                    "Protection Container Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateJobsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                JobQueryParameter jobQueryParameter = new JobQueryParameter();
                var response = client.Jobs.List(jobQueryParameter, RequestHeaders);

                Assert.True(response.Jobs.Count > 0, "Jobs count can't be less than 1");
                Assert.True(response.Jobs.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)),
                    "Job name can't be null or empty");
                Assert.True(response.Jobs.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Id)),
                    "Job Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
