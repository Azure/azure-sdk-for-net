// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests;

public class IdGeneratorTests
{
    // ── T003: NewId() format tests ─────────────────────────────────

    [Test]
    public void NewId_ReturnsStringWithPrefixUnderscoreBody()
    {
        var id = IdGenerator.NewId("test");

        XAssert.Contains("_", id);
        XAssert.StartsWith("test_", id);
    }

    [Test]
    public void NewId_BodyIs50Characters()
    {
        var id = IdGenerator.NewId("test");
        var body = id[(id.IndexOf('_') + 1)..];

        Assert.That(body.Length, Is.EqualTo(50));
    }

    [Test]
    public void NewId_PartitionKeyIsFirst18CharsOfBody()
    {
        var id = IdGenerator.NewId("test");
        var body = id[(id.IndexOf('_') + 1)..];
        var pk = body[..18];

        // First 16 chars are lowercase hex, last 2 chars are "00"
        XAssert.Matches("^[0-9a-f]{16}00$", pk);
    }

    [Test]
    public void NewId_EntropyIs32AlphanumericChars()
    {
        var id = IdGenerator.NewId("test");
        var body = id[(id.IndexOf('_') + 1)..];
        var entropy = body[18..];

        Assert.That(entropy.Length, Is.EqualTo(32));
        XAssert.Matches("^[A-Za-z0-9]{32}$", entropy);
    }

    [Test]
    public void NewId_DelimiterIsAddedAutomatically()
    {
        // Prefix should NOT include underscore — it's added by NewId
        var id = IdGenerator.NewId("caresp");

        XAssert.StartsWith("caresp_", id);
        // Total = "caresp_" (7) + 50 body = 57
        Assert.That(id.Length, Is.EqualTo(57));
    }

    [Test]
    public void NewId_ProducesUniqueIds()
    {
        var ids = Enumerable.Range(0, 100)
            .Select(_ => IdGenerator.NewId("test"))
            .ToHashSet();

        Assert.That(ids.Count, Is.EqualTo(100));
    }

    [Test]
    public void NewId_DifferentPrefixesProduceDifferentFormats()
    {
        var msgId = IdGenerator.NewId("msg");
        var fcId = IdGenerator.NewId("fc");

        XAssert.StartsWith("msg_", msgId);
        XAssert.StartsWith("fc_", fcId);
    }

    // ── T005: ExtractPartitionKey tests ────────────────────────────

    [Test]
    public void ExtractPartitionKey_NewFormat_ReturnsFirst18Chars()
    {
        var id = IdGenerator.NewId("caresp");
        var body = id[(id.IndexOf('_') + 1)..];
        var expectedPk = body[..18];

        var pk = IdGenerator.ExtractPartitionKey(id);

        Assert.That(pk, Is.EqualTo(expectedPk));
        Assert.That(pk.Length, Is.EqualTo(18));
    }

    [Test]
    public void ExtractPartitionKey_LegacyFormat_ReturnsLast16Chars()
    {
        // Legacy format: prefix_<32 entropy><16 hex pk> = 48-char body
        var legacyId = "resp_" + new string('a', 32) + "ff00112233445566";
        var pk = IdGenerator.ExtractPartitionKey(legacyId);

        Assert.That(pk, Is.EqualTo("ff00112233445566"));
        Assert.That(pk.Length, Is.EqualTo(16));
    }

