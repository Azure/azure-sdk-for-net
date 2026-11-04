// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_ClientInitialization : ProjectsOpenAITestBase
{
    [Test]
    [SyncOnly]
    public void CreateClientOnly()
    {
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        _ = projectClient.ProjectOpenAIClient;
    }

    public Sample_ClientInitialization(bool isAsync) : base(isAsync)
    { }
}
