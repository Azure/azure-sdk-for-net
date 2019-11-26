// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.AzureBridge.Admin;
using Microsoft.AzureStack.Management.AzureBridge.Admin.Models;
using System;
using Xunit;

namespace AzureBridge.Tests
{
    public class DownloadedProductTests : AzureBridgeTestBase
    {
        [Fact]
        public void TestDownloadAzsAzureBridgeProduct() {
            RunTest((client) => {
                var ProductName1 = "Canonical.UbuntuServer1710-ARM.1.0.6";
                client.Products.Download("azurestack-activation", "default", ProductName1);
            });
        }

        [Fact]
        public void TestGetAzsAzureBridgeDownloadedProduct()
        {
            RunTest((client) => {
                var list = client.DownloadedProducts.List("azurestack-activation", "default");
                Common.WriteIPagesToFile(list, client.DownloadedProducts.ListNext, "TestListDownloadedProducts");
            });
        }

        [Fact]
        public void TestGetAzsAzureBridgeDownloadedProductByProductName()
        {
            RunTest((client) => {
                var productName1 = "Canonical.UbuntuServer1710-ARM.1.0.6";
                var product = client.DownloadedProducts.Get("azurestack-activation", "default", productName1);
                Assert.NotNull(product);
            });
        }

        [Fact(Skip="Disabled")]
        public void TestRemoveAzsAzureBridgeDownloadedProduct()
        {
            RunTest((client) => {
                var productName1 = "Canonical.UbuntuServer1710-ARM.1.0.6";
                client.DownloadedProducts.Delete("azurestack-activation", "default", productName1);
                var deletedProduct = client.DownloadedProducts.Get("azurestack-activation", "default", productName1);
                Assert.Null(deletedProduct);
            });
        }
    }
}
