// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI;
using System;

namespace Azure.AI.OpenAI.Tests;

[Category("Smoke")]
public class AzureOpenAIClientSmokeTests : AoaiTestBase<AzureOpenAIClient>
{
    private IConfiguration DefaultTestConfig { get; }

    public AzureOpenAIClientSmokeTests(bool isAsync) : base(isAsync)
    {
        DefaultTestConfig = TestConfig.GetConfig("default");
    }

    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient azureOpenAIClient = GetTestTopLevelClient(DefaultTestConfig);
        Assert.That(azureOpenAIClient, Is.InstanceOf<AzureOpenAIClient>());
        Assert.That(azureOpenAIClient as OpenAIClient, Is.Not.Null);
    }

    [Test]
    public void VerifyAllVersionsStringify()
    {
        foreach (AzureOpenAIClientOptions.ServiceVersion possibleVersionValue
            in Enum.GetValues(typeof(AzureOpenAIClientOptions.ServiceVersion)))
        {
            AzureOpenAIClientOptions clientOptionsWithVersion = new(possibleVersionValue);
            string stringifiedVersion = clientOptionsWithVersion.GetRawServiceApiValueForClient(null);
            Assert.That(stringifiedVersion, Is.Not.Null.And.Not.Empty);
        }
    }
}
