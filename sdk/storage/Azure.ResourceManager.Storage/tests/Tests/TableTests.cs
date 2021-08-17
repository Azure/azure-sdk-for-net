// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class TableTests:StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        private TableServiceContainer tableServiceContainer;
        private TableService tableService;
        private TableContainer tableContainer;
        public TableTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAndGetTableContainer()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            tableServiceContainer = curStorageAccount.GetTableServices();
            tableService = await tableServiceContainer.GetAsync("default");
            tableContainer = tableService.GetTables();
        }
    }
}
