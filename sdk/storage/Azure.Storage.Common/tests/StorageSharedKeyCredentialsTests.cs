// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Common.Test
{
    public class StorageSharedKeyCredentialsTests : StorageTestBase
    {
        public StorageSharedKeyCredentialsTests(bool async)
            : base(async, null /* RecordedTestMode.Record to re-record */)
        {
        }

        [Test]
        public async Task RollCredentials()
        {
            // Create a service client
            var credential = new StorageSharedKeyCredential(
                this.TestConfigDefault.AccountName,
                this.TestConfigDefault.AccountKey);
            var service =
                this.InstrumentClient(
                    new BlobServiceClient(
                        new Uri(this.TestConfigDefault.BlobServiceEndpoint),
                        credential,
                        this.Recording.InstrumentClientOptions(
                            new BlobClientOptions
                            {
                                ResponseClassifier = new TestResponseClassifier(),
                                Diagnostics = { IsLoggingEnabled = true },
                                Retry =
                                {
                                    Mode = RetryMode.Exponential,
                                    MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                                    Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                                    MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                                }
                            })));

            // Verify the credential
            await service.GetAccountInfoAsync();

            // Clear the credentials and try again
            credential.AccountKey = Convert.ToBase64String(Encoding.UTF8.GetBytes("Invalid"));
            Assert.ThrowsAsync<StorageRequestFailedException>(
                async () => await service.GetAccountInfoAsync());

            // Roll to a valid key and make sure it succeeds
            credential.AccountKey = this.TestConfigDefault.AccountKey;
            await service.GetAccountInfoAsync();
        }
    }
}
