// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Fixtures
{
    using Xunit;

    /// <summary>
    /// This class is used by XUnit.
    /// </summary>
    [CollectionDefinition("StorageCacheCollection")]
    public class StorageCacheCollection : ICollectionFixture<StorageCacheTestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces
    }
}
