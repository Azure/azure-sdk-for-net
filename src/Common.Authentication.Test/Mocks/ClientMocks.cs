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

using Hyak.Common;
using Microsoft.Azure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    /// <summary>
    /// Test helper class for managing mocking the various client objects
    /// and operations in the service management library.
    /// </summary>
    public class ClientMocks
    {
        private readonly MockRepository repository;
        internal Mock<Microsoft.Azure.Internal.Management.Rdfe.ManagementClient> ManagementClientMock { get; private set; }
        internal Mock<Microsoft.Azure.Internal.Management.Csm.ResourceManagementClient> ResourceManagementClientMock { get; private set; }
        internal Mock<Microsoft.Azure.Internal.Subscriptions.Csm.SubscriptionClient> CsmSubscriptionClientMock { get; private set; }
        internal Mock<Microsoft.Azure.Internal.Subscriptions.Rdfe.SubscriptionClient> RdfeSubscriptionClientMock { get; private set; }

        public ClientMocks(Guid subscriptionId)
        {
            repository = new MockRepository(MockBehavior.Default) {DefaultValue = DefaultValue.Mock};

            var creds = CreateCredentials(subscriptionId);
            ManagementClientMock = repository.Create<Microsoft.Azure.Internal.Management.Rdfe.ManagementClient>(creds);
            ResourceManagementClientMock = repository.Create<Microsoft.Azure.Internal.Management.Csm.ResourceManagementClient>(creds);
            RdfeSubscriptionClientMock = repository.Create<Microsoft.Azure.Internal.Subscriptions.Rdfe.SubscriptionClient>(creds);
            CsmSubscriptionClientMock = repository.Create<Microsoft.Azure.Internal.Subscriptions.Csm.SubscriptionClient>(creds);
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

        public void LoadCsmSubscriptions(List<Microsoft.Azure.Internal.Subscriptions.Csm.Models.Subscription> subscriptions)
        {
            var subscriptionOperationsMock = new Mock<Microsoft.Azure.Internal.Subscriptions.Csm.ISubscriptionOperations>();
            subscriptionOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new Microsoft.Azure.Internal.Subscriptions.Csm.Models.SubscriptionListResult
                {
                    Subscriptions = subscriptions
                }));

            CsmSubscriptionClientMock.Setup(f => f.Subscriptions).Returns(subscriptionOperationsMock.Object);
        }

        public void LoadRdfeSubscriptions(List<Microsoft.Azure.Internal.Subscriptions.Rdfe.Models.Subscription> subscriptions)
        {
            var subscriptionOperationsMock = new Mock<Microsoft.Azure.Internal.Subscriptions.Rdfe.ISubscriptionOperations>();
            subscriptionOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new Microsoft.Azure.Internal.Subscriptions.Rdfe.Models.SubscriptionListOperationResponse
                {
                    Subscriptions = subscriptions
                }));

            RdfeSubscriptionClientMock.Setup(f => f.Subscriptions).Returns(subscriptionOperationsMock.Object);
        }

        public void LoadTenants(List<Microsoft.Azure.Internal.Subscriptions.Csm.Models.TenantIdDescription> tenantIds = null)
        {

            tenantIds = tenantIds ?? new[]
            {
                new Microsoft.Azure.Internal.Subscriptions.Csm.Models.TenantIdDescription
                {
                    Id = "Common",
                    TenantId = "Common"
                }
            }.ToList();
            var tenantOperationsMock = new Mock<Microsoft.Azure.Internal.Subscriptions.Csm.ITenantOperations>();
            tenantOperationsMock.Setup(f => f.ListAsync(new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new Microsoft.Azure.Internal.Subscriptions.Csm.Models.TenantListResult
                {
                    TenantIds = tenantIds
                }));
            
            CsmSubscriptionClientMock.Setup(f => f.Tenants).Returns(tenantOperationsMock.Object);
        }
    }
}
