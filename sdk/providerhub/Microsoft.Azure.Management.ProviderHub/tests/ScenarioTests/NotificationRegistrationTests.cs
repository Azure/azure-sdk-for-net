
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class NotificationRegistrationTests
    {
        [Fact]
        public void NotificationRegistrationsCRUDTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string providerNamespace = "Microsoft.Contoso";
                string notificationRegistrationName = "employeesNotificationRegistration";
                var employeesResourceTypeProperties = new NotificationRegistrationPropertiesModel
                {
                    NotificationMode = "EventHub",
                    MessageScope = "RegisteredSubscriptions",
                    IncludedEvents = new string[]
                    {
                        "*/write",
                        "Microsoft.Contoso/employees/delete"
                    },
                    NotificationEndpoints = new NotificationEndpoint[]
                    {
                        new NotificationEndpoint
                        {
                            Locations = new string[]
                            {
                                "",
                                "East US"
                            },
                            NotificationDestination = "/subscriptions/ac6bcfb5-3dc1-491f-95a6-646b89bf3e88/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"
                        }
                    }
                };

                var notificationRegistration = CreateNotificationRegistration(context, providerNamespace, notificationRegistrationName, employeesResourceTypeProperties);
                Assert.NotNull(notificationRegistration);

                notificationRegistration = GetNotificationRegistration(context, providerNamespace, notificationRegistrationName);
                Assert.NotNull(notificationRegistration);

                var notificationRegistrationsList = ListNotificationRegistration(context, providerNamespace);
                Assert.NotNull(notificationRegistrationsList);

                DeleteNotificationRegistration(context, providerNamespace, notificationRegistrationName);
                var exception = Assert.Throws<ErrorResponseException>(() => GetNotificationRegistration(context, providerNamespace, notificationRegistrationName));
                Assert.True(exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound);

                notificationRegistration = CreateNotificationRegistration(context, providerNamespace, notificationRegistrationName, employeesResourceTypeProperties);
                Assert.NotNull(notificationRegistration);
            }
        }

        private NotificationRegistration CreateNotificationRegistration(MockContext context, string providerNamespace, string notificationRegistrationName, NotificationRegistrationPropertiesModel properties)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.NotificationRegistrations.CreateOrUpdate(providerNamespace, notificationRegistrationName, properties);
        }

        private NotificationRegistration GetNotificationRegistration(MockContext context, string providerNamespace, string notificationRegistrationName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.NotificationRegistrations.Get(providerNamespace, notificationRegistrationName);
        }

        private IPage<NotificationRegistration> ListNotificationRegistration(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.NotificationRegistrations.ListByProviderRegistration(providerNamespace);
        }

        private void DeleteNotificationRegistration(MockContext context, string providerNamespace, string notificationRegistrationName)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.NotificationRegistrations.Delete(providerNamespace, notificationRegistrationName);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
