
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class CustomRolloutTests
    {
        [Fact]
        public void CustomRolloutOperationsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var providerNamespace = "Microsoft.Contoso";
                var rolloutName = "customRolloutSDK";
                var customRolloutProperties = new CustomRolloutPropertiesModel
                {
                    Specification = new CustomRolloutPropertiesSpecification
                    {
                        Canary = new CustomRolloutSpecificationCanary
                        {
                            Regions = new string[]
                            {
                                "Eastus2euap"
                            }
                        }
                    }
                };

                var customRollout = CreateCustomRollout(context, providerNamespace, rolloutName, customRolloutProperties);
                Assert.NotNull(customRollout);

                customRollout = GetCustomRollout(context, providerNamespace, rolloutName);
                Assert.NotNull(customRollout);

                var customRolloutsList = ListCustomRollouts(context, providerNamespace);
                Assert.NotNull(customRolloutsList);
            }
        }

        private CustomRollout CreateCustomRollout(MockContext context, string providerNamespace, string rolloutName, CustomRolloutPropertiesModel properties)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.CustomRollouts.CreateOrUpdate(providerNamespace, rolloutName, properties);
        }

        private CustomRollout GetCustomRollout(MockContext context, string providerNamespace, string rolloutName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.CustomRollouts.Get(providerNamespace, rolloutName);
        }

        private IPage<CustomRollout> ListCustomRollouts(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.CustomRollouts.ListByProviderRegistration(providerNamespace);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
