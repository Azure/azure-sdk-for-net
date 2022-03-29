// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Account.Tests
{
    public class PurviewCollectionTestEnvironment: TestEnvironment
    {
        public PurviewCollectionTestEnvironment()
        {
        }
        public Uri Endpoint => new(GetRecordedVariable("PURVIEW_ACCOUNT_URL"));
    }
}
