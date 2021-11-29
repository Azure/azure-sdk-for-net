// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Runs <see cref="BlobClientOpenWriteTests"/> but with client-side encryption enabled.
    /// Requires a derived class instead of parameterizing the parent class because
    /// client-side encryption tests require a <see cref="LiveOnlyAttribute"/>, which is
    /// difficult to add onto only one test fixture parameter value and not others.
    /// </summary>
    [LiveOnly]
    public class ClientSideEncryptedBlobClientOpenWriteTests : BlobClientOpenWriteTests
    {
        public ClientSideEncryptedBlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, RecordedTestMode.Live /* RecordedTestMode.Record /* to re-record */)
        {
            // Validate every test actually used client-side encryption when writing a blob.
            AdditionalAssertions += async (client) =>
            {
                IDictionary<string, string> metadata = (await client.GetPropertiesAsync()).Value.Metadata;
                Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
            };
        }

        protected override BlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            options ??= ClientBuilder.GetOptions();
            options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey().Object,
                KeyWrapAlgorithm = ClientSideEncryptionTestExtensions.s_algorithmName
            };

            return base.GetResourceClient(container, resourceName, options);
        }
    }
}
