// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.AppConfiguration
{
    public class AppConfigurationTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("secret"));
        public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT_STRING");
    }
}
