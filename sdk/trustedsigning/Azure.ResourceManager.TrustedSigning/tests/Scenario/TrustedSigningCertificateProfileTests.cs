// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TrustedSigning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.TrustedSigning.Tests.Scenario
{
    public class TrustedSigningCertificateProfileTests : TrustedSigningManagementTestBase
    {
        protected TrustedSigningCertificateProfileTests(bool isAsync) : base(isAsync)
        {
        }

        protected TrustedSigningCertificateProfileTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        // Delete a certificate profile.
        [Test]
        [RecordedTest]
        public async Task Delete_DeleteACertificateProfile()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            string profileName = "profileA";
            ResourceIdentifier certificateProfileResourceId = TrustedSigningCertificateProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, profileName);
            TrustedSigningCertificateProfileResource certificateProfile = client.GetTrustedSigningCertificateProfileResource(certificateProfileResourceId);

            // invoke the operation
            var result = await certificateProfile.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(result);
        }

        // Get details of a certificate profile.
        [Test]
        [RecordedTest]
        public async Task Get_GetDetailsOfACertificateProfile()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            string profileName = "profileA";
            ResourceIdentifier certificateProfileResourceId = TrustedSigningCertificateProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, profileName);
            TrustedSigningCertificateProfileResource certificateProfile = client.GetTrustedSigningCertificateProfileResource(certificateProfileResourceId);
            TrustedSigningCertificateProfileResource result = await certificateProfile.GetAsync();

            TrustedSigningCertificateProfileData resourceData = result.Data;
            Assert.IsNotNull(resourceData);
        }

        // List certificate profiles under a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task GetAll_ListCertificateProfilesUnderATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = TrustedSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            TrustedSigningAccountResource codeSigningAccount = client.GetTrustedSigningAccountResource(codeSigningAccountResourceId);

            // get the collection of this CertificateProfileResource
            TrustedSigningCertificateProfileCollection collection = codeSigningAccount.GetTrustedSigningCertificateProfiles();

            // invoke the operation and iterate over the result
            await foreach (TrustedSigningCertificateProfileResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                TrustedSigningCertificateProfileData resourceData = item.Data;
                // for demo we just print out the id
                Assert.IsNotNull (resourceData);
            }
        }

        // Create a certificate profile.
        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateACertificateProfile()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = TrustedSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            TrustedSigningAccountResource codeSigningAccount = client.GetTrustedSigningAccountResource(codeSigningAccountResourceId);

            // get the collection of this CertificateProfileResource
            TrustedSigningCertificateProfileCollection collection = codeSigningAccount.GetTrustedSigningCertificateProfiles();

            // invoke the operation
            string profileName = "profileA";
            TrustedSigningCertificateProfileData data = new TrustedSigningCertificateProfileData()
            {
                ProfileType = CertificateProfileType.PublicTrust,
                IncludeStreetAddress = false,
                IncludePostalCode = true,
                IdentityValidationId = "",
            };
            ArmOperation<TrustedSigningCertificateProfileResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            TrustedSigningCertificateProfileResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            TrustedSigningCertificateProfileData resourceData = result.Data;
            // for demo we just print out the id
            Assert.IsNotNull(resourceData);
        }
    }
}
