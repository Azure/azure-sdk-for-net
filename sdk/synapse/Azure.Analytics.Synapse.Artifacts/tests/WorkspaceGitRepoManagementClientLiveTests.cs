// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="WorkspaceGitRepoManagementClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class WorkspaceGitRepoManagementClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public WorkspaceGitRepoManagementClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private WorkspaceGitRepoManagementClient TriggerRunClient()
        {
            return InstrumentClient(new WorkspaceGitRepoManagementClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18079 - Difficulties getting these to work - 'GitHubClientId is invalid'?")]
        [RecordedTest]
        public async Task TestGetWorkspace()
        {
            WorkspaceGitRepoManagementClient client = TriggerRunClient();
            string clientID = "";
            string accessToken = "";
            GitHubAccessTokenRequest request = new GitHubAccessTokenRequest (clientID, accessToken, "https://github.com/login/oauth/access_token");
            GitHubAccessTokenResponse response = await client.GetGitHubAccessTokenAsync (request);
            Assert.NotNull (response.GitHubAccessToken);
        }
    }
}
