// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.Playwright.Interface;
using Azure.Developer.Playwright.Implementation;
using Azure.Developer.Playwright.Model;
using System;

namespace Azure.Developer.Playwright.Utility;

internal class CIProvider
{
    private readonly IEnvironment _environment;
    public CIProvider(IEnvironment? environment = null)
    {
        _environment = environment ?? new EnvironmentHandler();
    }

    public string GetCIProvider()
    {
        if (IsGitHubActions())
            return CIConstants.s_gITHUB_ACTIONS;
        else if (IsAzureDevOps())
            return CIConstants.s_aZURE_DEVOPS;
        else
            return CIConstants.s_dEFAULT;
    }

    public static string GetRunId()
    {
        return Guid.NewGuid().ToString();
    }

    public CIInfo GetCIInfo()
    {
        string ciProvider = GetCIProvider();
        if (ciProvider == CIConstants.s_gITHUB_ACTIONS)
        {
            // Logic to get GitHub Actions CIInfo
            return new CIInfo
            {
                Provider = CIConstants.s_gITHUB_ACTIONS,
                Repo = _environment.GetEnvironmentVariable("GITHUB_REPOSITORY_ID"),
                Branch = GetGHBranchName(),
                Author = _environment.GetEnvironmentVariable("GITHUB_ACTOR"),
                CommitId = _environment.GetEnvironmentVariable("GITHUB_SHA"),
                RevisionUrl = _environment.GetEnvironmentVariable("GITHUB_SERVER_URL") != null
                    ? $"{_environment.GetEnvironmentVariable("GITHUB_SERVER_URL")}/{_environment.GetEnvironmentVariable("GITHUB_REPOSITORY")}/commit/{_environment.GetEnvironmentVariable("GITHUB_SHA")}"
                    : null,
                RunId = _environment.GetEnvironmentVariable("GITHUB_RUN_ID"),
                RunAttempt = _environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT") != null
                    ? int.Parse(_environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT")!)
                    : null,
                JobId = _environment.GetEnvironmentVariable("GITHUB_JOB")
            };
        }
        else if (ciProvider == CIConstants.s_aZURE_DEVOPS)
        {
            // Logic to get Azure DevOps CIInfo
            return new CIInfo
            {
                Provider = CIConstants.s_aZURE_DEVOPS,
                Repo = _environment.GetEnvironmentVariable("BUILD_REPOSITORY_ID"),
                Branch = _environment.GetEnvironmentVariable("BUILD_SOURCEBRANCH"),
                Author = _environment.GetEnvironmentVariable("BUILD_REQUESTEDFOR"),
                CommitId = _environment.GetEnvironmentVariable("BUILD_SOURCEVERSION"),
                RevisionUrl = _environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI") != null
                    ? $"{_environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI")}{_environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECT")}/_git/{_environment.GetEnvironmentVariable("BUILD_REPOSITORY_NAME")}/commit/{_environment.GetEnvironmentVariable("BUILD_SOURCEVERSION")}"
                    : null,
                RunId = GetADORunId(),
                RunAttempt = _environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER") != null
                    ? int.Parse(_environment.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER")!)
                    : int.Parse(_environment.GetEnvironmentVariable("SYSTEM_JOBATTEMPT")!),
                JobId = _environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") ?? _environment.GetEnvironmentVariable("SYSTEM_JOBID")
            };
        }
        else
        {
            // Handle unsupported CI provider
            return new CIInfo
            {
                Provider = CIConstants.s_dEFAULT,
                Repo = _environment.GetEnvironmentVariable("REPO"),
                Branch = _environment.GetEnvironmentVariable("BRANCH"),
                Author = _environment.GetEnvironmentVariable("AUTHOR"),
                CommitId = _environment.GetEnvironmentVariable("COMMIT_ID"),
                RevisionUrl = _environment.GetEnvironmentVariable("REVISION_URL"),
                RunId = _environment.GetEnvironmentVariable("RUN_ID"),
                RunAttempt = _environment.GetEnvironmentVariable("RUN_ATTEMPT") != null
                    ? int.Parse(_environment.GetEnvironmentVariable("RUN_ATTEMPT")!)
                    : null,
                JobId = _environment.GetEnvironmentVariable("JOB_ID")
            };
        }
    }

    internal string GetADORunId()
    {
        if (_environment.GetEnvironmentVariable("RELEASE_DEFINITIONID") != null && _environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID") != null)
            return $"{_environment.GetEnvironmentVariable("RELEASE_DEFINITIONID")}-{_environment.GetEnvironmentVariable("RELEASE_DEPLOYMENTID")}";
        else
            return $"{_environment.GetEnvironmentVariable("SYSTEM_DEFINITIONID")}-{_environment.GetEnvironmentVariable("SYSTEM_JOBID")}";
    }

    internal string GetGHBranchName()
    {
        if (_environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request" ||
            _environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request_target")
            return _environment.GetEnvironmentVariable("GITHUB_HEAD_REF")!;
        else
            return _environment.GetEnvironmentVariable("GITHUB_REF_NAME")!;
    }

    internal bool IsGitHubActions()
    {
        return _environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
    }

    internal bool IsAzureDevOps()
    {
        return _environment.GetEnvironmentVariable("AZURE_HTTP_USER_AGENT") != null &&
        _environment.GetEnvironmentVariable("TF_BUILD") != null;
    }
}
