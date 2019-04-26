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
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetModel");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                Stream stream = await client.Model.GetAsync();
                Assert.NotEqual(stream.ReadByte(), -1);
            }
        }

        [Fact]
        public async Task DeleteModel()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeleteModel");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.Model.DeleteAsync();
            }
        }

        [Fact]
        public async Task GetModelProperties()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetModelProperties");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                ModelProperties modelProperties = await client.Model.GetPropertiesAsync();
                Assert.True(modelProperties.CreationTime != null);
                Assert.True(modelProperties.LastModifiedTime != null);
            }
        }
    }
}
