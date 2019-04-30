﻿using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class LogsTests : BaseTests
    {
        [Fact]
        public async Task GetLogsProperties()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetLogsProperties");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                LogsProperties properties = await client.Log.GetPropertiesAsync();
                Assert.Equal(new DateTime(2019, 04, 27), new DateTime(properties.DateRange.FromProperty.Value.Year, properties.DateRange.FromProperty.Value.Month, properties.DateRange.FromProperty.Value.Day));
                Assert.Equal(new DateTime(2019, 04, 28), new DateTime(properties.DateRange.To.Value.Year, properties.DateRange.To.Value.Month, properties.DateRange.To.Value.Day));
            }
        }

        [Fact]
        public async Task DeleteLogs()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeleteLogs");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.Log.DeleteAsync();
            }
        }
    }
}
