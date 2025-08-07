// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdCustomDomainOperationsTests : CdnManagementTestBase
    {
        public AfdCustomDomainOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-4.azuretest.net";
            FrontDoorCustomDomainResource afdCustomDomain = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            await afdCustomDomain.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            //This test doesn't create a new afd custom domain bucause the update actoin needs to manualy add dns txt record and validate.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            FrontDoorCustomDomainResource afdCustomDomain = await afdProfile.GetFrontDoorCustomDomains().GetAsync("domainupdatetest-clitest-azfdtest-xyz-edc3");
            FrontDoorCustomDomainPatch updateOptions = new FrontDoorCustomDomainPatch
            {
                TlsSettings = new FrontDoorCustomDomainHttpsContent(FrontDoorCertificateType.ManagedCertificate)
                {
                    MinimumTlsVersion = FrontDoorMinimumTlsVersion.Tls1_0
                },
            };
            var lro = await afdCustomDomain.UpdateAsync(WaitUntil.Completed, updateOptions);
            ;
            FrontDoorCustomDomainResource updatedAfdCustomDomain = lro.Value;
            ResourceDataHelper.AssertAfdDomainUpdate(updatedAfdCustomDomain, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task RefreshVlidationToken()
        {
            //This test doesn't create a new afd custom domain bucause the refresh validation token actoin needs to manualy add dns txt record and validate.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            FrontDoorCustomDomainResource afdCustomDomain = await afdProfile.GetFrontDoorCustomDomains().GetAsync("azuretest-azuretest-net-91c8");
            Assert.DoesNotThrowAsync(async () => await afdCustomDomain.RefreshValidationTokenAsync(WaitUntil.Completed));
        }
    }
}
