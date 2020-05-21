// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.Storage.Tests
{
    public class StorageManagementTestEnvironment : TestEnvironment
    {
        public StorageManagementTestEnvironment() : base("storagemgmt")
        {
        }
    }
}
