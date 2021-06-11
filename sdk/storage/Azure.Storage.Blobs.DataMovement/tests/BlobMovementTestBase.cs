// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Tests
{
    public class BlobMovementTestBase : BlobTestBase
    {
        public BlobMovementTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, serviceVersion, mode)
        {
        }
    }
}
