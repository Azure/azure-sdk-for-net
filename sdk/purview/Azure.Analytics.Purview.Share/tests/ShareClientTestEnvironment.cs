// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Share.Tests
{
    public class ShareClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Share_ENDPOINT");

        // Add other client paramters here as above.
    }
}
