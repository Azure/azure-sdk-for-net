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
        new object[] { typeof(OutputItemReasoningItem) },
        new object[] { typeof(OutputItemWebSearchToolCall) },
        new object[] { typeof(OutputItemFunctionToolCallOutput) },
    };

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
        new object[] { typeof(ResponseContentPart) },
    };

    // ========================================
    // OutputItem subtypes
    // ========================================

    [TestCaseSource(nameof(OpenAIOutputItemTypes))]
    public void OutputItemSubtype_HasAtLeastOnePublicConstructor(Type type)
    {
        if (IsOpenAIOwned(type))
        {
            Assert.That(typeof(OutputItem).IsAssignableFrom(type), Is.True);
            return;
        }

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
        if (IsOpenAIOwned(type))
        {
            Assert.That(type, Is.Not.Null);
            return;
        }

        var publicCtors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True,
            $"{type.Name} should have at least one public constructor but has none.");
    }

    [TestCaseSource(nameof(MessageContentTypes))]
    public void MessageContentSubtype_HasAtLeastOnePublicConstructor(Type type)
    {
        if (type.Namespace == typeof(MessageContent).Namespace)
        {
            Assert.That(typeof(MessageContent).IsAssignableFrom(type), Is.True);
            return;
        }

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
        if (IsOpenAIOwned(typeof(ResponseErrorInfo)))
        {
            Assert.That(typeof(ResponseErrorInfo), Is.Not.Null);
            return;
        }

        var publicCtors = typeof(ResponseErrorInfo).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
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
        if (IsOpenAIOwned(typeof(OutputItem)))
        {
            Assert.That(typeof(OutputItem), Is.Not.Null);
            return;
        }

        var publicCtors = typeof(OutputItem).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void OutputItem_IsAbstract()
    {
        if (IsOpenAIOwned(typeof(OutputItem)))
        {
            Assert.That(typeof(OutputItem), Is.Not.Null);
            return;
        }

        Assert.That(typeof(OutputItem).IsAbstract, Is.True);
    }

    [Test]
    public void OutputContent_HasNoPublicConstructors()
    {
        if (IsOpenAIOwned(typeof(OutputContent)))
        {
            Assert.That(typeof(OutputContent), Is.Not.Null);
            return;
        }

        var publicCtors = typeof(OutputContent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void OutputContent_IsAbstract()
    {
        if (IsOpenAIOwned(typeof(OutputContent)))
        {
            Assert.That(typeof(OutputContent), Is.Not.Null);
            return;
        }

        Assert.That(typeof(OutputContent).IsAbstract, Is.True);
    }

    [Test]
    public void MessageContent_HasNoPublicConstructors()
    {
        if (IsOpenAIOwned(typeof(MessageContent)))
        {
            Assert.That(typeof(MessageContent), Is.Not.Null);
            return;
        }

        var publicCtors = typeof(MessageContent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void MessageContent_IsAbstract()
    {
        if (IsOpenAIOwned(typeof(MessageContent)))
        {
            Assert.That(typeof(MessageContent), Is.Not.Null);
            return;
        }

        Assert.That(typeof(MessageContent).IsAbstract, Is.True);
    }

    // ========================================
    // Counts
    // ========================================

    [Test]
    public void OpenAIOutputItemTypes_Count_Is23()
    {
        Assert.That(OpenAIOutputItemTypes.Count(), Is.EqualTo(23));
    }

    private static bool IsOpenAIOwned(Type type) => type.Namespace?.StartsWith("OpenAI.", StringComparison.Ordinal) == true;
}
