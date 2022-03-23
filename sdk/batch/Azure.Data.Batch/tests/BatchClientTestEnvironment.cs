// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.Batch.Tests
{
    public class BatchClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Batch_ENDPOINT");

        // Add other client paramters here as above.
    }
}
