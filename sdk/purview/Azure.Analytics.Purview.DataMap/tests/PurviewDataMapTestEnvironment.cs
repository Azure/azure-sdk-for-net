// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    public class PurviewDataMapTestEnvironment: TestEnvironment
    {
        public PurviewDataMapTestEnvironment()
        {
        }
        public Uri Endpoint => new(GetRecordedVariable("PURVIEW_ENDPOINT"));
    }
}
