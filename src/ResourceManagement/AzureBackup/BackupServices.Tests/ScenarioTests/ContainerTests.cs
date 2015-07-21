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

using BackupServices.Tests.Helpers;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackupServices.Tests
{
    public class ContainerTests : BackupServicesTestsBase
    {
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
    }
}
