// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class RedTeamTests : ProjectsClientTestBase
{
    public RedTeamTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task TestRedTeamCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AzureOpenAIModelConfiguration config = new(modelDeploymentName: TestEnvironment.MODELDEPLOYMENTNAME);
        RedTeam redTeam = new(target: config)
        {
            AttackStrategies = { AttackStrategy.Base64 },
            RiskCategories = { RiskCategory.Violence },
            DisplayName = "redteamtest1"
        };

        RequestOptions options = new();
        options.AddHeader("model-endpoint", TestEnvironment.MODEL_ENDPOINT);
        options.AddHeader("model-api-key", TestEnvironment.MODEL_API_KEY);

        string initialName = redTeam.DisplayName;
        redTeam = await projectClient.RedTeams.CreateAsync(redTeam: redTeam, options: options);
        Assert.That(redTeam.DisplayName, Is.EqualTo(initialName), $"Got unexpected name {redTeam.DisplayName}");
        // Get
        redTeam = await projectClient.RedTeams.GetAsync(redTeam.Name);
        Assert.That(redTeam.DisplayName, Is.EqualTo(initialName), $"Got unexpected name {redTeam.DisplayName}");
        // List
        HashSet<string> hshStatuses = [];
        await foreach (RedTeam team in projectClient.RedTeams.GetAllAsync())
        {
            hshStatuses.Add(team.DisplayName);
        }
        Assert.That(hshStatuses, Contains.Item(initialName), $"The red team names {initialName} was not listed.");
    }

    [RecordedTest]
    public async Task TestRedTeamScan()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AzureOpenAIModelConfiguration config = new(modelDeploymentName: TestEnvironment.MODELDEPLOYMENTNAME);
        RedTeam redTeam = new(target: config)
        {
            AttackStrategies = { AttackStrategy.Base64 },
            RiskCategories = { RiskCategory.Violence },
            DisplayName = "redteamtest1"
        };
        RequestOptions options = new();
        options.AddHeader("model-endpoint", TestEnvironment.MODEL_ENDPOINT);
        options.AddHeader("model-api-key", TestEnvironment.MODEL_API_KEY);
        redTeam = await projectClient.RedTeams.CreateAsync(redTeam: redTeam, options: options);
        while (redTeam.Status != "Completed" && redTeam.Status != "Failed")
        {
            await Delay();
            redTeam = await projectClient.RedTeams.GetAsync(redTeam.Name);
        }
        Assert.That(redTeam.Status, Is.EqualTo("Completed"), $"Wrong Red team statu {redTeam.Status}");
    }
}
