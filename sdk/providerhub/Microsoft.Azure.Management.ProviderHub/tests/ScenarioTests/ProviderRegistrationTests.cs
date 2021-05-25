
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    /*
    Note: Service Principal uses credentials from the RPaaS SDK Test App.
    TEST_CSM_ORGID_AUTHENTICATION=
    SubscriptionId=6f53185c-ea09-4fc3-9075-318dec805303;ServicePrincipal=7a26a40b-b149-4388-a7c2-f0c8a2ca5f56;ServicePrincipalSecret=**hidden**;
    AZURE_TEST_MODE=Record
    */
    public class ProviderRegistrationTests
    {
        [Fact]
        public void ProviderRegistrationsCRUDTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string providerNamespace = "Microsoft.Contoso";
                var providerRegistrationProperties = new ProviderRegistrationPropertiesModel
                {
                    ProviderHubMetadata = new ProviderRegistrationPropertiesProviderHubMetadata
                    {
                        ProviderAuthentication = new ProviderHubMetadataProviderAuthentication
                        {
                            AllowedAudiences = new string[]
                            {
                                "https://management.core.windows.net/"
                            }
                        },
                        ProviderAuthorizations = new ResourceProviderAuthorization[]
                        {
                            new ResourceProviderAuthorization
                            {
                                ApplicationId = "3d834152-5efa-46f7-85a4-a18c2b5d46f9",
                                RoleDefinitionId = "760505bf-dcfa-4311-b890-18da392a00b2"
                            }
                        }
                    },
                    ProviderVersion = "2.0",
                    ProviderType = "Internal, Hidden",
                    Management = new ResourceProviderManifestPropertiesManagement
                    {
                        ManifestOwners = new string[] { "SPARTA-PlatformServiceAdministrator" },
                        IncidentRoutingService = "Resource Provider Service as a Service",
                        IncidentRoutingTeam = "RPaaS",
                        IncidentContactEmail = "rpaascore@microsoft.com",
                        ServiceTreeInfos = new ServiceTreeInfo[]
                        {
                            new ServiceTreeInfo
                            {
                                ServiceId = "d1b7d8ba-05e2-48e6-90d6-d781b99c6e69",
                                ComponentId = "d1b7d8ba-05e2-48e6-90d6-d781b99c6e69"
                            }
                        }
                    },
                    Capabilities = new ResourceProviderCapabilities[]
                    {
                        new ResourceProviderCapabilities
                        {
                            QuotaId = "CSP_2015-05-01",
                            Effect = "Allow"
                        },
                        new ResourceProviderCapabilities
                        {
                            QuotaId = "CSP_MG_2017-12-01",
                            Effect = "Allow"
                        }
                    }
                };

                var providerRegistration = CreateProviderRegistration(context, providerNamespace, providerRegistrationProperties);
                Assert.NotNull(providerRegistration);

                providerRegistration = GetProviderRegistration(context, providerNamespace);
                Assert.NotNull(providerRegistration);

                var providerRegistrationsList = ListProviderRegistration(context);
                Assert.NotNull(providerRegistrationsList);

                DeleteProviderRegistration(context, providerNamespace);
                var exception = Assert.Throws<ErrorResponseException>(() => GetProviderRegistration(context, providerNamespace));
                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                providerRegistration = CreateProviderRegistration(context, providerNamespace, providerRegistrationProperties);
                Assert.NotNull(providerRegistration);
            }
        }

        private ProviderRegistration CreateProviderRegistration(MockContext context, string providerNamespace, ProviderRegistrationPropertiesModel properties)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ProviderRegistrations.CreateOrUpdate(providerNamespace, properties);
        }

        private ProviderRegistration GetProviderRegistration(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ProviderRegistrations.Get(providerNamespace);
        }

        private IPage<ProviderRegistration> ListProviderRegistration(MockContext context)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.ProviderRegistrations.List();
        }

        private void DeleteProviderRegistration(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.ProviderRegistrations.Delete(providerNamespace);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
