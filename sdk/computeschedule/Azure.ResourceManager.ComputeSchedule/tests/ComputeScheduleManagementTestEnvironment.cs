// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleManagementTestEnvironment : TestEnvironment
    {
        // Override to use DefaultAzureCredential (includes AzCli + AzPowerShell)
        // instead of the broker-based credential which requires a window handle.
        protected override TokenCredential CreateDeveloperCredential()
        {
            return new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = true,
                    ExcludeWorkloadIdentityCredential = true,
                    ExcludeBrokerCredential = true,
                    ExcludeVisualStudioCodeCredential = true,
                });
        }
    }
}
