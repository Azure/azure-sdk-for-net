// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Tests
{
    public class ClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ContentSafety_ENDPOINT");

        // Add other client paramters here as above.
    }
}
