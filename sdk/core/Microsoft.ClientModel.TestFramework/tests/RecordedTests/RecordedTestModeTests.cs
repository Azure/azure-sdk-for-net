// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;
[TestFixture]
public class RecordedTestModeTests
{
    [Test]
    public void RecordedTestMode_HasCorrectValues()
    {
        var liveValue = (int)RecordedTestMode.Live;
        var recordValue = (int)RecordedTestMode.Record;
        var playbackValue = (int)RecordedTestMode.Playback;
        Assert.AreEqual(0, liveValue);
        Assert.AreEqual(1, recordValue);
        Assert.AreEqual(2, playbackValue);
    }
    [Test]
    public void RecordedTestMode_AllValuesAreDefined()
    {
        var enumValues = Enum.GetValues(typeof(RecordedTestMode));
        Assert.AreEqual(3, enumValues.Length);
        Assert.Contains(RecordedTestMode.Live, enumValues);
        Assert.Contains(RecordedTestMode.Record, enumValues);
        Assert.Contains(RecordedTestMode.Playback, enumValues);
    }
    [Test]
    public void RecordedTestMode_CanConvertToString()
    {
        Assert.AreEqual("Live", RecordedTestMode.Live.ToString());
        Assert.AreEqual("Record", RecordedTestMode.Record.ToString());
        Assert.AreEqual("Playback", RecordedTestMode.Playback.ToString());
    }
    [Test]
    public void RecordedTestMode_TryParseValidValues_ReturnsTrue()
    {
        Assert.IsTrue(Enum.TryParse<RecordedTestMode>("Live", out var live));
        Assert.AreEqual(RecordedTestMode.Live, live);
        Assert.IsTrue(Enum.TryParse<RecordedTestMode>("Record", out var record));
        Assert.AreEqual(RecordedTestMode.Record, record);
        Assert.IsTrue(Enum.TryParse<RecordedTestMode>("Playback", out var playback));
        Assert.AreEqual(RecordedTestMode.Playback, playback);
    }
    [Test]
    public void RecordedTestMode_TryParseInvalidValue_ReturnsFalse()
    {
        Assert.IsFalse(Enum.TryParse<RecordedTestMode>("Invalid", out var result));
        Assert.AreEqual(default(RecordedTestMode), result);
    }
    [Test]
    public void RecordedTestMode_CanUseInSwitchStatement()
    {
        string GetModeDescription(RecordedTestMode mode)
        {
            return mode switch
            {
                RecordedTestMode.Live => "Live execution",
                RecordedTestMode.Record => "Recording mode",
                RecordedTestMode.Playback => "Playback mode",
                _ => "Unknown mode"
            };
        }
        Assert.AreEqual("Live execution", GetModeDescription(RecordedTestMode.Live));
        Assert.AreEqual("Recording mode", GetModeDescription(RecordedTestMode.Record));
        Assert.AreEqual("Playback mode", GetModeDescription(RecordedTestMode.Playback));
    }
    [Test]
    public void RecordedTestMode_CanCompareValues()
    {
        Assert.IsTrue(RecordedTestMode.Live < RecordedTestMode.Record);
        Assert.IsTrue(RecordedTestMode.Record < RecordedTestMode.Playback);
        Assert.IsTrue(RecordedTestMode.Live != RecordedTestMode.Playback);
    }
    [Test]
    public void RecordedTestMode_CanConvertToInt()
    {
        int liveInt = (int)RecordedTestMode.Live;
        int recordInt = (int)RecordedTestMode.Record;
        int playbackInt = (int)RecordedTestMode.Playback;
        Assert.AreEqual(0, liveInt);
        Assert.AreEqual(1, recordInt);
        Assert.AreEqual(2, playbackInt);
    }
    [Test]
    public void RecordedTestMode_CanConvertFromInt()
    {
        var live = (RecordedTestMode)0;
        var record = (RecordedTestMode)1;
        var playback = (RecordedTestMode)2;
        Assert.AreEqual(RecordedTestMode.Live, live);
        Assert.AreEqual(RecordedTestMode.Record, record);
        Assert.AreEqual(RecordedTestMode.Playback, playback);
    }
    [Test]
    public void RecordedTestMode_HashCodeIsConsistent()
    {
        var live1 = RecordedTestMode.Live;
        var live2 = RecordedTestMode.Live;
        Assert.AreEqual(live1.GetHashCode(), live2.GetHashCode());
        Assert.AreNotEqual(RecordedTestMode.Live.GetHashCode(), RecordedTestMode.Record.GetHashCode());
    }
}
