// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Engine;

[TestFixture]
public sealed class EtagConflictResolverTests
{
    private const string Owner = "agent-a|session:s1";
    private const string OurInstance = "worker-1-aabbccdd-1000";
    private const string OtherInstance = "worker-2-eeff0011-2000";

    private static TaskRecord InProgress(string instanceId, long expiryCount, long generation = 0) => new()
    {
        Id = "t",
        Status = TaskWireKeys.StatusInProgress,
        Etag = "e2",
        Lease = new Lease
        {
            Owner = Owner,
            InstanceId = instanceId,
            Generation = generation,
            ExpiryCount = expiryCount,
        },
    };

    // Regression: a reclaimed task carries a server expiry_count >= 1 from prior lifetimes while the
    // per-task entry's cached expiry count starts at 0 (the recovered path seeds via Track()). Before
    // the Python-parity fix the resolver consulted expiry_count and spuriously abandoned a legitimate
    // retryable 412, silently dropping the task's terminal output. The lease is still ours (same
    // instance id), so the decision MUST be Retry.
    [Test]
    public void TerminalWrite_ReclaimedTaskWithHigherExpiryCount_StillOurs_Retries()
    {
        var entry = new ActiveTaskEntry("t")
        {
            HeldInstanceId = OurInstance,
            HeldGeneration = 0,
            CachedExpiryCount = 0, // unseeded (recovered via Track)
        };

        EtagConflictResolver.Decision decision = EtagConflictResolver.Resolve(
            WriteIntent.Complete,
            InProgress(OurInstance, expiryCount: 3),
            entry,
            attempt: 1,
            maxAttempts: 5);

        Assert.That(decision, Is.EqualTo(EtagConflictResolver.Decision.Retry));
    }

    // Even with no held identity seeded (HeldInstanceId null) and a high server expiry_count, the
    // resolver must not abandon on the expiry_count leg alone — it should retry.
    [Test]
    public void TerminalWrite_UnseededIdentity_HighExpiryCount_Retries()
    {
        var entry = new ActiveTaskEntry("t")
        { CachedExpiryCount = 0 };

        EtagConflictResolver.Decision decision = EtagConflictResolver.Resolve(
            WriteIntent.Fail,
            InProgress(OurInstance, expiryCount: 5),
            entry,
            attempt: 1,
            maxAttempts: 5);

        Assert.That(decision, Is.EqualTo(EtagConflictResolver.Decision.Retry));
    }

    // A genuine takeover (a different worker instance reacquired the lease) is detected via the
    // instance-id comparison and must abandon so we do not clobber the new owner's lifecycle.
    [Test]
    public void TerminalWrite_DifferentInstance_Abandons()
    {
        var entry = new ActiveTaskEntry("t")
        { HeldInstanceId = OurInstance, CachedExpiryCount = 0 };

        EtagConflictResolver.Decision decision = EtagConflictResolver.Resolve(
            WriteIntent.Complete,
            InProgress(OtherInstance, expiryCount: 1),
            entry,
            attempt: 1,
            maxAttempts: 5);

        Assert.That(decision, Is.EqualTo(EtagConflictResolver.Decision.Abandon));
    }

    // A newer generation on the same instance id (per C-LSE-3 a real handoff bumps identity) also
    // signals a takeover and must abandon.
    [Test]
    public void TerminalWrite_NewerGeneration_Abandons()
    {
        var entry = new ActiveTaskEntry("t")
        { HeldInstanceId = OurInstance, HeldGeneration = 1, CachedExpiryCount = 0 };

        EtagConflictResolver.Decision decision = EtagConflictResolver.Resolve(
            WriteIntent.Complete,
            InProgress(OurInstance, expiryCount: 0, generation: 2),
            entry,
            attempt: 1,
            maxAttempts: 5);

        Assert.That(decision, Is.EqualTo(EtagConflictResolver.Decision.Abandon));
    }

    // Another actor already wrote the terminal — abandon.
    [Test]
    public void TerminalWrite_AlreadyCompleted_Abandons()
    {
        var entry = new ActiveTaskEntry("t")
        { HeldInstanceId = OurInstance, CachedExpiryCount = 0 };
        TaskRecord completed = InProgress(OurInstance, expiryCount: 0);
        completed.Status = TaskWireKeys.StatusCompleted;

        EtagConflictResolver.Decision decision = EtagConflictResolver.Resolve(
            WriteIntent.Complete,
            completed,
            entry,
            attempt: 1,
            maxAttempts: 5);

        Assert.That(decision, Is.EqualTo(EtagConflictResolver.Decision.Abandon));
    }
}
