// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientTestEnvironment: TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable(CommunicationRecordedTestSanitizer.ConnectionStringEnvironmentVariableName);
        public Uri Endpoint => new Uri(GetRecordedVariable(CommunicationRecordedTestSanitizer.EndpointEnvironmentVariableName));
        public string AccessKey => GetRecordedVariable(CommunicationRecordedTestSanitizer.AccessKeyEnvironmentVariableName);
    }
}
