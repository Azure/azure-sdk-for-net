using System.IO;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class GetModelTest : BaseTests
    {
        [Fact]
        public async Task GetModel()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetModel");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                Stream stream = await client.GetModelAsync();
                Assert.NotEqual(stream.ReadByte(), -1);
            }
        }
    }
}
