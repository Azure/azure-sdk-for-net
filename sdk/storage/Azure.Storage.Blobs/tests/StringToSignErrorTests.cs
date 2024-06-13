// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Test;

namespace Azure.Storage.Blobs.Tests
{
    public class StringToSignErrorTests : BlobBaseClientTests
    {
        public StringToSignErrorTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task SharedKeyStringToSignError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // This is not a real shared key.  This is fake key, deliberately put here to test this case.
            // This is not a security issue.
            StorageSharedKeyCredential invalidSharedKey = new StorageSharedKeyCredential(TestConfigDefault.AccountName, "d8o0LmmcPmkw==");

            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(test.Container.Uri, invalidSharedKey, GetOptions()));

            try
            {
                await containerClient.GetPropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
