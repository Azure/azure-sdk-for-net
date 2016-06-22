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
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class SourceControlsScenarioTests : TestBase
    {
        static SourceControlsScenarioTests()
        {
        }

        private static readonly SourceControl GitHubSourceControl = new SourceControl()
        {
            Name = "GitHub",
            Properties = new SourceControlProperties()
            {
                Token = "myToken",
                TokenSecret = "myTokenSecret"
            }
        };

        private static readonly SourceControl BitbucketSourceControl = new SourceControl()
        {
            Name = "Bitbucket",
            Properties = new SourceControlProperties()
        };

        [Fact]
        public void TestUpdateSourceControlUpdates()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);

                webSitesClient.SourceControls.Update(GitHubSourceControl.Name, new SourceControlUpdateParameters()
                {
                    Properties = GitHubSourceControl.Properties
                });

                var sourceControlGetResponse = webSitesClient.SourceControls.Get("GitHub");

                AssertSourceControl(GitHubSourceControl, sourceControlGetResponse.SourceControl);

                var sourceControlListResponse = webSitesClient.SourceControls.List();

                Assert.True(sourceControlListResponse.SourceControls.Count >= 4, "Invalid source controls count at " + sourceControlListResponse.SourceControls.Count);
                var github = sourceControlListResponse.SourceControls.FirstOrDefault(s => s.Name == "GitHub");
                AssertSourceControl(GitHubSourceControl, github);

                var bitbucket = sourceControlListResponse.SourceControls.FirstOrDefault(s => s.Name == "Bitbucket");
                AssertSourceControl(BitbucketSourceControl, bitbucket);
            }
        }

        private static void AssertSourceControl(SourceControl expectedSourceControl, SourceControl actualSourceControl)
        {
            Assert.Equal(expectedSourceControl.Name, actualSourceControl.Name);
            Assert.Equal(expectedSourceControl.Properties.Token, actualSourceControl.Properties.Token);
            Assert.Equal(expectedSourceControl.Properties.TokenSecret, actualSourceControl.Properties.TokenSecret);
        }
    }
}
