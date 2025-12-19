// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class TestUtilitiesSamples : RecordedTestBase
{
    public void CanSetAndRetrieveEnvironmentVariable()
    {
        #region Snippet:TestEnvVarUsage
        // Use TestEnvVar to temporarily set environment variables
        using var testEnvVar = new TestEnvVar("TEST_SAMPLE_VALUE", "test-value");

        // Retrieve the value that was set
        var value = Environment.GetEnvironmentVariable("TEST_SAMPLE_VALUE");
        Assert.That(value, Is.EqualTo("test-value"));

        // Variable will be automatically restored to its original value when disposed
        #endregion
    }

    [Test]
    public void TestRandomProvidesDeterministicValues()
    {
        #region Snippet:RandomId
        string repeatableRandomId = Recording!.GenerateId();
        #endregion

        #region Snippet:RandomGuid
        string repeatableGuid = Recording!.Random.NewGuid().ToString();
        #endregion

    }

    [Test]
    public async Task CanTestAsyncEnumerable()
    {
        #region Snippet:AsyncEnumerableExtension
        var items = GetAsyncItems();

        // Use extension to collect async enumerable items
        var collectedItems = await items.ToEnumerableAsync();
        #endregion
    }

    private async IAsyncEnumerable<string> GetAsyncItems()
    {
        yield return "item1";
        await Task.Delay(10);
        yield return "item2";
        await Task.Delay(10);
        yield return "item3";
    }
}
