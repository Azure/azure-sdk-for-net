// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Maps.TimeZones.Tests
{
    public class TimeZoneClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint
        {
            get
            {
                var endpoint = GetRecordedOptionalVariable("ENDPOINT_URL");
                return endpoint != null ? new Uri(endpoint) : null;
            }
        }
        public string MapAccountClientId => GetRecordedVariable("AZMAPS_CLIENT_ID");
    }
}
