// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Ingestion_ENDPOINT");

        // Add other client paramters here as above.
    }
}
