// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Administration.Tests
{
    public class PurviewAccountTestEnvironment: TestEnvironment
    {
        public PurviewAccountTestEnvironment()
        {
        }
        public Uri Endpoint => new(GetRecordedVariable("PURVIEW_ACCOUNT_URL"));
    }
}
