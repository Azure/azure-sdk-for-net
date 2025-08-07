// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TrustedSigning.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.ResourceManager.TrustedSigning.Tests.Scenario
{
    public class TrustedSigningCertificateProfileTests : TrustedSigningManagementTestBase
    {
        public TrustedSigningCertificateProfileTests(bool isAsync) : base(isAsync)
        {
        }

        public TrustedSigningCertificateProfileTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        // Delete a certificate profile.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task Delete_DeleteACertificateProfile()
        {
            TrustedSigningAccountCollection accountCollection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            TrustedSigningCertificateProfileCollection certProfileCollection = account.GetTrustedSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            TrustedSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);

            ArmOperation op = await certProfile.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(op.HasCompleted);
        }

        // Get details of a certificate profile.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task Get_GetDetailsOfACertificateProfile()
        {
            TrustedSigningAccountCollection accountCollection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            TrustedSigningCertificateProfileCollection certProfileCollection = account.GetTrustedSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            TrustedSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);

            TrustedSigningCertificateProfileResource certProfileResource = Client.GetTrustedSigningCertificateProfileResource(certProfile.Id);
            TrustedSigningCertificateProfileResource result = await certProfileResource.GetAsync();
            Assert.IsNotNull(result);
        }

        // List certificate profiles under a trusted signing account.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task GetAll_ListCertificateProfilesUnderATrustedSigningAccount()
        {
            TrustedSigningAccountCollection accountCollection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            TrustedSigningCertificateProfileCollection certProfileCollection = account.GetTrustedSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            TrustedSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);

            bool exist = false;
            await foreach (TrustedSigningCertificateProfileResource item in certProfileCollection.GetAllAsync())
            {
                Assert.IsNotNull(item);
                if (item.Id == certProfile.Id)
                {
                    exist = true;
                    break;
                }
            }
            Assert.IsTrue(exist);
        }

        // Create a certificate profile.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task CreateOrUpdate_CreateACertificateProfile()
        {
            TrustedSigningAccountCollection accountCollection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            TrustedSigningCertificateProfileCollection certProfileCollection = account.GetTrustedSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            TrustedSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);
        }
    }
}