    [Test]
    public void ExtractPartitionKey_NullId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => IdGenerator.ExtractPartitionKey(null!));
    }

    [Test]
    public void ExtractPartitionKey_EmptyId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => IdGenerator.ExtractPartitionKey(""));
    }

    [Test]
    public void ExtractPartitionKey_NoDelimiter_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => IdGenerator.ExtractPartitionKey("nounderscore"));
    }

    [Test]
    public void ExtractPartitionKey_WrongBodyLength_ThrowsArgumentException()
    {
        // Body length neither 48 nor 50
        Assert.Throws<ArgumentException>(() => IdGenerator.ExtractPartitionKey("test_tooshort"));
    }

    // ── T007: IsValid tests ────────────────────────────────────────

    [Test]
    public void IsValid_NewFormatId_ReturnsTrue()
    {
        var id = IdGenerator.NewId("msg");

        Assert.That(IdGenerator.IsValid(id, out var error), Is.True);
        Assert.That(error, Is.Null);
    }

    [Test]
    public void IsValid_LegacyFormatId_ReturnsTrue()
    {
        var legacyId = "msg_" + new string('a', 32) + "ff00112233445566";

        Assert.That(IdGenerator.IsValid(legacyId, out var error), Is.True);
        Assert.That(error, Is.Null);
    }

    [Test]
    public void IsValid_Null_ReturnsFalse()
    {
        Assert.That(IdGenerator.IsValid(null!, out var error), Is.False);
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void IsValid_Empty_ReturnsFalse()
    {
        Assert.That(IdGenerator.IsValid("", out var error), Is.False);
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void IsValid_NoDelimiter_ReturnsFalse()
    {
        Assert.That(IdGenerator.IsValid("550e8400-e29b-41d4-a716-446655440000", out var error), Is.False);
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void IsValid_WrongBodyLength_ReturnsFalse()
    {
        Assert.That(IdGenerator.IsValid("msg_12345", out var error), Is.False);
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void IsValid_AllowedPrefixes_AcceptsMatchingPrefix()
    {
        var id = IdGenerator.NewId("msg");

        Assert.That(IdGenerator.IsValid(id, out _, ["msg", "fc"]), Is.True);
    }

    [Test]
    public void IsValid_AllowedPrefixes_RejectsNonMatchingPrefix()
    {
        var id = IdGenerator.NewId("msg");

        Assert.That(IdGenerator.IsValid(id, out var error, ["fc", "rs"]), Is.False);
        Assert.That(error, Is.Not.Null);
    }

    // ── T009: Hint propagation tests ───────────────────────────────

    [Test]
    public void NewId_WithHint_PropagatesPartitionKey()
    {
        var responseId = IdGenerator.NewId("caresp");
        var messageId = IdGenerator.NewId("msg", responseId);

        var responsePk = IdGenerator.ExtractPartitionKey(responseId);
        var messagePk = IdGenerator.ExtractPartitionKey(messageId);

        Assert.That(messagePk, Is.EqualTo(responsePk));
    }

    [Test]
    public void NewId_WithHint_SamePartitionKeyExtracted()
    {
        var hint = IdGenerator.NewId("caresp");
        var id1 = IdGenerator.NewId("msg", hint);
        var id2 = IdGenerator.NewId("fc", hint);

        var pk1 = IdGenerator.ExtractPartitionKey(id1);
        var pk2 = IdGenerator.ExtractPartitionKey(id2);

        Assert.That(pk2, Is.EqualTo(pk1));
    }

    [Test]
    public void NewId_WithLegacyHint_PropagatesPartitionKey()
    {
        // Legacy format: prefix_<32 entropy><16 hex pk>
        var legacyPk = "ff00112233445566";
        var legacyId = "resp_" + new string('a', 32) + legacyPk;

        var newId = IdGenerator.NewId("msg", legacyId);
        var newBody = newId[(newId.IndexOf('_') + 1)..];

        // New format embeds the legacy pk + "00" suffix at the start
        var newPk = newBody[..18];
        Assert.That(newPk, Is.EqualTo(legacyPk + "00"));
    }

    [Test]
    public void NewId_WithEmptyHint_AutoGeneratesPartitionKey()
    {
        var id1 = IdGenerator.NewId("test", "");
        var id2 = IdGenerator.NewId("test", "");

        // Different partition keys (overwhelmingly likely)
        var pk1 = IdGenerator.ExtractPartitionKey(id1);
        var pk2 = IdGenerator.ExtractPartitionKey(id2);

        Assert.That(pk2, Is.Not.EqualTo(pk1));
    }

    [Test]
    public void NewId_WithNullHint_AutoGeneratesPartitionKey()
    {
        var id1 = IdGenerator.NewId("test", null!);
        var id2 = IdGenerator.NewId("test", null!);

        var pk1 = IdGenerator.ExtractPartitionKey(id1);
        var pk2 = IdGenerator.ExtractPartitionKey(id2);

        Assert.That(pk2, Is.Not.EqualTo(pk1));
    }

    // ── T011: Thread safety ────────────────────────────────────────

    [Test]
    public void NewId_IsThreadSafe_1000ParallelCalls()
    {
        var ids = new System.Collections.Concurrent.ConcurrentBag<string>();

        Parallel.For(0, 1000, _ =>
        {
            ids.Add(IdGenerator.NewId("test"));
        });

        Assert.That(ids.Distinct().Count(), Is.EqualTo(1000));
    }

    // ── T012: Prefix validation tests ──────────────────────────────

    [Test]
    public void NewId_NullPrefix_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => IdGenerator.NewId(null!));
    }

    [Test]
    public void NewId_EmptyPrefix_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => IdGenerator.NewId(""));
    }

    // ── T014-T017: Convenience method tests ────────────────────────

    [Test]
    public void NewResponseId_ProducesCarespPrefix()
    {
        var id = IdGenerator.NewResponseId();

        XAssert.StartsWith("caresp_", id);
        Assert.That(id.Length, Is.EqualTo(57)); // "caresp_" (7) + 50 body
    }

    [Test]
    public void NewResponseId_WithHint_PropagatesPartitionKey()
    {
        var hint = IdGenerator.NewResponseId();
        var id = IdGenerator.NewResponseId(hint);

        Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(IdGenerator.ExtractPartitionKey(hint)));
    }

    [Test]
    public void NewMessageItemId_ProducesMsgPrefix()
    {
        var id = IdGenerator.NewMessageItemId();

        XAssert.StartsWith("msg_", id);
        Assert.That(id.Length, Is.EqualTo(54)); // "msg_" (4) + 50
    }

    [Test]
    public void NewMessageItemId_WithHint_PropagatesPartitionKey()
    {
        var hint = IdGenerator.NewResponseId();
        var id = IdGenerator.NewMessageItemId(hint);

        Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(IdGenerator.ExtractPartitionKey(hint)));
    }

    [Test]
    public void NewFunctionCallItemId_ProducesFcPrefix()
    {
        var id = IdGenerator.NewFunctionCallItemId();

        XAssert.StartsWith("fc_", id);
    }

    [Test]
    public void NewFunctionCallItemId_WithHint_PropagatesPartitionKey()
    {
        var hint = IdGenerator.NewResponseId();
        var id = IdGenerator.NewFunctionCallItemId(hint);

        Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(IdGenerator.ExtractPartitionKey(hint)));
    }

    [TestCase("rs")]
    [TestCase("fs")]
    [TestCase("ws")]
    [TestCase("ci")]
    [TestCase("ig")]
    [TestCase("mcp")]
    [TestCase("mcpl")]
    [TestCase("ctc")]
    public void ConvenienceMethod_ProducesCorrectPrefix(string expectedPrefix)
    {
        var id = expectedPrefix switch
        {
            "rs" => IdGenerator.NewReasoningItemId(),
            "fs" => IdGenerator.NewFileSearchCallItemId(),
            "ws" => IdGenerator.NewWebSearchCallItemId(),
            "ci" => IdGenerator.NewCodeInterpreterCallItemId(),
            "ig" => IdGenerator.NewImageGenCallItemId(),
            "mcp" => IdGenerator.NewMcpCallItemId(),
            "mcpl" => IdGenerator.NewMcpListToolsItemId(),
            "ctc" => IdGenerator.NewCustomToolCallItemId(),
            _ => throw new ArgumentException($"Unknown prefix: {expectedPrefix}")
        };

        XAssert.StartsWith($"{expectedPrefix}_", id);
        var body = id[(id.IndexOf('_') + 1)..];
        Assert.That(body.Length, Is.EqualTo(50));
    }

    [TestCase("rs")]
    [TestCase("fs")]
    [TestCase("ws")]
    [TestCase("ci")]
    [TestCase("ig")]
    [TestCase("mcp")]
    [TestCase("mcpl")]
    [TestCase("ctc")]
    public void ConvenienceMethod_WithHint_PropagatesPartitionKey(string prefix)
    {
        var hint = IdGenerator.NewResponseId();
        var id = prefix switch
        {
            "rs" => IdGenerator.NewReasoningItemId(hint),
            "fs" => IdGenerator.NewFileSearchCallItemId(hint),
            "ws" => IdGenerator.NewWebSearchCallItemId(hint),
            "ci" => IdGenerator.NewCodeInterpreterCallItemId(hint),
            "ig" => IdGenerator.NewImageGenCallItemId(hint),
            "mcp" => IdGenerator.NewMcpCallItemId(hint),
            "mcpl" => IdGenerator.NewMcpListToolsItemId(hint),
            "ctc" => IdGenerator.NewCustomToolCallItemId(hint),
            _ => throw new ArgumentException($"Unknown prefix: {prefix}")
        };

        Assert.That(IdGenerator.ExtractPartitionKey(id), Is.EqualTo(IdGenerator.ExtractPartitionKey(hint)));
    }
}
