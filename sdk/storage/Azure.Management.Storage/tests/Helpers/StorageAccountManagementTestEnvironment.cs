// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.Storage.Tests.Helpers
{
    public class StorageAccountManagementTestEnvironment : TestEnvironment
    {
        public StorageAccountManagementTestEnvironment() : base("storagemgmt")
        {
        }
    }
}
