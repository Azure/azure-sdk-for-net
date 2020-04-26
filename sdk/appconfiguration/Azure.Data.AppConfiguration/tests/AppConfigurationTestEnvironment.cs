﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Data.AppConfiguration
{
    public class AppConfigurationTestEnvironment : TestEnvironment
    {
        public AppConfigurationTestEnvironment() : base("appconfiguration")
        {
        }

        public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING");
        public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT_STRING");
    }
}