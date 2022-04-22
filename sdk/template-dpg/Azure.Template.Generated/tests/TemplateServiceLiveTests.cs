// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Generated.Tests
{
    public class TemplateServiceLiveTests: RecordedTestBase<TemplateServiceTestEnvironment>
    {
        public TemplateServiceLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private TemplateServiceClient CreateClient()
        {
            return InstrumentClient(new TemplateServiceClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                InstrumentClientOptions(new TemplateServiceClientOptions())
            ));
        }

        // Add live tests here. If you need more information please refer https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing and
        // here are some examples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/AccessControlClientLiveTests.cs.
    }
}
