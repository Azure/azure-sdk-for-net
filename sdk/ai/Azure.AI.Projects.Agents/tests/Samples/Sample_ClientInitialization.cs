// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_ClientInitialization : SamplesBase
{
    [Test]
    [SyncOnly]
    public void CreateClientOnly()
    {
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        Assert.IsNotNull(agentsClient);
    }

    public Sample_ClientInitialization(bool isAsync) : base(isAsync)
    { }
}
