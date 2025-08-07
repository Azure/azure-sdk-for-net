// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    internal class AppServiceCertificateOrderDataTest : AppServiceTestBase
    {
        public AppServiceCertificateOrderDataTest(bool isAsync) : base(isAsync)// RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAppServiceCertificateOrdersAsync_Test()
        {
            string resourceGroupName = "testRG";
            string location = "global";
            string certificateOrderName = "myCertificateOrder";
            int count = 0;
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync(resourceGroupName);
            AppServiceCertificateOrderData certificateOrderData = new AppServiceCertificateOrderData(location)
            {
                DistinguishedName = "CN=mycustomdomain.com",
                ProductType = CertificateProductType.StandardDomainValidatedSsl,
                ValidityInYears = 1,
                IsAutoRenew = true
            };
            await resourceGroup.GetAppServiceCertificateOrders().CreateOrUpdateAsync(WaitUntil.Completed, certificateOrderName, certificateOrderData);
            var certOrders = DefaultSubscription.GetAppServiceCertificateOrdersAsync();
            if (certOrders != null)
            {
                await foreach (AppServiceCertificateOrderResource certOrder in certOrders)
                {
                    count++;
                }
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
