// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.OpenAI.Assistants;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Assistants.Tests;
public abstract partial class AssistantsTestBase : RecordedTestBase<OpenAITestEnvironment>
{
    public enum OpenAIClientServiceTarget
    {
        Azure,
        NonAzure,
    }

    public enum OpenAIClientAuthenticationType
    {
        Unknown,
        ApiKey,
        Token,
        ActiveDirectory,
    }

    public AssistantsClient GetTestClient(
        OpenAIClientServiceTarget target,
        OpenAIClientAuthenticationType authenticationType)
    {
        return (target, authenticationType) switch
        {
            (OpenAIClientServiceTarget.NonAzure, OpenAIClientAuthenticationType.ApiKey) => GetNonAzureClientWithKey(),
            (OpenAIClientServiceTarget.Azure, OpenAIClientAuthenticationType.ApiKey) => GetAzureClientWithKey(),
            _ => throw new NotImplementedException()
        };
    }

    public AssistantsClient GetTestClient(OpenAIClientServiceTarget target)
        => GetTestClient(target, OpenAIClientAuthenticationType.ApiKey);

    protected AssistantsClient GetNonAzureClientWithKey() => InstrumentClient(
        new AssistantsClient(NonAzureApiKey, GetInstrumentedClientOptions()));

    protected AssistantsClient GetAzureClientWithKey() => InstrumentClient(
        new AssistantsClient(new(AzureResourceUrl), AzureApiKeyCredential, GetInstrumentedClientOptions()));

    private AssistantsClientOptions GetInstrumentedClientOptions(
        AssistantsClientOptions.ServiceVersion? azureServiceVersionOverride = null)
    {
        AssistantsClientOptions uninstrumentedClientOptions = azureServiceVersionOverride.HasValue
            ? new AssistantsClientOptions(azureServiceVersionOverride.Value)
            : new AssistantsClientOptions();
        return InstrumentClientOptions(uninstrumentedClientOptions);
    }

    protected string GetDeploymentOrModelName(OpenAIClientServiceTarget target)
        => target switch
        {
            OpenAIClientServiceTarget.Azure => "gpt-4-1106-preview",
            OpenAIClientServiceTarget.NonAzure => "gpt-4-1106-preview",
            _ => throw new NotImplementedException(),
        };
}
