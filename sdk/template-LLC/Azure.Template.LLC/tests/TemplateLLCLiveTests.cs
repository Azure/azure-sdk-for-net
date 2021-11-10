// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.LLC.Tests
{
    public class TemplateLLCLiveTests: RecordedTestBase<TemplateLLCTestEnvironment>
    {
        public TemplateLLCLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private TemplateLLCClient CreateClient()
        {
            return InstrumentClient(new TemplateLLCClient(
                TestEnvironment.Credential,
                new Uri(TestEnvironment.Endpoint),
                InstrumentClientOptions(new TemplateLLCClientOptions())
            ));
        }

        // Add live tests here
    }
}
