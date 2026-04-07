// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponseContextExtensionsTests
{
    private static ResponseContext CreateContext()
    {
        var responseId = IdGenerator.NewResponseId();
        return new ResponseContext(responseId);
    }

    [Test]
    public void NewMessageItemId_StartsWithMsgPrefix()
    {
        var context = CreateContext();
        var id = context.NewMessageItemId();
        XAssert.StartsWith("msg_", id);
    }

    [Test]
    public void NewMessageItemId_SharesPartitionKeyWithResponse()
    {
        var context = CreateContext();
        var id = context.NewMessageItemId();

        var responsePk = IdGenerator.ExtractPartitionKey(context.ResponseId);
        var itemPk = IdGenerator.ExtractPartitionKey(id);
        Assert.That(itemPk, Is.EqualTo(responsePk));
    }

    [Test]
    public void NewFunctionCallItemId_StartsWithFcPrefix()
    {
        var context = CreateContext();
        var id = context.NewFunctionCallItemId();
        XAssert.StartsWith("fc_", id);
    }

    [Test]
    public void NewFunctionCallItemId_SharesPartitionKey()
    {
        var context = CreateContext();
        var id = context.NewFunctionCallItemId();
        Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(IdGenerator.ExtractPartitionKey(context.ResponseId)));
    }

    [Test]
    public void NewReasoningItemId_StartsWithRsPrefix()
    {
        var context = CreateContext();
        var id = context.NewReasoningItemId();
        XAssert.StartsWith("rs_", id);
    }

    [Test]
    public void NewFileSearchCallItemId_StartsWithFsPrefix()
    {
        var context = CreateContext();
        var id = context.NewFileSearchCallItemId();
        XAssert.StartsWith("fs_", id);
    }

    [Test]
    public void NewWebSearchCallItemId_StartsWithWsPrefix()
    {
        var context = CreateContext();
        var id = context.NewWebSearchCallItemId();
        XAssert.StartsWith("ws_", id);
    }

    [Test]
    public void NewCodeInterpreterCallItemId_StartsWithCiPrefix()
    {
        var context = CreateContext();
        var id = context.NewCodeInterpreterCallItemId();
        XAssert.StartsWith("ci_", id);
    }

    [Test]
    public void NewImageGenCallItemId_StartsWithIgPrefix()
    {
        var context = CreateContext();
        var id = context.NewImageGenCallItemId();
        XAssert.StartsWith("ig_", id);
    }

    [Test]
    public void NewMcpCallItemId_StartsWithMcpPrefix()
    {
        var context = CreateContext();
        var id = context.NewMcpCallItemId();
        XAssert.StartsWith("mcp_", id);
    }

    [Test]
    public void NewMcpListToolsItemId_StartsWithMcplPrefix()
    {
        var context = CreateContext();
        var id = context.NewMcpListToolsItemId();
        XAssert.StartsWith("mcpl_", id);
    }

    [Test]
    public void NewCustomToolCallItemId_StartsWithCtcPrefix()
    {
        var context = CreateContext();
        var id = context.NewCustomToolCallItemId();
        XAssert.StartsWith("ctc_", id);
    }

    [Test]
    public void AllMethods_SharePartitionKeyWithResponse()
    {
        var context = CreateContext();
        var responsePk = IdGenerator.ExtractPartitionKey(context.ResponseId);

        var ids = new[]
        {
            context.NewMessageItemId(),
            context.NewFunctionCallItemId(),
            context.NewReasoningItemId(),
            context.NewFileSearchCallItemId(),
            context.NewWebSearchCallItemId(),
            context.NewCodeInterpreterCallItemId(),
            context.NewImageGenCallItemId(),
            context.NewMcpCallItemId(),
            context.NewMcpListToolsItemId(),
            context.NewCustomToolCallItemId(),
        };

        foreach (var id in ids)
        {
            Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(responsePk));
        }
    }

    [Test]
    public void AllMethods_ProduceUniqueIds()
    {
        var context = CreateContext();
        var ids = new HashSet<string>
        {
            context.NewMessageItemId(),
            context.NewFunctionCallItemId(),
            context.NewReasoningItemId(),
            context.NewFileSearchCallItemId(),
            context.NewWebSearchCallItemId(),
            context.NewCodeInterpreterCallItemId(),
            context.NewImageGenCallItemId(),
            context.NewMcpCallItemId(),
            context.NewMcpListToolsItemId(),
            context.NewCustomToolCallItemId(),
        };

        Assert.That(ids.Count, Is.EqualTo(10));
    }
}
