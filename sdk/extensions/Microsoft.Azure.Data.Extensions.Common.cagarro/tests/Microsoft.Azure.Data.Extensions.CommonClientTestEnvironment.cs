// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common.Tests
{
    public class Microsoft.Azure.Data.Extensions.CommonClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Microsoft.Azure.Data.Extensions.Common_ENDPOINT");

        // Add other client paramters here as above.
    }
}
