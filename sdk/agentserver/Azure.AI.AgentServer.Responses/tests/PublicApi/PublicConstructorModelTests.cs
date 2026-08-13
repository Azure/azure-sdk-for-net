// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T009: Reflection tests asserting key OutputItem subtypes, OutputContent subtypes,
/// Models.ResponseObject, and Models.ResponseErrorInfo have public constructors. Abstract bases and Unknown
/// variants must NOT have public constructors.
/// </summary>
public class PublicConstructorModelTests
{
    /// <summary>
    /// Concrete OutputItem subtypes from OpenAI namespace.
    /// </summary>
    public static IEnumerable<object[]> OpenAIOutputItemTypes => new[]
    {
        new object[] { typeof(OutputItemApplyPatchToolCall) },
        new object[] { typeof(OutputItemApplyPatchToolCallOutput) },
        new object[] { typeof(OutputItemCodeInterpreterToolCall) },
        new object[] { typeof(OutputItemCompactionBody) },
        new object[] { typeof(OutputItemComputerToolCall) },
        new object[] { typeof(OutputItemComputerToolCallOutput) },
        new object[] { typeof(OutputItemCustomToolCall) },
        new object[] { typeof(OutputItemCustomToolCallOutput) },
        new object[] { typeof(OutputItemFileSearchToolCall) },
        new object[] { typeof(OutputItemFunctionShellCall) },
        new object[] { typeof(OutputItemFunctionShellCallOutput) },
        new object[] { typeof(OutputItemFunctionToolCall) },
        new object[] { typeof(OutputItemImageGenToolCall) },
        new object[] { typeof(OutputItemLocalShellToolCall) },
        new object[] { typeof(OutputItemLocalShellToolCallOutput) },
        new object[] { typeof(OutputItemMcpApprovalRequest) },
        new object[] { typeof(OutputItemMcpApprovalResponseResource) },
        new object[] { typeof(OutputItemMcpListTools) },
        new object[] { typeof(OutputItemMcpToolCall) },
        new object[] { typeof(OutputItemMessage) },
        new object[] { typeof(OutputItemMessage) },
        new object[] { typeof(OutputItemReasoningItem) },
        new object[] { typeof(OutputItemWebSearchToolCall) },
        new object[] { typeof(OutputItemFunctionToolCallOutput) },
    };

    /// <summary>
    /// Concrete OutputItem subtypes from Azure.AI.Projects namespace.
    /// </summary>
    public static IEnumerable<object[]> AzureOutputItemTypes => new[]
    {
        new object[] { typeof(A2AToolCall) },
        new object[] { typeof(A2AToolCallOutput) },
        new object[] { typeof(AzureAISearchToolCall) },
        new object[] { typeof(AzureAISearchToolCallOutput) },
        new object[] { typeof(AzureFunctionToolCall) },
        new object[] { typeof(AzureFunctionToolCallOutput) },
        new object[] { typeof(BingCustomSearchToolCall) },
        new object[] { typeof(BingCustomSearchToolCallOutput) },
        new object[] { typeof(BingGroundingToolCall) },
        new object[] { typeof(BingGroundingToolCallOutput) },
        new object[] { typeof(BrowserAutomationToolCall) },
        new object[] { typeof(BrowserAutomationToolCallOutput) },
        new object[] { typeof(FabricDataAgentToolCall) },
        new object[] { typeof(FabricDataAgentToolCallOutput) },
        new object[] { typeof(MemorySearchToolCallItemResource) },
        new object[] { typeof(OAuthConsentRequestOutputItem) },
        new object[] { typeof(OpenApiToolCall) },
        new object[] { typeof(OpenApiToolCallOutput) },
        new object[] { typeof(SharepointGroundingToolCall) },
        new object[] { typeof(SharepointGroundingToolCallOutput) },
        new object[] { typeof(StructuredOutputsOutputItem) },
        new object[] { typeof(WorkflowActionOutputItem) },
    };

    /// <summary>
    /// All concrete OutputItem subtypes (both namespaces).
    /// </summary>
    public static IEnumerable<object[]> AllOutputItemTypes =>
        OpenAIOutputItemTypes.Concat(AzureOutputItemTypes);

    /// <summary>
    /// Concrete OutputContent subtypes.
    /// </summary>
    public static IEnumerable<object[]> OutputContentTypes => new[]
    {
        new object[] { typeof(OutputContentOutputTextContent) },
        new object[] { typeof(OutputContentReasoningTextContent) },
        new object[] { typeof(OutputContentRefusalContent) },
    };

    /// <summary>
    /// Concrete MessageContent subtypes.
    /// </summary>
    public static IEnumerable<object[]> MessageContentTypes => new[]
    {
        new object[] { typeof(MessageContentOutputTextContent) },
        new object[] { typeof(MessageContentRefusalContent) },
    };

    // ========================================
    // OutputItem subtypes
    // ========================================

    [TestCaseSource(nameof(AllOutputItemTypes))]
    public void OutputItemSubtype_HasAtLeastOnePublicConstructor(Type type)
    {
        var publicCtors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True,
            $"{type.Name} should have at least one public constructor but has none.");
    }

    // ========================================
    // OutputContent subtypes
    // ========================================

    [TestCaseSource(nameof(OutputContentTypes))]
    public void OutputContentSubtype_HasAtLeastOnePublicConstructor(Type type)
    {
        var publicCtors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True,
            $"{type.Name} should have at least one public constructor but has none.");
    }

    [TestCaseSource(nameof(MessageContentTypes))]
    public void MessageContentSubtype_HasAtLeastOnePublicConstructor(Type type)
    {
        var publicCtors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True,
            $"{type.Name} should have at least one public constructor but has none.");
    }

    // ========================================
    // Models.ResponseObject and Models.ResponseErrorInfo
    // ========================================

    [Test]
    public void Response_HasAtLeastOnePublicConstructor()
    {
        var publicCtors = typeof(Models.ResponseObject).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True, "Response should have at least one public constructor.");
    }

    [Test]
    public void ResponseError_HasAtLeastOnePublicConstructor()
    {
        var publicCtors = typeof(Models.ResponseErrorInfo).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True, "ResponseError should have at least one public constructor.");
    }

    [Test]
    public void CreateResponse_HasAtLeastOnePublicConstructor()
    {
        var publicCtors = typeof(CreateResponse).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True, "CreateResponse should have at least one public constructor.");
    }

    // ========================================
    // Abstract base types must NOT be constructable
    // ========================================

    [Test]
    public void OutputItem_HasNoPublicConstructors()
    {
        var publicCtors = typeof(OutputItem).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void OutputItem_IsAbstract()
    {
        Assert.That(typeof(OutputItem).IsAbstract, Is.True);
    }

    [Test]
    public void OutputContent_HasNoPublicConstructors()
    {
        var publicCtors = typeof(OutputContent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void OutputContent_IsAbstract()
    {
        Assert.That(typeof(OutputContent).IsAbstract, Is.True);
    }

    [Test]
    public void MessageContent_HasNoPublicConstructors()
    {
        var publicCtors = typeof(MessageContent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void MessageContent_IsAbstract()
    {
        Assert.That(typeof(MessageContent).IsAbstract, Is.True);
    }

    // ========================================
    // Counts
    // ========================================

    [Test]
    public void AllOutputItemTypes_Count_Is46()
    {
        Assert.That(AllOutputItemTypes.Count(), Is.EqualTo(46));
    }
}
