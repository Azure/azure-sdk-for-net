// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.Core;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Moq;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Persistence;

public class FoundryConversationThreadRepositoryTests
{
    private static readonly Uri ProjectEndpoint = new("https://contoso.services.ai.azure.com/api/projects/demo");

    [Test]
    public async Task Get_WithSameConversationId_ReturnsSameSession()
    {
        var repository = CreateRepository();
        var agent = CreateTestAgent();

        var first = await repository.Get("conv_123", agent).ConfigureAwait(false);
        var second = await repository.Get("conv_123", agent).ConfigureAwait(false);

        Assert.That(first, Is.SameAs(second));
    }

    [Test]
    public async Task Set_WithExistingSession_ReplacesSessionEntry()
    {
        var repository = CreateRepository();
        var agent = CreateTestAgent();

        var first = await repository.Get("conv_789", agent).ConfigureAwait(false);
        var replacement = await agent.CreateSessionAsync().ConfigureAwait(false);

        await repository.Set("conv_789", replacement).ConfigureAwait(false);
        var updated = await repository.Get("conv_789", agent).ConfigureAwait(false);

        Assert.That(updated, Is.SameAs(replacement));
        Assert.That(updated, Is.Not.SameAs(first));
    }

    [Test]
    public async Task Get_WithAgent_CreatesSessionUsingAgent()
    {
        var repository = CreateRepository();
        var agent = CreateTestAgent();

        var session = await repository.Get("conv_with_agent", agent).ConfigureAwait(false);

        Assert.That(session, Is.Not.Null);
        Assert.That(session, Is.InstanceOf<AgentSession>());
    }

    [Test]
    public async Task Get_WithNullConversationId_ReturnsNewSessionFromAgent()
    {
        var repository = CreateRepository();
        var agent = CreateTestAgent();

        var session = await repository.Get(null, agent).ConfigureAwait(false);

        Assert.That(session, Is.Not.Null);
        Assert.That(session, Is.InstanceOf<AgentSession>());
    }

    [Test]
    public void Get_WithNullConversationIdAndNoAgent_ThrowsInvalidOperationException()
    {
        var repository = CreateRepository();

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await repository.Get(null).ConfigureAwait(false));
    }

    [Test]
    public void Set_WithNullConversationId_DoesNotThrow()
    {
        var repository = CreateRepository();
        var agent = CreateTestAgent();

        Assert.DoesNotThrowAsync(async () =>
            await repository.Set(null, await agent.CreateSessionAsync().ConfigureAwait(false)).ConfigureAwait(false));
    }

    private static FoundryConversationThreadRepository CreateRepository()
    {
        return new FoundryConversationThreadRepository(ProjectEndpoint, new TestTokenCredential());
    }

    private static ChatClientAgent CreateTestAgent()
    {
        return new ChatClientAgent(new Mock<IChatClient>().Object);
    }

    private sealed class TestTokenCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new("test-token", DateTimeOffset.UtcNow.AddMinutes(30));

        public override ValueTask<AccessToken> GetTokenAsync(
            TokenRequestContext requestContext,
            CancellationToken cancellationToken)
            => ValueTask.FromResult(GetToken(requestContext, cancellationToken));
    }
}
