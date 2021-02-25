
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class DefaultRolloutTests
    {
        [Fact]
        public void DefaultRolloutOperationsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string providerNamespace = "Microsoft.Contoso";
                string rolloutName = "defaultRolloutSDK";

                var defaultRollout = CreateDefaultRollout(context, providerNamespace, rolloutName);
                Assert.NotNull(defaultRollout);

                defaultRollout = GetDefaultRollout(context, providerNamespace, rolloutName);
                Assert.NotNull(defaultRollout);

                var defaultRolloutsList = ListDefaultRollout(context, providerNamespace);
                Assert.NotNull(defaultRolloutsList);

                CancelDefaultRollout(context, providerNamespace, rolloutName);
                defaultRollout = GetDefaultRollout(context, providerNamespace, rolloutName);
                Assert.True(defaultRollout.ProvisioningState == "Canceled");

                DeleteDefaultRollout(context, providerNamespace, rolloutName);
                var exception = Assert.Throws<ErrorResponseException>(() => GetDefaultRollout(context, providerNamespace, rolloutName));
                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

        private DefaultRollout CreateDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            providerhubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.BeginCreateOrUpdate(providerNamespace, rolloutName);
        }

        private DefaultRollout GetDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            providerhubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.Get(providerNamespace, rolloutName);
        }

        private IPage<DefaultRollout> ListDefaultRollout(MockContext context, string providerNamespace)
        {
            providerhubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.ListByProviderRegistration(providerNamespace);
        }

        private void CancelDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            providerhubClient client = GetProviderHubManagementClient(context);
            client.DefaultRollouts.Stop(providerNamespace, rolloutName);
        }

        private void DeleteDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            providerhubClient client = GetProviderHubManagementClient(context);
            client.DefaultRollouts.Delete(providerNamespace, rolloutName);
        }

        private providerhubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<providerhubClient>();
        }
    }
}
