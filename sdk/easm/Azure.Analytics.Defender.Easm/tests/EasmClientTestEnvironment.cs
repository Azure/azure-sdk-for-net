// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    public class EasmClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Easm_ENDPOINT");

        // Add other client paramters here as above.
    }
}
