// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersClientTestEnvironment : CommunicationTestEnvironment
    {
        internal const string LiveTestConnectionStringEnvironmentVariableName = "AZURE_COMMUNICATION_LIVETEST_CONNECTION_STRING";

        public string LiveTestConnectionString => GetRecordedVariable(LiveTestConnectionStringEnvironmentVariableName);
    }
}
