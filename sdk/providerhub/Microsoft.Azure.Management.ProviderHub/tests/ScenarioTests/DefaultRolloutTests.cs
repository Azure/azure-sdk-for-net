
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
                var providerNamespace = "Microsoft.Contoso";
                var rolloutName = "defaultRolloutSDK";
                var properties = new DefaultRolloutPropertiesModel
                {
                    Specification = new DefaultRolloutPropertiesSpecification
                    {
                        Canary = new DefaultRolloutSpecificationCanary
                        {
                            SkipRegions = new List<string>
                            {
                                "BrazilUS"
                            }
                        }
                    }
                };

                var defaultRollout = CreateDefaultRollout(context, providerNamespace, rolloutName, properties);
                Assert.NotNull(defaultRollout);

                defaultRollout = GetDefaultRollout(context, providerNamespace, rolloutName);
                Assert.NotNull(defaultRollout);

                var defaultRolloutsList = ListDefaultRollout(context, providerNamespace);
                Assert.NotNull(defaultRolloutsList);

                CancelDefaultRollout(context, providerNamespace, rolloutName);
                defaultRollout = GetDefaultRollout(context, providerNamespace, rolloutName);
                Assert.True(defaultRollout.Properties.ProvisioningState == "Canceled");

                DeleteDefaultRollout(context, providerNamespace, rolloutName);
                var exception = Assert.Throws<ErrorResponseException>(() => GetDefaultRollout(context, providerNamespace, rolloutName));
                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

        private DefaultRollout CreateDefaultRollout(MockContext context, string providerNamespace, string rolloutName, DefaultRolloutPropertiesModel properties)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.BeginCreateOrUpdate(providerNamespace, rolloutName, properties);
        }

        private DefaultRollout GetDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.Get(providerNamespace, rolloutName);
        }

        private IPage<DefaultRollout> ListDefaultRollout(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.DefaultRollouts.ListByProviderRegistration(providerNamespace);
        }

        private void CancelDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.DefaultRollouts.Stop(providerNamespace, rolloutName);
        }

        private void DeleteDefaultRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.DefaultRollouts.Delete(providerNamespace, rolloutName);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
