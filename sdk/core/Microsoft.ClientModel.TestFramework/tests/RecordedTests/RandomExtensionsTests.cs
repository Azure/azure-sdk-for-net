// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class RandomExtensionsTests
{
    [Test]
    public void NewGuid_WithSameRandomSeed_ReturnsSameGuid()
    {
        // Arrange
        const int seed = 12345;
        var random1 = new Random(seed);
        var random2 = new Random(seed);

        // Act
        var guid1 = random1.NewGuid();
        var guid2 = random2.NewGuid();

        // Assert
        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_WithDifferentRandomSeeds_ReturnsDifferentGuids()
    {
        // Arrange
        var random1 = new Random(12345);
        var random2 = new Random(54321);

        // Act
        var guid1 = random1.NewGuid();
        var guid2 = random2.NewGuid();

        // Assert
        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_ReturnsValidGuid()
    {
        // Arrange
        var random = new Random();

        // Act
        var guid = random.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
        Assert.That(guid.ToString(), Is.Not.Empty);
    }

    [Test]
    public void NewGuid_MultipleCallsWithSameSeed_ReturnsDeterministicSequence()
    {
        // Arrange
        const int seed = 98765;
        var random1 = new Random(seed);
        var random2 = new Random(seed);

        // Act
        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();

        for (int i = 0; i < 10; i++)
        {
            sequence1.Add(random1.NewGuid());
            sequence2.Add(random2.NewGuid());
        }

        // Assert
        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_MultipleCallsWithSameInstance_ReturnsDifferentGuids()
    {
        // Arrange
        var random = new Random(12345);

        // Act
        var guid1 = random.NewGuid();
        var guid2 = random.NewGuid();
        var guid3 = random.NewGuid();

        // Assert
        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid2, Is.Not.EqualTo(guid3));
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewGuid_WithDefaultRandom_ReturnsValidGuid()
    {
        // Arrange
        var random = new Random();

        // Act
        var guid = random.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
        Assert.That(guid.ToString().Length, Is.EqualTo(36)); // Standard GUID string format
    }

    [Test]
    public void NewGuid_GeneratesGuidWithAllBytes()
    {
        // Arrange
        var random = new Random(42);

        // Act
        var guid = random.NewGuid();
        var guidBytes = guid.ToByteArray();

        // Assert
        Assert.That(guidBytes.Length, Is.EqualTo(16));
        Assert.That(guidBytes, Is.Not.All.EqualTo(0)); // At least some bytes should be non-zero
    }

    [Test]
    public void NewGuid_DifferentRandomInstances_ProduceDifferentResults()
    {
        // Arrange
        var random1 = new Random();
        var random2 = new Random();

        // Act & Assert (run multiple times to increase confidence)
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

        Assert.That(allSame, Is.False, "Different Random instances should produce different GUID sequences");
    }

    [Test]
    public void NewGuid_WithZeroSeed_ReturnsValidGuid()
    {
        // Arrange
        var random = new Random(0);

        // Act
        var guid = random.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMaxIntSeed_ReturnsValidGuid()
    {
        // Arrange
        var random = new Random(int.MaxValue);

        // Act
        var guid = random.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMinIntSeed_ReturnsValidGuid()
    {
        // Arrange
        var random = new Random(int.MinValue);

        // Act
        var guid = random.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_RepeatedCallsWithSameSeed_ProducesConsistentPattern()
    {
        // Arrange
        const int seed = 42;

        // Act
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

        // Assert
        Assert.That(secondRun, Is.EqualTo(firstRun));
    }

    [Test]
    public void NewGuid_UsesRandomByteGeneration()
    {
        // Arrange
        var random = new Random(123);

        // Act
        var guid1 = random.NewGuid();
        var guid2 = random.NewGuid();

        var bytes1 = guid1.ToByteArray();
        var bytes2 = guid2.ToByteArray();

        // Assert - The bytes should be different between GUIDs
        Assert.That(bytes1, Is.Not.EqualTo(bytes2));
    }

    [Test]
    public void NewGuid_GeneratedFromRandomBytes_HasCorrectStructure()
    {
        // Arrange
        var random = new Random(456);

        // Act
        var guid = random.NewGuid();
        var guidString = guid.ToString();

        // Assert - Should match GUID format (8-4-4-4-12 hex digits)
        Assert.That(guidString, Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
    }

    [Test]
    public void NewGuid_PerformanceTest_CompletesInReasonableTime()
    {
        // Arrange
        var random = new Random();
        const int iterations = 1000;

        // Act
        var startTime = DateTime.UtcNow;
        for (int i = 0; i < iterations; i++)
        {
            random.NewGuid();
        }
        var duration = DateTime.UtcNow - startTime;

        // Assert - Should complete quickly
        Assert.That(duration.TotalSeconds, Is.LessThan(1.0));
    }
}
