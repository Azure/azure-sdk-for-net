using System.IO;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class DeleteLogsTest : BaseTests
    {
        [Fact]
        public async Task DeleteLogs()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeleteLogs");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.DeleteLogsAsync();
            }
        }
    }
}
