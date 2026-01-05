// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.ClientModel.Primitives;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.Identity;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_RedTeam : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentRedTeamAsync()
    {
        #region Snippet:Sample_CreateClient_RedTeam
#if SNIPPET
        // Sample : https://<account_name>.services.ai.azure.com/api/projects/<project_name>
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        // Sample : https://<account_name>.services.ai.azure.com
        var modelEndpoint = System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT");
        var modelApiKey = System.Environment.GetEnvironmentVariable("MODEL_API_KEY");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelEndpoint = TestEnvironment.MODEL_ENDPOINT;
        var modelApiKey = TestEnvironment.MODEL_API_KEY;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateRedTeam_RedTeam
        AzureOpenAIModelConfiguration config = new(modelDeploymentName: modelDeploymentName);
        RedTeam redTeam = new(target: config)
        {
            AttackStrategies = { AttackStrategy.Base64 },
            RiskCategories = { RiskCategory.Violence },
            DisplayName = "redteamtest1"
        };
        #endregion

        #region Snippet:Sample_RunScan_RedTeam_Async
        RequestOptions options = new();
        options.AddHeader("model-endpoint", modelEndpoint);
        options.AddHeader("model-api-key", modelApiKey);
        redTeam = await projectClient.RedTeams.CreateAsync(redTeam: redTeam, options: options);
        Console.WriteLine($"Red Team scan created with scan name: {redTeam.Name}");
        #endregion

        #region Snippet:Sample_GetScanDetails_RedTeam_Async
        redTeam = await projectClient.RedTeams.GetAsync(name: redTeam.Name);
        Console.WriteLine($"Red Team scan status: {redTeam.Status}");
        #endregion

        #region Snippet:Sample_ListRedTeams_RedTeam_Async
        await foreach (RedTeam scan in projectClient.RedTeams.GetAllAsync())
        {
            Console.WriteLine($"Found scan: {scan.Name}, Status: {scan.Status}");
        }
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentRedTeam()
    {
#if SNIPPET
        // Sample : https://<account_name>.services.ai.azure.com/api/projects/<project_name>
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        // Sample : https://<account_name>.services.ai.azure.com
        var modelEndpoint = System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT");
        var modelApiKey = System.Environment.GetEnvironmentVariable("MODEL_API_KEY");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelEndpoint = TestEnvironment.MODEL_ENDPOINT;
        var modelApiKey = TestEnvironment.MODEL_API_KEY;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        AzureOpenAIModelConfiguration config = new(modelDeploymentName: modelDeploymentName);
        RedTeam redTeam = new(target: config)
        {
            AttackStrategies = { AttackStrategy.Base64 },
            RiskCategories = { RiskCategory.Violence },
            DisplayName = "redteamtest1"
        };

        #region Snippet:Sample_RunScan_RedTeam_Sync
        RequestOptions options = new();
        options.AddHeader("model-endpoint", modelEndpoint);
        options.AddHeader("model-api-key", modelApiKey);
        redTeam = projectClient.RedTeams.Create(redTeam: redTeam, options: options);
        Console.WriteLine($"Red Team scan created with scan name: {redTeam.Name}");
        #endregion

        #region Snippet:Sample_GetScanDetails_RedTeam_Sync
        redTeam = projectClient.RedTeams.Get(name: redTeam.Name);
        Console.WriteLine($"Red Team scan status: {redTeam.Status}");
        #endregion

        #region Snippet:Sample_ListRedTeams_RedTeam_Sync
        foreach (RedTeam scan in projectClient.RedTeams.GetAll())
        {
            Console.WriteLine($"Found scan: {scan.Name}, Status: {scan.Status}");
        }
        #endregion
    }

    public Sample_RedTeam(bool isAsync) : base(isAsync)
    { }
}
