// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    using System;

    using Azure.Core.TestFramework;

    public class AzureMonitorTestEnvironment : TestEnvironment
    {
        protected override Azure.Core.TokenCredential CreateDeveloperCredential()
        {
            if (string.Equals(GetOptionalVariable("USE_AZURE_POWERSHELL_CREDENTIAL"), "true", StringComparison.OrdinalIgnoreCase))
            {
                return new Azure.Identity.AzurePowerShellCredential(
                    new Azure.Identity.AzurePowerShellCredentialOptions { TenantId = GetOptionalVariable("TENANT_ID") });
            }

            return base.CreateDeveloperCredential();
        }

        public Uri LogsEndpoint => new(GetRecordedVariable("LOGS_ENDPOINT"));

        /// <summary>
        /// Connection String is used to connect to an Application Insights resource.
        /// This value comes from the ARM Template.
        /// </summary>
        public string ConnectionString => GetRecordedVariable("CONNECTION_STRING");

        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");

        public string SecondaryConnectionString => GetRecordedVariable("SECONDARY_CONNECTION_STRING");

        public string SecondaryWorkspaceId => GetRecordedVariable("SECONDARY_WORKSPACE_ID");
    }
}
