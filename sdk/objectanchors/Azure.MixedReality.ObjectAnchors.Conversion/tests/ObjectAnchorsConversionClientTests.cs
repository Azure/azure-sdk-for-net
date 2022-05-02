// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ObjectAnchorsConversionClientTests : ClientTestBase
    {
        public ObjectAnchorsConversionClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ConstructorParameters()
        {
            // Arrange
            string accountDomain = "eastus2.azure.com";
            Guid accountId = Guid.Parse("43d00847-9b3d-4be4-8bcc-c6a8a3f2e45a");
            AzureKeyCredential azureCredential = new("MyAccountKey");
            AccessToken accessToken = new("dummykey", new DateTimeOffset(new DateTime(3000, 1, 1)));
            ObjectAnchorsConversionClientOptions options = new();
            TokenCredential tokenCredential = new StaticAccessTokenCredential(accessToken);

            // Act and assert
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, accessToken);
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, accessToken, options);
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, azureCredential);
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, azureCredential, options);
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, tokenCredential);
            _ = new ObjectAnchorsConversionClient(accountId, accountDomain, tokenCredential, options);
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, accessToken));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, accessToken, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, azureCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, azureCredential, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, tokenCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(default, accountDomain, tokenCredential, options));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, accessToken));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, accessToken, options));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, azureCredential));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, azureCredential, options));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, tokenCredential));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, null!, tokenCredential, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, accessToken));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, accessToken, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, azureCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, azureCredential, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, tokenCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, string.Empty, tokenCredential, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", accessToken));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", accessToken, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", azureCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", azureCredential, options));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", tokenCredential));
            Assert.Throws<ArgumentException>(() => new ObjectAnchorsConversionClient(accountId, " ", tokenCredential, options));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, accountDomain, (AzureKeyCredential)null!));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, accountDomain, (AzureKeyCredential)null!, options));
            Assert.Throws<ArgumentNullException>(() => new ObjectAnchorsConversionClient(accountId, accountDomain, (TokenCredential)null!));
        }

        [Test]
        public void InvalidFileTypes()
        {
            // Arrange
            ObjectAnchorsConversionClient client = new(
                Guid.NewGuid(),
                "eastus2.azure.com",
                new AccessToken("dummykey", new DateTimeOffset(new DateTime(3000, 1, 1))));

            AssetConversionOptions conversionOptions = new(
                new Uri("https://sampleazurestorageurl.com"),
                new AssetFileType(".exe"),
                new AssetConversionConfiguration(new System.Numerics.Vector3(0, 0, 1), 1));

            // Act and assert
            Assert.ThrowsAsync<AssetFileTypeNotSupportedException>(async () => await client.StartAssetConversionAsync(conversionOptions));
        }
    }
}
