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
using Azure.ResourceManager.ArtifactSigning.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.ResourceManager.ArtifactSigning.Tests.Scenario
{
    public class ArtifactSigningCertificateProfileTests : ArtifactSigningManagementTestBase
    {
        public ArtifactSigningCertificateProfileTests(bool isAsync) : base(isAsync)
        {
        }

        public ArtifactSigningCertificateProfileTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        // Delete a certificate profile.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task Delete_DeleteACertificateProfile()
        {
            ArtifactSigningAccountCollection accountCollection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            ArtifactSigningCertificateProfileCollection certProfileCollection = account.GetArtifactSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            ArtifactSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
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
            ArtifactSigningAccountCollection accountCollection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            ArtifactSigningCertificateProfileCollection certProfileCollection = account.GetArtifactSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            ArtifactSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);

            ArtifactSigningCertificateProfileResource certProfileResource = Client.GetArtifactSigningCertificateProfileResource(certProfile.Id);
            ArtifactSigningCertificateProfileResource result = await certProfileResource.GetAsync();
            Assert.IsNotNull(result);
        }

        // List certificate profiles under a artifact signing account.
        [Test]
        [RecordedTest]
        [Ignore("Need servie team to provide correct input data")]
        public async Task GetAll_ListCertificateProfilesUnderAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection accountCollection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            ArtifactSigningCertificateProfileCollection certProfileCollection = account.GetArtifactSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            ArtifactSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);

            bool exist = false;
            await foreach (ArtifactSigningCertificateProfileResource item in certProfileCollection.GetAllAsync())
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
            ArtifactSigningAccountCollection accountCollection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(accountCollection, accountName);
            Assert.IsNotNull(account);

            ArtifactSigningCertificateProfileCollection certProfileCollection = account.GetArtifactSigningCertificateProfiles();

            string profileName = Recording.GenerateAssetName("profile-");
            ArtifactSigningCertificateProfileResource certProfile = await CreateCertificateProfile(certProfileCollection, profileName);
            Assert.IsNotNull(certProfile);
        }
    }
}
