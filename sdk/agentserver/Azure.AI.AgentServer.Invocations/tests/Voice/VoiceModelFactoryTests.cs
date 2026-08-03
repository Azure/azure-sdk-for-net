// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceModelFactoryTests
{
    [Test]
    public void SessionStartEventCopiesAndFreezesCallerMetadata()
    {
        var nested = new Dictionary<string, object?> { ["campaign"] = "renewals" };
        var caller = new Dictionary<string, object?> { ["custom_parameters"] = nested };

        var start = VoiceModelFactory.SessionStartEvent(caller: caller);
        nested["campaign"] = "changed";
        caller["new"] = true;

        var frozenNested = (IReadOnlyDictionary<string, object?>)start.Caller!["custom_parameters"]!;
        Assert.Multiple(() =>
        {
            Assert.That(start.Caller.ContainsKey("new"), Is.False);
            Assert.That(frozenNested["campaign"], Is.EqualTo("renewals"));
        });
    }

    [Test]
    public void ResponseTimeoutFactoriesKeepTargetsExclusive()
    {
        var responseTimeout = VoiceModelFactory.ResponseTimeoutEvent(responseId: "r_1");
        var batchTimeout = VoiceModelFactory.ResponseTimeoutEventForItems(new[] { "in_1", "in_2" });

        Assert.Multiple(() =>
        {
            Assert.That(responseTimeout.ResponseId, Is.EqualTo("r_1"));
            Assert.That(responseTimeout.ItemIds, Is.Null);
            Assert.That(batchTimeout.ResponseId, Is.Null);
            Assert.That(batchTimeout.ItemIds, Is.EqualTo(new[] { "in_1", "in_2" }));
        });
    }
}
