// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : TestEnvironment
    {
        public SmsClientTestEnvironment() : base("communication")
        {
        }

        public string ConnectionString => GetRecordedVariable(CommunicationEnvironmentVariableNames.ConnectionStringEnvironmentVariableName);

        public string ToPhoneNumber => GetRecordedVariable(CommunicationEnvironmentVariableNames.ToPhoneNumberEnvironmentVariableName);

        public string FromPhoneNumber => GetRecordedVariable(CommunicationEnvironmentVariableNames.FromPhoneNumberEnvironmentVariableName);
    }
}
