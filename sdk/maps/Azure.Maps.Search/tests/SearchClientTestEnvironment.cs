// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint {
            get {
                var endpoint = GetRecordedOptionalVariable("ENDPOINT_URL");
                return endpoint != null ? new Uri(endpoint) : null;
            }
        }
        public string MapAccountClientId => GetRecordedVariable("AZMAPS_CLIENT_ID");
    }
}
