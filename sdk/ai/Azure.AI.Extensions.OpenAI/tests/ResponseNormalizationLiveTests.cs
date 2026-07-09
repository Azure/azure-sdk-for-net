// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

/// <summary>
/// Live/recorded tests that verify Azure-only <see cref="ResponseItem"/> / <see cref="ResponseTool"/>
/// subtypes round-trip through the real service and materialize as their strongly-typed Azure
/// subtypes via the normalization bridge, without the caller having to invoke
/// <c>AsAgentResponseItem()</c>. Each test targets a distinct response funnel
/// (non-streaming create, retrieval, streaming) so that regressions are attributed to the funnel
/// they affect. Currently covers the non-streaming create funnel with Bing grounding; additional
/// funnels and tool kinds are added incrementally.
/// </summary>
public class ResponseNormalizationLiveTests : ProjectsOpenAITestBase
{
    public ResponseNormalizationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesToTypedItem()
    {
        // This test verifies the central promise of the Azure ResponseItem normalization bridge:
        // an Azure-only tool-call output item (Bing grounding) round-trips through the real service
        // and materializes as its strongly-typed Azure subtype WITHOUT the caller having to invoke
        // AsAgentResponseItem(). Without the bridge, this item would arrive as OpenAI's opaque
        // InternalUnknownItemResource. It requires a provisioned Bing grounding connection.
        string bingConnectionName = TryGetBingConnectionName();
        if (string.IsNullOrEmpty(bingConnectionName))
        {
            Assert.Ignore("BING_CONNECTION_NAME is not configured; skipping until a Bing grounding connection is provisioned.");
        }

        AIProjectConnection bingConnection = await GetTestProjectClient().Connections.GetConnectionAsync(connectionName: bingConnectionName);

        BingGroundingTool bingGroundingTool = new(
            new BingGroundingSearchToolOptions(
                searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnection.Id)]));

        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        ResponseResult response = await responsesClient.CreateResponseAsync(
            new CreateResponseOptions()
            {
                Model = TestEnvironment.FOUNDRY_MODEL_NAME,
                Tools = { bingGroundingTool },
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("What is the latest news about the Mars Perseverance rover? Use Bing grounding."),
                },
            });

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        // The crux: the Bing grounding call surfaces as the typed Azure subtype directly off
        // OutputItems, with no AsAgentResponseItem() conversion by the caller.
        BingGroundingToolCall bingCall = response.OutputItems.OfType<BingGroundingToolCall>().FirstOrDefault();
        Assert.That(
            bingCall,
            Is.Not.Null,
            "Expected a strongly-typed BingGroundingToolCall in OutputItems (normalization bridge). "
            + "Getting InternalUnknownItemResource instead means the bridge did not fire.");

        // Sanity: no output item should remain the opaque OpenAI unknown-item type.
        Assert.That(
            response.OutputItems.Any(item => item.GetType().FullName == "OpenAI.Responses.InternalUnknownItemResource"),
            Is.False,
            "No output item should remain OpenAI's opaque InternalUnknownItemResource after normalization.");
    }

    private string TryGetBingConnectionName()
    {
        try
        {
            return TestEnvironment.BING_CONNECTION_NAME;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
