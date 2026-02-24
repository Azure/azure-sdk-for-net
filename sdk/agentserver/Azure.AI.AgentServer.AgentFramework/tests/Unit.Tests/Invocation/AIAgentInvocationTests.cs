// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Text.Json;
using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Moq;

using AgentRunContext = Azure.AI.AgentServer.Responses.Invocation.AgentRunContext;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Invocation;

public class AIAgentInvocationTests
{
    // Valid ID format: prefix_<18 char partition key><32 char entropy>
    private const string ValidConversationId = "conv_abc123def456ghi7jkl012mno345pqr678stu901vwx234abcdef";

    [Test]
    public async Task GetSession_PassesCurrentAgentToThreadRepository()
    {
        var agent = new Mock<AIAgent>(MockBehavior.Strict);
        var repository = new Mock<IAgentThreadRepository>(MockBehavior.Strict);
        var expectedSession = new Mock<AgentSession>().Object;

        repository.Setup(mock => mock.Get(It.IsAny<string>(), agent.Object))
            .ReturnsAsync(expectedSession);

        var invocation = new AIAgentInvocation(agent.Object, repository.Object);
        var context = CreateContextWithConversation();

        var getSessionMethod = typeof(AIAgentInvocation)
            .GetMethod("GetSession", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.That(getSessionMethod, Is.Not.Null);

        var task = (Task<AgentSession?>)getSessionMethod!.Invoke(invocation, [context])!;
        var actualSession = await task.ConfigureAwait(false);

        Assert.That(actualSession, Is.SameAs(expectedSession));
        repository.Verify(mock => mock.Get(It.IsAny<string>(), agent.Object), Times.Once);
    }

    [Test]
    public async Task GetSession_WithNullConversationId_ReturnsNullWithoutCallingRepository()
    {
        var agent = new Mock<AIAgent>(MockBehavior.Strict);
        var repository = new Mock<IAgentThreadRepository>(MockBehavior.Strict);

        var invocation = new AIAgentInvocation(agent.Object, repository.Object);
        var context = CreateContextWithoutConversation();

        var getSessionMethod = typeof(AIAgentInvocation)
            .GetMethod("GetSession", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.That(getSessionMethod, Is.Not.Null);

        var task = (Task<AgentSession?>)getSessionMethod!.Invoke(invocation, [context])!;
        var actualSession = await task.ConfigureAwait(false);

        Assert.That(actualSession, Is.Null);
        repository.Verify(mock => mock.Get(It.IsAny<string?>(), It.IsAny<AIAgent>()), Times.Never);
    }

    private static AgentRunContext CreateContextWithConversation()
    {
        var json = "{\"input\": \"Hello\", \"conversation\": {\"id\": \"" + ValidConversationId + "\"}}";
        var request = JsonSerializer.Deserialize<CreateResponseRequest>(json, JsonExtensions.DefaultJsonSerializerOptions)!;
        return new AgentRunContext(request);
    }

    private static AgentRunContext CreateContextWithoutConversation()
    {
        return new AgentRunContext(
            new CreateResponseRequest
            {
                Input = BinaryData.FromString("\"Hello\"")
            });
    }
}
