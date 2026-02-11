// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Moq;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Invocation;

public class AIAgentInvocationTests
{
    [Test]
    public async Task GetThread_PassesCurrentAgentToThreadRepository()
    {
        var agent = new Mock<AIAgent>(MockBehavior.Strict);
        var repository = new Mock<IAgentThreadRepository>(MockBehavior.Strict);
        var expectedThread = new TestAgentThread();

        repository.Setup(mock => mock.Get(It.IsAny<string>(), agent.Object))
            .ReturnsAsync(expectedThread);

        var invocation = new AIAgentInvocation(agent.Object, repository.Object);
        var context = CreateContext();

        var getThreadMethod = typeof(AIAgentInvocation)
            .GetMethod("GetThread", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.That(getThreadMethod, Is.Not.Null);

        var task = (Task<AgentThread?>)getThreadMethod!.Invoke(invocation, [context])!;
        var actualThread = await task.ConfigureAwait(false);

        Assert.That(actualThread, Is.SameAs(expectedThread));
        repository.Verify(mock => mock.Get(It.IsAny<string>(), agent.Object), Times.Once);
    }

    private static AgentRunContext CreateContext()
    {
        return new AgentRunContext(
            new CreateResponseRequest
            {
                Input = BinaryData.FromString("\"Hello\"")
            });
    }

    private sealed class TestAgentThread : InMemoryAgentThread
    {
        public TestAgentThread()
            : base(Array.Empty<ChatMessage>())
        {
        }
    }
}
