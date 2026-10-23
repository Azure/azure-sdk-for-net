// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageManagementTestEnvironment : TestEnvironment
    {
        public string BlobAccessPointSecretAccessKey => GetRecordedVariable(
            "BAP_SECRET_ACCESS_KEY",
            options => options.IsSecret());
    }
}
