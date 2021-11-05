
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class ManifestTests
    {
        [Fact]
        public void ManifestOperationsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string providerNamespace = "Microsoft.Contoso";
                var manifestParams = new CheckinManifestParams
                {
                    Environment = "Canary",
                    BaselineArmManifestLocation = "EastUS2EUAP"
                };

                var resourceProviderManifest = GenerateManifest(context, providerNamespace);
                Assert.NotNull(resourceProviderManifest);

                var checkinManifestInfo = CheckinManifest(context, providerNamespace, manifestParams);
                Assert.NotNull(checkinManifestInfo);
            }
        }

        private ResourceProviderManifest GenerateManifest(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.GenerateManifest(providerNamespace);
        }

        private CheckinManifestInfo CheckinManifest(MockContext context, string providerNamespace, CheckinManifestParams manifestParameters)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.CheckinManifest(providerNamespace, manifestParameters);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
