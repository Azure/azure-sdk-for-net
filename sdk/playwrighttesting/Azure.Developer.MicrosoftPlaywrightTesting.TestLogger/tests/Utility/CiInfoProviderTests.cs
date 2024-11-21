// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Utility
{
    [TestFixture]
    public class CiInfoProviderTests
    {
        private Dictionary<string, string> _originalEnvironmentVariables = new();

        [OneTimeSetUp]
        public void Init()
        {
            _originalEnvironmentVariables = Environment.GetEnvironmentVariables()
            .Cast<DictionaryEntry>()
            .ToDictionary(entry => (string)entry.Key, entry => (string)entry.Value!)!;
        }

        [SetUp]
        public void Setup()
        {
            foreach (KeyValuePair<string, string> kvp in _originalEnvironmentVariables)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }

            var keysToRemove = Environment.GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .Select(entry => (string)entry.Key)
                .Where(key => key.StartsWith("github", StringComparison.OrdinalIgnoreCase) || key.StartsWith("gh", StringComparison.OrdinalIgnoreCase) || key.StartsWith("ado", StringComparison.OrdinalIgnoreCase) || key.StartsWith("azure", StringComparison.OrdinalIgnoreCase) || key.StartsWith("tf", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var key in keysToRemove)
            {
                Environment.SetEnvironmentVariable(key, null); // Remove environment variable
            }
        }

        [Test]
        public void GetCIProvider_GitHubActions_ReturnsGitHubActions()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");

            string ciProvider = CiInfoProvider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciProvider);
        }

        [Test]
        public void GetCIProvider_AzureDevOps_ReturnsAzureDevOps()
        {
            Environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            Environment.SetEnvironmentVariable("TF_BUILD", "some_value");

            string ciProvider = CiInfoProvider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciProvider);
        }

        [Test]
        public void GetCIProvider_Default_ReturnsDefault()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", null);
            Environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", null);
            Environment.SetEnvironmentVariable("TF_BUILD", null);

            string ciProvider = CiInfoProvider.GetCIProvider();

            Assert.AreEqual(CIConstants.s_dEFAULT, ciProvider);
        }
        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            Environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            Environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            Environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            Environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            Environment.SetEnvironmentVariable("GITHUB_REF_NAME", "refs/heads/branch_name");
            Environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.Provider);
            Assert.AreEqual("repo_id", ciInfo.Repo);
            Assert.AreEqual("refs/heads/branch_name", ciInfo.Branch);
            Assert.AreEqual("actor", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.RevisionUrl);
            Assert.AreEqual("run_id", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("job_id", ciInfo.JobId);
        }

        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo_WithRefPrefixWhenEventNameIsPullRequest()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            Environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            Environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            Environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            Environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            Environment.SetEnvironmentVariable("GITHUB_REF", "refs/heads/feature/branch_name");
            Environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");
            Environment.SetEnvironmentVariable("GITHUB_EVENT_NAME", "pull_request");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.Provider);
            Assert.AreEqual("repo_id", ciInfo.Repo);
            Assert.AreEqual("refs/heads/head_branch_name", ciInfo.Branch);
            Assert.AreEqual("actor", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.RevisionUrl);
            Assert.AreEqual("run_id", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("job_id", ciInfo.JobId);
        }

        [Test]
        public void GetCIInfo_GitHubActions_ReturnsGitHubActionsCIInfo_WithRefPrefixWhenEventNameIsPullRequestTarget()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY_ID", "repo_id");
            Environment.SetEnvironmentVariable("GITHUB_ACTOR", "actor");
            Environment.SetEnvironmentVariable("GITHUB_SHA", "commit_sha");
            Environment.SetEnvironmentVariable("GITHUB_SERVER_URL", "server_url");
            Environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "repository");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ID", "run_id");
            Environment.SetEnvironmentVariable("GITHUB_RUN_ATTEMPT", "1");
            Environment.SetEnvironmentVariable("GITHUB_JOB", "job_id");
            Environment.SetEnvironmentVariable("GITHUB_REF", "refs/heads/feature/branch_name");
            Environment.SetEnvironmentVariable("GITHUB_HEAD_REF", "refs/heads/head_branch_name");
            Environment.SetEnvironmentVariable("GITHUB_EVENT_NAME", "pull_request_target");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, ciInfo.Provider);
            Assert.AreEqual("repo_id", ciInfo.Repo);
            Assert.AreEqual("refs/heads/head_branch_name", ciInfo.Branch);
            Assert.AreEqual("actor", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("server_url/repository/commit/commit_sha", ciInfo.RevisionUrl);
            Assert.AreEqual("run_id", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("job_id", ciInfo.JobId);
        }

        [Test]
        public void GetCIInfo_AzureDevOps_ReturnsAzureDevOpsCIInfo()
        {
            Environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            Environment.SetEnvironmentVariable("TF_BUILD", "some_value");
            Environment.SetEnvironmentVariable("BUILD_REPOSITORY_ID", "repo_id");
            Environment.SetEnvironmentVariable("BUILD_SOURCEBRANCH", "branch_name");
            Environment.SetEnvironmentVariable("BUILD_REQUESTEDFOR", "author");
            Environment.SetEnvironmentVariable("BUILD_SOURCEVERSION", "commit_sha");
            Environment.SetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", "collection_uri/");
            Environment.SetEnvironmentVariable("SYSTEM_TEAMPROJECT", "team_project");
            Environment.SetEnvironmentVariable("BUILD_REPOSITORY_NAME", "repository_name");
            Environment.SetEnvironmentVariable("RELEASE_ATTEMPTNUMBER", "1");
            Environment.SetEnvironmentVariable("SYSTEM_JOBATTEMPT", "2");
            Environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "deployment_id");
            Environment.SetEnvironmentVariable("SYSTEM_DEFINITIONID", "definition_id");
            Environment.SetEnvironmentVariable("SYSTEM_JOBID", "job_id");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciInfo.Provider);
            Assert.AreEqual("repo_id", ciInfo.Repo);
            Assert.AreEqual("branch_name", ciInfo.Branch);
            Assert.AreEqual("author", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("collection_uri/team_project/_git/repository_name/commit/commit_sha", ciInfo.RevisionUrl);
            Assert.AreEqual("definition_id-job_id", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("deployment_id", ciInfo.JobId);
        }

        [Test]
        public void GetCIInfo_AzureDevOpsWithReleaseInfo_ReturnsAzureDevOpsCIInfo()
        {
            Environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", "some_value");
            Environment.SetEnvironmentVariable("TF_BUILD", "some_value");
            Environment.SetEnvironmentVariable("BUILD_REPOSITORY_ID", "repo_id");
            Environment.SetEnvironmentVariable("BUILD_SOURCEBRANCH", "branch_name");
            Environment.SetEnvironmentVariable("BUILD_REQUESTEDFOR", "author");
            Environment.SetEnvironmentVariable("BUILD_SOURCEVERSION", "commit_sha");
            Environment.SetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", "collection_uri/");
            Environment.SetEnvironmentVariable("SYSTEM_TEAMPROJECT", "team_project");
            Environment.SetEnvironmentVariable("BUILD_REPOSITORY_NAME", "repository_name");
            Environment.SetEnvironmentVariable("RELEASE_ATTEMPTNUMBER", "1");
            Environment.SetEnvironmentVariable("SYSTEM_JOBATTEMPT", "2");
            Environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "deployment_id");
            Environment.SetEnvironmentVariable("SYSTEM_DEFINITIONID", "definition_id");
            Environment.SetEnvironmentVariable("SYSTEM_JOBID", "job_id");
            Environment.SetEnvironmentVariable("RELEASE_DEFINITIONID", "release-def");
            Environment.SetEnvironmentVariable("RELEASE_DEPLOYMENTID", "release-dep");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, ciInfo.Provider);
            Assert.AreEqual("repo_id", ciInfo.Repo);
            Assert.AreEqual("branch_name", ciInfo.Branch);
            Assert.AreEqual("author", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("collection_uri/team_project/_git/repository_name/commit/commit_sha", ciInfo.RevisionUrl);
            Assert.AreEqual("release-def-release-dep", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("release-dep", ciInfo.JobId);
        }

        [Test]
        public void GetCIInfo_Default_ReturnsDefaultCIInfo()
        {
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", null);
            Environment.SetEnvironmentVariable("AZURE_HTTP_USER_AGENT", null);
            Environment.SetEnvironmentVariable("TF_BUILD", null);
            Environment.SetEnvironmentVariable("REPO", "repo");
            Environment.SetEnvironmentVariable("BRANCH", "branch");
            Environment.SetEnvironmentVariable("AUTHOR", "author");
            Environment.SetEnvironmentVariable("COMMIT_ID", "commit_sha");
            Environment.SetEnvironmentVariable("REVISION_URL", "revision_url");
            Environment.SetEnvironmentVariable("RUN_ID", "run_id");
            Environment.SetEnvironmentVariable("RUN_ATTEMPT", "1");
            Environment.SetEnvironmentVariable("JOB_ID", "job_id");

            CIInfo ciInfo = CiInfoProvider.GetCIInfo();

            Assert.AreEqual(CIConstants.s_dEFAULT, ciInfo.Provider);
            Assert.AreEqual("repo", ciInfo.Repo);
            Assert.AreEqual("branch", ciInfo.Branch);
            Assert.AreEqual("author", ciInfo.Author);
            Assert.AreEqual("commit_sha", ciInfo.CommitId);
            Assert.AreEqual("revision_url", ciInfo.RevisionUrl);
            Assert.AreEqual("run_id", ciInfo.RunId);
            Assert.AreEqual(1, ciInfo.RunAttempt);
            Assert.AreEqual("job_id", ciInfo.JobId);
        }
    }
}
