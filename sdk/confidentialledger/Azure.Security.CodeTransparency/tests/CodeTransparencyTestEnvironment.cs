// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("CODETRANSPARENCY_ENDPOINT"));

        /// <summary>
        /// Optional identity service endpoint override (e.g. for canary environments).
        /// Defaults to the production identity service if not set.
        /// </summary>
        public string IdentityClientEndpoint => GetRecordedOptionalVariable("CODETRANSPARENCY_IDENTITY_ENDPOINT");
    }
}
