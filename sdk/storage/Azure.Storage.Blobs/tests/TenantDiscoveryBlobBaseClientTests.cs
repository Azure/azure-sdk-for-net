// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class TenantDiscoveryBlobBaseClientTests : BlobTestBase
    {
        public TenantDiscoveryBlobBaseClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion)
        { }

        [RecordedTest]
        public async Task ExistsAsync_WithTenantDiscovery()
        {
            await using DisposingContainer test = await GetTestContainerAsync(GetServiceClient_OauthAccount(true));

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }
    }
}
