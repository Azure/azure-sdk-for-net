// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class AIProjectClientTest : ProjectsClientTestBase
{
    public AIProjectClientTest(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [SyncOnly]
    [TestCase("https://sample.services.ai.azure.com/api/projects/sampleProject", true)]
    [TestCase("https://sample.services.ai.azurewcom/api/projects/sampleProject", false)]
    [TestCase("https://sample.services.aiwazure.com/api/projects/sampleProject", false)]
    [TestCase("https://sample.serviceswai.azure.com/api/projects/sampleProject", false)]
    [TestCase("https://samplewservices.ai.azure.com/api/projects/sampleProject", false)]
    [TestCase("https://evil.com/api/projects/sampleProject", false)]
    [TestCase("https://www.evil.com/api/projects/sampleProject", false)]
    [TestCase("https://www.evil.com/path", false)]
    [TestCase("https://www.evil.com", false)]
    public void TestCreateProject(string endpoint, bool success)
    {
        if (success)
        {
            Assert.That(new AIProjectClient(new Uri(endpoint), TestEnvironment.Credential) is null, Is.False);
        }
        else
        {
            Assert.Throws<InvalidOperationException>( () => new AIProjectClient(new Uri(endpoint), TestEnvironment.Credential));
        }
    }
}
