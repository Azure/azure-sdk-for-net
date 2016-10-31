//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;
using Xunit;

namespace ServiceBus.Tests
{
    public class ClientTest : TestBase
    {
        [Fact]
        public void CanCreateNamespace()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var sbClient = TestBase.GetServiceClient<ServiceBusManagementClient>(new CSMTestEnvironmentFactory());

                string namespaceName = TestUtilities.GenerateName("dummy");
                string location = sbClient.GetServiceBusRegionsAsync(CancellationToken.None).Result.First().FullName;
                var response = sbClient.Namespaces.CreateNamespaceAsync(
                    namespaceName,
                    new ServiceBusNamespaceCreateParameters
                    {
                        Region = location,
                        CreateACSNamespace = true,
                        NamespaceType = NamespaceType.NotificationHub
                    },
                    new CancellationToken()).Result;

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(namespaceName, response.Namespace.Name);
                Assert.Equal(location, response.Namespace.Region);
                Assert.Equal(true, response.Namespace.CreateACSNamespace);
                Assert.Equal(NamespaceType.NotificationHub, response.Namespace.NamespaceType);
                int retries = 0;
                while (true)
                {
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(4));
                    }

                    var description = sbClient.Namespaces.GetAsync(namespaceName, CancellationToken.None).Result;
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                    if (description.Namespace.Status.Equals("Active", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    retries++;
                    Assert.True(retries < 15, "number of retries to wait for namespace activation too high");
                }
            }
        }


        [Fact]
        public void CanCreateEventHubNamespace()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var sbClient = TestBase.GetServiceClient<ServiceBusManagementClient>(new RDFETestEnvironmentFactory());

                string namespaceName = TestUtilities.GenerateName("testeventHubNS");
                string location = sbClient.GetServiceBusRegionsAsync(CancellationToken.None).Result.First().FullName;
                var response = sbClient.Namespaces.CreateNamespaceAsync(
                    namespaceName,
                    new ServiceBusNamespaceCreateParameters
                    {
                        Region = location,
                        CreateACSNamespace = false,
                        NamespaceType = NamespaceType.EventHub
                    },
                    new CancellationToken()).Result;

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(namespaceName, response.Namespace.Name);
                Assert.Equal(location, response.Namespace.Region);
                Assert.Equal(false, response.Namespace.CreateACSNamespace);
                Assert.Equal(NamespaceType.EventHub, response.Namespace.NamespaceType);
                int retries = 0;
                while (true)
                {
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(4));
                    }

                    var description = sbClient.Namespaces.GetAsync(namespaceName, CancellationToken.None).Result;
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                    if (description.Namespace.Status.Equals("Active", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    retries++;
                    Assert.True(retries < 15, "number of retries to wait for namespace activation too high");
                }
            }
        }

        public class NamespaceGroupUndoHandler : ComplexTypedOperationUndoHandler<INamespaceOperations, ServiceBusManagementClient>
        {
            protected override bool DoLookup(
                IServiceOperations<ServiceBusManagementClient> client,
                string method,
                IDictionary<string, object> parameters,
                out Action undoFunction)
            {
                undoFunction = null;
                switch (method)
                {
                    case "CreateNamespaceAsync":
                        return TryHandleCreateNamespaceAsync(client, parameters, out undoFunction);
                    default:
                        TraceUndoNotFound(this, method, parameters);
                        return false;
                }
            }

            protected override ServiceBusManagementClient GetClientFromOperations(IServiceOperations<ServiceBusManagementClient> operations)
            {
                return new ServiceBusManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
            }

            private bool TryHandleCreateNamespaceAsync(
                IServiceOperations<ServiceBusManagementClient> client,
                IDictionary<string, object> parameters,
                out Action undoFunction)
            {
                undoFunction = null;
                string namespaceName;
                if (TryAssignParameter<string>("namespaceName", parameters, out namespaceName)
                    && !string.IsNullOrEmpty(namespaceName))
                {
                    undoFunction = () =>
                    {
                        using (ServiceBusManagementClient managment = GetClientFromOperations(client))
                        {
                            managment.Namespaces.DeleteAsync(namespaceName, CancellationToken.None).Wait();
                        }
                    };

                    return true;
                }

                TraceParameterError(this, "CreateNamespaceAsync", parameters);
                return false;

            }
        }

        /// <summary>
        /// Discovery extensions - used to discover and construct available undo handlers 
        /// in the current app domain
        /// </summary>
        /// 
        [UndoHandlerFactory]
        public static class UndoContextDiscoveryExtensions
        {
            /// <summary>
            /// Create the undo handler for affinity group operations
            /// </summary>
            /// <returns>An undo handler for affinity group operations</returns>
            public static OperationUndoHandler CreateNamespaceGroupUndoHandler()
            {
                return new NamespaceGroupUndoHandler();
            }
        }

    }
}
