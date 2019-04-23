using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class DeleteModelTest : BaseTests
    {
        [Fact]
        public async Task DeleteModel()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeleteModel");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.DeleteModelAsync();               
            }
        }
    }
}
