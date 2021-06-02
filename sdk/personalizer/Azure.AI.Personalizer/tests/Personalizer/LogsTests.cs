using Azure.AI.Personalizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Threading.Tasks;
using Azure.AI.Personalizer;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class LogsTests : BaseTests
    {
        [Fact]
        public async Task GetLogsProperties()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetLogsProperties");
                LogRestClient client = GetLogClient(HttpMockServer.CreateInstance());
                LogsProperties properties = await client.GetPropertiesAsync();
                Assert.Equal(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.From.Value.Year, properties.DateRange.From.Value.Month, properties.DateRange.From.Value.Day));
                Assert.Equal(new DateTime(0001, 01, 01), new DateTime(properties.DateRange.To.Value.Year, properties.DateRange.To.Value.Month, properties.DateRange.To.Value.Day));
            }
        }

        [Fact]
        public async Task DeleteLogs()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DeleteLogs");
                LogRestClient client = GetLogClient(HttpMockServer.CreateInstance());
                await client.DeleteAsync();
            }
        }
    }
}
