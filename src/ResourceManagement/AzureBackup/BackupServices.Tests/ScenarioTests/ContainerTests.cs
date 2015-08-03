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

using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;
using System.Configuration;
using System;

namespace BackupServices.Tests
{
    public class ContainerTests : BackupServicesTestsBase
    {
        [Fact]
        public void RegisterContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var response = client.Container.Register(containerName, GetCustomRequestHeaders());
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        [Fact]
        public void UnregisterContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var response = client.Container.Unregister(containerName, GetCustomRequestHeaders());
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        [Fact]
        public void RefreshContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var response = client.Container.Refresh(GetCustomRequestHeaders());
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        [Fact]
        void ListMarsContainersByTypeReturnsNonZeroContainers()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string subscriptionId = ConfigurationManager.AppSettings["SubscriptionId"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceId = ConfigurationManager.AppSettings["ResourceId"];
                string containerId = ConfigurationManager.AppSettings["ContainerId"];
                string containerStampId = ConfigurationManager.AppSettings["ContainerStampId"];
                string containerStampUri = ConfigurationManager.AppSettings["ContainerStampUri"];
                string friendlyName = ConfigurationManager.AppSettings["ContainerFriendlyName"];
                string uniqueName = ConfigurationManager.AppSettings["ContainerUniqueName"];

                ListMarsContainerOperationResponse response = client.Container.ListMarsContainersByType(MarsContainerType.Machine, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.ListMarsContainerResponse);

                // Basic Validation
                Assert.True(response.ListMarsContainerResponse.Value.Any(marsContainer =>
                {
                    return marsContainer.ContainerType == MarsContainerType.Machine.ToString() &&
                           marsContainer.Properties != null &&
                           marsContainer.Properties.ContainerId.ToString() == containerId &&
                           marsContainer.Properties.ContainerStampId.ToString() == containerStampId &&
                           marsContainer.Properties.ContainerStampUri == containerStampUri &&
                           marsContainer.Properties.CustomerType == CustomerType.OBS.ToString() &&
                           string.Equals(marsContainer.Properties.FriendlyName, friendlyName, StringComparison.OrdinalIgnoreCase) &&
                           string.Equals(marsContainer.UniqueName, uniqueName, StringComparison.OrdinalIgnoreCase);
                }), "Obtained container list doesn't contain the input container");
            }
        }

