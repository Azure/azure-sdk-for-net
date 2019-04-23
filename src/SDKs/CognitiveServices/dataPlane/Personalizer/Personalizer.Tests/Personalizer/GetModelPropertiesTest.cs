using System.IO;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class GetModelPropertiesTest : BaseTests
    {
        [Fact]
        public async Task GetModelProperties()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetModelProperties");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                ModelProperties modelProperties = await client.GetModelPropertiesAsync();
                Assert.True(modelProperties.CreationTime != null);
                Assert.True(modelProperties.LastModifiedTime != null);
            }
        }
    }
}
