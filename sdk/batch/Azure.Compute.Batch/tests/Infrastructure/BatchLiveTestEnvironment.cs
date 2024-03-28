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
    public class BatchLiveTestEnvironment:  TestEnvironment
    {
        public string BatchAccountName => GetVariable("BATCH_ACCOUNT_NAME");

        public string BatchAccountURI => GetVariable("BATCH_ACCOUNT_URI");

        public string BatchAccountKey => GetVariable("BATCH_ACCOUNT_KEY");
    }
}
