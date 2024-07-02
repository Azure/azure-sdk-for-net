// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.Signing.Tests
{
    public class DevSigningClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("DEVSIGNING_ENDPOINT"));
        public string Region => GetRecordedVariable("DEVSIGNING_REGION");
        public string ProfileName => GetRecordedVariable("DEVSIGNING_PROFILE_NAME");
        public string AccountName => GetRecordedVariable("DEVSIGNING_ACCOUNT_NAME");

        public RequestContext context = null;
    }
}
