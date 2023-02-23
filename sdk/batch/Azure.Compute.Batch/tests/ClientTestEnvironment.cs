// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Compute.Tests
{
    public class ClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Batch_ENDPOINT");

        // Add other client paramters here as above.
    }
}
