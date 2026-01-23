// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Converters;

public class ResponseConverterExtensionsTests
{
    [Test]
    public void ToResponseUsage_WithNullUsage_ReturnsNull()
    {
        UsageDetails? usage = null;

        var result = usage.ToResponseUsage();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToResponseUsage_WithValidUsage_ConvertsCorrectly()
    {
        var usage = new UsageDetails
        {
            InputTokenCount = 100,
            OutputTokenCount = 50,
            TotalTokenCount = 150
        };

        var result = usage.ToResponseUsage();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.InputTokens, Is.EqualTo(100));
        Assert.That(result.OutputTokens, Is.EqualTo(50));
        Assert.That(result.TotalTokens, Is.EqualTo(150));
    }

    [Test]
    public void ToResponseUsage_WithNullTokenCounts_DefaultsToZero()
    {
        var usage = new UsageDetails
        {
            InputTokenCount = null,
            OutputTokenCount = null,
            TotalTokenCount = null
        };

        var result = usage.ToResponseUsage();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.InputTokens, Is.EqualTo(0));
        Assert.That(result.OutputTokens, Is.EqualTo(0));
        Assert.That(result.TotalTokens, Is.EqualTo(0));
    }

    [Test]
    public void ToResponseUsage_WithCachedInputTokenDetails_IncludesDetails()
    {
        var usage = new UsageDetails
        {
            InputTokenCount = 100,
            OutputTokenCount = 50,
            TotalTokenCount = 150,
            AdditionalCounts = new AdditionalPropertiesDictionary<long>
            {
                { "InputTokenDetails.CachedTokenCount", 25 }
            }
        };

        var result = usage.ToResponseUsage();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.InputTokensDetails, Is.Not.Null);
        Assert.That(result.InputTokensDetails!.CachedTokens, Is.EqualTo(25));
    }

    [Test]
    public void ToResponseUsage_WithReasoningTokenDetails_IncludesDetails()
    {
        var usage = new UsageDetails
        {
            InputTokenCount = 100,
            OutputTokenCount = 50,
            TotalTokenCount = 150,
            AdditionalCounts = new AdditionalPropertiesDictionary<long>
            {
                { "OutputTokenDetails.ReasoningTokenCount", 10 }
            }
        };

        var result = usage.ToResponseUsage();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.OutputTokensDetails, Is.Not.Null);
        Assert.That(result.OutputTokensDetails!.ReasoningTokens, Is.EqualTo(10));
    }

    [Test]
    public void ToItemContent_WithTextContent_ReturnsOutputText()
    {
        var content = new TextContent("Hello, world!");

        var result = content.ToItemContent();

        Assert.That(result, Is.TypeOf<ItemContentOutputText>());
        var outputText = (ItemContentOutputText)result!;
        Assert.That(outputText.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void ToItemContent_WithNullTextInTextContent_ReturnsEmptyString()
    {
        var content = new TextContent(null);

        var result = content.ToItemContent();

        Assert.That(result, Is.TypeOf<ItemContentOutputText>());
        var outputText = (ItemContentOutputText)result!;
        Assert.That(outputText.Text, Is.EqualTo(string.Empty));
    }

    [Test]
    public void ToItemContent_WithErrorContent_ThrowsAgentInvocationException()
    {
        var content = new ErrorContent("Error message");

        Assert.Throws<AgentInvocationException>(() => content.ToItemContent());
    }

    [Test]
    public void ToFunctionToolCallItemResource_ConvertsCorrectly()
    {
        var arguments = new Dictionary<string, object?> { { "city", "Seattle" } };
        var content = new FunctionCallContent("call_123", "get_weather", arguments);

        var result = content.ToFunctionToolCallItemResource("fc_001");

        Assert.That(result.Id, Is.EqualTo("fc_001"));
        Assert.That(result.CallId, Is.EqualTo("call_123"));
        Assert.That(result.Name, Is.EqualTo("get_weather"));
        Assert.That(result.Status, Is.EqualTo(FunctionToolCallItemResourceStatus.Completed));
        Assert.That(result.Arguments, Does.Contain("city"));
        Assert.That(result.Arguments, Does.Contain("Seattle"));
    }

    [Test]
    public void ToFunctionToolCallItemResource_WithEmptyArguments_SerializesEmptyObject()
    {
        var content = new FunctionCallContent("call_123", "no_args_function", new Dictionary<string, object?>());

        var result = content.ToFunctionToolCallItemResource("fc_001");

        Assert.That(result.Arguments, Is.EqualTo("{}"));
    }

    [Test]
    public void ToFunctionToolCallOutputItemResource_WithResult_ConvertsResultToString()
    {
        var content = new FunctionResultContent("call_123", "72F, Sunny");

        var result = content.ToFunctionToolCallOutputItemResource("fco_001");

        Assert.That(result.Id, Is.EqualTo("fco_001"));
        Assert.That(result.CallId, Is.EqualTo("call_123"));
        Assert.That(result.Output, Is.EqualTo("72F, Sunny"));
        Assert.That(result.Status, Is.EqualTo(FunctionToolCallOutputItemResourceStatus.Completed));
    }

    [Test]
    public void ToFunctionToolCallOutputItemResource_WithNullResult_ReturnsNullString()
    {
        var content = new FunctionResultContent("call_123", null);

        var result = content.ToFunctionToolCallOutputItemResource("fco_001");

        Assert.That(result.Output, Is.EqualTo("(null)"));
    }

    [Test]
    public void ToResponseError_FormatsMessageCorrectly()
    {
        var content = new ErrorContent("Something went wrong");

        var result = content.ToResponseError();

        Assert.That(result.Message, Does.Contain("Something went wrong"));
    }

    [Test]
    public void ToResponseError_WithErrorCode_IncludesCodeInMessage()
    {
        var content = new ErrorContent("Something went wrong")
        {
            ErrorCode = "ERR_001"
        };

        var result = content.ToResponseError();

        Assert.That(result.Message, Does.Contain("ERR_001"));
    }

    [Test]
    public void ToResponseError_WithDetails_IncludesDetailsInMessage()
    {
        var content = new ErrorContent("Something went wrong")
        {
            Details = "Additional context about the error"
        };

        var result = content.ToResponseError();

        Assert.That(result.Message, Does.Contain("Additional context about the error"));
    }
}
