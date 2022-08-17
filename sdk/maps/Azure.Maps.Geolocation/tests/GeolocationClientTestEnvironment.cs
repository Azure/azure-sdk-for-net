// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Maps.Geolocation.Tests
{
    public class GeolocationClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint
        {
            get
            {
                var endpoint = GetRecordedOptionalVariable("ENDPOINT_URL");
                return endpoint != null ? new Uri(endpoint) : null;
            }
        }
        // cspell:ignore azmaps
        public string MapAccountClientId => GetRecordedOptionalVariable("AZMAPS_CLIENT_ID");
    }
}
