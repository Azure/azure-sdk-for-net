// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class RedTeamTests : ProjectsClientTestBase
{
    public RedTeamTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
    {
    }

    [RecordedTest]
    //[Ignore("Pending Microsoft.ClientModel.TestFramework migration")]
    public async Task RedTeamTest()
    {
        AIProjectClient projectClient = GetTestClient();

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

        if (IsAsync)
        {
            await RedTeamTestAsync(projectClient, redTeam, options);
        }
        else
        {
            RedTeamTestSync(projectClient, redTeam, options);
        }
    }
    private static async Task RedTeamTestAsync(AIProjectClient projectClient, RedTeam redTeam, RequestOptions options)
    {
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

    private static void RedTeamTestSync(AIProjectClient projectClient, RedTeam redTeam, RequestOptions options)
    {
        string initialName = redTeam.DisplayName;
        redTeam = projectClient.RedTeams.Create(redTeam: redTeam, options: options);
        Assert.That(redTeam.DisplayName, Is.EqualTo(initialName), $"Got unexpected name {redTeam.DisplayName}");
        // Get
        redTeam = projectClient.RedTeams.Get(redTeam.Name);
        Assert.That(redTeam.DisplayName, Is.EqualTo(initialName), $"Got unexpected name {redTeam.DisplayName}");
        // List
        HashSet<string> hshStatuses = [];
        foreach (RedTeam team in projectClient.RedTeams.GetAll())
        {
            hshStatuses.Add(team.DisplayName);
        }
        Assert.That(hshStatuses, Contains.Item(initialName), $"The red team names {initialName} was not listed.");
    }
}
