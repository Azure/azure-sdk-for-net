// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Communication.Administration.Tests
{
    public class CommunicationIdentityClientTestEnvironment: TestEnvironment
    {
        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";
        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        internal const string EndpointEnvironmentVariableName = "COMMUNICATION_ENDPOINT";
        public Uri Endpoint => new Uri(GetRecordedVariable(EndpointEnvironmentVariableName));

        internal const string AccessKeyEnvironmentVariableName = "COMMUNICATION_ACCESS_KEY";
        public string AccessKey => GetRecordedVariable(AccessKeyEnvironmentVariableName);
    }
}
