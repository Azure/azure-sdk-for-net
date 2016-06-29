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
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Testing;
using Xunit;

namespace Microsoft.WindowsAzure.Management.Storage.Testing
{
    public class StorageManagementOperationTests
    {
        [Fact]
        public void CanCreateUpdateGetAndDeleteStorageAccounts()
        {
            TestLogTracingInterceptor.Current.Start();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = TestBase.GetServiceClient<ManagementClient>();
                var storage = TestBase.GetServiceClient<StorageManagementClient>();

                try
                {
                    var location = mgmt.GetDefaultLocation("Storage");
                    const string westUS = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, westUS, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = westUS;
                    }

                    var storageAccountName = HttpMockServer.GetAssetName(
                        "teststorage1234",
                        "teststorage").ToLower();

                    Assert.True(storage.StorageAccounts
                               .CheckNameAvailability(storageAccountName).IsAvailable);

                    // Create
                    var storageCreateParams = new StorageAccountCreateParameters
                    {
                        Location = location,
                        AffinityGroup = null,
                        Label = "Test测试1",
                        Description = "Test测试2",
                        Name = storageAccountName,
                        AccountType = StorageAccountTypes.StandardGRS,
                        ExtendedProperties = new Dictionary<string, string>
                        {
                            { "foo1", "bar" },
                            { "foo2", "baz" }
                        }
                    };
                    var st1 = storage.StorageAccounts.Create(storageCreateParams);

                    // Get
                    var storageCreated = storage.StorageAccounts
                                        .Get(storageAccountName).StorageAccount;
                    VerifyStorageAccount(
                        storageCreated,
                        storageCreateParams.Name,
                        storageCreateParams.Label,
                        storageCreateParams.Description,
                        storageCreateParams.Location,
                        storageCreateParams.AccountType);
                    Assert.True(storageCreated.ExtendedProperties["foo1"] == "bar");
                    Assert.True(storageCreated.ExtendedProperties["foo2"] == "baz");

                    // Update
                    var storageUpdateParams = new StorageAccountUpdateParameters
                    {
                        Label = "Test测试3",
                        Description = "Test测试4",
                        AccountType = StorageAccountTypes.StandardRAGRS
                    };
                    var st2 = storage.StorageAccounts.Update(
                        storageAccountName,
                        storageUpdateParams);

                    // List
                    var storageUpdated = storage.StorageAccounts.List()
                                        .First(s => s.Name == storageAccountName);
                    VerifyStorageAccount(
                        storageUpdated,
                        storageAccountName,
                        storageUpdateParams.Label,
                        storageUpdateParams.Description,
                        storageCreateParams.Location,
                        storageUpdateParams.AccountType);

                    // Keys
                    var st3 = storage.StorageAccounts.GetKeys(storageAccountName);

                    var st4 = storage.StorageAccounts.RegenerateKeys(
                        new StorageAccountRegenerateKeysParameters
                        {
                            Name = storageAccountName,
                            KeyType = StorageKeyType.Primary
                        });

                    var st5 = storage.StorageAccounts.GetKeys(storageAccountName);

                    Assert.True(st5.PrimaryKey != st3.PrimaryKey
                             && st5.SecondaryKey == st3.SecondaryKey);


                    // Delete
                    var st6 = storage.StorageAccounts.Delete(storageAccountName);

                    Assert.True(!storage.StorageAccounts.List()
                                .StorageAccounts.Any(s => s.Name == storageAccountName));
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanValidateStorageAccountForMigration()
        {
            TestLogTracingInterceptor.Current.Start();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = TestBase.GetServiceClient<ManagementClient>();
                var storage = TestBase.GetServiceClient<StorageManagementClient>();

                try
                {
                    var location = mgmt.GetDefaultLocation("Storage");
                    const string westUS = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, westUS, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = westUS;
                    }

                    var storageAccountName = "foo";
                    var response = storage.StorageAccounts.ValidateMigration(storageAccountName);

                    Assert.NotNull(response);
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                    Assert.NotNull(response.ValidateStorageMessages);
                    Assert.Equal(1, response.ValidateStorageMessages.Count);
                    Assert.Equal(string.Format("The storage account '{0}' was not found.", storageAccountName), response.ValidateStorageMessages[0].Message);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanMigrateStorageAccountToSrp()
        {
            TestLogTracingInterceptor.Current.Start();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = TestBase.GetServiceClient<ManagementClient>();
                var storage = TestBase.GetServiceClient<StorageManagementClient>();

                try
                {
                    var location = mgmt.GetDefaultLocation("Storage");
                    const string westUS = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, westUS, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = westUS;
                    }

                    var storageAccountName = HttpMockServer.GetAssetName(
                        "teststorage1234",
                        "teststorage").ToLower();

                    Assert.True(storage.StorageAccounts
                               .CheckNameAvailability(storageAccountName).IsAvailable);

                    // Create
                    var storageCreateParams = new StorageAccountCreateParameters
                    {
                        Location = location,
                        AffinityGroup = null,
                        Label = "Test测试1",
                        Description = "Test测试2",
                        Name = storageAccountName,
                        AccountType = StorageAccountTypes.StandardGRS,
                        ExtendedProperties = new Dictionary<string, string>
                        {
                            { "foo1", "bar" },
                            { "foo2", "baz" }
                        }
                    };
                    var st1 = storage.StorageAccounts.Create(storageCreateParams);

                    // Get
                    var storageCreated = storage.StorageAccounts
                                        .Get(storageAccountName).StorageAccount;
                    VerifyStorageAccount(
                        storageCreated,
                        storageCreateParams.Name,
                        storageCreateParams.Label,
                        storageCreateParams.Description,
                        storageCreateParams.Location,
                        storageCreateParams.AccountType);
                    Assert.True(storageCreated.ExtendedProperties["foo1"] == "bar");
                    Assert.True(storageCreated.ExtendedProperties["foo2"] == "baz");

                    var response = storage.StorageAccounts.PrepareMigration(storageAccountName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);

                    storageCreated = storage.StorageAccounts.Get(storageAccountName).StorageAccount;
                    Assert.Equal(IaaSClassicToArmMigrationState.Prepared, storageCreated.MigrationState);

                    response = storage.StorageAccounts.CommitMigration(storageAccountName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanAbortStorageAccountMigrationToSrp()
        {
            TestLogTracingInterceptor.Current.Start();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = TestBase.GetServiceClient<ManagementClient>();
                var storage = TestBase.GetServiceClient<StorageManagementClient>();

                try
                {
                    var location = mgmt.GetDefaultLocation("Storage");
                    const string westUS = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, westUS, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = westUS;
                    }

                    var storageAccountName = HttpMockServer.GetAssetName(
                        "teststorage1234",
                        "teststorage").ToLower();

                    Assert.True(storage.StorageAccounts
                               .CheckNameAvailability(storageAccountName).IsAvailable);

                    // Create
                    var storageCreateParams = new StorageAccountCreateParameters
                    {
                        Location = location,
                        AffinityGroup = null,
                        Label = "Test测试1",
                        Description = "Test测试2",
                        Name = storageAccountName,
                        AccountType = StorageAccountTypes.StandardGRS,
                        ExtendedProperties = new Dictionary<string, string>
                        {
                            { "foo1", "bar" },
                            { "foo2", "baz" }
                        }
                    };
                    var st1 = storage.StorageAccounts.Create(storageCreateParams);

                    // Get
                    var storageCreated = storage.StorageAccounts
                                        .Get(storageAccountName).StorageAccount;
                    VerifyStorageAccount(
                        storageCreated,
                        storageCreateParams.Name,
                        storageCreateParams.Label,
                        storageCreateParams.Description,
                        storageCreateParams.Location,
                        storageCreateParams.AccountType);
                    Assert.True(storageCreated.ExtendedProperties["foo1"] == "bar");
                    Assert.True(storageCreated.ExtendedProperties["foo2"] == "baz");

                    var response = storage.StorageAccounts.PrepareMigration(storageAccountName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);

                    storageCreated = storage.StorageAccounts.Get(storageAccountName).StorageAccount;
                    Assert.Equal(IaaSClassicToArmMigrationState.Prepared, storageCreated.MigrationState);

                    response = storage.StorageAccounts.AbortMigration(storageAccountName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        private static bool VerifyStorageAccount(
            StorageAccount storageCreated,
            string storageAccountName,
            string label,
            string description,
            string location,
            string accountType)
        {
            bool verified = true;

            verified &= storageCreated.Name == storageAccountName;
            verified &= storageCreated.Uri.ToString().Contains(storageAccountName);
            verified &= storageCreated.Name == storageAccountName;
            verified &= storageCreated.Properties.Label == label;
            verified &= storageCreated.Properties.Description == description;
            verified &= storageCreated.Properties.Location == location;
            verified &= storageCreated.Properties.AccountType == accountType;

            return verified;
        }
    }
}
