// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using System;
using PlaywrightConstants = Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility.Constants;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

internal class CiInfoProvider
{
    private static bool IsGitHubActions()
    {
        return Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
    }

    private static bool IsAzureDevOps()
    {
        return Environment.GetEnvironmentVariable("AZURE_HTTP_USER_AGENT") != null &&
            Environment.GetEnvironmentVariable("TF_BUILD") != null;
    }

    internal static string GetCIProvider()
    {
        if (IsGitHubActions())
            return PlaywrightConstants.GITHUB_ACTIONS;
        else if (IsAzureDevOps())
            return PlaywrightConstants.AZURE_DEVOPS;
        else
            return PlaywrightConstants.DEFAULT;
    }

    internal static CIInfo GetCIInfo()
    {
        string ciProvider = GetCIProvider();
        if (ciProvider == PlaywrightConstants.GITHUB_ACTIONS)
        {
            // Logic to get GitHub Actions CIInfo
            return new CIInfo
            {
                Provider = PlaywrightConstants.GITHUB_ACTIONS,
                Repo = Environment.GetEnvironmentVariable("GITHUB_REPOSITORY_ID"),
                Branch = GetGHBranchName(),
                Author = Environment.GetEnvironmentVariable("GITHUB_ACTOR"),
                CommitId = Environment.GetEnvironmentVariable("GITHUB_SHA"),
                RevisionUrl = Environment.GetEnvironmentVariable("GITHUB_SERVER_URL") != null
                    ? $"{Environment.GetEnvironmentVariable("GITHUB_SERVER_URL")}/{Environment.GetEnvironmentVariable("GITHUB_REPOSITORY")}/commit/{Environment.GetEnvironmentVariable("GITHUB_SHA")}"
                    : null,
                RunId = Environment.GetEnvironmentVariable("GITHUB_RUN_ID"),
                RunAttempt = Environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT") != null
                    ? int.Parse(Environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT")!)
                    : null,
                JobId = Environment.GetEnvironmentVariable("GITHUB_JOB")
            };
        }
        else if (ciProvider == PlaywrightConstants.AZURE_DEVOPS)
        {
            // Logic to get Azure DevOps CIInfo
            return new CIInfo
            {
                Provider = PlaywrightConstants.AZURE_DEVOPS,
                Repo = Environment.GetEnvironmentVariable("BUILD_REPOSITORY_ID"),
                Branch = Environment.GetEnvironmentVariable("BUILD_SOURCEBRANCH"),
                Author = Environment.GetEnvironmentVariable("BUILD_REQUESTEDFOR"),
                CommitId = Environment.GetEnvironmentVariable("BUILD_SOURCEVERSION"),
                RevisionUrl = Environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI") != null
                    ? $"{Environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI")}{Environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECT")}/_git/{Environment.GetEnvironmentVariable("BUILD_REPOSITORY_NAME")}/commit/{Environment.GetEnvironmentVariable("BUILD_SOURCEVERSION")}"
                    : null,
                RunId = GetADORunId(),
                RunAttempt = Environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER") != null
                    ? int.Parse(Environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER")!)
                    : int.Parse(Environment.GetEnvironmentVariable("SYSTEM_JOBATTEMPT")!),
                JobId = Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") ?? Environment.GetEnvironmentVariable("SYSTEM_JOBID")
            };
        }
        else
        {
            // Handle unsupported CI provider
            return new CIInfo
            {
                Provider = PlaywrightConstants.DEFAULT,
                Repo = Environment.GetEnvironmentVariable("REPO"),
                Branch = Environment.GetEnvironmentVariable("BRANCH"),
                Author = Environment.GetEnvironmentVariable("AUTHOR"),
                CommitId = Environment.GetEnvironmentVariable("COMMIT_ID"),
                RevisionUrl = Environment.GetEnvironmentVariable("REVISION_URL"),
                RunId = Environment.GetEnvironmentVariable("RUN_ID"),
                RunAttempt = Environment.GetEnvironmentVariable("RUN_ATTEMPT") != null
                    ? int.Parse(Environment.GetEnvironmentVariable("RUN_ATTEMPT")!)
                    : null,
                JobId = Environment.GetEnvironmentVariable("JOB_ID")
            };
        }
    }

    private static string GetADORunId()
    {
        if (Environment.GetEnvironmentVariable("RELEASE_DEFINITIONID") != null && Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") != null)
            return $"{Environment.GetEnvironmentVariable("RELEASE_DEFINITIONID")}-{Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID")}";
        else
            return $"{Environment.GetEnvironmentVariable("SYSTEM_DEFINITIONID")}-{Environment.GetEnvironmentVariable("SYSTEM_JOBID")}";
    }

    private static string GetGHBranchName()
    {
        if (Environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request" ||
            Environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request_target")
            return Environment.GetEnvironmentVariable("GITHUB_HEAD_REF")!;
        else
            return Environment.GetEnvironmentVariable("GITHUB_REF_NAME")!;
    }
}
