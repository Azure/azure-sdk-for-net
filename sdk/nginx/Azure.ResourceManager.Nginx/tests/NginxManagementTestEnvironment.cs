// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Nginx.Tests
{
    public class NginxManagementTestEnvironment : TestEnvironment
    {
        public string NginxSubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");

        public string KeyVaultSecretId = System.Environment.GetEnvironmentVariable("KeyVaultSecretId");

        public string ManagedIdentityResourceID = System.Environment.GetEnvironmentVariable("ManagedIdentityResourceID");

        public string NginxConfigurationContent = "aHR0cCB7CiAgICBzZXJ2ZXIgewogICAgICAgIGxpc3RlbiA4MDsKICAgICAgICBsb2NhdGlvbiAvIHsKICAgICAgICAgICAgZGVmYXVsdF90eXBlIHRleHQvaHRtbDsKICAgICAgICAgICAgcmV0dXJuIDIwMCAnPCFET0NUWVBFIGh0bWw+PGgxIHN0eWxlPSJmb250LXNpemU6MzBweDsiPk5naW54IGNvbmZpZyBpcyB3b3JraW5nITwvaDE+JzsKICAgICAgICB9CiAgICB9Cn0=";
    }
}
