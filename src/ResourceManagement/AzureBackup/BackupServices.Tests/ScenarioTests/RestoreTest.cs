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
using System.Net;
using Xunit;
using System.Configuration;
using System;
using System.Web.Script.Serialization;

namespace BackupServices.Tests
{
    public class RestoreTests : BackupServicesTestsBase
    {
        [Fact]
        public void TriggerRestoreTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                string itemName = ConfigurationManager.AppSettings["ItemName"];
                string recoveryPointName = ConfigurationManager.AppSettings["RecoveryPointName"];
                string region = ConfigurationManager.AppSettings["Region"];
                string storageAccountName = ConfigurationManager.AppSettings["StorageAccountName"];

                AzureIaaSVMRecoveryInputsCSMObject azureIaaSVMRecoveryInputsCSMObject = new AzureIaaSVMRecoveryInputsCSMObject()
                {
                    AffinityGroup = string.Empty,
                    CloudServiceName = string.Empty,
                    VmName = string.Empty,
                    CreateNewCloudService = false,
                    Region = region,
                    InputStorageAccountName = storageAccountName,
                    ContinueProtection = false,
                    SubNetName = string.Empty,
                    TargetVNet = string.Empty,
                };

                var serializer = new JavaScriptSerializer();
                string azureIaaSVMRecoveryInputsCSMObjectString = serializer.Serialize(azureIaaSVMRecoveryInputsCSMObject);

                CSMRestoreRequest restoreRequest = new CSMRestoreRequest()
                {
                    Properties = new CSMRestoreRequestProperties()
                    {
                        TypeOfRecovery = RecoveryType.RestoreDisks.ToString(),
                        RecoveryDSTypeSpecificInputs = azureIaaSVMRecoveryInputsCSMObjectString,
                    },
                };

                var response = client.Restore.TriggerResotre(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, GetCustomRequestHeaders(), containerName, itemName, recoveryPointName, restoreRequest);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }
    }
}
