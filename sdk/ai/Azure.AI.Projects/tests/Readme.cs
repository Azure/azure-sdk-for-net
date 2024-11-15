// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Identity;

namespace Azure.AI.Projects.Tests;

internal partial class Readme
{
    public void CreateProjectClient()
    {
        #region Snippet:OverviewCreateClient
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        AIProjectClient projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        #endregion
    }

    public void Troubleshooting()
    {
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

        #region Snippet:Readme_Troubleshooting
        try
        {
            client.CreateMessage(
            "1234",
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            Console.WriteLine($"Exception status code: {ex.Status}");
            Console.WriteLine($"Exception message: {ex.Message}");
        }
        #endregion
    }
}
