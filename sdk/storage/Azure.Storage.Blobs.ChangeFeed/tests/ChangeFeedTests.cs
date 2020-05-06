// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedTests : ChangeFeedTestBase
    {
        public ChangeFeedTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }
    }
}
