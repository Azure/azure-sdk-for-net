// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Readme : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    public void Authenticate()
    {
        #region Snippet:AgentsOverviewCreateClient
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        PersistentAgentsClient projectClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
    }

    [Test]
    public void Troubleshooting()
    {
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        #region Snippet:AgentsReadme_Troubleshooting
        try
        {
            client.Messages.CreateMessage(
            "thread1234",
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
