// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template..Tests
{
    public class ClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("_ENDPOINT");

        // Add other client paramters here as above.
    }
}
