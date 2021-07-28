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
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerLogProperties properties = await client.GetPersonalizerLogPropertiesAsync();

            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.Start.Value.Year, properties.DateRange.Start.Value.Month, properties.DateRange.Start.Value.Day));
            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.End.Value.Year, properties.DateRange.End.Value.Month, properties.DateRange.End.Value.Day));
        }

        [Test]
        public async Task DeleteLogs()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            await client.DeletePersonalizerLogsAsync();
        }
    }
}
