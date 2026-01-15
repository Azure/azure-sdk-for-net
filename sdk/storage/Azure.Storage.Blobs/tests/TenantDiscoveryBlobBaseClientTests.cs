// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
    public class TenantDiscoveryBlobBaseClientTests : BlobTestBase
    {
        public TenantDiscoveryBlobBaseClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion)
        { }

        [RecordedTest]
        public async Task ExistsAsync_WithTenantDiscovery()
        {
            await using DisposingContainer test = await GetTestContainerAsync(GetServiceClient_OauthAccount_TenantDiscovery());

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }
    }
}
