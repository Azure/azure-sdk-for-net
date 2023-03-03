// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Communication.Identity.Tests.Infrastructure
{
    public class CommunicationTestEnvironment : TestEnvironment
    {
        public const string LiveTestDynamicConnectionStringEnvironmentVariableName = "COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING";
        public const string LiveTestStaticConnectionStringEnvironmentVariableName = "COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING";

        public string LiveTestDynamicConnectionString => GetRecordedVariable(
            LiveTestDynamicConnectionStringEnvironmentVariableName,
            options => options.IsSecret("endpoint=https://sanitized.communication.azure.com/;accesskey=Kg=="));

        public Uri LiveTestDynamicEndpoint => new(Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("endpoint"));

        public string LiveTestDynamicAccessKey => Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("accesskey");

        public string LiveTestStaticConnectionString => GetRecordedVariable(
                LiveTestStaticConnectionStringEnvironmentVariableName,
                options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public Uri LiveTestStaticEndpoint => new(Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("endpoint"));

        public string LiveTestStaticAccessKey => Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("accesskey");
    }
}
