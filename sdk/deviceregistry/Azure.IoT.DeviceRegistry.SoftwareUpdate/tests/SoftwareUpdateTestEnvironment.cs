// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.IoT.DeviceRegistry._SoftwareUpdate.Tests
{
    public class SoftwareUpdateTestEnvironment : TestEnvironment
    {
        protected override TokenCredential CreateDeveloperCredential() => new AzureCliCredential(
            new AzureCliCredentialOptions { ProcessTimeout = TimeSpan.FromMinutes(2) });

        public const string SanitizedEndpoint = "https://fake.api.adu.microsoft.com";
        public const string SanitizedManifestUrl = "https://fake.blob.core.windows.net/container/manifest.json?sanitized";
        public const string SanitizedPayloadUrl = "https://fake.blob.core.windows.net/container/README.md?sanitized";

        public string Endpoint => GetRecordedVariable(
            "DEVICE_REGISTRY_SOFTWARE_UPDATE_ENDPOINT",
            options => options.IsSecret(SanitizedEndpoint));

        public string ManifestUrl => GetRecordedVariable(
            "DEVICE_REGISTRY_SOFTWARE_UPDATE_MANIFEST_URL",
            options => options.IsSecret(SanitizedManifestUrl));

        public string PayloadUrl => GetRecordedVariable(
            "DEVICE_REGISTRY_SOFTWARE_UPDATE_PAYLOAD_URL",
            options => options.IsSecret(SanitizedPayloadUrl));
    }
}