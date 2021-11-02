// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceKeysScenarioTests
    {
        // Update with values from a current MI on the region
        //
        private const string ManagedInstanceResourceGroup = "MlAndzic_RG";
        //Test will fail if the managedinstance does not have system assigned identity
        private const string ManagedInstanceName = "midemoinstancebc";

        [Fact(Skip = "Manual test due to long setup time required")]
        public void TestCreateUpdateDropManagedInstanceKeys()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                string resourceGroupName = ManagedInstanceResourceGroup;
                string managedInstanceName = ManagedInstanceName;
                
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                ResourceManagementClient resourceClient = context.GetClient<ResourceManagementClient>();
                ResourceGroup resourceGroup = resourceClient.ResourceGroups.Get(resourceGroupName);
                ManagedInstance managedInstance = sqlClient.ManagedInstances.Get(resourceGroupName, managedInstanceName);

                var keyBundle = SqlManagementTestUtilities.CreateKeyVaultKeyWithManagedInstanceAccess(context, resourceGroup, managedInstance);
                string serverKeyName = SqlManagementTestUtilities.GetServerKeyNameFromKeyBundle(keyBundle);
                string keyUri = keyBundle.Key.Kid;
                var managedInstanceKey = sqlClient.ManagedInstanceKeys.CreateOrUpdate(
                    resourceGroupName: resourceGroup.Name,
                    managedInstanceName: managedInstance.Name, 
                    keyName: serverKeyName, 
                    parameters: new ManagedInstanceKey()
                    {
                        ServerKeyType = "AzureKeyVault",
                        Uri = keyUri
                    });

                SqlManagementTestUtilities.ValidateManagedInstanceKey(managedInstanceKey, serverKeyName, "AzureKeyVault", keyUri);


                // Validate key exists by getting key
                var key1 = sqlClient.ManagedInstanceKeys.Get(
                    resourceGroupName: resourceGroup.Name, 
                    managedInstanceName:managedInstance.Name,
                    keyName: serverKeyName);

                SqlManagementTestUtilities.ValidateManagedInstanceKey(key1, serverKeyName, "AzureKeyVault", keyUri);
                
                // Validate key exists by listing keys
                var keyList = sqlClient.ManagedInstanceKeys.ListByInstance(
                    resourceGroupName: resourceGroup.Name,
                    managedInstanceName: managedInstance.Name);

                Assert.True(keyList.Count() > 0);
            }
        }

    }
}
