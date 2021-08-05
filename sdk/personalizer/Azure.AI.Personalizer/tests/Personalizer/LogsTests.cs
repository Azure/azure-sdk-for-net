// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class LogsTests : PersonalizerTestBase
    {
        public LogsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetLogProperties()
        {
            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
            PersonalizerLogProperties properties = await client.GetPersonalizerLogPropertiesAsync();
            DateTime start = new DateTime(properties.StartTime.Value.Year, properties.StartTime.Value.Month, properties.StartTime.Value.Day);
            DateTime end = new DateTime(properties.EndTime.Value.Year, properties.EndTime.Value.Month, properties.EndTime.Value.Day);
            Assert.IsTrue(DateTime.UtcNow >= start);
            Assert.IsTrue(end >= start);
        }

        [Test]
        public async Task DeleteLogs()
        {
            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
            await client.DeletePersonalizerLogsAsync();
        }
    }
}
