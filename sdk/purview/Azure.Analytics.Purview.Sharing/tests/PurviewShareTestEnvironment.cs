// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests
{
    public class PurviewShareTestEnvironment : TestEnvironment
    {
        public PurviewShareTestEnvironment()
        { }

        public Uri Endpoint => new(GetVariable("PURVIEW_SHARE_URL"));
    }
}
