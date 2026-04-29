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
}
