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
    class ProtectedItemTest : RecoveryServicesTestsBase
    {
        [Fact]
        public void EnableAzureBackupProtectionTest()
        {
             ExecuteTest(
                client =>
                {
                    ProtectedItemCreateOrUpdateRequest input = new ProtectedItemCreateOrUpdateRequest();
                    AzureIaaSVMProtectedItem iaasVmProtectedItem = new AzureIaaSVMProtectedItem();
                    iaasVmProtectedItem.PolicyName = ConfigurationManager.AppSettings["IaaSVMPolicyName"];
                    ProtectedItemResource protectedItemResource = new ProtectedItemResource();
                    protectedItemResource.Properties = iaasVmProtectedItem;
                    input.Item = protectedItemResource;

                    string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                    string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                    string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                    string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                    string containerName = containeType + ";" + containerUniqueName;
                    string itemName = itemType + ";" + itemUniqueName;
                    string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                    string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                    string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                    ProtectedItemTestHelper protectedItemTestHelper = new ProtectedItemTestHelper(client);
                    
                    var response = protectedItemTestHelper.AddOrUpdateProtectedItem(fabricName,
                        containerName, itemName, input);
                    
                });
        }

        [Fact]
        public void RemoveAzureBackupProtectionTest()
        {
            ExecuteTest(
               client =>
               {
                   string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                   string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                   string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                   string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                   string containerName = containeType + ";" + containerUniqueName;
                   string itemName = itemType + ";" + itemUniqueName;
                   string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                   string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                   string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                   ProtectedItemTestHelper protectedItemTestHelper = new ProtectedItemTestHelper(client);

                   var response = protectedItemTestHelper.DeleteProtectedItem(fabricName,
                       containerName, itemName);                   
               });
        }        
    }
}
