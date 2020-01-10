using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class ModelTests : BaseTests
    {
        [Fact]
        public async Task GetModel()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetModel");
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                Stream stream = await client.Model.GetAsync();
                Assert.NotEqual(-1 , stream.ReadByte());
            }
        }

        [Fact]
        public async Task ResetModel()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ResetModel");
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                await client.Model.ResetAsync();
            }
        }

        [Fact]
        public async Task GetModelProperties()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetModelProperties");
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                ModelProperties modelProperties = await client.Model.GetPropertiesAsync();
                Assert.True(modelProperties.CreationTime != null);
                Assert.True(modelProperties.LastModifiedTime != null);
            }
        }
    }
}
