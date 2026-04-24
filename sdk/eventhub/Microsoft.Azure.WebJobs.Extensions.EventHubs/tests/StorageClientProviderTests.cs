// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class StorageClientProviderTests
    {
        [Test]
        public void TryGetServiceUri_AccountNameOnly_UsesDefaultSuffix()
        {
            var provider = CreateProvider(new Dictionary<string, string>
            {
                ["accountName"] = "myacct",
            });

            Assert.IsTrue(provider.TryGetServiceUri(out Uri uri));
            Assert.AreEqual("https://myacct.blob.core.windows.net/", uri.AbsoluteUri);
        }

        [Test]
        public void TryGetServiceUri_AccountNameWithEndpointSuffix_UsesSovereignSuffix()
        {
            var provider = CreateProvider(new Dictionary<string, string>
            {
                ["accountName"] = "myacct",
                ["endpointSuffix"] = "core.usgovcloudapi.net",
            });

            Assert.IsTrue(provider.TryGetServiceUri(out Uri uri));
            Assert.AreEqual("https://myacct.blob.core.usgovcloudapi.net/", uri.AbsoluteUri);
        }

        [Test]
        public void TryGetServiceUri_BlobServiceUriOnly_UsesExplicitUri()
        {
            var provider = CreateProvider(new Dictionary<string, string>
            {
                ["blobServiceUri"] = "https://myacct.blob.core.usgovcloudapi.net/",
            });

            Assert.IsTrue(provider.TryGetServiceUri(out Uri uri));
            Assert.AreEqual("https://myacct.blob.core.usgovcloudapi.net/", uri.AbsoluteUri);
        }

        // Regression test for https://github.com/Azure/azure-sdk-for-net/issues/57543:
        // when both `accountName` and the explicit `{subdomain}ServiceUri` are configured,
        // the explicit URI must win so sovereign-cloud endpoints are not silently overridden
        // by the default `core.windows.net` suffix.
        [Test]
        public void TryGetServiceUri_AccountNameAndBlobServiceUri_PrefersExplicitUri()
        {
            var provider = CreateProvider(new Dictionary<string, string>
            {
                ["accountName"] = "myacct",
                ["blobServiceUri"] = "https://myacct.blob.core.usgovcloudapi.net/",
            });

            Assert.IsTrue(provider.TryGetServiceUri(out Uri uri));
            Assert.AreEqual("https://myacct.blob.core.usgovcloudapi.net/", uri.AbsoluteUri);
        }

        [Test]
        public void TryGetServiceUri_NoConfiguration_ReturnsFalse()
        {
            var provider = CreateProvider(new Dictionary<string, string>());

            Assert.IsFalse(provider.TryGetServiceUri(out Uri uri));
            Assert.IsNull(uri);
        }

        private static TestStorageClientProvider CreateProvider(IDictionary<string, string> settings)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .Build();
            return new TestStorageClientProvider(configuration);
        }

        private class TestStorageClientProvider : StorageClientProvider<BlobServiceClient, BlobClientOptions>
        {
            private readonly IConfiguration _configuration;

            public TestStorageClientProvider(IConfiguration configuration)
                : base(configuration: null, componentFactory: null, logForwarder: null, logger: NullLogger<BlobServiceClient>.Instance)
            {
                _configuration = configuration;
            }

            protected override string ServiceUriSubDomain => "blob";

            public bool TryGetServiceUri(out Uri serviceUri) => TryGetServiceUri(_configuration, out serviceUri);
        }
    }
}
