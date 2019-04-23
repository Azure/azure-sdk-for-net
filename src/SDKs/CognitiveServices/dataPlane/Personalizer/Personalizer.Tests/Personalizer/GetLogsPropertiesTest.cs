using System;
using System.IO;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class GetLogsPropertiesTest : BaseTests
    {
        [Fact]
        public async Task GetLogsProperties()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetLogsProperties");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                LogsProperties properties = await client.GetLogsPropertiesAsync();
                Assert.Equal(new DateTime(2019, 04, 13), new DateTime(properties.DateRange.FromProperty.Value.Year, properties.DateRange.FromProperty.Value.Month, properties.DateRange.FromProperty.Value.Day));
                Assert.Equal(new DateTime(2019, 04, 23), new DateTime(properties.DateRange.To.Value.Year, properties.DateRange.To.Value.Month, properties.DateRange.To.Value.Day));
            }
        }
    }
}
