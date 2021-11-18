// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.LLC.Tests
{
    public class TemplateServiceLiveTests: RecordedTestBase<TemplateServiceTestEnvironment>
    {
        public TemplateServiceLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private TemplateServiceClient CreateClient()
        {
            return InstrumentClient(new TemplateServiceClient(
                TestEnvironment.Credential,
                new Uri(TestEnvironment.Endpoint),
                InstrumentClientOptions(new TemplateServiceClientOptions())
            ));
        }

        // Add live tests here. If you need more information please refer https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing and
        // here are some examples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/AccessControlClientLiveTests.cs.
    }
}
