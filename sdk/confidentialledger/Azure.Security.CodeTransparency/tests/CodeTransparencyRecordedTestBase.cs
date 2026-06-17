// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyRecordedTestBase : RecordedTestBase<CodeTransparencyTestEnvironment>
    {
        protected CodeTransparencyClient Client { get; private set; }

        public CodeTransparencyRecordedTestBase(bool isAsync) : base(isAsync)
        {
            // Code Transparency exchanges binary COSE/CBOR payloads, not JSON.
            TestDiagnostics = false;
        }

        [SetUp]
        public void Setup()
        {
            var options = InstrumentClientOptions(new CodeTransparencyClientOptions());

            // Support canary/custom identity service endpoints
            string identityEndpoint = TestEnvironment.IdentityClientEndpoint;
            if (!string.IsNullOrEmpty(identityEndpoint))
            {
                options.IdentityClientEndpoint = identityEndpoint;
            }

            Client = InstrumentClient(
                new CodeTransparencyClient(
                    TestEnvironment.Endpoint,
                    options));
        }
    }
}
