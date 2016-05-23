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
using System.Net;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class SourceControlsScenarioTests : TestBase
    {
        private static readonly SourceControl GitHubSourceControl = new SourceControl()
        {
            Location = "global",
            SourceControlName = "GitHub",
            Token = "myToken",
            TokenSecret = "myTokenSecret"
        };

        private static readonly SourceControl BitbucketSourceControl = new SourceControl()
        {
            SourceControlName = "Bitbucket"
        };

        [Fact]
        public void TestUpdateSourceControlUpdates()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);

                webSitesClient.Provider.UpdateSourceControl(GitHubSourceControl.SourceControlName, GitHubSourceControl);

                var sourceControlGetResponse = webSitesClient.Provider.GetSourceControl("GitHub");

                AssertSourceControl(GitHubSourceControl, sourceControlGetResponse);

                var sourceControlListResponse = webSitesClient.Provider.GetSourceControls();

                Assert.True(sourceControlListResponse.Value.Count >= 4, "Invalid source controls count at " + sourceControlListResponse.Value.Count);
                var github = sourceControlListResponse.Value.FirstOrDefault(s => s.Name == "GitHub");
                AssertSourceControl(GitHubSourceControl, github);

                var bitbucket = sourceControlListResponse.Value.FirstOrDefault(s => s.Name == "Bitbucket");
                AssertSourceControl(BitbucketSourceControl, bitbucket);
            }
        }

        private static void AssertSourceControl(SourceControl expectedSourceControl, SourceControl actualSourceControl)
        {
            Assert.Equal(expectedSourceControl.SourceControlName, actualSourceControl.SourceControlName);
            Assert.Equal(expectedSourceControl.Token, actualSourceControl.Token);
            Assert.Equal(expectedSourceControl.TokenSecret, actualSourceControl.TokenSecret);
        }
    }
}
