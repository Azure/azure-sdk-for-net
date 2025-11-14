// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RandomExtensionsTests
{
    [Test]
    public void NewGuid_WithSameRandomSeed_ReturnsSameGuid()
    {
        const int seed = 12345;
        var random1 = new Random(seed);
        var random2 = new Random(seed);

        var guid1 = random1.NewGuid();
        var guid2 = random2.NewGuid();

        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_WithDifferentRandomSeeds_ReturnsDifferentGuids()
    {
        var random1 = new Random(12345);
        var random2 = new Random(54321);

        var guid1 = random1.NewGuid();
        var guid2 = random2.NewGuid();

        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_MultipleCallsWithSameSeed_ReturnsDeterministicSequence()
    {
        const int seed = 98765;
        var random1 = new Random(seed);
        var random2 = new Random(seed);

        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();
        for (int i = 0; i < 10; i++)
        {
            sequence1.Add(random1.NewGuid());
            sequence2.Add(random2.NewGuid());
        }

        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_MultipleCallsWithSameInstance_ReturnsDifferentGuids()
    {
        var random = new Random(12345);
        var guid1 = random.NewGuid();
        var guid2 = random.NewGuid();
        var guid3 = random.NewGuid();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(guid1, Is.Not.EqualTo(guid2));
            Assert.That(guid2, Is.Not.EqualTo(guid3));
        }
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewGuid_WithDefaultRandom_ReturnsValidGuid()
    {
        var random = new Random();
        var guid = random.NewGuid();

        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
        Assert.That(guid.ToString().Length, Is.EqualTo(36)); // Standard GUID string format
    }

    [Test]
    public void NewGuid_DifferentRandomInstances_ProduceDifferentResults()
    {
        // Use different seeds to ensure different Random instances on all .NET versions
        var random1 = new Random(12345);
        var random2 = new Random(54321);
        var allSame = true;
        for (int i = 0; i < 10; i++)
        {
            var guid1 = random1.NewGuid();
            var guid2 = random2.NewGuid();
            if (guid1 != guid2)
            {
                allSame = false;
                break;
            }
        }
        Assert.That(allSame, Is.False, "Random instances with different seeds should produce different GUID sequences");
    }

    [Test]
    public void NewGuid_RepeatedCallsWithSameSeed_ProducesConsistentPattern()
    {
        const int seed = 42;
        var firstRun = new List<Guid>();
        var secondRun = new List<Guid>();
        for (int run = 0; run < 2; run++)
        {
            var random = new Random(seed);
            var currentRun = run == 0 ? firstRun : secondRun;
            for (int i = 0; i < 5; i++)
            {
                currentRun.Add(random.NewGuid());
            }
        }
        Assert.That(secondRun, Is.EqualTo(firstRun));
    }
}
