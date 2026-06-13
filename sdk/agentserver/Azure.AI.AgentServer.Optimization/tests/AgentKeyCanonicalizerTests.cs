// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class AgentKeyCanonicalizerTests
{
    [TestCase("triage-agent", "TRIAGE_AGENT")]
    [TestCase("triage_agent", "TRIAGE_AGENT")]
    [TestCase("TRIAGE_AGENT", "TRIAGE_AGENT")]
    [TestCase("Triage-Agent", "TRIAGE_AGENT")]
    [TestCase("agent1", "AGENT1")]
    [TestCase("a-b-c-d-e", "A_B_C_D_E")]
    [TestCase("a", "A")]
    public void TryCanonicalize_ValidKeys_ProduceExpected(string input, string expected)
    {
        Assert.That(AgentKeyCanonicalizer.TryCanonicalize(input), Is.EqualTo(expected));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase("triage agent")]   // space
    [TestCase("triage!agent")]   // punctuation
    [TestCase("triage.agent")]   // dot
    [TestCase("triage/agent")]   // slash
    [TestCase("triäge-agent")]   // non-ASCII
    public void TryCanonicalize_InvalidKeys_ReturnNull(string input)
    {
        Assert.That(AgentKeyCanonicalizer.TryCanonicalize(input), Is.Null);
    }

    [Test]
    public void Canonicalize_InvalidKey_ThrowsArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(
            () => AgentKeyCanonicalizer.Canonicalize("bad key!", "myParam"));
        Assert.That(ex!.ParamName, Is.EqualTo("myParam"));
    }

    [Test]
    public void Canonicalize_HyphenAndUnderscoreVariants_Collide()
    {
        // Intentional: both map to the same canonical form. Multi-agent
        // hosts must detect this collision at registration time.
        var a = AgentKeyCanonicalizer.Canonicalize("triage-agent", "x");
        var b = AgentKeyCanonicalizer.Canonicalize("triage_agent", "x");
        Assert.That(a, Is.EqualTo(b));
    }
}

[TestFixture]
public class CandidateIdValidatorTests
{
    [TestCase("cand_001")]
    [TestCase("cand-abc-123")]
    [TestCase("MyCandidate42")]
    public void IsValid_AcceptableIds_AreTrue(string id)
    {
        Assert.That(CandidateIdValidator.IsValid(id), Is.True);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("../escape")]
    [TestCase("a/b")]
    [TestCase("a\\b")]
    [TestCase("..")]
    [TestCase("foo/../bar")]
    public void IsValid_InvalidIds_AreFalse(string id)
    {
        Assert.That(CandidateIdValidator.IsValid(id), Is.False);
    }

    [Test]
    public void ThrowIfInvalid_RejectsParentTraversal()
    {
        Assert.Throws<ArgumentException>(
            () => CandidateIdValidator.ThrowIfInvalid("../escape", "candidateId"));
    }
}
