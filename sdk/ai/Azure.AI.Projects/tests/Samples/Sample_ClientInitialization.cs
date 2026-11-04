// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_ClientInitialization : SamplesBase
{
    [Test]
    [SyncOnly]
    public void CreateClientOnly()
    {
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        AIProjectClient projectClient = new(endpoint: new Uri(endpoint), tokenProvider: new DefaultAzureCredential());
        _ = projectClient;
    }

    public Sample_ClientInitialization(bool isAsync) : base(isAsync) { }
}
