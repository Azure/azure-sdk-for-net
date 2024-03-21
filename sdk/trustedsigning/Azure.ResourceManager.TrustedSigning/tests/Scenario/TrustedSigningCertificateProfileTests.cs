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

            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            string profileName = "profileA";
            ResourceIdentifier certificateProfileResourceId = CertificateProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, profileName);
            CertificateProfileResource certificateProfile = client.GetCertificateProfileResource(certificateProfileResourceId);

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

            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            string profileName = "profileA";
            ResourceIdentifier certificateProfileResourceId = CertificateProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, profileName);
            CertificateProfileResource certificateProfile = client.GetCertificateProfileResource(certificateProfileResourceId);
            CertificateProfileResource result = await certificateProfile.GetAsync();

            CertificateProfileData resourceData = result.Data;
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

            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // get the collection of this CertificateProfileResource
            CertificateProfileCollection collection = codeSigningAccount.GetCertificateProfiles();

            // invoke the operation and iterate over the result
            await foreach (CertificateProfileResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                CertificateProfileData resourceData = item.Data;
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

            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // get the collection of this CertificateProfileResource
            CertificateProfileCollection collection = codeSigningAccount.GetCertificateProfiles();

            // invoke the operation
            string profileName = "profileA";
            CertificateProfileData data = new CertificateProfileData()
            {
                ProfileType = ProfileType.PublicTrust,
                IncludeStreetAddress = false,
                IncludePostalCode = true,
                IdentityValidationId = "00000000-1234-5678-3333-444444444444",
            };
            ArmOperation<CertificateProfileResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            CertificateProfileResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CertificateProfileData resourceData = result.Data;
            // for demo we just print out the id
            Assert.IsNotNull(resourceData);
        }
    }
}
