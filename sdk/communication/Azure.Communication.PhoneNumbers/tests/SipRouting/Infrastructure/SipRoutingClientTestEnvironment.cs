// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    public class SipRoutingClientTestEnvironment: CommunicationTestEnvironment
    {
        public string GetTestDomain()
        {
            if (!string.IsNullOrEmpty(GetTestAgent))
            {
                return GetOptionalVariable("AZURE_TEST_DOMAIN_" + GetTestAgent) ?? "testdomain.com";
            }
            else
            {
                return GetOptionalVariable("AZURE_TEST_DOMAIN") ?? "testdomain.com";
            }
        }

        public string GetTestAgent
            => GetOptionalVariable("AZURE_TEST_AGENT") ?? "";

        public string LiveTestSipAgentSpecificConnectionString(string azureTestAgent)
        {
            return Environment.GetEnvironmentVariable("COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING_SIP_" + azureTestAgent) ?? "";
        }

        public string GetLiveTestConnectionString()
        {
            var azureTestAgent = GetTestAgent;
            return azureTestAgent == "" ? LiveTestStaticConnectionString : LiveTestSipAgentSpecificConnectionString(azureTestAgent);
        }
    }
}
