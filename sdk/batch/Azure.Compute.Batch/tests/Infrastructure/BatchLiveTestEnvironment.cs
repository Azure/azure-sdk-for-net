// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class BatchLiveTestEnvironment : TestEnvironment
    {
        public string BatchAccountName => GetRecordedVariable("batch_account_name");

        public string BatchAccountURI => GetRecordedVariable("batch_account_uri");

        public string BatchAccountKey => GetRecordedVariable("batch_account_key");
    }
}
