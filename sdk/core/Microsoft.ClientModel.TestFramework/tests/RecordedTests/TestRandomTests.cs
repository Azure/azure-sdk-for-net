// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestRandomTests
{
    [Test]
    public void Constructor_WithSeed_CreatesInstance()
    {
        var testRandom = new TestRandom(RecordedTestMode.Record, 12345);
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void Constructor_WithoutSeed_CreatesInstance()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void NewGuid_InLiveMode_ReturnsUniqueGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);
        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();

        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid1, Is.Not.EqualTo(Guid.Empty));
        Assert.That(guid2, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_InRecordMode_ReturnsDeterministicGuids()
    {
        const int seed = 42;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InPlaybackMode_ReturnsDeterministicGuids()
    {
        const int seed = 12345;
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, seed);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InRecordModeWithDifferentSeeds_ReturnsDifferentGuids()
    {
        var testRandom1 = new TestRandom(RecordedTestMode.Record, 111);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, 222);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_InPlaybackModeWithDifferentSeeds_ReturnsDifferentGuids()
    {
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, 333);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, 444);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewGuid_RepeatedCallsInRecordMode_ProducesDeterministicSequence()
    {
        const int seed = 98765;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();
        for (int i = 0; i < 5; i++)
        {
            sequence1.Add(testRandom1.NewGuid());
            sequence2.Add(testRandom2.NewGuid());
        }

        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_RepeatedCallsInPlaybackMode_ProducesDeterministicSequence()
    {
        const int seed = 54321;
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, seed);

        var sequence1 = new List<Guid>();
        var sequence2 = new List<Guid>();
        for (int i = 0; i < 5; i++)
        {
            sequence1.Add(testRandom1.NewGuid());
            sequence2.Add(testRandom2.NewGuid());
        }

        Assert.That(sequence2, Is.EqualTo(sequence1));
    }

    [Test]
    public void NewGuid_WithSameInstanceInRecordMode_ProducesDifferentGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Record, 777);

        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid2, Is.Not.EqualTo(guid3));
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewGuid_WithSameInstanceInPlaybackMode_ProducesDifferentGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Playback, 888);

        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid2, Is.Not.EqualTo(guid3));
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void InheritsFromRandom_CanUseBaseRandomMethods()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);

        var randomInt = testRandom.Next(1, 100);
        var randomDouble = testRandom.NextDouble();
        var randomBytes = new byte[10];
        testRandom.NextBytes(randomBytes);

        Assert.That(randomInt, Is.InRange(1, 99));
        Assert.That(randomDouble, Is.InRange(0.0, 1.0));
        Assert.That(randomBytes, Is.Not.All.EqualTo(0)); // At least some bytes should be non-zero
    }

    [Test]
    public void BaseRandomMethods_InRecordMode_AreDeterministic()
    {
        const int seed = 999;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        var int1 = testRandom1.Next(1, 100);
        var int2 = testRandom2.Next(1, 100);
        var double1 = testRandom1.NextDouble();
        var double2 = testRandom2.NextDouble();

        Assert.That(int2, Is.EqualTo(int1));
        Assert.That(double2, Is.EqualTo(double1));
    }

    [Test]
    public void NewGuid_AllModes_ReturnValidGuidFormat()
    {
        var liveModeRandom = new TestRandom(RecordedTestMode.Live);
        var recordModeRandom = new TestRandom(RecordedTestMode.Record, 123);
        var playbackModeRandom = new TestRandom(RecordedTestMode.Playback, 456);

        var liveGuid = liveModeRandom.NewGuid();
        var recordGuid = recordModeRandom.NewGuid();
        var playbackGuid = playbackModeRandom.NewGuid();

        Assert.That(liveGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
        Assert.That(recordGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
        Assert.That(playbackGuid.ToString(), Does.Match(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$"));
    }

    [Test]
    public void NewGuid_InLiveMode_DifferentInstancesProduceDifferentResults()
    {
        var testRandom1 = new TestRandom(RecordedTestMode.Live);
        var testRandom2 = new TestRandom(RecordedTestMode.Live);

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
        var testRandom = new TestRandom(RecordedTestMode.Record, 0);

        var guid = testRandom.NewGuid();

        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMaxIntSeed_WorksCorrectly()
    {
        var testRandom = new TestRandom(RecordedTestMode.Playback, int.MaxValue);
        var guid = testRandom.NewGuid();

        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_WithMinIntSeed_WorksCorrectly()
    {
        var testRandom = new TestRandom(RecordedTestMode.Record, int.MinValue);

        var guid = testRandom.NewGuid();

        Assert.That(guid, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void NewGuid_PerformanceTest_CompletesInReasonableTime()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);
        const int iterations = 1000;

        var startTime = DateTime.UtcNow;
        for (int i = 0; i < iterations; i++)
        {
            testRandom.NewGuid();
        }
        var duration = DateTime.UtcNow - startTime;

        Assert.That(duration.TotalSeconds, Is.LessThan(1.0));
    }

    [Test]
    public void NewGuid_CrossModeComparison_ShowsBehaviorDifferences()
    {
        const int seed = 42;
        var recordRandom = new TestRandom(RecordedTestMode.Record, seed);
        var playbackRandom = new TestRandom(RecordedTestMode.Playback, seed);
        var liveRandom = new TestRandom(RecordedTestMode.Live, seed);

        var recordGuid = recordRandom.NewGuid();
        var playbackGuid = playbackRandom.NewGuid();
        var liveGuid = liveRandom.NewGuid();
        // Record and Playback should be the same with same seed
        Assert.That(playbackGuid, Is.EqualTo(recordGuid));
        // Live mode uses system GUID generation, so likely different
        // (though there's a tiny chance they could be the same)
    }
}