        [Fact]
        void ListMarsContainersByTypeAndFriendlyNameReturnsSameContainer()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string subscriptionId = ConfigurationManager.AppSettings["SubscriptionId"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceId = ConfigurationManager.AppSettings["ResourceId"];
                string containerId = ConfigurationManager.AppSettings["ContainerId"];
                string containerStampId = ConfigurationManager.AppSettings["ContainerStampId"];
                string containerStampUri = ConfigurationManager.AppSettings["ContainerStampUri"];
                string friendlyName = ConfigurationManager.AppSettings["ContainerFriendlyName"];
                string uniqueName = ConfigurationManager.AppSettings["ContainerUniqueName"];

                ListMarsContainerOperationResponse response = client.Container.ListMarsContainersByTypeAndFriendlyName(MarsContainerType.Machine, friendlyName, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.ListMarsContainerResponse);

                // Basic Validation
                Assert.True(response.ListMarsContainerResponse.Value.Any(marsContainer =>
                {
                    return marsContainer.ContainerType == MarsContainerType.Machine.ToString() &&
                           marsContainer.Properties != null &&
                           marsContainer.Properties.ContainerId.ToString() == containerId &&
                           marsContainer.Properties.ContainerStampId.ToString() == containerStampId &&
                           marsContainer.Properties.ContainerStampUri == containerStampUri &&
                           marsContainer.Properties.CustomerType == CustomerType.OBS.ToString() &&
                           string.Equals(marsContainer.Properties.FriendlyName, friendlyName, StringComparison.OrdinalIgnoreCase) &&
                           string.Equals(marsContainer.UniqueName, uniqueName, StringComparison.OrdinalIgnoreCase);
                }), "Obtained container list doesn't contain the input container");
            }
        }

        [Fact]
        void UnregisterContainerDeletesContainer()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();
                string containerId = ConfigurationManager.AppSettings["ContainerId"];
                string friendlyName = ConfigurationManager.AppSettings["ContainerFriendlyName"];

                OperationResponse response = client.Container.UnregisterMarsContainer(containerId, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.NoContent, "Status code should be NoContent");

                bool containerDeleted = false;
                try
                {
                    ListMarsContainerOperationResponse getResponse = client.Container.ListMarsContainersByTypeAndFriendlyName(MarsContainerType.Machine, friendlyName, GetCustomRequestHeaders());
                    if (getResponse.ListMarsContainerResponse.Value.Count == 0)
                    {
                        containerDeleted = true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Hyak.Common.CloudException))
                    {
                        Hyak.Common.CloudException cloudEx = ex as Hyak.Common.CloudException;
                        if (cloudEx != null &&
                            cloudEx.Error != null &&
                            !string.IsNullOrEmpty(cloudEx.Error.Code) &&
                            cloudEx.Error.Code == "ResourceNotFound")
                        {
                            containerDeleted = true;
                        }
                    }
                }

                Assert.True(containerDeleted, "Container still exists after unregistration");
            }
        }

        [Fact]
        void EnableContainerReregistrationSetsReregisterFlag()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();
                string containerId = ConfigurationManager.AppSettings["ContainerId"];
                string friendlyName = ConfigurationManager.AppSettings["ContainerFriendlyName"];

                EnableReregistrationRequest request = new EnableReregistrationRequest()
                {
                    ContainerReregistrationState = new ContainerReregistrationState()
                    {
                        EnableReregistration = true,
                    },
                };

                OperationResponse response = client.Container.EnableMarsContainerReregistration(containerId, request, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.NoContent, "Status code should be NoContent");

                // Basic Validation
                ListMarsContainerOperationResponse getResponse = client.Container.ListMarsContainersByTypeAndFriendlyName(MarsContainerType.Machine, friendlyName, GetCustomRequestHeaders());
                Assert.True(getResponse.ListMarsContainerResponse.Value.Any(marsContainer =>
                {
                    return marsContainer.ContainerType == MarsContainerType.Machine.ToString() &&
                           marsContainer.Properties != null &&
                           string.Equals(marsContainer.Properties.FriendlyName, friendlyName, StringComparison.OrdinalIgnoreCase) &&
                           marsContainer.Properties.CanReRegister == true;
                }), "Reregistration doesn't appear to have been enabled for the input container");
            }
        }

        [Fact]
        void ListContainersReturnsNonZeroContainers()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();

                string subscriptionId = ConfigurationManager.AppSettings["SubscriptionId"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceId = ConfigurationManager.AppSettings["ResourceId"];
                string containerId = ConfigurationManager.AppSettings["ContainerId"];
                string containerStampId = ConfigurationManager.AppSettings["ContainerStampId"];
                string containerStampUri = ConfigurationManager.AppSettings["ContainerStampUri"];
                string friendlyName = ConfigurationManager.AppSettings["ContainerFriendlyName"];
                string uniqueName = ConfigurationManager.AppSettings["ContainerUniqueName"];

                CSMContainerListOperationResponse response = client.Container.List(null, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.CSMContainerListResponse);

                // Basic Validation
                //Assert.True(response.CSMContainerListResponse.Value.Any(container =>
                //{
                //    return container.ContainerType == MarsContainerType.Machine.ToString() &&
                //           container.Properties != null &&
                //           container.Properties.ContainerId.ToString() == containerId &&
                //           container.Properties.ContainerStampId.ToString() == containerStampId &&
                //           container.Properties.ContainerStampUri == containerStampUri &&
                //           container.Properties.CustomerType == CustomerType.OBS.ToString() &&
                //           string.Equals(container.Properties.FriendlyName, friendlyName, StringComparison.OrdinalIgnoreCase) &&
                //           string.Equals(container.UniqueName, uniqueName, StringComparison.OrdinalIgnoreCase);
                //}), "Obtained container list doesn't contain the input container");
            }
        }
    }
}
