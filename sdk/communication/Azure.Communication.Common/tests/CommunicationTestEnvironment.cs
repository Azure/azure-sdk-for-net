// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Communication.Tests
{
    public class CommunicationTestEnvironment : TestEnvironment
    {
        public const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        public Uri Endpoint => new Uri(Core.ConnectionString.Parse(ConnectionString).GetRequired("endpoint"));

        public string AccessKey => Core.ConnectionString.Parse(ConnectionString).GetRequired("accesskey");
    }
}
