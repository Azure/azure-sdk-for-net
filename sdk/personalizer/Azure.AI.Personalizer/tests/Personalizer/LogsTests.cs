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
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerLogProperties properties = await client.GetPersonalizerLogPropertiesAsync();

            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.StartTime.Value.Year, properties.StartTime.Value.Month, properties.StartTime.Value.Day));
            Assert.AreEqual(new DateTime(0001, 01, 01), new DateTime(properties.EndTime.Value.Year, properties.EndTime.Value.Month, properties.EndTime.Value.Day));
        }

        [Test]
        public async Task DeleteLogs()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            await client.DeletePersonalizerLogsAsync();
        }
    }
}
