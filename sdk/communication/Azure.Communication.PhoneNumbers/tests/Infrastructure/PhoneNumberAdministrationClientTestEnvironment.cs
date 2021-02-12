// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumberAdministrationClientTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable(CommunicationRecordedTestSanitizer.ConnectionStringEnvironmentVariableName);
    }
}
