// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationClientLiveTests: RecordedTestBase<AttestationClientTestEnvironment>
    {
        public AttestationClientLiveTests(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }
    }
}
