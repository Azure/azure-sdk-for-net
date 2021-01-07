// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Administration.Tests
{
    public class CommunicationIdentityClientTestEnvironment: TestEnvironment
    {
        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        internal const string EndpointStringEnvironmentVariableName = "COMMUNICATION_ENDPOINT_STRING";

        public string EndpointString => GetRecordedVariable(EndpointStringEnvironmentVariableName);
    }
}
