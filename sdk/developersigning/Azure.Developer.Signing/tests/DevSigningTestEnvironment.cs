// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.Signing.Tests
{
    public class DevSigningTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("DEFAULT_DEVSIGNING_ENDPOINT"));
        public string ProfileName => GetRecordedVariable("DEFAULT_DEVSIGNING_PROFILE_NAME");
        public string AccountName => GetRecordedVariable("DEFAULT_DEVSIGNING_ACCOUNT_NAME");
    }
}
