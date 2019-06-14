// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.Management.AzureStack.Tests
{
    using System;
    using Microsoft.Azure.Management.AzureStack;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Xunit;

    public class ProductTests : AzureStackTestBase
    {
        private const string TestResourceGroupName = "AzsGroup";
        private const string TestRegistrationName = "TestRegistration";

        private void ValidateProduct(Product product)
        {
            Assert.NotNull(product);
            Assert.NotEmpty(product.Id);
            Assert.NotEmpty(product.DisplayName);
            Assert.NotEmpty(product.PublisherDisplayName);
            Assert.NotEmpty(product.PublisherIdentifier);
            Assert.NotNull(product.Offer);
            Assert.NotNull(product.OfferVersion);
            Assert.NotNull(product.Sku);
            Assert.NotEmpty(product.GalleryItemIdentity);
            Assert.NotNull(product.IconUris);
            Assert.NotNull(product.PayloadLength);
            Assert.NotEmpty(product.ProductKind);
            Assert.NotEmpty(product.ProductProperties.Version);
        }

        private void ValidateProductDetails(ExtendedProduct productDetails)
        {
            Assert.NotEmpty(productDetails.GalleryPackageBlobSasUri);
            Assert.NotEmpty(productDetails.ProductKind);
            Assert.NotEmpty(productDetails.Version);
        }

        private void AssertSame(Product expected, Product given)
        {
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.DisplayName, given.DisplayName);
            Assert.Equal(expected.PublisherDisplayName, given.PublisherDisplayName);
            Assert.Equal(expected.PublisherIdentifier, given.PublisherIdentifier);
            Assert.Equal(expected.Offer, given.Offer);
            Assert.Equal(expected.OfferVersion, given.OfferVersion);
            Assert.Equal(expected.Sku, given.Sku);
            Assert.Equal(expected.VmExtensionType, given.VmExtensionType);
            Assert.Equal(expected.GalleryItemIdentity, given.GalleryItemIdentity);
            Assert.Equal(expected.IconUris.Hero, given.IconUris.Hero);
            Assert.Equal(expected.IconUris.Large, given.IconUris.Large);
            Assert.Equal(expected.IconUris.Medium, given.IconUris.Medium);
            Assert.Equal(expected.IconUris.Small, given.IconUris.Small);
            Assert.Equal(expected.IconUris.Wide, given.IconUris.Wide);
            Assert.Equal(expected.PayloadLength, given.PayloadLength);
            Assert.Equal(expected.ProductKind, given.ProductKind);
            Assert.Equal(expected.ProductProperties.Version, given.ProductProperties.Version);
        }

        [Fact]
        public void TestListProducts()
        {
            RunTest((client) =>
            {
                var products = client.Products.List(TestResourceGroupName, TestRegistrationName);

                foreach (var product in products)
                {
                    ValidateProduct(product);
                }
            });
        }

        [Fact]
        public void TestGetProduct()
        {
            RunTest((client) =>
            {
                var products = client.Products.List(TestResourceGroupName, TestRegistrationName);

                foreach (var product in products)
                {
                    var productName = product.Name.Replace($"{TestRegistrationName}/", string.Empty, StringComparison.InvariantCultureIgnoreCase);
                    var productResult = client.Products.Get(TestResourceGroupName, TestRegistrationName, productName);
                    ValidateProduct(productResult);
                    AssertSame(product, productResult);
                }
            });
        }

        [Fact]
        public void TestGetProductDetails()
        {
            RunTest((client) =>
            {
                var products = client.Products.List(TestResourceGroupName, TestRegistrationName);

                foreach (var product in products)
                {
                    var productName = product.Name.Replace($"{TestRegistrationName}/", string.Empty, StringComparison.InvariantCultureIgnoreCase);
                    var productDetailsResult = client.Products.ListDetails(TestResourceGroupName, TestRegistrationName, productName);
                    ValidateProductDetails(productDetailsResult);
                }
            });
        }
    }
}