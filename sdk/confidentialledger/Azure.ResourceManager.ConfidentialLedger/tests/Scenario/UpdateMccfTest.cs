// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.ConfidentialLedger.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("update")]
    public class UpdateMccfTest : MccfManagementTestBase
    {
        private ManagedCCFResource _mccfResource;

        public UpdateMccfTest(string testFixtureName) : base(true, RecordedTestMode.Record, testFixtureName)
        {
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task TestAddNodeCountToMccf()
        {
            // Create Ledger
            await CreateMccf(mccfName);
            _mccfResource = await GetMccfByName(mccfName);

            int additionalNodeCount = 1;
            int newNodeCount = Convert.ToInt32(_mccfResource.Data.Properties.NodeCount) + additionalNodeCount;

            // Add the AadBasedSecurityPrincipal
            _mccfResource.Data.Properties = AddNodeCount(_mccfResource.Data.Properties, additionalNodeCount);
            await UpdateMccf(mccfName, _mccfResource.Data);

            // Get the updated ledger
            _mccfResource = await GetMccfByName(mccfName);

            Assert.AreEqual(newNodeCount, _mccfResource.Data.Properties.NodeCount);
        }

        [RecordedTest]
        public async Task TestUpdate()
        {
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagedCCFResource created on azure
            // for more information of creating ManagedCCFResource, please refer to the document of ManagedCCFResource
            string subscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
            string resourceGroupName = "pratik-rg";
            string appName = "pythonMccf1";
            ResourceIdentifier managedCCFResourceId = ManagedCCFResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, appName);
            ManagedCCFResource managedCCF = client.GetManagedCCFResource(managedCCFResourceId);

            // invoke the operation
            ManagedCCFData data = new ManagedCCFData(new AzureLocation("southcentralus"))
            {
                Properties = new ManagedCCFProperties()
                {
                    DeploymentType = new DeploymentType()
                    {
                        LanguageRuntime = LanguageRuntime.CPP,
                        AppSourceUri = new Uri("https://myaccount.blob.core.windows.net/storage/mccfsource?sv=2022-02-11%st=2022-03-11"),
                    },
                },
                Tags =
{
["additionalProps1"] = "additional properties",
},
            };
            await managedCCF.UpdateAsync(WaitUntil.Completed, data);

            Console.WriteLine($"Succeeded");
        }

        /// <summary>
        /// Method create a copy of the input LedgerProperties and update the list of securityPrincipals while copying
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="additionalCount"></param>
        /// <returns></returns>
        private ManagedCCFProperties AddNodeCount(ManagedCCFProperties properties, int additionalCount)
        {
            return new ManagedCCFProperties(properties.AppName, properties.AppUri,
                properties.IdentityServiceUri, properties.MemberIdentityCertificates, properties.DeploymentType,
                properties.ProvisioningState, properties.NodeCount + additionalCount);
        }
    }
}
