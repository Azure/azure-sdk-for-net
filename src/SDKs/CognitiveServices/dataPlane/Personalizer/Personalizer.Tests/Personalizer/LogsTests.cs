using Microsoft.Azure.CognitiveServices.Personalizer.Models;
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

                LogsProperties properties = await client.Logs.GetPropertiesAsync();
                Assert.Equal(new DateTime(0001, 01, 01), new DateTime(properties.StartTime.Value.Year, properties.StartTime.Value.Month, properties.StartTime.Value.Day));
                Assert.Equal(new DateTime(0001, 01, 01), new DateTime(properties.EndTime.Value.Year, properties.EndTime.Value.Month, properties.EndTime.Value.Day));

            }
        }

        [Fact]
        public async Task DeleteLogs()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeleteLogs");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.Logs.DeleteAsync();
            }
        }
    }
}
