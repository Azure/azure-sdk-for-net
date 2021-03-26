// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Communication.Tests
{
    public class CommunicationTestEnvironment : TestEnvironment
    {
        public const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";
        public const string LiveTestConnectionStringEnvironmentVariableName = "AZURE_COMMUNICATION_LIVETEST_CONNECTION_STRING";
        public const string AzurePhoneNumber = "AZURE_PHONE_NUMBER";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        public Uri Endpoint => new Uri(Core.ConnectionString.Parse(ConnectionString).GetRequired("endpoint"));

        public string AccessKey => Core.ConnectionString.Parse(ConnectionString).GetRequired("accesskey");

        public string LiveTestConnectionString => GetRecordedVariable(LiveTestConnectionStringEnvironmentVariableName);

        public Uri LiveTestEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestConnectionString).GetRequired("endpoint"));

        public string LiveTestAccessKey => Core.ConnectionString.Parse(LiveTestConnectionString).GetRequired("accesskey");

        public string CommunicationTestPhoneNumber => GetVariable(AzurePhoneNumber);
    }
}
