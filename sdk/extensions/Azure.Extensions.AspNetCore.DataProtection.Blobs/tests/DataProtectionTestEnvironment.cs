// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionTestEnvironment: TestEnvironment
    {
        public Uri BlobStorageEndpoint => new(GetVariable("BLOB_STORAGE_ENDPOINT"));
    }
}