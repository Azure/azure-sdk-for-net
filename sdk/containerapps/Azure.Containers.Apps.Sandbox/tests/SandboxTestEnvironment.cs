// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTAINERAPPS_SANDBOX_ENDPOINT");

        public string SandboxGroupName => GetRecordedVariable("CONTAINERAPPS_SANDBOX_GROUP_NAME");

        protected override TokenCredential CreateDeveloperCredential() =>
            new ChainedTokenCredential(
                new AzureCliCredential(new AzureCliCredentialOptions
                {
                    ProcessTimeout = TimeSpan.FromMinutes(2)
                }),
                base.CreateDeveloperCredential());
    }
}
