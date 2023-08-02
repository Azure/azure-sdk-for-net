// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Base class for Blob DataMovement Tests tests
    /// </summary>
    public abstract class DataMovementTestBase : StorageTestBase<StorageTestEnvironment>
    {
        public DataMovementTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record /* to re-record */)
        {
        }
    }
}
