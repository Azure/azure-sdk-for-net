using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Personalizer;
using Azure.AI.Personalizer.Models;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class ModelTests : BaseTests
    {
        [Fact]
        public async Task GetModel()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetModel");
                ModelRestClient client = GetModelClient(HttpMockServer.CreateInstance());
                Stream stream = await client.GetAsync();
                Assert.NotEqual(-1 , stream.ReadByte());
            }
        }

        [Fact]
        public async Task ResetModel()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ResetModel");
                ModelRestClient client = GetModelClient(HttpMockServer.CreateInstance());
                await client.ResetAsync();
            }
        }

        [Fact]
        public async Task GetModelProperties()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetModelProperties");
                ModelRestClient client = GetModelClient(HttpMockServer.CreateInstance());
                ModelProperties modelProperties = await client.GetPropertiesAsync();
                Assert.True(modelProperties.CreationTime != null);
                Assert.True(modelProperties.LastModifiedTime != null);
            }
        }
    }
}
