// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.Core;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Persistence;

public class FoundryConversationThreadRepositoryTests
{
    private static readonly Uri ProjectEndpoint = new("https://contoso.services.ai.azure.com/api/projects/demo");

    [Test]
    public async Task Get_WithSameConversationId_ReturnsSameThread()
    {
        var repository = CreateRepository();

        var first = await repository.Get("conv_123").ConfigureAwait(false);
        var second = await repository.Get("conv_123").ConfigureAwait(false);

        Assert.That(first, Is.SameAs(second));
    }

    [Test]
    public async Task Get_CreatesInMemoryAgentThreadWithMessageStore()
    {
        var repository = CreateRepository();

        var thread = await repository.Get("conv_456").ConfigureAwait(false);

        Assert.That(thread, Is.InstanceOf<InMemoryAgentThread>());
        Assert.That(((InMemoryAgentThread)thread).MessageStore, Is.Not.Null);
    }

    [Test]
    public async Task Set_WithExistingThread_ReplacesThreadEntry()
    {
        var repository = CreateRepository();
        var first = await repository.Get("conv_789").ConfigureAwait(false);
        var replacement = new TestAgentThread();

        await repository.Set("conv_789", replacement).ConfigureAwait(false);
        var updated = await repository.Get("conv_789").ConfigureAwait(false);

        Assert.That(updated, Is.SameAs(replacement));
        Assert.That(updated, Is.Not.SameAs(first));
    }

    private static FoundryConversationThreadRepository CreateRepository()
    {
        return new FoundryConversationThreadRepository(ProjectEndpoint, new TestTokenCredential());
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

    private sealed class TestAgentThread : InMemoryAgentThread
    {
        public TestAgentThread()
            : base(Array.Empty<ChatMessage>())
        {
        }
    }
}
