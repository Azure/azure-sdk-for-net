// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ENDPOINT_URL");
    }
}
