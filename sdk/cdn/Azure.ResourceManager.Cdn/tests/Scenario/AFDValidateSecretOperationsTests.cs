// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDValidateSecretOperationsTests : CdnManagementTestBase
    {
        public AFDValidateSecretOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        // ValidateSecret method is removed
        //[TestCase]
        //[RecordedTest]
        //[Ignore("Not Ready")]
        //public async Task Validate()
        //{
        //    ValidateSecretInput input = new ValidateSecretInput(new WritableSubResource
        //    {
        //        Id = "/subscriptions/87082bb7-c39f-42d2-83b6-4980444c7397/resourceGroups/CdnTest/providers/Microsoft.KeyVault/vaults/testKV4AFD/certificates/testCert"
        //    }, ValidateSecretType.CustomerCertificate);
        //    Subscription subscription = await Client.GetDefaultSubscriptionAsync();
        //    ValidateSecretOutput validateSecretOutput = await subscription.ValidateSecretAsync(input);
        //    Assert.AreEqual(validateSecretOutput.Status, Status.Valid);
        //}
    }
}
