// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    {/*
        private static readonly SourceControl GitHubSourceControl = new SourceControl()
        {
            SourceControlName = "GitHub",
            Token = "myToken",
            TokenSecret = "myTokenSecret"
        };

        private static readonly SourceControl BitbucketSourceControl = new SourceControl()
        {
            SourceControlName = "Bitbucket"
        };

        [Fact(Skip = "Obsolete API")]
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
        */
    }
}
