// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.StoragePool.Tests
{
    public class DiskPoolTestBase : StoragePoolTestBase
    {
        public DiskPoolTestBase(bool isAsync) : base(isAsync)
        {
        }

        public DiskPoolTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
    }
}
