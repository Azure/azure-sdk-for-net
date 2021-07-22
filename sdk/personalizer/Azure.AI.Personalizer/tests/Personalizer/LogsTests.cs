// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class LogsTests : PersonalizerTestBase
    {
        public LogsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetLogsProperties()
        {
            PersonalizerManagementClient client = GetPersonalizerManagementClient();
            PersonalizerLogProperties properties = await client.GetPersonalizerLogPropertiesAsync();

            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.From.Value.Year, properties.DateRange.From.Value.Month, properties.DateRange.From.Value.Day));
            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.To.Value.Year, properties.DateRange.To.Value.Month, properties.DateRange.To.Value.Day));
        }

        [Test]
        public async Task DeleteLogs()
        {
            PersonalizerManagementClient client = GetPersonalizerManagementClient();
            await client.DeletePersonalizerLogsAsync();
        }
    }
}
