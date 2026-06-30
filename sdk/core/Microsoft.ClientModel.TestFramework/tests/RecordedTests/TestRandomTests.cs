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
    public void CreateWithSeed()
    {
        var testRandom = new TestRandom(RecordedTestMode.Record, 12345);
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void CreateWithoutSeed()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);
        Assert.That(testRandom, Is.Not.Null);
        Assert.That(testRandom, Is.InstanceOf<Random>());
    }

    [Test]
    public void NewInLiveModeReturnsUniqueGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Live);
        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();

        Assert.That(guid1, Is.Not.EqualTo(guid2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(guid1, Is.Not.EqualTo(Guid.Empty));
            Assert.That(guid2, Is.Not.EqualTo(Guid.Empty));
        }
    }

    [Test]
    public void NewInRecordModeReturnsDeterministicGuids()
    {
        const int seed = 42;
        var testRandom1 = new TestRandom(RecordedTestMode.Record, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, seed);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewInPlaybackModeReturnsDeterministicGuids()
    {
        const int seed = 12345;
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, seed);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, seed);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.EqualTo(guid1));
    }

    [Test]
    public void NewInRecordModeWithDifferentSeedsReturnsDifferentGuids()
    {
        var testRandom1 = new TestRandom(RecordedTestMode.Record, 111);
        var testRandom2 = new TestRandom(RecordedTestMode.Record, 222);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewInPlaybackModeWithDifferentSeedsReturnsDifferentGuids()
    {
        var testRandom1 = new TestRandom(RecordedTestMode.Playback, 333);
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, 444);

        var guid1 = testRandom1.NewGuid();
        var guid2 = testRandom2.NewGuid();

        Assert.That(guid2, Is.Not.EqualTo(guid1));
    }

    [Test]
    public void NewRepeatedCallsInRecordModeProducesDeterministicSequence()
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
    public void NewRepeatedCallsInPlaybackModeProducesDeterministicSequence()
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
    public void NewWithSameInstanceInRecordModeProducesDifferentGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Record, 777);

        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(guid1, Is.Not.EqualTo(guid2));
            Assert.That(guid2, Is.Not.EqualTo(guid3));
        }
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewWithSameInstanceInPlaybackModeProducesDifferentGuids()
    {
        var testRandom = new TestRandom(RecordedTestMode.Playback, 888);

        var guid1 = testRandom.NewGuid();
        var guid2 = testRandom.NewGuid();
        var guid3 = testRandom.NewGuid();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(guid1, Is.Not.EqualTo(guid2));
            Assert.That(guid2, Is.Not.EqualTo(guid3));
        }
        Assert.That(guid1, Is.Not.EqualTo(guid3));
    }

    [Test]
    public void NewInLiveModeDifferentInstancesProduceDifferentResults()
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
}
