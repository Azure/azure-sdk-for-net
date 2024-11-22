// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

internal class CiInfoProvider
{
    private static bool IsGitHubActions(IEnvironment? environment = null)
    {
        environment ??= new EnvironmentHandler();
        return environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
    }

    private static bool IsAzureDevOps(IEnvironment? environment = null)
    {
        environment ??= new EnvironmentHandler();
        return environment.GetEnvironmentVariable("AZURE_HTTP_USER_AGENT") != null &&
            environment.GetEnvironmentVariable("TF_BUILD") != null;
    }

    internal static string GetCIProvider(IEnvironment? environment = null)
    {
        if (IsGitHubActions(environment))
            return CIConstants.s_gITHUB_ACTIONS;
        else if (IsAzureDevOps(environment))
            return CIConstants.s_aZURE_DEVOPS;
        else
            return CIConstants.s_dEFAULT;
    }

    internal static CIInfo GetCIInfo(IEnvironment? environment = null)
    {
        environment ??= new EnvironmentHandler();
        string ciProvider = GetCIProvider(environment);
        if (ciProvider == CIConstants.s_gITHUB_ACTIONS)
        {
            // Logic to get GitHub Actions CIInfo
            return new CIInfo
            {
                Provider = CIConstants.s_gITHUB_ACTIONS,
                Repo = environment.GetEnvironmentVariable("GITHUB_REPOSITORY_ID"),
                Branch = GetGHBranchName(environment),
                Author = environment.GetEnvironmentVariable("GITHUB_ACTOR"),
                CommitId = environment.GetEnvironmentVariable("GITHUB_SHA"),
                RevisionUrl = environment.GetEnvironmentVariable("GITHUB_SERVER_URL") != null
                    ? $"{environment.GetEnvironmentVariable("GITHUB_SERVER_URL")}/{environment.GetEnvironmentVariable("GITHUB_REPOSITORY")}/commit/{environment.GetEnvironmentVariable("GITHUB_SHA")}"
                    : null,
                RunId = environment.GetEnvironmentVariable("GITHUB_RUN_ID"),
                RunAttempt = environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT") != null
                    ? int.Parse(environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT")!)
                    : null,
                JobId = environment.GetEnvironmentVariable("GITHUB_JOB")
            };
        }
        else if (ciProvider == CIConstants.s_aZURE_DEVOPS)
        {
            // Logic to get Azure DevOps CIInfo
            return new CIInfo
            {
                Provider = CIConstants.s_aZURE_DEVOPS,
                Repo = environment.GetEnvironmentVariable("BUILD_REPOSITORY_ID"),
                Branch = environment.GetEnvironmentVariable("BUILD_SOURCEBRANCH"),
                Author = environment.GetEnvironmentVariable("BUILD_REQUESTEDFOR"),
                CommitId = environment.GetEnvironmentVariable("BUILD_SOURCEVERSION"),
                RevisionUrl = environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI") != null
                    ? $"{environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI")}{environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECT")}/_git/{environment.GetEnvironmentVariable("BUILD_REPOSITORY_NAME")}/commit/{environment.GetEnvironmentVariable("BUILD_SOURCEVERSION")}"
                    : null,
                RunId = GetADORunId(environment),
                RunAttempt = environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER") != null
                    ? int.Parse(environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER")!)
                    : int.Parse(environment.GetEnvironmentVariable("SYSTEM_JOBATTEMPT")!),
                JobId = environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") ?? environment.GetEnvironmentVariable("SYSTEM_JOBID")
            };
        }
        else
        {
            // Handle unsupported CI provider
            return new CIInfo
            {
                Provider = CIConstants.s_dEFAULT,
                Repo = environment.GetEnvironmentVariable("REPO"),
                Branch = environment.GetEnvironmentVariable("BRANCH"),
                Author = environment.GetEnvironmentVariable("AUTHOR"),
                CommitId = environment.GetEnvironmentVariable("COMMIT_ID"),
                RevisionUrl = environment.GetEnvironmentVariable("REVISION_URL"),
                RunId = environment.GetEnvironmentVariable("RUN_ID"),
                RunAttempt = environment.GetEnvironmentVariable("RUN_ATTEMPT") != null
                    ? int.Parse(environment.GetEnvironmentVariable("RUN_ATTEMPT")!)
                    : null,
                JobId = environment.GetEnvironmentVariable("JOB_ID")
            };
        }
    }

    private static string GetADORunId(IEnvironment? environment = null)
    {
        environment ??= new EnvironmentHandler();
        if (environment.GetEnvironmentVariable("RELEASE_DEFINITIONID") != null && environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") != null)
            return $"{environment.GetEnvironmentVariable("RELEASE_DEFINITIONID")}-{environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID")}";
        else
            return $"{environment.GetEnvironmentVariable("SYSTEM_DEFINITIONID")}-{environment.GetEnvironmentVariable("SYSTEM_JOBID")}";
    }

    private static string GetGHBranchName(IEnvironment? environment = null)
    {
        environment ??= new EnvironmentHandler();
        if (environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request" ||
            environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request_target")
            return environment.GetEnvironmentVariable("GITHUB_HEAD_REF")!;
        else
            return environment.GetEnvironmentVariable("GITHUB_REF_NAME")!;
    }
}
