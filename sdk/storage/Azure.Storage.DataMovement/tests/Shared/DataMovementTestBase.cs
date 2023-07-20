// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using System.IO;
using System.Collections.Generic;
using System;
using Azure.Storage.Test;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;

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
