// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class TestRandomTests
{
    [Test]
    public void Constructor_WithSeed_CreatesInstance()
    {
        // Arrange & Act
        var testRandom = new TestRandom(RecordedTestMode.Record, 12345);

        // Assert
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void Constructor_WithoutSeed_CreatesInstance()
    {
        // Arrange & Act
        var testRandom = new TestRandom(RecordedTestMode.Live);

        // Assert
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void NewGuid_InLiveMode_ReturnsUniqueGuids()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Live);

        // Act
        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();

        // Assert
        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid1, Is.Not.EqualTo(Guid.Empty));
        Assert.That(guid2, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_InRecordMode_ReturnsDeterministicGuids()
    {
        // Arrange
        const int seed = 42;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        // Act
        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        // Assert
        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InPlaybackMode_ReturnsDeterministicGuids()
    {
        // Arrange
        const int seed = 12345;
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, seed);

        // Act
        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        // Assert
        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InRecordModeWithDifferentSeeds_ReturnsDifferentGuids()
    {
        // Arrange
        var testRandom1 = new TestRandom(RecordedTestMode.Record, 111);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, 222);

        // Act
        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        // Assert
        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InPlaybackModeWithDifferentSeeds_ReturnsDifferentGuids()
    {
        // Arrange
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, 333);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, 444);

        // Act
        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        // Assert
        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_RepeatedCallsInRecordMode_ProducesDeterministicSequence()
    {
        // Arrange
        const int seed = 98765;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        // Act
        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();

        for (int i = 0; i < 5; i++)
        {
            sequence1.Add(testRandom1.NewGuid());
            sequence2.Add(testRandom2.NewGuid());
        }

        // Assert
        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_RepeatedCallsInPlaybackMode_ProducesDeterministicSequence()
    {
        // Arrange
        const int seed = 54321;
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, seed);

        // Act
        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();

        for (int i = 0; i < 5; i++)
        {
            sequence1.Add(testRandom1.NewGuid());
            sequence2.Add(testRandom2.NewGuid());
        }

        // Assert
        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_WithSameInstanceInRecordMode_ProducesDifferentGuids()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Record, 777);

        // Act
        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        // Assert
        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid2, Is.Not.EqualTo(guid3));
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewGuid_WithSameInstanceInPlaybackMode_ProducesDifferentGuids()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Playback, 888);

        // Act
        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        // Assert
        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid2, Is.Not.EqualTo(guid3));
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void InheritsFromRandom_CanUseBaseRandomMethods()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Live);

        // Act
        var randomInt = testRandom.Next(1, 100);
        var randomDouble = testRandom.NextDouble();
        var randomBytes = new byte[10];
        testRandom.NextBytes(randomBytes);

        // Assert
        Assert.That(randomInt, Is.InRange(1, 99));
        Assert.That(randomDouble, Is.InRange(0.0, 1.0));
        Assert.That(randomBytes, Is.Not.All.EqualTo(0)); // At least some bytes should be non-zero
    }

    [Test]
    public void BaseRandomMethods_InRecordMode_AreDeterministic()
    {
        // Arrange
        const int seed = 999;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        // Act
        var int1 = testRandom1.Next(1, 100);
        var int2 = testRandom2.Next(1, 100);

        var double1 = testRandom1.NextDouble();
        var double2 = testRandom2.NextDouble();

        // Assert
        Assert.That(int2, Is.EqualTo(int1));
        Assert.That(double2, Is.EqualTo(double1));
    }

    [Test]
    public void NewGuid_AllModes_ReturnValidGuidFormat()
    {
        // Arrange
        var liveModeRandom = new TestRandom(RecordedTestMode.Live);
        var recordModeRandom = new TestRandom(RecordedTestMode.Record, 123);
        var playbackModeRandom = new TestRandom(RecordedTestMode.Playback, 456);

        // Act
        var liveGuid = liveModeRandom.NewGuid();
        var recordGuid = recordModeRandom.NewGuid();
        var playbackGuid = playbackModeRandom.NewGuid();

        // Assert
        Assert.That(liveGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
        Assert.That(recordGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
        Assert.That(playbackGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
    }

    [Test]
    public void NewGuid_InLiveMode_DifferentInstancesProduceDifferentResults()
    {
        // Arrange
        var testRandom1 = new TestRandom(RecordedTestMode.Live);
        var testRandom2 = new TestRandom(RecordedTestMode.Live);

        // Act & Assert (multiple attempts to increase confidence)
        var allSame = true;
        for (int i = 0; i < 10; i++)
        {
            var guid1 = testRandom1.NewGuid();
            var guid2 = testRandom2.NewGuid();
            if (guid1 != guid2)
            {
                allSame = false;
                break;
            }
        }

        Assert.That(allSame, Is.False, "Different TestRandom instances in Live mode should produce different GUID sequences");
    }

    [Test]
    public void NewGuid_WithZeroSeed_WorksCorrectly()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Record, 0);

        // Act
        var guid = testRandom.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMaxIntSeed_WorksCorrectly()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Playback, int.MaxValue);

        // Act
        var guid = testRandom.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMinIntSeed_WorksCorrectly()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Record, int.MinValue);

        // Act
        var guid = testRandom.NewGuid();

        // Assert
        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_PerformanceTest_CompletesInReasonableTime()
    {
        // Arrange
        var testRandom = new TestRandom(RecordedTestMode.Live);
        const int iterations = 1000;

        // Act
        var startTime = DateTime.UtcNow;
        for (int i = 0; i < iterations; i++)
        {
            testRandom.NewGuid();
        }
        var duration = DateTime.UtcNow - startTime;

        // Assert - Should complete quickly
        Assert.That(duration.TotalSeconds, Is.LessThan(1.0));
    }

    [Test]
    public void NewGuid_CrossModeComparison_ShowsBehaviorDifferences()
    {
        // Arrange
        const int seed = 42;
        var recordRandom = new TestRandom(RecordedTestMode.Record, seed);
        var playbackRandom = new TestRandom(RecordedTestMode.Playback, seed);
        var liveRandom = new TestRandom(RecordedTestMode.Live, seed);

        // Act
        var recordGuid = recordRandom.NewGuid();
        var playbackGuid = playbackRandom.NewGuid();
        var liveGuid = liveRandom.NewGuid();

        // Assert
        // Record and Playback should be the same with same seed
        Assert.That(playbackGuid, Is.EqualTo(recordGuid));
        // Live mode uses system GUID generation, so likely different
        // (though there's a tiny chance they could be the same)
    }
}
