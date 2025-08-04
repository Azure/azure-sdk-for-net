// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;

[TestFixture]
public class EntryRecordModelTests
{
    [Test]
    public void EntryRecordModel_HasExpectedValues()
    {
        Assert.AreEqual(0, (int)EntryRecordModel.Record);
        Assert.AreEqual(1, (int)EntryRecordModel.DoNotRecord);
        Assert.AreEqual(2, (int)EntryRecordModel.RecordWithoutRequestBody);
    }

    [Test]
    public void EntryRecordModel_AllValuesAreDefined()
    {
        var values = System.Enum.GetValues<EntryRecordModel>();
        Assert.AreEqual(3, values.Length);
        Assert.Contains(EntryRecordModel.Record, values);
        Assert.Contains(EntryRecordModel.DoNotRecord, values);
        Assert.Contains(EntryRecordModel.RecordWithoutRequestBody, values);
    }

    [Test]
    public void EntryRecordModel_CanConvertToString()
    {
        Assert.AreEqual("Record", EntryRecordModel.Record.ToString());
        Assert.AreEqual("DoNotRecord", EntryRecordModel.DoNotRecord.ToString());
        Assert.AreEqual("RecordWithoutRequestBody", EntryRecordModel.RecordWithoutRequestBody.ToString());
    }

    [Test]
    public void EntryRecordModel_CanParseFromString()
    {
        Assert.IsTrue(System.Enum.TryParse<EntryRecordModel>("Record", out var record));
        Assert.AreEqual(EntryRecordModel.Record, record);

        Assert.IsTrue(System.Enum.TryParse<EntryRecordModel>("DoNotRecord", out var doNotRecord));
        Assert.AreEqual(EntryRecordModel.DoNotRecord, doNotRecord);

        Assert.IsTrue(System.Enum.TryParse<EntryRecordModel>("RecordWithoutRequestBody", out var recordWithoutBody));
        Assert.AreEqual(EntryRecordModel.RecordWithoutRequestBody, recordWithoutBody);
    }

    [Test]
    public void EntryRecordModel_InvalidStringReturnsFalse()
    {
        Assert.IsFalse(System.Enum.TryParse<EntryRecordModel>("InvalidValue", out _));
        Assert.IsFalse(System.Enum.TryParse<EntryRecordModel>("", out _));
        Assert.IsFalse(System.Enum.TryParse<EntryRecordModel>("record", out _)); // Case sensitive
    }

    [Test]
    public void EntryRecordModel_SupportsComparison()
    {
        Assert.IsTrue(EntryRecordModel.Record == EntryRecordModel.Record);
        Assert.IsFalse(EntryRecordModel.Record == EntryRecordModel.DoNotRecord);
        Assert.IsTrue(EntryRecordModel.Record != EntryRecordModel.DoNotRecord);
    }

    [Test]
    public void EntryRecordModel_CanBeUsedInSwitchStatement()
    {
        string result = EntryRecordModel.Record switch
        {
            EntryRecordModel.Record => "Recording",
            EntryRecordModel.DoNotRecord => "Not Recording",
            EntryRecordModel.RecordWithoutRequestBody => "Recording Without Body",
            _ => "Unknown"
        };

        Assert.AreEqual("Recording", result);
    }
}
