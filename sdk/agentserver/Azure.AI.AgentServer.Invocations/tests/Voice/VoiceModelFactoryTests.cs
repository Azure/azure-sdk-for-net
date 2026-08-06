// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
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
    public void SessionStartEventFreezesStringKeyedNestedDictionaryAsDictionary()
    {
        var nested = new Dictionary<string, string> { ["campaign"] = "renewals" };
        var caller = new Dictionary<string, object?> { ["custom_parameters"] = nested };

        var start = VoiceModelFactory.SessionStartEvent(caller: caller);

        Assert.That(
            start.Caller!["custom_parameters"],
            Is.InstanceOf<IReadOnlyDictionary<string, object?>>());
        var frozenNested = (IReadOnlyDictionary<string, object?>)start.Caller["custom_parameters"]!;
        Assert.That(frozenNested["campaign"], Is.EqualTo("renewals"));
    }

    [Test]
    public void SessionStartEventFreezesReadOnlyStringKeyedDictionaryAsDictionary()
    {
        var nested = new ReadOnlyStringDictionary(new Dictionary<string, string>
        {
            ["campaign"] = "renewals",
        });
        var caller = new Dictionary<string, object?> { ["custom_parameters"] = nested };

        var start = VoiceModelFactory.SessionStartEvent(caller: caller);

        var frozenNested = (IReadOnlyDictionary<string, object?>)start.Caller!["custom_parameters"]!;
        Assert.That(frozenNested["campaign"], Is.EqualTo("renewals"));
    }

    [Test]
    public void SessionStartEventRejectsNonStringDictionaryKeys()
    {
        var caller = new Dictionary<string, object?>
        {
            ["custom_parameters"] = new Dictionary<int, string> { [1] = "one" },
        };

        Assert.Throws<ArgumentException>(() => VoiceModelFactory.SessionStartEvent(caller: caller));
    }

    [Test]
    public void SessionStartEventRejectsNestedNonStringDictionaryKeys()
    {
        var caller = new Dictionary<string, object?>
        {
            ["custom_parameters"] = new object[]
            {
                new Dictionary<int, string> { [1] = "one" },
            },
        };

        Assert.Throws<ArgumentException>(() => VoiceModelFactory.SessionStartEvent(caller: caller));
    }

    [Test]
    public void SessionStartEventRejectsMutableCustomValues()
    {
        var metadata = new MutableMetadata { Campaign = "renewals" };
        var caller = new Dictionary<string, object?> { ["custom_parameters"] = metadata };

        Assert.Throws<ArgumentException>(() => VoiceModelFactory.SessionStartEvent(caller: caller));
    }

    [Test]
    public void SessionStartEventPreservesLargeJsonInteger()
    {
        using var document = JsonDocument.Parse("9007199254740993");
        var caller = new Dictionary<string, object?> { ["order_id"] = document.RootElement };

        var start = VoiceModelFactory.SessionStartEvent(caller: caller);

        Assert.That(start.Caller!["order_id"], Is.EqualTo(9007199254740993m));
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

    private sealed class MutableMetadata
    {
        public string Campaign { get; set; } = string.Empty;
    }

    private sealed class ReadOnlyStringDictionary : IReadOnlyDictionary<string, string>
    {
        private readonly IReadOnlyDictionary<string, string> _values;

        public ReadOnlyStringDictionary(IReadOnlyDictionary<string, string> values)
        {
            _values = values;
        }

        public string this[string key] => _values[key];

        public IEnumerable<string> Keys => _values.Keys;

        public IEnumerable<string> Values => _values.Values;

        public int Count => _values.Count;

        public bool ContainsKey(string key) => _values.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _values.GetEnumerator();

        public bool TryGetValue(string key, out string value) => _values.TryGetValue(key, out value!);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
