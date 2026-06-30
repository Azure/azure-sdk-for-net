// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class CredentialSectionHasherTests
{
    private static IConfigurationSection BuildSection(string sectionName, IDictionary<string, string?> data)
    {
        var root = new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        return root.GetSection(sectionName);
    }

    [Test]
    public void ComputeKey_ValueContainingDelimiters_DoesNotCollideWithSplitLeaves()
    {
        // Two distinct configurations:
        //   A) one leaf "a" whose VALUE happens to contain ';' and '=' bytes
        //      that look like the canonical separators.
        //   B) two separate leaves "a" = "b" and "c" = "d"
        // Without unambiguous encoding, both serialize to "a=b;c=d;"
        // → identical hash → cache key collision → wrong provider could be
        // handed back to a caller. Keys are sorted ascending so the
        // collision aligns when the second-leaf name sorts after the first.
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:a"] = "b;c=d",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:a"] = "b",
            ["Cred:c"] = "d",
        });

        string keyA = CredentialSectionHasher.ComputeKey(a);
        string keyB = CredentialSectionHasher.ComputeKey(b);

        Assert.That(keyA, Is.Not.EqualTo(keyB),
            "Different sections must produce different cache keys; a value that contains ';' or '=' bytes must not be confusable with structure.");
    }

    [Test]
    public void ComputeKey_KeyEqualsAndValueWithLeadingValue_DoNotCollide()
    {
        // Edge case where a leaf value contains "=" content that could merge
        // with a following leaf to mimic a different layout.
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:foo"] = "bar;baz=qux",
            ["Cred:zz"] = "1",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:foo"] = "bar",
            ["Cred:baz"] = "qux",
            ["Cred:zz"] = "1",
        });

        string keyA = CredentialSectionHasher.ComputeKey(a);
        string keyB = CredentialSectionHasher.ComputeKey(b);

        Assert.That(keyA, Is.Not.EqualTo(keyB));
    }

    [Test]
    public void ComputeKey_IdenticalContent_ProducesSameKey()
    {
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "secret",
            ["Cred:Other"] = "x",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "secret",
            ["Cred:Other"] = "x",
        });

        Assert.That(CredentialSectionHasher.ComputeKey(a), Is.EqualTo(CredentialSectionHasher.ComputeKey(b)));
    }

    [Test]
    public void ComputeKey_DifferentValues_ProduceDifferentKeys()
    {
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "secret-1",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "secret-2",
        });

        Assert.That(CredentialSectionHasher.ComputeKey(a), Is.Not.EqualTo(CredentialSectionHasher.ComputeKey(b)));
    }

    [Test]
    public void ComputeKey_KeysDifferOnlyInCasing_ProduceSameKey()
    {
        // IConfiguration treats keys case-insensitively. Two sections that
        // only differ in the casing of their keys must produce the same hash
        // (and therefore share a cache slot), while values must remain
        // case-sensitive.
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:TenantId"] = "abc",
            ["Cred:ClientId"] = "xyz",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:tenantid"] = "abc",
            ["Cred:CLIENTID"] = "xyz",
        });

        Assert.That(CredentialSectionHasher.ComputeKey(a), Is.EqualTo(CredentialSectionHasher.ComputeKey(b)),
            "Configuration keys are case-insensitive; hash must be invariant to key casing.");
    }

    [Test]
    public void ComputeKey_ValuesDifferOnlyInCasing_ProduceDifferentKeys()
    {
        // Values are case-sensitive — credentials, tokens, secrets etc.
        IConfigurationSection a = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "Secret",
        });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "secret",
        });

        Assert.That(CredentialSectionHasher.ComputeKey(a), Is.Not.EqualTo(CredentialSectionHasher.ComputeKey(b)),
            "Configuration values are case-sensitive; hash must distinguish them.");
    }

    // Golden hashes pin the canonical byte stream so future allocation
    // refactors of ComputeKey can't silently change the cache key for a
    // given input. If you intentionally change the canonical form,
    // re-capture these values and bump cache compatibility expectations.
    [TestCase("empty-section",         "",           "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=")]
    [TestCase("single-leaf",           "single",     "RgUCz7JlTE2PQViot+0NfCxoP39QwEQC9i0RNOwExlk=")]
    [TestCase("two-leaves",            "two",        "1OkjHUXH7QWZhlDIOWJFNy2zcC0WdHBLijz/RsGYCnI=")]
    [TestCase("nested-section",        "nested",     "Ybg8rkMdCUNWbCgSO/FIP3FIGsTrJHgIEd7v7A48E80=")]
    [TestCase("value-with-delimiters", "delimiters", "2XXzrdoYvlBSf0TLCk7+pu/q6F0nrlneJ4M5yaBVlyw=")]
    [TestCase("uppercase-key",         "upperkey",   "1OkjHUXH7QWZhlDIOWJFNy2zcC0WdHBLijz/RsGYCnI=")]
    public void ComputeKey_GoldenHash_StableAcrossRefactors(string scenario, string variant, string expected)
    {
        var data = scenario switch
        {
            "empty-section" => new Dictionary<string, string?>(),
            "single-leaf" => new Dictionary<string, string?> { ["Cred:Token"] = "abc" },
            "two-leaves" => new Dictionary<string, string?> { ["Cred:TenantId"] = "t1", ["Cred:ClientId"] = "c1" },
            "nested-section" => new Dictionary<string, string?> { ["Cred:Inner:A"] = "1", ["Cred:Inner:B"] = "2", ["Cred:X"] = "y" },
            "value-with-delimiters" => new Dictionary<string, string?> { ["Cred:Conn"] = "Server=foo;Key=bar" },
            "uppercase-key" => new Dictionary<string, string?> { ["Cred:TENANTID"] = "t1", ["Cred:CLIENTID"] = "c1" },
            _ => throw new ArgumentException(scenario),
        };

        IConfigurationSection section = BuildSection("Cred", data);
        string actual = CredentialSectionHasher.ComputeKey(section);

        Assert.That(actual, Is.EqualTo(expected),
            $"Canonical byte stream changed for scenario '{scenario}/{variant}'. " +
            "If this is intentional, re-capture the golden values.");
    }

    [Test]
    public void ComputeKey_MultiByteUtf8Value_IsDeterministicAndDistinct()
    {
        // Verify byte-stream is well-defined when values contain multi-byte
        // UTF-8 characters (the length prefix is char-count, not byte-count,
        // so we want to ensure two distinct multi-byte values still hash
        // distinctly and the same value hashes the same way each call).
        IConfigurationSection a1 = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Display"] = "café 漢 🔑" });
        IConfigurationSection a2 = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Display"] = "café 漢 🔑" });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Display"] = "cafe 漢 🔑" });

        string ha1 = CredentialSectionHasher.ComputeKey(a1);
        string ha2 = CredentialSectionHasher.ComputeKey(a2);
        string hb = CredentialSectionHasher.ComputeKey(b);

        Assert.That(ha1, Is.EqualTo(ha2), "Same multi-byte UTF-8 input must hash deterministically.");
        Assert.That(ha1, Is.Not.EqualTo(hb), "Distinct multi-byte UTF-8 values must produce distinct hashes.");
    }

    [Test]
    public void ComputeKey_LongValue_ExercisesArrayPoolPath()
    {
        // StackThreshold in CredentialSectionHasher is 256; values larger than
        // that take the ArrayPool rental path. Verify both determinism and
        // distinctness across that threshold.
        string longA = new string('a', 1024);
        string longB = new string('b', 1024);
        string shortA = new string('a', 100);

        IConfigurationSection a1 = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Blob"] = longA });
        IConfigurationSection a2 = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Blob"] = longA });
        IConfigurationSection b = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Blob"] = longB });
        IConfigurationSection s = BuildSection("Cred", new Dictionary<string, string?> { ["Cred:Blob"] = shortA });

        string ha1 = CredentialSectionHasher.ComputeKey(a1);
        string ha2 = CredentialSectionHasher.ComputeKey(a2);
        string hb = CredentialSectionHasher.ComputeKey(b);
        string hs = CredentialSectionHasher.ComputeKey(s);

        Assert.That(ha1, Is.EqualTo(ha2), "Long value must hash deterministically (ArrayPool path).");
        Assert.That(ha1, Is.Not.EqualTo(hb), "Distinct long values must produce distinct hashes.");
        Assert.That(ha1, Is.Not.EqualTo(hs), "Long and short variants of the same character must hash differently.");
    }

    [Test]
    public void ComputeKey_SectionWithValueAndChildren_IncludesBoth()
    {
        // IConfiguration allows a section to have both a Value and children.
        // Collect adds a leaf at the empty relative path for the section's
        // own value AND walks the children — verify dropping/adding the
        // parent's own value changes the hash.
        IConfigurationSection withParentValue = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred"] = "parent-value",
            ["Cred:Token"] = "child-value",
        });
        IConfigurationSection childrenOnly = BuildSection("Cred", new Dictionary<string, string?>
        {
            ["Cred:Token"] = "child-value",
        });

        Assert.That(CredentialSectionHasher.ComputeKey(withParentValue),
            Is.Not.EqualTo(CredentialSectionHasher.ComputeKey(childrenOnly)),
            "A section's own Value must contribute to the hash even when it also has children.");
    }
}
