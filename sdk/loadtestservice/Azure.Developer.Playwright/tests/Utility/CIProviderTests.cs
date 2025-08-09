// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.Playwright.Model;
using Azure.Developer.Playwright.Utility;

namespace Azure.Developer.Playwright.Tests.Utility
{
    [TestFixture]
    public class CIProviderTests
    {
        [Test]
        public void GetCIProvider_GitHubActions_ReturnsGitHubActions()
        {
            var environment = new TestEnvironment();
            environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            var provider = new CIProvider(environment: environment);
            string ciProvider = provider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciProvider);
        }

        [Test]
        public void GetCIProvider_AzureDevOps_ReturnsAzureDevOps()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            environment.SetEnvironmentVariable("TF_BUILD", "some_value");

            var provider = new CIProvider(environment: environment);
            string ciProvider = provider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciProvider);
        }

        [Test]
        public void GetCIProvider_Default_ReturnsDefault()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("GITHUB_ACTIONS", null);
            environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", null);
            environment.SetEnvironmentVariable("TF_BUILD", null);

            var provider = new CIProvider(environment: environment);
            string ciProvider = provider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_dEFAULT, ciProvider);
        }
        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            environment.SetEnvironmentVariable("GITHUB_REF_NAME", "refs/heads/branch_name");
            environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.providerName);
            Assert.AreEqual("refs/heads/branch_name", ciInfo.branch);
            Assert.AreEqual("actor", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.revisionUrl);
        }

        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo_WithRefPrefixWhenEventNameIsPullRequest()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            environment.SetEnvironmentVariable("GITHUB_REF", "refs/heads/feature/branch_name");
            environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");
            environment.SetEnvironmentVariable("GITHUB_EVENT_NAME", "pull_request");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.providerName);
            Assert.AreEqual("refs/heads/head_branch_name", ciInfo.branch);
            Assert.AreEqual("actor", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.revisionUrl);
        }

        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo_WithRefPrefixWhenEventNameIsPullRequestTarget()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            environment.SetEnvironmentVariable("GITHUB_REF", "refs/heads/feature/branch_name");
            environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");
            environment.SetEnvironmentVariable("GITHUB_EVENT_NAME", "pull_request_target");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.providerName);
            Assert.AreEqual("refs/heads/head_branch_name", ciInfo.branch);
            Assert.AreEqual("actor", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.revisionUrl);
        }

        [Test]
        public void GetCIInfo_AzureDevOps_ReturnsAzureDevOpsCIInfo()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            environment.SetEnvironmentVariable("TF_BUILD", "some_value");
            environment.SetEnvironmentVariable("BUILD_REPOSITORY_ID", "repo_id");
            environment.SetEnvironmentVariable("BUILD_SOURCEBRANCH", "branch_name");
            environment.SetEnvironmentVariable("BUILD_REQUESTEDFOR", "author");
            environment.SetEnvironmentVariable("BUILD_SOURCEVERSION", "commit_sha");
            environment.SetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", "collection_uri/");
            environment.SetEnvironmentVariable("SYSTEM_TEAMPROJECT", "team_project");
            environment.SetEnvironmentVariable("BUILD_REPOSITORY_NAME", "repository_name");
            environment.SetEnvironmentVariable("RELEASE_ATTEMPTNUMBER", "1");
            environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "deployment_id");
            environment.SetEnvironmentVariable("SYSTEM_DEFINITIONID", "definition_id");
            environment.SetEnvironmentVariable("SYSTEM_JOBID", "job_id");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciInfo.providerName);
            Assert.AreEqual("branch_name", ciInfo.branch);
            Assert.AreEqual("author", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("collection_uri/team_project/_git/repository_name/commit/commit_sha", ciInfo.revisionUrl);
        }

        [Test]
        public void GetCIInfo_AzureDevOpsWithReleaseInfo_ReturnsAzureDevOpsCIInfo()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            environment.SetEnvironmentVariable("TF_BUILD", "some_value");
            environment.SetEnvironmentVariable("BUILD_REPOSITORY_ID", "repo_id");
            environment.SetEnvironmentVariable("BUILD_SOURCEBRANCH", "branch_name");
            environment.SetEnvironmentVariable("BUILD_REQUESTEDFOR", "author");
            environment.SetEnvironmentVariable("BUILD_SOURCEVERSION", "commit_sha");
            environment.SetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", "collection_uri/");
            environment.SetEnvironmentVariable("SYSTEM_TEAMPROJECT", "team_project");
            environment.SetEnvironmentVariable("BUILD_REPOSITORY_NAME", "repository_name");
            environment.SetEnvironmentVariable("RELEASE_ATTEMPTNUMBER", "1");
            environment.SetEnvironmentVariable("SYSTEM_JOBATTEMPT", "2");
            environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "deployment_id");
            environment.SetEnvironmentVariable("SYSTEM_DEFINITIONID", "definition_id");
            environment.SetEnvironmentVariable("SYSTEM_JOBID", "job_id");
            environment.SetEnvironmentVariable("RELEASE_DEFINITIONID", "release-def");
            environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "release-dep");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciInfo.providerName);
            Assert.AreEqual("branch_name", ciInfo.branch);
            Assert.AreEqual("author", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("collection_uri/team_project/_git/repository_name/commit/commit_sha", ciInfo.revisionUrl);
        }

        [Test]
        public void GetCIInfo_Default_ReturnsDefaultCIInfo()
        {
            var environment = new TestEnvironment();

            environment.SetEnvironmentVariable("GITHUB_ACTIONS", null);
            environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", null);
            environment.SetEnvironmentVariable("TF_BUILD", null);
            environment.SetEnvironmentVariable("REPO", "repo");
            environment.SetEnvironmentVariable("BRANCH", "branch");
            environment.SetEnvironmentVariable("AUTHOR", "author");
            environment.SetEnvironmentVariable("COMMIT_ID", "commit_sha");
            environment.SetEnvironmentVariable("REVISION_URL", "revision_url");
            environment.SetEnvironmentVariable("RUN_ID", "run_id");
            environment.SetEnvironmentVariable("RUN_ATTEMPT", "1");
            environment.SetEnvironmentVariable("JOB_ID", "job_id");

            var provider = new CIProvider(environment: environment);
            CIInfo ciInfo = provider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_dEFAULT, ciInfo.providerName);
            Assert.AreEqual("branch", ciInfo.branch);
            Assert.AreEqual("author", ciInfo.author);
            Assert.AreEqual("commit_sha", ciInfo.commitId);
            Assert.AreEqual("revision_url", ciInfo.revisionUrl);
        }
    }
}
