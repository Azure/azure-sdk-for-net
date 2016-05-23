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

using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests
{
    public class ProtectableObjectTests : RecoveryServicesTestsBase
    {
        [Fact]
        public void ListProtectableObjectTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                ProtectableObjectListQueryParameters queryParams = new ProtectableObjectListQueryParameters();

                PaginationRequest paginationParam = new PaginationRequest();

                ProtectableObjectTestHelper poTestHelper = new ProtectableObjectTestHelper(client);
                ProtectableObjectListResponse response = poTestHelper.ListProtectableObjects(queryParams, paginationParam);

                string protectableObjectName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                Assert.True(
                    response.ItemList.ProtectableObjects.Any(
                        protectableObject =>
                        {
                            return protectableObject.Properties.GetType() == typeof(AzureIaaSClassicComputeVMProtectableItem) &&
                                    protectableObject.Name == protectableObjectName;
                        }),
                        "Retrieved list of containers doesn't contain AzureIaaSClassicComputeVMProtectable Item");
            }
        }
    }
}
