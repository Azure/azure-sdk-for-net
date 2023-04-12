// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class VaultTests : NetAppTestBase
    {
        public VaultTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            //_pool1Name = Recording.GenerateAssetName("pool1");
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            _netAppAccount = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
        }

        [TearDown]
        public async Task ClearCapacityPools()
        {
            //remove all CapacityPool accounts under current netAppAccound and remove netAppAccount
            if (_resourceGroup != null)
            {
                List<CapacityPoolResource> capacityPoolList = await _capacityPoolCollection.GetAllAsync().ToEnumerableAsync();
                //remove capacityPools
                foreach (CapacityPoolResource capacityPool in capacityPoolList)
                {
                    await capacityPool.DeleteAsync(WaitUntil.Completed);
                }
                //remove account
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
        [RecordedTest]
        public async Task GetVaultObsolteButCustomCodeWorksOn2022_05_01()
        {
            List<NetAppVault> _vaults;
            NetAppVault _vault;
            _vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            _vault = _vaults.FirstOrDefault();
            _vaults.Should().HaveCount(1);
            Assert.IsNotNull(_vault);
        }
    }
}
