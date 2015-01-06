// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    /// <summary>
    /// Test helper class for managing mocking the various client objects
    /// and operations in the service management library.
    /// </summary>
    public class ClientMocks
    {
        private readonly MockRepository repository;
        public Mock<WindowsAzure.Management.ManagementClient> ManagementClientMock { get; private set; }
        public Mock<Azure.Management.Resources.ResourceManagementClient> ResourceManagementClientMock { get; private set; }
        public Mock<Azure.Subscriptions.SubscriptionClient> CsmSubscriptionClientMock { get; private set; }
        public Mock<WindowsAzure.Subscriptions.SubscriptionClient> RdfeSubscriptionClientMock { get; private set; }

        public ClientMocks(Guid subscriptionId)
        {
            repository = new MockRepository(MockBehavior.Default) {DefaultValue = DefaultValue.Mock};

            var creds = CreateCredentials(subscriptionId);
            ManagementClientMock = repository.Create<WindowsAzure.Management.ManagementClient>(creds);
            ResourceManagementClientMock = repository.Create<Azure.Management.Resources.ResourceManagementClient>(creds);
            RdfeSubscriptionClientMock = repository.Create<WindowsAzure.Subscriptions.SubscriptionClient>(creds);
            CsmSubscriptionClientMock = repository.Create<Azure.Subscriptions.SubscriptionClient>(creds);
        }

        private SubscriptionCloudCredentials CreateCredentials(Guid subscriptionId)
        {
            var mockCreds = repository.Create<SubscriptionCloudCredentials>(MockBehavior.Loose);
            mockCreds.SetupGet(c => c.SubscriptionId).Returns(subscriptionId.ToString());
            return mockCreds.Object;
        }

        public static CloudException Make404Exception()
    {
            return CloudException.Create(
                new HttpRequestMessage(),
                null,
                new HttpResponseMessage(HttpStatusCode.NotFound),
                "<Error><Message>Not found</Message></Error>");
        }

        public void LoadCsmSubscriptions(List<Azure.Subscriptions.Models.Subscription> subscriptions)
        {
            var subscriptionOperationsMock = new Mock<Azure.Subscriptions.ISubscriptionOperations>();
            subscriptionOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new Azure.Subscriptions.Models.SubscriptionListResult
                {
                    Subscriptions = subscriptions
                }));

            CsmSubscriptionClientMock.Setup(f => f.Subscriptions).Returns(subscriptionOperationsMock.Object);
        }

        public void LoadRdfeSubscriptions(List<WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription> subscriptions)
        {
            var subscriptionOperationsMock = new Mock<WindowsAzure.Subscriptions.ISubscriptionOperations>();
            subscriptionOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse
                {
                    Subscriptions = subscriptions
                }));

            RdfeSubscriptionClientMock.Setup(f => f.Subscriptions).Returns(subscriptionOperationsMock.Object);
        }

        public void LoadTenants(List<Azure.Subscriptions.Models.TenantIdDescription> tenantIds = null)
        {

            tenantIds = tenantIds ?? new[]
            {
                new Azure.Subscriptions.Models.TenantIdDescription
                {
                    Id = "Common",
                    TenantId = "Common"
                }
            }.ToList();
            var tenantOperationsMock = new Mock<Azure.Subscriptions.ITenantOperations>();
            tenantOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new Azure.Subscriptions.Models.TenantListResult
                {
                    TenantIds = tenantIds
                }));
            
            CsmSubscriptionClientMock.Setup(f => f.Tenants).Returns(tenantOperationsMock.Object);
        }
    }
}
